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
            //Pig pig = new Pig();
            //SingVerse(pig);

            //Chicken chicken = new Chicken();
            //SingVerse(chicken);

            // TODO 01: Let's create a real animal that actually makes a sound

            // TODO 02: Can we create another, and use both?

            // TODO 03: Let's create a couple more animal sub-classes, and put them in a collection to sing

            List<ISingable> singables = new List<ISingable>();
            singables.Add(new Pig());
            singables.Add(new Chicken());
            singables.Add(new Cow());
            singables.Add(new Horse());
            singables.Add(new Tractor());
            foreach (ISingable singable in singables)
            {
                SingVerse(singable);
            }

            // TODO 04: What if we wanted to sing about other things on the farm that were singable but not farm animals, like a tractor or a truck?
            // Can it be done? 


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
        public void SingVerse(ISingable singableThings)
        {
            Console.WriteLine($"Old MacDonald had a farm. {EIEIO}");
            Console.WriteLine($"And on his farm there was a {singableThings.Name}. {EIEIO}");
            Console.WriteLine($"With a '{singableThings.MakeSoundTwice()}' here and a '{singableThings.MakeSoundTwice()}' there,");
            Console.WriteLine($"Here a '{singableThings.MakeSound()}', there a '{singableThings.MakeSound()}', everywhere a '{singableThings.MakeSoundTwice()}'!");
            Console.WriteLine($"Old Macdonald had a farm. {EIEIO}");
            Console.WriteLine();
        }
    }
}