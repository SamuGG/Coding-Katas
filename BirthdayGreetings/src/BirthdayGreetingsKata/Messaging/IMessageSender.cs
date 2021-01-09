namespace BirthdayGreetingsKata.Messaging
{
    public interface IMessageSender
    {
        void Queue(string serializedMessage);
    }
}