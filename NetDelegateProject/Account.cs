using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDelegateProject
{
    public class Account
    {
        public delegate void SendMessage(string message);

        public event SendMessage? AddNotify;
        public event SendMessage? TakeNotify;

        int amount;

        public int Amount
        {
            get => amount;
            set => amount = value;
        }


        public Account(int amount)
        {
            this.amount = amount;
        }

        public void Add(int amount)
        {
            this.amount += amount;
            AddNotify?.Invoke($"Add {amount} rub. Total: {this.amount}");
        }

        public void Take(int amount)
        {
            if (amount < this.amount)
            {
                this.amount -= amount;
                TakeNotify?.Invoke($"Take {amount} rub. Total: {this.amount}");
            }
            else
                TakeNotify?.Invoke($"No many. Total: {this.amount}.");

        }

    }
}
