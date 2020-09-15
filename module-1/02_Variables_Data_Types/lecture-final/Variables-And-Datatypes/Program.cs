using System;

namespace Variables_And_Datatypes
{
    class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES & DATA TYPES , 
             * I can type anything I want 
             * Multi-line comment
             */

            // This is a single-line comment


            /*
		    1. Create a variable to hold an int and call it numberOfExercises.
			Then set it to 26.
		    */
            int numberOfExercises;      // Here is where I store # of exercises
            numberOfExercises = 26;
            Console.WriteLine(numberOfExercises);

            /*
            2. Create a variable to hold a double and call it half.
                Set it to 0.5.
            */
            double half;
            half = 0.5;
            Console.WriteLine(half);

            /*
            3. Create a variable to hold a string and call it name.
                Set it to "TechElevator".
            */
            string name = "TechElevator";
            char firstLetter = 'T';
            Console.WriteLine(name);
            Console.WriteLine(firstLetter);

            /*
            4. Create a variable called seasonsOfFirefly and set it to 1.
            */
            int seasonsOfFirefly = 1;
            Console.WriteLine(seasonsOfFirefly);

            /*
            5. Create a variable called myFavoriteLanguage and set it to "C#".
            */

            string myFavoriteLanguage = "C#";
            Console.WriteLine(myFavoriteLanguage);

            /*
            6. Create a variable called pi and set it to 3.1416.
            */
            const double pi =3.1416;
            Console.WriteLine(pi);

            /*
            7. Create and set a variable that holds your name.
            */
            string yourName = "Mike";
            Console.WriteLine(yourName);

            /*
            8. Create and set a variable that holds the number of buttons on your mouse.
            */
            int numberMouseButtons = 6;
            Console.WriteLine(numberMouseButtons);

            /*
            9. Create and set a variable that holds the percentage of battery left on
            your phone.
            */
            int percentBatteryLeft = 67;
            Console.WriteLine(percentBatteryLeft);

            /* EXPRESSIONS */

            /*
            10. Create an int variable that holds the difference between 121 and 27.
            */
            int difference = 121 - 27;
            Console.WriteLine(difference);

            /*
            11. Create a double that holds the addition of 12.3 and 32.1.
            */
            double sum = 12.3 + 32.1;
            Console.WriteLine(sum);

            /*
            12. Create a string that holds your full name.
            */
            string fullName = "Mike Morel";

            /*
            13. Create a string that holds the word "Hello, " concatenated onto your
            name from above.
            */
            string greeting = "Hello, " + fullName;
            Console.WriteLine(greeting);
            /*
            14. Add a " Esquire" onto the end of your full name and save it back to
            the same variable.
            */
            //greeting = greeting + " Esquire";
            //Console.WriteLine(greeting);

            /*
            15. Now do the same as exercise 14, but use the += operator.
            */
            greeting += " Esquire";
            Console.WriteLine(greeting);

            /*
            16. Create a variable to hold "Saw" and add a 2 onto the end of it.
            */
            string movie = "Saw";
            movie = movie + 2;
            Console.WriteLine(movie);

            /*
            17. Add a 0 onto the end of the variable from exercise 16.
            */
            movie += 0;
            Console.WriteLine(movie);


            /*
            18. What is 4.4 divided by 2.2?
            */
            double quotient1 = 4.5 / 2.2;
            Console.WriteLine(quotient1);

            /*
            18a. What is 4.4 divided by 2.2?
            */
            int quotient2 = (int)(4.5 / 2.2);
            Console.WriteLine(quotient2);

            /*
            19. What is 5.4 divided by 2?
            */
            Console.WriteLine( 5.4 / 2 );

            /* CASTING */

            /*
            20. What is 5 divided by 2?
            */
            Console.WriteLine(5 / 2);

            /*
            21. What is 5.0 divided by 2?
            */
            Console.WriteLine(5.0 / 2);

            /*
             * 21. dEFINE A PI VARIABLE
             */
            float pii = 3.14F;


            /*
            22. Create a variable that holds a bank balance with the value of 1234.56.
            */
            decimal bankBalance = 1234.56m;

            /*
            23. If I divide 5 by 2, what's my remainder?
            */
            int remainder = 5 % 2;
            int q = 5 / 2;
            Console.WriteLine("The answer of 5 / 2 = " + q + ", remainder " + remainder);

            /*
            24. Create two variables: 3 and 1,000,000,000 and multiple them together. 
                What is the result?
            */
            int var1 = 3;
            long var2 = 1_000_000_000;
            long product = var1 * var2;
            Console.WriteLine(product);

            /*
            25. Create a variable that holds a boolean called doneWithExercises and
            set it to false.
            */
            bool doneWithExercises = false;

            /*
            26. Now set doneWithExercise to true.
            */
            doneWithExercises = true;

            Console.WriteLine(doneWithExercises);

            //Console.ReadLine();
        }
    }
}
