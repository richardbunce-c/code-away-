using System;

namespace Lecture
{
    class Program
    {

        static void Main(string[] args)
        {
            /*****************************************************************************
            Part 1: Variable Scope
            ******************************************************************************/
            // Declare a variable
            int outerVariable = 10;
            Console.WriteLine($"The outer variable is {outerVariable}");

            // Start a statement block
            {
                // Print out the variable defined in the outer scope
                Console.WriteLine($"The outer variable is {outerVariable}");

                // Declare a variable in the block (inner scope)
                int innerVariable = 20;

                outerVariable *= 2;

                // Print out that variable
                Console.WriteLine($"The inner variable is {innerVariable}");
                // End the statement block
            }
            // Print the the variable declared in the block
            //Console.WriteLine($"The inner variable is {innerVariable}");
            Console.WriteLine($"The outer variable is {outerVariable}");

            /*****************************************************************************
            Part 2: Methods
            ******************************************************************************/
            // Call the MultiplyBy method
            int height = 15;
            int length = 25;
            int area = MultiplyBy(height, length);
            Console.WriteLine($"Area is {area}");

            // Create and print some boolean expressions
            int age = 22;

            // Test whether the person can vote
            if (age < 18)
            {
                Console.WriteLine("You are not old enough to vote");
            }
            else if (age <= 20)
            {
                Console.WriteLine("You can vote, but you cannot drink");
            }
            else
            {
                Console.WriteLine("You should have a drink before you vote!");
            }




        }

        /*
 * Create a method called MultiplyBy, which takes two integers and returns the integer product.
 */
        static public int MultiplyBy(int num1, int num2)
        {
            int answer = num1 * num2;
            return answer;
        }



    }
}
