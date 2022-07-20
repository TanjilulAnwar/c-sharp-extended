using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
    
        public static void calculateAgeByRef(ref Person per)
        {
            per.Age = Convert.ToInt32(DateTime.Now.Year - per.Dob.Year);
        }

        public static int calculateAge(Person per)
        {
            return Convert.ToInt32(DateTime.Now.Year - per.Dob.Year);
        }
        public static void increment(ref Person per, in int increment, out string status)
        {
            per.Salary = per.Salary + increment;
            status = "incremented";
        }
        static void Main(string[] args)
        {

            // ref keyword causes arguments to be passed by reference
            // for ref argument needs to be initialized before passing
            // in is similar but cannot be modified by caller method
            // out need not be initialized
            // A property or indexer of a class may not be passed as an out or ref parameter

            //foreach (int i in Power(2, 8))
            //{
            //    Console.Write("{0} ", i);
            //}

            foreach (int i in RunningTotal())
            {
                Console.Write("{0} ", i);
            }



            Person p = new Person()
            {
                Name = "Ami",
                Age = 0,
                Salary = 66000,
                Dob = new DateTime(2000, 2, 24)
            };

            int incrementAmount=10000;

             
            // p.Age = calculateAge(p);
            calculateAgeByRef(ref p);
            Console.WriteLine("\nAmi's Age is : " + p.Age);
            Console.WriteLine("Ami's salary is : " + p.Salary+" USD");
            increment(ref p, in incrementAmount, out string result);
            Console.WriteLine("Ami's salary after increment is : " + p.Salary + " USD");
            Console.WriteLine("Ami's Salary Result : " + result );
             Console.ReadKey();
        }

        public class Person
        {
            public string Name { get; set; }
            public DateTime Dob { get; set; }
            public int Age { get; set; }
            public int Salary { get; set; }
            
        }


        public static IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
                //moves back and forth from source to the caller and caller to the source
            }
        }

        static List<int> MyList = new List<int>()
        {
            1,2,3,4,5,6,7,8
        };


        public static IEnumerable<int> RunningTotal()
        {
            int result = 0;

            foreach (int i in MyList)
            {
                result += i;
                yield return result;// stateful and custom iteration
                //moves back and forth from source to the caller and caller to the source
            }
        }

        //indexer
        class Dipto<T>
        {
            // Declare an array to store the data elements.
            private T[] arr = new T[100];
            int nextIndex = 0;

            // Define the indexer to allow client code to use [] notation.
            public T this[int i] => arr[i];

            public void Add(T value)
            {
                if (nextIndex >= arr.Length)
                    throw new IndexOutOfRangeException($"The collection can hold only {arr.Length} elements.");
                arr[nextIndex++] = value;
            }
        }
    }
}
