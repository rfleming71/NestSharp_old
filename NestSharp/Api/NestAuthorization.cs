using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using NestSharp.Api.Responses.Authorization;
using Newtonsoft.Json;

namespace NestSharp.Api
{
    class NestAuthorization : INestAuthorization
    {
        /// <summary>
        /// Converts a pin into an Authorization code
        /// </summary>
        /// <param name="clientId">Nest Client ID</param>
        /// <param name="clientSecret">Nest Client Secret</param>
        /// <param name="pinCode">Authorization pin code</param>
        /// <returns>The new authorization code</returns>
        public async Task<string> GetAccessToken(string clientSecret, string clientId, string pinCode)
        {
            const string AuthorizationUrl = "https://api.home.nest.com/oauth2/access_token?code={0}&client_id={1}&client_secret={2}&grant_type=authorization_code";
            Dictionary<string, string> body = new Dictionary<string, string>()
            {
                { "code", pinCode },
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "grant_type", "authorization_code" },
            };
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsync(AuthorizationUrl, new FormUrlEncodedContent(body));
            if (!response.IsSuccessStatusCode)
            { 
                throw new NestException("Received status code " + response.StatusCode);
            }

            string content = await response.Content.ReadAsStringAsync();
            AuthorizationResponse authResponse = JsonConvert.DeserializeObject<AuthorizationResponse>(content);

            if (!string.IsNullOrWhiteSpace(authResponse.Error))
            {
                string message = string.Format("Error obtaining authorization code. {0}: {1}", authResponse.Error, authResponse.ErrorDescription);
                throw new NestException(message);
            }

            return authResponse.AuthorizationCode;
        }
    }
}
