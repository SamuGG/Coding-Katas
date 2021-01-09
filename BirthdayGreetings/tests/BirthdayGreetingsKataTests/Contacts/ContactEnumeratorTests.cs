using System;
using System.IO;
using System.Text;
using BirthdayGreetingsKata.Contacts;
using Xunit;

namespace BirthdayGreetingsKataTests.Contacts
{
    public class ContactEnumeratorTests
    {
        private const string TestCsvLine = ",,0001-01-01,,";

        [Fact]
        public void InitiallyCurrentIsNull()
        {
            using(var memoryStream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(",,,,")))
            using(var streamReader = new StreamReader(memoryStream))
            Assert.Null(new ContactEnumerator(streamReader, new ContactFactory(FormatConstants.CsvSeparator)).Current);
        }
        
        [Fact]
        public void CanMoveNextWhenThereIsMoreDataToRead()
        {
            using(var memoryStream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(TestCsvLine)))
            using(var streamReader = new StreamReader(memoryStream))
            Assert.True(new ContactEnumerator(streamReader, new ContactFactory(FormatConstants.CsvSeparator)).MoveNext());
        }
        
        [Fact]
        public void CannotMoveNextWhenAllDataIsRead()
        {
            using(var memoryStream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(TestCsvLine)))
            using(var streamReader = new StreamReader(memoryStream))
            {
                var enumerator = new ContactEnumerator(streamReader, new ContactFactory(FormatConstants.CsvSeparator));
                enumerator.MoveNext();
                Assert.False(enumerator.MoveNext());
            }
        }
        
        [Fact]
        public void CurrentContainsContactPreviouslyRead()
        {
            const string firstName = "A";
            const string lastName = "B";
            var dateOfBirth = new DateTime(2019, 5, 12);
            const string email = "a@email.com";
            const string phoneNumber = "123";
            using(var memoryStream = new MemoryStream(UTF8Encoding.UTF8.GetBytes($"{firstName},{lastName},{dateOfBirth.ToShortDateString()},{email},{phoneNumber}")))
            using(var streamReader = new StreamReader(memoryStream))
            {
                var enumerator = new ContactEnumerator(streamReader, new ContactFactory(FormatConstants.CsvSeparator));
                enumerator.MoveNext();
                Assert.Equal(firstName, enumerator.Current.FirstName);
                Assert.Equal(lastName, enumerator.Current.LastName);
                Assert.Equal(dateOfBirth, enumerator.Current.DateOfBirth);
                Assert.Equal(email, enumerator.Current.Email);
                Assert.Equal(phoneNumber, enumerator.Current.PhoneNumber);
            }
        }
    }
}