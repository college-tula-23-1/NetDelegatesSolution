using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDelegateProject
{
    public class Button
    {
        EventHandler? clickNotify = null;

        public event EventHandler? ClickNotify
        {
            add
            {
                if(value is not null)
                {
                    clickNotify += value;
                    Console.WriteLine($"Add method {value.Method.Name}");
                }
            }
            remove
            {
                if (clickNotify is not null)
                {
                    clickNotify -= value;
                    Console.WriteLine($"Remove method {value.Method.Name}");
                }
            }
        }
        public string Text { get; set; }

        public Button(string text = "Click me")
        {
            Text = text;
        }

        public void Click()
        {
            clickNotify?.Invoke(this, new ButtonEventArgs() 
            { 
                Message = $"Button {Text} clicked",
                ButtonText = Text
            });
        }
    }

    public class ListBox
    {
        string[] items;
        string selectedItem;
        
        public event EventHandler SelectNotify;

        public ListBox(string[] items)
        {
            this.items = items;
        }

        public void Select(int index)
        {
            SelectNotify?.Invoke(this, new MyEventArgs() { Message = $"In list selected item: {items[index]}"});
        }
    }

    public class MyEventArgs 
    {
        public string? Message { set; get; }
    }
    public class ButtonEventArgs : MyEventArgs
    {
        public string? ButtonText { set; get; }
    }


    public delegate void EventHandler(object sender, MyEventArgs args);
}
