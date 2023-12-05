using FinalCourseAssignment.Domain.Services;
using FinalCourseAssignment.Domain.Constants;
using System.Security.Cryptography;

namespace FinalCourseAssignment.Services.Services
{
    public class SaltGenerator : ISaltGenerator
    {
        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[NumberConstants.SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }
    }
}
