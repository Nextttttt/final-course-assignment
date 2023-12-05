using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace FinalCourseAssignment.Domain.Services
{
    public interface IKeyDerivationWrapper
    {
        byte[] GeneratePdkdf2(string password, byte[] salt, KeyDerivationPrf prf, int iterationCount, int numBytesRequested);
    }
}
