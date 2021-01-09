using BirthdayGreetingsKata.Contacts;

namespace BirthdayGreetingsKata.Messaging
{
    public interface IMessageFactory
    {
        IMessage Create(Contact contact);
    }
}