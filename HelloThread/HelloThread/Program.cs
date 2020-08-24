using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelloThread
{
    class Program
    {
        public static int counter = 0;
        public static int mamasCounter = 0;
        public static int empireCounter = 0;
        public static void PrintMany(string str, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(str);
            }
        }
        static void Main(string[] args)
        {
            Object locker = new object();
            Thread mamas = new Thread(() => {
                while(counter < 10000)
                {
                    lock (locker)
                    {
                        if (counter%2==0)
                    {
                        Console.WriteLine("mamas");
                        ++mamasCounter;
                    }
                    //lock (locker)
                    //{
                        ++counter;
                    }
                }
            });
            Thread empire = new Thread(() => {
                while (counter < 10000)
                {
                    lock (locker)
                    {
                        if (counter % 2 == 1)
                    {
                        Console.WriteLine("empire");
                        ++empireCounter;
                    }
                    //lock (locker)
                    //{
                        ++counter;
                    }
                }
            });
            mamas.Start();
            empire.Start();

            mamas.Join();
            empire.Join();

            Console.WriteLine($"mamas {mamasCounter} and empire {empireCounter}, total is {counter}");
        }
    }
}
