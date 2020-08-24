using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelloThread
{
    class Program
    {
        public static void PrintMany(string str, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(str);
            }
        }
        static void Main(string[] args)
        {
            Thread mamas = new Thread(() => PrintMany("mamas", 1000));
            Thread empire = new Thread(() => PrintMany("empire", 1000));
            mamas.IsBackground = false;
            empire.IsBackground = false;
            mamas.Start();
            empire.Start();
        }
    }
}
