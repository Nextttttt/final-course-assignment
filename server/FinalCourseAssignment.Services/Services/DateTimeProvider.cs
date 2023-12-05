using FinalCourseAssignment.Domain.Services;
using System;

namespace FinalCourseAssignment.Services.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetNow() => DateTime.Now;
    }
}
