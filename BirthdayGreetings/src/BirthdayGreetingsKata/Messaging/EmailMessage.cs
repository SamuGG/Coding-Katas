namespace BirthdayGreetingsKata.Messaging
{
    public class EmailMessage : Message
    {
        public string ToEmailAddress { get; set; }
        public string Subject { get; set; }
        
        public EmailMessage(string to, string subject, string content) : base(content)
            => (ToEmailAddress, Subject) = (to, subject);
        
        protected override string Serialize()
            => $"{ToEmailAddress}|{Subject}|{base.Serialize()}";
    }
}