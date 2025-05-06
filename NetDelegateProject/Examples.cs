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
        public static void AnonimeDelegateLambdaExample()
        {
            Account account = new(1000);
            account.AddNotify += OkGreenText;
            account.Add(500);
            Console.WriteLine();

            account.AddNotify += OkMagentaText;
            account.Add(300);
            Console.WriteLine();

            account.AddNotify -= OkGreenText;
            account.Add(600);
            Console.WriteLine();

            account.AddNotify += delegate (string message)
            {
                var currentForground = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(message);


                Console.ForegroundColor = currentForground;
            };

            account.Add(400);
            Console.WriteLine();

            account.AddNotify -= delegate (string message)
            {
                var currentForground = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(message);


                Console.ForegroundColor = currentForground;
            };

            account.Add(800);
            Console.WriteLine();



            void OkGreenText(string message)
            {
                var currentForground = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);


                Console.ForegroundColor = currentForground;
            }

            void OkMagentaText(string message)
            {
                var currentForground = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(message);

                Console.ForegroundColor = currentForground;
            }

            var f1 = delegate (int a, int b)
            {
                a *= 2;
                return a + b;
            };

            var fl1 = (int a, int b) =>
            {
                a *= 2;
                return a + b;
            };

            var f2 = delegate (string name)
            {
                Console.WriteLine($"Hello {name}");
            };

            var fl2 = (string name) => Console.WriteLine($"Hello {name}");
        }

        public static void EventsExample()
        {

            Button btnSend = new("Send Message");

            btnSend.ClickNotify += ButtonClick;
            //    (string message) =>
            //{
            //    var color = Console.ForegroundColor;

            //    Console.ForegroundColor = ConsoleColor.Cyan;
            //    Console.WriteLine(message);

            //    Console.ForegroundColor = color;
            //};

            btnSend.Click();

            ListBox listBox = new(new[]
            {
                "Moscow", "Voroneg", "Kaluga", "Tula"
            });

            listBox.SelectNotify += (object sender, MyEventArgs args) =>
            {
                var color = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(args.Message);

                Console.ForegroundColor = color;
            };

            listBox.Select(2);


            void ButtonClick(object sender, MyEventArgs args)
            {
                if (sender is Button btn)
                {
                    var color = Console.ForegroundColor;

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(args.Message);

                    Console.ForegroundColor = color;
                }


            }

        }
    }
}
