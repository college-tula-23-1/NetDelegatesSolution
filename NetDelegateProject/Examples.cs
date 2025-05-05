using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDelegateProject
{
    static class Examples
    {
        delegate int Operation(int a, int b);
        delegate void Message(string message);

        delegate T TOperation<T>(T a, T b);

        delegate T TKOpeartion<T, K>(T a, K b);
        public static void DelegateWelcomeExample()
        {
            Operation operation1 = Summa;
            Operation operation2 = new Operation(Mult);

            TOperation<int> sum = Summa;
            TKOpeartion<int, double> tkoper;

            Message? message = SayHello;
            message("Bobby");
            Console.WriteLine();

            message += SayGoodby;
            message("Bobby");
            Console.WriteLine();

            message -= SayHello;
            message -= SayGoodby;
            message?.Invoke("Bobby");
            Console.WriteLine();

            int Summa(int a, int b) => a + b;
            int Mult(int a, int b) => a * b;
            int Calc(int a, int b, Operation o)
            {
                return o(a, b);
            }

            void SayHello(string name)
            {
                Console.WriteLine("Hello " + name);
            }

            void SayGoodby(string name)
            {
                Console.WriteLine($"Good by {name}");
            }

            
        }
    }
}
