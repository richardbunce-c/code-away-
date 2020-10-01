using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();

            Console.WriteLine(a.DoSomething(4));
            Console.WriteLine(b.DoSomething(4));
            Console.WriteLine(c.DoSomething(4));
        }
    }
}
