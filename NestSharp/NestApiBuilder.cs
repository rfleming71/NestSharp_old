using System.Threading.Tasks;
using NestSharp.Api;

namespace NestSharp
{
    public static class NestApiBuilder
    {
        public static INestApi WithExistingAccessToken(string accessToken)
        {
            return new NestApi(accessToken);
        }

        public static async Task<INestApi> Authorize(string clientSecret, string clientId, string pinCode)
        {
            string result = await new NestAuthorization().GetAccessToken(clientSecret, clientId, pinCode);
            return new NestApi(result);
        }
    }
}
