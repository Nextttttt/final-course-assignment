using FinalCourseAssignment.Domain.Models;

namespace FinalCourseAssignment.Domain.Services
{
    public interface IHasherService
    {
        PasswordAndSaltDto HashPassword(string password);
        bool VerifyHashedPassword(string providedPassword, string hashedPassword, string saltString);
    }
}
