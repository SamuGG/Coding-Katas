using BirthdayGreetingsKata.Contacts;
using BirthdayGreetingsKata.Messaging;

namespace BirthdayGreetingsKata
{
    public class GreetingsSMSMessageFactory : IMessageFactory
    {
        public IMessage Create(Contact contact)
        {
            return new SMSMessage(
                contact.Email, 
                $"Happy birthday, dear {contact.FirstName}!");
        }
    }
}