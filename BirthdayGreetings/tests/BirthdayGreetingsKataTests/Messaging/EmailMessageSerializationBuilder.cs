namespace BirthdayGreetingsKataTests.Messaging
{
    public class EmailMessageSerializationBuilder
    {
        private string _toEmailAddress = string.Empty;
        private string _subject = string.Empty;
        private string _content = string.Empty;

        public EmailMessageSerializationBuilder WithTo(string value)
        {
            _toEmailAddress = value;
            return this;
        }

        public EmailMessageSerializationBuilder WithSubject(string value)
        {
            _subject = value;
            return this;
        }

        public EmailMessageSerializationBuilder WithContent(string value)
        {
            _content = value;
            return this;
        }

        public string Build()
            => $"{_toEmailAddress}|{_subject}|{_content}";
    }
}