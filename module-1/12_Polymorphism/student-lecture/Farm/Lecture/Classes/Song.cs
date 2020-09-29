using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Classes
{
    public class Song
    {
        private const string EIO = "Ee Aye Ee Aye Oh!";
        public void Sing()
        {
            // Let's sing about a Farm Animal
            FarmAnimal animal = new FarmAnimal("Animal");
            SingVerse(animal);

            // TODO 01: Let's create a real animal that actually makes a sound

            // TODO 02: Can we create another, and use both?

            // TODO 03: Let's create a couple more animal sub-classes, and put them in a collection to sing

            // TODO 04: What if we wanted to sing about other things on the farm that were singable but not farm animals, like a tractor or a truck?
            // Can it be done? 


        }
        public void SingVerse(FarmAnimal animal)
        {
            //
            // OLD MACDONALD
            //
            Console.WriteLine($"Old MacDonald had a farm. {EIO}");
            Console.WriteLine($"And on his farm there was a {animal.Name}. {EIO}");
            Console.WriteLine($"With a '{animal.MakeSoundTwice()}' here and a '{animal.MakeSoundTwice()}' there,");
            Console.WriteLine($"Here a '{animal.MakeSound()}', there a '{animal.MakeSound()}', everywhere a '{animal.MakeSoundTwice()}'!");
            Console.WriteLine($"Old Macdonald had a farm. {EIO}");
            Console.WriteLine();
        }
    }
}
