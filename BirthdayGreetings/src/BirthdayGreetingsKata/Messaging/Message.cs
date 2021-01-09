namespace BirthdayGreetingsKata.Messaging
{
    public class Message : IMessage
    {
        public string Content { get; set; }
        
        public Message(string content)
            => Content = content;
        
        public void Send(IMessageSender sender)
            => sender.Queue(Serialize());
        
        protected virtual string Serialize()
            => Content;
    }
}