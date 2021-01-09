namespace BirthdayGreetingsKata.Messaging
{
    public interface IMessage
    {
        void Send(IMessageSender sender);
    }
}