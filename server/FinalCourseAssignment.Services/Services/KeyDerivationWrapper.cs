using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using FinalCourseAssignment.Domain.Services;
using FinalCourseAssignment.Domain.Constants;

namespace FinalCourseAssignment.Services
{
    public class KeyDerivationWrapper : IKeyDerivationWrapper
    {
        public byte[] GeneratePdkdf2(string password, byte[] salt, KeyDerivationPrf prf, int iterationCount, int numBytesRequested)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: NumberConstants.IterationCount,
                numBytesRequested: NumberConstants.KeySize);
        }
    }
}
