# Birthday Grretings

**Problem:** Prrocess a list of contacts and send birthday greentings emails.

Kata: [codingdojo.org/kata/birthday-greetings](https://codingdojo.org/kata/birthday-greetings/)

#### Solution

The test [ContactListBirthdayGreetingsTests](tests/BirthdayGreetingsKataTests/ContactListBirthdayGreetingsTests.cs) implements the whole system for sending a happy birthday email. 

If the system required to send SMS messages instead of emails then, change the `greeter` from 

```csharp
var greeter = new ContactBirthdayGreeter(
    anniversaryChecker,
    new GreetingsEmailMessageFactory(), // -- CHANGE THIS --
    senderService);
```
to: 

```csharp
var greeter = new ContactBirthdayGreeter(
    anniversaryChecker,
    new GreetingsSMSMessageFactory(),   // -- SMS MESSAGES --
    senderService);
```

Then, if you want to complete the test, it would check that the `senderService` queues SMS messages (serialized), like this: 

```csharp
senderService.Verify(s => s.Queue("111-111-111|Happy birthday, dear Peter!"));
senderService.Verify(s => s.Queue("333-333-333|Happy birthday, dear Robert!");
senderService.Verify(s => s.Queue("555-555-555|Happy birthday, dear Margaret!"));
```

The `IMessageSender` has no implementation for this exercise, it's only used to pretend it can send messages. In a real system, you could have different implementations for real services (i.e.: EmailSender, SMSSender, MessengerSender, SkypeSender, etc.)
