using System;
using BirthdayGreetingsKata.Contacts;
using Xunit;

namespace BirthdayGreetingsKataTests.Contacts
{
    public class ContactFactoryTests
    {
        [Fact]
        public void FailsWhenCreatingContactWithInsufficientDetails()
        {
            Assert.Throws<ArgumentException>(() 
                => new ContactFactory(char.MinValue)
                .Create(string.Empty));
        }

        public static TheoryData<string, string, string, DateTime, string, string> GetContactsDetails()
        {
            var data = new TheoryData<string, string, string, DateTime, string, string>();
            data.Add(
                "A,B,11/12/2013,a@email.com,123",
                "A", "B", new DateTime(2013, 12, 11), "a@email.com", "123");

            data.Add(
                "Contact1,,3/7/2005,contact1@email.com,",
                "Contact1", "", new DateTime(2005, 7, 3), "contact1@email.com", "");

            data.Add(
                ",,1/1/0001,,",
                "", "", new DateTime(), "", "");

            return data;
        }

        [Theory]
        [MemberData(nameof(GetContactsDetails))]
        public void ContactContainsAllDetailsFromCsv(
            string csv,
            string expectedFirstName,
            string expectedLastName,
            DateTime expectedDOB,
            string expectedEmail,
            string expectedPhoneNumber)
        {
            var factory = new ContactFactory(FormatConstants.CsvSeparator);
            var contact = factory.Create(csv);
            Assert.Equal(expectedFirstName, contact.FirstName);
            Assert.Equal(expectedLastName, contact.LastName);
            Assert.Equal(expectedDOB, contact.DateOfBirth);
            Assert.Equal(expectedEmail, contact.Email);
            Assert.Equal(expectedPhoneNumber, contact.PhoneNumber);
        }

        [Fact]
        public void FailsWhenDateOfBirthIsNotProvided()
        {
            Assert.Throws<FormatException>(()
                => new ContactFactory(FormatConstants.CsvSeparator).Create(",,,,"));
        }

        [Fact]
        public void FailsWhenDateOfBirthIsInvalid()
        {
            Assert.Throws<FormatException>(()
                => new ContactFactory(FormatConstants.CsvSeparator).Create(",,9999-13-32,,"));
        }
    }
}