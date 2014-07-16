namespace Nest.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Nest.Api.Responses;
    using System.Net.Http;
    using Newtonsoft.Json;

    /// <summary>
    /// API for talking to Nest
    /// </summary>
    public class NestApi
    {
        private const string NestDevEndPoint = "https://developer-api.nest.com/";
        private string _clientId;
        private string _clientSecret;
        private string _pinCode;
        private string _authCode;
        private HttpClient _webClient = new HttpClient() { BaseAddress = new Uri(NestDevEndPoint) };

        /// <summary>
        /// Initializes a new instance of the <see cref="NestResponse" /> class.
        /// </summary>
        /// <param name="clientId">Nest Client ID</param>
        /// <param name="clientSecret">Nest Client Secret</param>
        /// <param name="pinCode">Authorization pin code</param>
        public NestApi(string clientId, string clientSecret, string pinCode)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _pinCode = pinCode;
        }

        /// <summary>
        /// Gets all Nest information
        /// </summary>
        /// <returns>Information about the given nest client</returns>
        public INestResponse GetAllInformation()
        {
            NestResponse response = GetResponse<NestResponse>(null);
            return response;
        }

        /// <summary>
        /// Gets all Nest information
        /// </summary>
        /// <returns>Information about the given nest client</returns>
        public IDevices GetDeviceInformation()
        {
            Devices response = GetResponse<Devices>("devices");
            return response;
        }

        /// <summary>
        /// Gets all Nest information
        /// </summary>
        /// <returns>Information about the given nest client</returns>
        public IEnumerable<IStructure> GetStructureInformation()
        {
            Dictionary<string, Structure> response = GetResponse<Dictionary<string, Structure>>("structures");
            return response.Values.ToList();
        }

        private T GetResponse<T>(string url)
        {
            url = string.Format("{0}.json?auth={1}", url, _authCode);
            var getTask = _webClient.GetAsync(url);
            getTask.Wait();
            var resultTak = getTask.Result.Content.ReadAsStringAsync();
            resultTak.Wait();
            string responseString = resultTak.Result;

            T response = JsonConvert.DeserializeObject<T>(responseString);

            return response;
        }
    }
}
