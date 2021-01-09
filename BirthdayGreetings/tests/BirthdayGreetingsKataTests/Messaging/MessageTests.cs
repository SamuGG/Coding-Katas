using BirthdayGreetingsKata.Messaging;
using Moq;
using Xunit;

namespace BirthdayGreetingsKataTests.Messaging
{
    public class MessageTests
    {
        [Fact]
        public void TheMessageIsSerializedForSending()
        {
            const string messageContent = "Have a good day!";
            
            var senderMock = new Mock<IMessageSender>();
            senderMock.Setup(x => x.Queue(It.IsAny<string>())).Verifiable();
            
            var message = new Message(messageContent);
            message.Send(senderMock.Object);
            
            senderMock.Verify(x => x.Queue(messageContent));
        }
    }
}