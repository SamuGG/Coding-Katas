using System;

namespace BirthdayGreetingsKata.IO
{
    public interface IDateProvider
    {
        DateTime Date { get; }
    }
}