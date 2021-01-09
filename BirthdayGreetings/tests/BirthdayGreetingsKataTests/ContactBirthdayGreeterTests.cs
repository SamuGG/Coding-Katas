using System;
using BirthdayGreetingsKata;
using BirthdayGreetingsKata.Contacts;
using BirthdayGreetingsKata.IO;
using BirthdayGreetingsKata.Messaging;
using Moq;
using Xunit;

namespace BirthdayGreetingsKataTests
{
    public class ContactBirthdayGreeterTests
    {
        private static readonly Contact TestContact = new Contact("ABC", "DEF", new DateTime(2000, 1, 1), "contact@email.com", "123");

        #region Helper Methods
        private static Mock<IDateProvider> MockDateProvider(DateTime currentDate)
        {
            var mock = new Mock<IDateProvider>();
            mock.SetupGet(provider => provider.Date).Returns(currentDate);
            return mock;
        }

        private static Mock<IMessageFactory> MockMessageFactory()
        {
            var mock = new Mock<IMessageFactory>();
            mock.Setup(factory => factory.Create(It.IsAny<Contact>()))
                .Returns(new Message(string.Empty))
                .Verifiable();
            return mock;
        }

        private static Mock<IMessageSender> MockMessageSender()
        {
            var mock = new Mock<IMessageSender>();
            mock.Setup(sender => sender.Queue(It.IsAny<string>())).Verifiable();
            return mock;
        }
        #endregion

        [Fact]
        public void WhenItsNotContactsBirthday_ThenNoMessageIsSent()
        {
            var messageSender = MockMessageSender();
            new ContactBirthdayGreeter(
                new AnniversaryChecker(MockDateProvider(TestContact.DateOfBirth.AddDays(1)).Object),
                MockMessageFactory().Object,
                messageSender.Object)
                .SendGreetings(TestContact);
            messageSender.Verify(sender => sender.Queue(It.IsAny<string>()), Times.Never);
        }
        
        [Fact]
        public void WhenItsContactsBirthday_ThenMessageIsSent()
        {
            var messageSender = MockMessageSender();
            new ContactBirthdayGreeter(
                new AnniversaryChecker(MockDateProvider(TestContact.DateOfBirth.AddYears(1)).Object),
                MockMessageFactory().Object,
                messageSender.Object)
                .SendGreetings(TestContact);
            messageSender.Verify(sender => sender.Queue(It.IsAny<string>()), Times.Once);
        }
    }
}