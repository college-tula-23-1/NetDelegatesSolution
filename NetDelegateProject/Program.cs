using NetDelegateProject;
using System.Dynamic;

MessageBuilder messageBuilder = GetMessage;
messageBuilder += GetEmailMessage;

Message GetMessage(string text)
{
    return new Message(text);
}

EmailMessage GetEmailMessage(string text)
{
    return new EmailMessage(text);
}


MessageReceiveHandler messageReceive = EmailMessageReceive;
messageReceive += MessageReceive;

void EmailMessageReceive(EmailMessage message)
{
    message.Print();
}

void MessageReceive(Message message)
{
    message.Print();
}


delegate Message MessageBuilder(string text);

delegate void MessageReceiveHandler(EmailMessage message);




