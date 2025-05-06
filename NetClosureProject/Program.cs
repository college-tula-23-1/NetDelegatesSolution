using static System.Runtime.InteropServices.JavaScript.JSType;

//var operation = GetOperation('+');
//Console.WriteLine(operation(20, 30));


Multiplicator mult = GetMultiplicator(3);
Console.WriteLine(mult(3));
Console.WriteLine(mult(10));

for(int i = 0; i < 5; i++)
    Console.WriteLine(Counter.GetCount());
Console.WriteLine();

var counter = GetCounter();
for (int i = 0; i < 5; i++)
    Console.WriteLine(counter());


Operation GetOperation(char sign)
{
    return sign switch
    {
        '+' => delegate (int a, int b) { return a + b; },
        '*' => delegate(int a, int b) { return a * b; },
    };
}

Multiplicator GetMultiplicator(int multiplicator)
{
    int Mult(int number)
    {
        return number * multiplicator;
    };

    return Mult;
}

int Mult5(int number)
{
    int multiplicator = 5;
    return number * multiplicator;
}

IntFunc GetCounter()
{
    int counter = 0;
    return delegate ()
    {
        return ++counter;
    };
}

class Counter
{
    static int counter = 0;
    public static int GetCount()
    {
        return ++counter;
    }
}

delegate int Operation(int a, int b);
delegate int Multiplicator(int number);
delegate int IntFunc();
