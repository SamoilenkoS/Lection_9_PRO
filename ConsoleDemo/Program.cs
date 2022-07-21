using System;

namespace ConsoleDemo
{
    class Program
    {
        public delegate int SomeMethod(int a, int b);
        static Func<int, int, int> FuncDelegate;
        static Action<int, int> ActionDelegate;
        static event Action<string> PlayerDied;

        static void Main(string[] args)
        {
            PlayerDied += Program_PlayerDied;
            int healthPoints = 100;

            for (; healthPoints >= 0; --healthPoints)
            {
                if(healthPoints <= 0)
                {
                    PlayerDied?.Invoke("User");
                }
            }
            //FuncDelegate = Max;
            //FuncDelegate.Invoke(10, 30);
            //ActionDelegate = Test;
            //ActionDelegate.Invoke(30, 40);
        }

        private static void Program_PlayerDied(string playerName)
        {
            Console.WriteLine($"{playerName} died!!!");
        }

        static void Test(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        static void Printer(SomeMethod someMethod)
        {
            Console.WriteLine(someMethod.Invoke(10,20));
        }

        static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        static int Min(int a, int b)
        {
            return a < b ? a : b;
        }
    }
}
