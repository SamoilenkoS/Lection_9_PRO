using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ConsoleDemo
{
    public class Student
    {
        public int FN { get; set; }
        public int LN { get; set; }

        public override int GetHashCode()
        {
            return FN + LN;
        }

        public override bool Equals(object obj)
        {//(Student)obj;
            Student other = obj as Student;
            if(other != null)
            {
                return FN == other.FN
                    && LN == other.LN;
            }

            return false;
        }
    }

    public class B
    {
        public Student[] items { get; set; }
    }

    public class TestData
    {
        public List<int> Items { get; set; }
        public string FN { get; set; }
        public DateTime Date { get; set; }
    }

    class Program
    {
        public delegate int SomeMethod(int a, int b);
        public delegate void VoidMethod(int a, int b);
        static Func<int, int, int> FuncDelegate;
        static Action<int, int> ActionDelegate;
        static event Action<string> PlayerDied;

        static void Main(string[] args)
        {
            var deserialized = JsonSerializer.Deserialize<TestData>
                (
                "{\"Items\":[5,9,4,8,6,6,0,2,3,7,6,2,7,2,1,0,7,2,2,4,8,2,3,5,1,2,4,8,5,0,0,5,5,0,4,1,1,4,6,8,6,6,1,7,4,3,6,0,2,2,7,9,3,9,0,3,5,9,7,4,1,1,6,3,7,0,6,6,7,9,9,2,5,4,8,1,1,6,0,8,5,3,6,3,2,0,2,5,9,1,6,1,7,1,6,4,0,7,0,4],\"FN\":\"asasdas sd q!\",\"Date\":\"2022-07-28T21:29:30.8418409+03:00\"}");
            Random random = new Random();
            List<int> items = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                items.Add(random.Next(10));
            }

            var data = new TestData
            {
                Items = items,
                Date = DateTime.Now,
                FN = "asasdas sd q!"
            };

            var serialized = JsonSerializer.Serialize(data);
            //HashSet<int> items = new HashSet<int>();
            //for (int i = 0; i < 10; i++)
            //{
            //    items.Add(i);
            //}
            Student student = new Student
            {
                FN = 123,
                LN = 456
            };
            Student s2 = new Student
            {
                FN = 123,
                LN = 456
            };
            HashSet<Student> students = new HashSet<Student>();
            students.Add(student);
            students.Add(s2);
            students.First().FN = 100;
            Console.WriteLine(students.Count);
            //foreach (var item in items)
            //{
            //    Console.WriteLine(item);
            //}
            ////MyArrayList myArrayList = new MyArrayList();
            //myArrayList.AddBack(10);
            //myArrayList.AddFront(50);

            //foreach (var item in myArrayList.Select(x => x * 2))
            //{
            //    Console.WriteLine(item);
            //}
            //PlayerDied += Program_PlayerDied;
            //PlayerDied?.Invoke("User");
            //SomeMethod delegateVariable = Max;
            //delegateVariable.Invoke(10, 20);
            //Action<int, int> input = Test;
            //int size = 100;
            //int[] array = new int[size];
            //Random random = new Random();
            //for (int i = 0; i < array.Length; i++)
            //{
            //    array[i] = random.Next(0, 100);
            //    Console.Write($"{array[i]} ");
            //}

            //Printer(array, GetOnlyIfDivideByThree);

            //var result = 
            //    from item in array
            //    select item * 2;

            //var another =
            //    from item in array
            //    orderby item ascending
            //    select item;

            //var res = 
            //    from item in array
            //    where item < 10
            //    select item;
            //Console.WriteLine();

            //var elements = array.Where(x => x % 2 == 0).Select(x => x / 2);
            ////elements.
            //foreach (var item in elements)
            //{
            //    Console.Write(item + " ");
            //}
            //var newMultiplied = array.Select(x => x * 2);

            //PlayerDied += Program_PlayerDied;
            //int healthPoints = 100;

            //for (; healthPoints >= 0; --healthPoints)
            //{
            //    if(healthPoints <= 0)
            //    {
            //        PlayerDied?.Invoke("User");
            //    }
            //}
            //FuncDelegate = Max;
            //FuncDelegate.Invoke(10, 30);
            //ActionDelegate = Test;
            //ActionDelegate.Invoke(30, 40);
        }

        public static void Printer(int[] items, Func<int, bool> filter)
        {
            foreach (var item in items)
            {
                if (filter.Invoke(item))
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static bool GetOnlyIfDivideByThree(int number)
        {
            return number % 3 == 0;
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
