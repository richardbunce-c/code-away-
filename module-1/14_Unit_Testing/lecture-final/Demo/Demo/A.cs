using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class A
    {
        public A()
        {
            Console.WriteLine($"A constructor: {this.GetType().ToString()}");
        }

        virtual public int DoSomething(int num)
        {
            return num * 2;
        }
    }

    public class B : A
    {
        public B()
        {
            Console.WriteLine($"B constructor: {this.GetType().ToString()}");
        }
    }


    public class C : B
    {
        public C()
        {
            Console.WriteLine($"C constructor: {this.GetType().ToString()}");
        }

        public override int DoSomething(int x)
        {

            return base.DoSomething(x) * 100;
        }
    }
}
