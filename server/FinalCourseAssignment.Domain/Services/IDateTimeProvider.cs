using System;

namespace FinalCourseAssignment.Domain.Services
{
    public interface IDateTimeProvider
    {
        DateTime GetNow();
    }
}
