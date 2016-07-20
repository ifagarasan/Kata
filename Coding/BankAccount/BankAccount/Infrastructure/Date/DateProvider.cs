using System;

namespace BankAccount.Infrastructure.Date
{
    public class DateProvider : IDateProvider
    {
        public Date Now() => new Date(DateTime.Now.ToShortDateString());
    }
}