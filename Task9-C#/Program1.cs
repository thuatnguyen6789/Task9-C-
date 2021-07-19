using System;
using System.Collections;
using System.Collections.Generic;

namespace IssuesWithNonGenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Issues with Non-Generic Collections *****\n");
            UsePersonCollection();
            Console.WriteLine();
            UseGenericList();

            Console.ReadLine();
        }

        #region Simple Box / Unbox
        private static void SimpleBoxUnboxOperation()
        {
            // Make a int value type.
            int myInt = 25;

            // Box the int into an object reference
            object boxedInt = myInt;

            // Unbox in the wrong data type to trigger
            // runtime exception.
            try
            {
                long unboxedInt = (long)boxedInt;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region ArrayList box / unbox
        static void WorkWithArrayList()
        {
            // Value types are automatically boxed when
            // passed to a member requesting an object.
            ArrayList myInts = new ArrayList();
            myInts.Add(10);
            myInts.Add(20);
            myInts.Add(35);
            Console.ReadLine();
        }
        #endregion

        #region ArrayList of random objects
        static void ArrayListOfRandomObjects()
        {
            // The ArrayList can hold anything at all.
            ArrayList allMyObjects = new ArrayList();
            allMyObjects.Add(true);
            allMyObjects.Add(new OperatingSystem(PlatformID.MacOSX, new Version(10, 0)));
            allMyObjects.Add(66);
            allMyObjects.Add(3.14);

        }
        #endregion

        #region Use custom generic class
        static void UsePersonCollection()
        {
            Console.WriteLine("***** Custom Person Collection *****\n");
            UsePersonCollection myPeople = new UsePersonCollection();
            myPeople.AddPerson(new Person("Homer", "Simpson", 40));
            myPeople.AddPerson(new Person("Marge", "Simpson", 38));
            myPeople.AddPerson(new Person("Code", "Lean", 9));
            myPeople.AddPerson(new Person("Bart", "Simpson", 7));
            myPeople.AddPerson(new Person("Maggie", "Simpson", 2));

            // This would be a compile-time error!
            // myPeople.AddPerson(new Car());

            foreach (Person p in myPeople)
                Console.WriteLine(p);

        }
        #endregion

        #region Use generic list
        static void UseGenericList()
        {
            Console.WriteLine("***** Fun with Generics *****\n");
            // This List<> can only hold Person objects.
            List<Person> morePeople = new List<Person>();
            morePeople.Add(new Person("Frank", "Black", 50));
            Console.WriteLine(morePeople[0]);

            // This List<> can only hold numeric data.
            List<int> moreInts = new List<int>();
            moreInts.Add(10);
            moreInts.Add(2);
            int sum = moreInts[0] + moreInts[1];

            // Compile-time error! Can't add Person object
            // to a list of ints!
            // moreInts.Add(new Person());
        }
        #endregion
        #region Use Queue<T>
        static void GetCoffee(Person p)
        {
            Console.WriteLine("{0} got coffee", p.FirstName);

        }
        static void UseGenericQueue()
        {
            // Make a Q with three people.
            Queue<Person> peopleQ = new Queue<Person>();
            peopleQ.Enqueue(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            peopleQ.Enqueue(new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            peopleQ.Enqueue(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });
            // Peek at first person in Q.
            Console.WriteLine("{0} is first in line!", peopleQ.Peek().FirstName);
            // Remove each person from Q.
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());

            // Try to de-Q again?
            try
            {
                GetCoffee(peopleQ.Dequeue());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error! {0}", e.Message);
            }

        }
        #endregion

        #region Use SortedSet<T>
        private static void UseSortedSed()
        {
            // Make some people with different ages.
            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge())
            {
                new Person {FirstName = "Homer", LastName = "Simpson", Age = 47},
                new Person {FirstName = "Marge", LastName = "Simpson", Age = 45},
                new Person {FirstName = "Lisa", LastName = "Simpson", Age = 9},
                new Person {FirstName = "Bart", LastName = "Simpson", Age = 8},

            };
            // Note the items are sorted by age!
            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            // Add a few new people, with various ages.
            setOfPeople.Add(new Person { FirstName = "Saku", LastName = "Jones", Age = 1 });
            setOfPeople.Add(new Person { FirstName = "Mikko", LastName = "Jones", Age = 32 });

            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);

            }
        }
        #endregion

        #region Use Dictionary<K, V>
        private static void UseDictionary()
        {
            // Populate using Add() method
            Dictionary<string, Person> peopleA = new Dictionary<string, Person>();

            peopleA.Add("Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            peopleA.Add("Homer", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            peopleA.Add("Homer", new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            // Get Homer.
            Person homer = peopleA["Homer"];
            Console.WriteLine(homer);

            // Populate with initialization syntax.
            Dictionary<string, Person> PeopleB = new Dictionary<string, Person>()
            {
                {"Homer", new Person {FirstName = "Homer", LastName = "Simpson", Age = 47} },
                {"Marge", new Person{FirstName = "Marge", LastName = "Simpson", Age = 45} },
                {"Lisa", new Person{FirstName = "Lisa", LastName = "Simpson", Age = 9 } }
            };

            // Get Lisa.
            Person Lisa = PeopleB["Lisa"];
            Console.WriteLine(Lisa);

            // Populate with dictionary initialization syntax.
            Dictionary<string, Person> peopleC = new Dictionary<string, Person>()
            {
                ["Homer"] = new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 },
                ["Marge"] = new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 },
                ["Lisa"] = new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 }
            };

            // Get Marge.
           Person marge = PeopleB["Marge"];
            Console.WriteLine(marge);

        }
        #endregion
    }
}
