using System;

namespace BirthdayGreetingsKata.Contacts
{
    public class ContactFactory
    {
        private readonly char _valuesSeparator;

        public ContactFactory(char valuesSeparator)
            => _valuesSeparator = valuesSeparator;

        public Contact Create(string csv)
        {
            string[] values = csv.Split(_valuesSeparator);
            if (values.Length < 5) throw new ArgumentException($"String \"{csv}\" doesn't contain all necessary values to form a {nameof(Contact)}", nameof(csv));
            return new Contact(
                values[0],
                values[1],
                DateTime.Parse(values[2]),
                values[3],
                values[4]);
        }
    }
}