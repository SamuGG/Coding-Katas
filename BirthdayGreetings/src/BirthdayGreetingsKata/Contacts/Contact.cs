using System;

namespace BirthdayGreetingsKata.Contacts
{
    public record Contact(
        string FirstName,
        string LastName,
        DateTime DateOfBirth,
        string Email,
        string PhoneNumber);
}