using BirthdayGreetingsKata.Contacts;
using BirthdayGreetingsKata.IO;
using BirthdayGreetingsKata.Messaging;

namespace BirthdayGreetingsKata
{
    public class ContactBirthdayGreeter
    {
        private readonly AnniversaryChecker _anniversaryChecker;
        private readonly IMessageFactory _messageFactory;
        private readonly IMessageSender _messageSender;

        public ContactBirthdayGreeter(
            AnniversaryChecker anniversaryChecker, 
            IMessageFactory messageFactory,
            IMessageSender messageSender)
            => (_anniversaryChecker, _messageFactory, _messageSender) = (anniversaryChecker, messageFactory, messageSender);

        public void SendGreetings(Contact contact)
        {
            if (_anniversaryChecker.IsBirthday(contact.DateOfBirth))
                _messageFactory.Create(contact).Send(_messageSender);
        }
    }
}