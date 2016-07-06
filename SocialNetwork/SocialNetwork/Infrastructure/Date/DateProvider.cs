using System;

namespace SocialNetwork.Infrastructure.Date
{
    public class DateProvider : IDateProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}