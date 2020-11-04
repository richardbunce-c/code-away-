using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace LinqLambda
{
    public class Functions
    {
        public void ExecuteFunctions()
        {
            int inputnumber = 125;
            int outputnumber = DoubleIt(inputnumber);


            int n = DoubleIt(4);
            Console.WriteLine(n);

            string s1 = "The quick brown fox";
            string s2 = s1;
            Console.WriteLine(s2);

            Func<int, int> AlsoDoubleIt = DoubleIt;
            Console.WriteLine(AlsoDoubleIt(100));

            Func<int, int> TripleIt = (number) => { return number * 3; };
            Console.WriteLine(TripleIt(33));

            Func<int, int> QuadrupleIt = number => number * 4;
            Console.WriteLine(QuadrupleIt(200));

            int[] arr = new int[] { 34, 5, 6, 71, 100 };
            PrintArray(arr);
            IEnumerable<int> result = ApplyToAllElements(arr, DoubleIt);
            PrintArray(result);

            PrintArray(ApplyToAllElements(arr, TripleIt));
            PrintArray(ApplyToAllElements(arr, QuadrupleIt));

            result = ApplyToAllElements(arr, (num) => { return num * num; });

            PrintArray(result);

        }


        public int DoubleIt(int number)
        {
            return number * 2;
        }


        IEnumerable<int> ApplyToAllElements(IEnumerable<int> arrayIn, Func<int, int> functionToApply)
        {
            List<int> arrayOut = new List<int>();
            foreach (int element in arrayIn)
            {
                int result = functionToApply(element);
                arrayOut.Add(result);
            }
            return arrayOut;
        }

        public void PrintArray(IEnumerable<int> array)
        {
            Console.WriteLine(string.Join(",", array));
        }
    }
}
