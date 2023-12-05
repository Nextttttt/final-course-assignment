using System;

namespace FinalCourseAssignment.Domain.Services
{
    public interface IJwtService
    {
        public string GenerateJsonWebToken(Guid userId);
    }
}
