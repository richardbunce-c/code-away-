using System;

namespace PlayingAround
{
    class Program
    {
        static void Main(string[] args)
        {
            //decimal cost = 499.52M;
            //DateTime now = DateTime.Now;

            //Console.WriteLine("The cost is " + cost.ToString("C2"));
            //Console.WriteLine($"The cost is {cost:C4}");

            //Console.WriteLine($"The date and time is: {now:dddd d}");


            Person p1 = new Person() { Name = "Taylor" };
            Person p2 = new Person() { Name = "Keith" };

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            p1.Name = "Dave";
            Person.staticField = 100;

            Console.WriteLine(p1);
            Console.WriteLine(p2);

        }
    }
}
