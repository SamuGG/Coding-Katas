using System;

namespace BirthdayGreetingsKata.IO
{
    public class AnniversaryChecker
    {
        private readonly IDateProvider _dateProvider;

        public AnniversaryChecker(IDateProvider dateProvider)
            => _dateProvider = dateProvider;

        public bool IsBirthday(DateTime candidate)
        {
            var current = _dateProvider.Date;
            return YearIsGreater(current, candidate) && 
                (DayAndMonthAreEqual(current, candidate) ||
                IsLastDayOfFebruary(current, candidate));
        }

        private static bool YearIsGreater(DateTime current, DateTime candidate)
            => current.Year > candidate.Year;

        private static bool DayAndMonthAreEqual(DateTime date1, DateTime date2)
            => date1.Month == date2.Month &&
            date1.Day == date2.Day;

        private static bool IsLastDayOfFebruary(DateTime current, DateTime candidate)
            => !DateTime.IsLeapYear(current.Year) && 
            current.Month == 2 && 
            candidate.Month == current.Month &&
            candidate.Day == 29 &&
            current.Day == 28;
    }
}