Account accaunt = new(1000);
accaunt.SendAddOk = OkGreenText;
accaunt.Add(500);

accaunt.SendAddOk = OkMagentaText;
accaunt.Add(500);

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


public class Account
{
    public delegate void SendMessage(string message);

    public SendMessage SendAddOk { set; get; }
    public SendMessage SendTakeOk { set; get; }
    public SendMessage SendTakeError { set; get; }

    int amount;
    public int Amount { get; private set; }

    public Account(int amount)
    {
        this.amount = amount;
    }

    public void Add(int amount)
    {
        this.amount += amount;
        SendAddOk($"Add {amount} rub. Total: {this.amount}");
    }

    public void Take(int amount)
    {
        if(amount > this.amount)
        {
            this.amount -= amount;
            SendTakeOk($"Take {amount} rub. Total: {this.amount}");
        }
        else
            SendTakeError($"No many. Total: {this.amount}.");

    }

}