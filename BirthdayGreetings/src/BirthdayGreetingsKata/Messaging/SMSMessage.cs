namespace BirthdayGreetingsKata.Messaging
{
    public class SMSMessage : Message
    {
        public string ToPhoneNumber { get; set; }
        public SMSMessage(string to, string content) : base(content)
            => ToPhoneNumber = to;
        
        protected override string Serialize()
            => $"{ToPhoneNumber}|{base.Serialize()}";
    }
}