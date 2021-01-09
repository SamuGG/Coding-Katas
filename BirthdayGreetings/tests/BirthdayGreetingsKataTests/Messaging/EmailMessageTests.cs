using BirthdayGreetingsKata.Messaging;
using Moq;
using Xunit;

namespace BirthdayGreetingsKataTests.Messaging
{
    public class EmailMessageTests
    {
        [Fact]
        public void TheMessageIsSerializedForSending()
        {
            const string toEmailAddress = "contact@email.com";
            const string subject = "Greetings";
            const string messageContent = "Have a good day!";
            
            var senderMock = new Mock<IMessageSender>();
            senderMock.Setup(x => x.Queue(It.IsAny<string>())).Verifiable();
            
            var message = new EmailMessage(toEmailAddress, subject, messageContent);
            message.Send(senderMock.Object);
            
            senderMock.Verify(sender 
                => sender.Queue(new EmailMessageSerializationBuilder()
                    .WithTo(toEmailAddress)
                    .WithSubject(subject)
                    .WithContent(messageContent)
                    .Build()));
        }
    }
}