using BirthdayGreetingsKata.Contacts;
using BirthdayGreetingsKata.Messaging;

namespace BirthdayGreetingsKata
{
    public class GreetingsEmailMessageFactory : IMessageFactory
    {
        public IMessage Create(Contact contact)
        {
            return new EmailMessage(
                contact.Email, 
                "Happy birthday!",
                $"Happy birthday, dear {contact.FirstName}!");
        }
    }
}