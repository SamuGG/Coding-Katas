using System;
using System.IO;
using BirthdayGreetingsKata;
using BirthdayGreetingsKata.Contacts;
using BirthdayGreetingsKata.IO;
using BirthdayGreetingsKata.Messaging;
using Moq;
using Xunit;

namespace BirthdayGreetingsKataTests
{
    public class ContactListBirthdayGreetingsTests
    {
        [Fact]
        public void BirthdayGreetingsEmailIsSentToEachContactWhoseBirthdayIsCurrentDate()
        {
            // Set current date
            var dateProvider = new Mock<IDateProvider>();
            dateProvider.SetupGet(provider => provider.Date).Returns(new DateTime(2021, 5, 19));

            // Mock message sender
            var senderService = new Mock<IMessageSender>();
            senderService.Setup(sender => sender.Queue(It.IsAny<string>())).Verifiable();

            // Create contact processor
            var greeter = new ContactBirthdayGreeter(
                new AnniversaryChecker(dateProvider.Object),
                new GreetingsEmailMessageFactory(),
                senderService.Object);

            // Generate contacts CSV
            using var contactStream = new MemoryStream();
            using (var contactWriter = new StreamWriter(contactStream, null, -1, true))
            {
                contactWriter.WriteLine("Peter,Peterson,1991-5-19,peter@email.com,111-111-111");
                contactWriter.WriteLine("William,Williamson,1990-9-5,william@email.com,222-222-222");
                contactWriter.WriteLine("Robert,Robertson,1991-5-19,robert@email.com,333-333-333");
                contactWriter.WriteLine("Claire,Clairson,1992-5-22,claire@email.com,444-444-444");
                contactWriter.WriteLine("Margaret,Peterson,1992-5-19,margaret@email.com,555-555-555");
                contactWriter.WriteLine("Ann,Peterson,1991-11-30,ann@email.com,666-666-666");
                contactWriter.Flush();
            }
            contactStream.Position = 0;
            using (var contactReader = new StreamReader(contactStream))
            using (var contactEnumerator = new ContactEnumerator(contactReader, new ContactFactory(',')))
            {
                // Process each contact
                while(contactEnumerator.MoveNext())
                {
                    greeter.SendGreetings(contactEnumerator.Current);
                }
            }

            // Verifications
            senderService.Verify(sender => sender.Queue("peter@email.com|Happy birthday!|Happy birthday, dear Peter!"), Times.Once);
            senderService.Verify(sender => sender.Queue("robert@email.com|Happy birthday!|Happy birthday, dear Robert!"), Times.Once);
            senderService.Verify(sender => sender.Queue("margaret@email.com|Happy birthday!|Happy birthday, dear Margaret!"), Times.Once);
            senderService.Verify(sender => sender.Queue(It.Is<string>(msg => msg.Contains("william@email.com"))), Times.Never);
            senderService.Verify(sender => sender.Queue(It.Is<string>(msg => msg.Contains("claire@email.com"))), Times.Never);
            senderService.Verify(sender => sender.Queue(It.Is<string>(msg => msg.Contains("ann@email.com"))), Times.Never);
        }
    }
}