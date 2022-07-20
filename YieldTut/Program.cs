using System;
using System.Collections.Generic;
namespace YieldTut
{
    class Program
    {
        static void Main(string[] args)
        {
             ProcessPeople();
          //  ProcessPeopleYield();
        }


        public static void ProcessPeople()
        {
            var people = GetPeople(1000000);
            foreach (var person in people)
            {
                if (person.Id < 1000000)
                    Console.WriteLine($"Id: {person.Id}, Name: {person.Name}");
                else
                    break;
            }
        }

        static IEnumerable<Person> GetPeople(int count)
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < count; i++)
            {
                people.Add(new Person() { Id = i, Name = $"Name {i}" });
            }
            return people;
        }

   
        public static void ProcessPeopleYield()
        {
            var people = GetPeopleYield(1000000);
            foreach (var person in people)
            {
                if (person.Id < 1000000)
                    Console.WriteLine($"Id: {person.Id}, Name: {person.Name}");
                else
                    break;
            }
        }

        static IEnumerable<Person> GetPeopleYield(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new Person() { Id = i, Name = $"Name {i}" };
            }
        }

        public IEnumerable<int> MyProperty
        {
            get
            {
                yield return 0;
                yield return 1;
                yield return 2;
                yield return 3;
                yield return 4;
            }
        }
    }
}
