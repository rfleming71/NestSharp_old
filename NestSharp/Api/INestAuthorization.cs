using System.Threading.Tasks;

namespace NestSharp.Api
{
    /// <summary>
    /// Performs authorization with Nest
    /// </summary>
    public interface INestAuthorization
    {
        /// <summary>
        /// Converts a pin into an Authorization code
        /// </summary>
        /// <param name="clientId">Nest Client ID</param>
        /// <param name="clientSecret">Nest Client Secret</param>
        /// <param name="pinCode">Authorization pin code</param>
        /// <returns>The new authorization code</returns>
        Task<string> GetAccessToken(string clientSecret, string clientId, string pinCode);
    }
}