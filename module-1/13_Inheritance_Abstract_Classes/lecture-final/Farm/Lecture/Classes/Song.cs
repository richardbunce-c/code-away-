using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Classes
{
    public class Song
    {
        private const string EIEIO = "Ee Aye Ee Aye Oh!";
        public void Sing()
        {
            // Let's sing about a Farm Animal
            //FarmAnimal animal = new Pig();
            //SingVerse(animal);

            //animal = new Chicken();
            //SingVerse(animal);

            // TODO 01: Let's create a real animal that actually makes a sound

            // TODO 02: Can we create another, and use both?

            // TODO 03: Let's create a couple more animal sub-classes, and put them in a collection to sing

            //List<FarmAnimal> animals = new List<FarmAnimal>();
            //animals.Add(new Pig());
            //animals.Add(new Chicken());
            //animals.Add(new Cow());
            //animals.Add(new Horse());
            //foreach(FarmAnimal fa in animals)
            //{
            //    SingVerse(fa);
            //}



            // TODO 04: What if we wanted to sing about other things on the farm that were singable but not farm animals, like a tractor or a truck?
            // Can it be done? 
            List<ISingable> singables = new List<ISingable>()
            {
                new Pig(),
                new Chicken(),
                new Cow(),
                new Horse(),
                new Tractor(),
                new Goat()
            };

            foreach (ISingable singable in singables)
            {
                SingVerse(singable);
            }



        }
        //public void SingVerse(FarmAnimal animal)
        //{
        //    //
        //    // OLD MACDONALD
        //    //
        //    Console.WriteLine($"Old MacDonald had a farm. {EIEIO}");
        //    Console.WriteLine($"And on his farm there was a {animal.Name}. {EIEIO}");
        //    Console.WriteLine($"With a '{animal.MakeSoundTwice()}' here and a '{animal.MakeSoundTwice()}' there,");
        //    Console.WriteLine($"Here a '{animal.MakeSound()}', there a '{animal.MakeSound()}', everywhere a '{animal.MakeSoundTwice()}'!");
        //    Console.WriteLine($"Old Macdonald had a farm. {EIEIO}");
        //    Console.WriteLine();
        //}
        public void SingVerse(ISingable singableThing)
        {
            //
            // OLD MACDONALD
            //
            Console.WriteLine($"Old MacDonald had a farm. {EIEIO}");
            Console.WriteLine($"And on his farm there was a {singableThing.Name}. {EIEIO}");
            Console.WriteLine($"With a '{singableThing.MakeSoundTwice()}' here and a '{singableThing.MakeSoundTwice()}' there,");
            Console.WriteLine($"Here a '{singableThing.MakeSound()}', there a '{singableThing.MakeSound()}', everywhere a '{singableThing.MakeSoundTwice()}'!");
            Console.WriteLine($"Old Macdonald had a farm. {EIEIO}");
            Console.WriteLine();
        }

    }
}
