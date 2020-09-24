using System;

namespace CarSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Car object (Create a new object of type Car)
            Car myCar = new Car("ABC1234", 1965, "Ford", "Mustang");

            // Display the car property value
            string make = myCar.Make;
            string model = myCar.Model;
            Console.WriteLine($"The car is a {myCar.Year} {make} {model}. This car is {myCar.Age} years old!");

            myCar.Gear = "D";
            Console.WriteLine($"Gear is {myCar.Gear}");
            myCar.Gear = "Q";
            Console.WriteLine($"Gear is {myCar.Gear}");
            myCar.Gear = "R";
            Console.WriteLine($"Gear is {myCar.Gear}");

            // Speed up to 60mph
            while (myCar.Speed < 60)
            {
                myCar.Accelerate();
                Console.WriteLine($"The car is now going {myCar.Speed} mph.");
            }

            // Now let's brake hard.
            while (myCar.Speed > 0)
            {
                myCar.Accelerate(-5);
                Console.WriteLine($"The car is now going {myCar.Speed} mph.");
            }
        }
    }
}
