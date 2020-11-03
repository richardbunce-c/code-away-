using System;
using System.Collections.Generic;

namespace LinqLambda
{
    public class Functions
    {
        public void ExecuteFunctions()
        {


        }

        IEnumerable<int> forEach(IEnumerable<int> arrayIn, Func<int, int> functionToApply)
        {
            List<int> arrayOut = new List<int>();
            foreach (int element in arrayIn)
            {
                int result = functionToApply(element);
                arrayOut.Add(result);
            }
            return arrayOut;
        }

    }
}
