using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace BirthdayGreetingsKata.Contacts
{
    public class ContactEnumerator : IEnumerator<Contact>
    {
        private readonly TextReader _reader;
        private readonly ContactFactory _contactFactory;
        private Contact _current = null;

        public ContactEnumerator(TextReader reader, ContactFactory contactFactory)
            => (_reader, _contactFactory) = (reader, contactFactory);

        public Contact Current => _current;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            string line;
            if (string.IsNullOrEmpty(line = _reader.ReadLine())) return false;
            _current = _contactFactory.Create(line);
            return true;
        }

        public void Reset()
            => throw new NotImplementedException();

        public void Dispose() {}
    }
}