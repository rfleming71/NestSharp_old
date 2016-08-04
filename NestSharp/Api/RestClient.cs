using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NestSharp.Api
{
    /// <summary>
    /// Performs the actual requests to the NEST api
    /// </summary>
    class RestClient : IRestClient
    {
        /// <summary>
        /// End point to hit for the API
        /// </summary>
        private const string NestDevEndPoint = "https://developer-api.nest.com/";

        /// <summary>
        /// Underlying http client
        /// </summary>
        private readonly HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClient" /> class.
        /// </summary>
        public RestClient()
        {
            _client = new HttpClient() { BaseAddress = new Uri(NestDevEndPoint) };
        }

        /// <summary>
        /// Gets or sets the authorization code from NEST
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets an object from the API
        /// </summary>
        /// <typeparam name="R">Type of the object being received</typeparam>
        /// <param name="url">URL to get</param>
        /// <returns>Response object</returns>
        public async Task<R> GetRequest<R>(string url)
        {
            return await SendRequest<object, R>(url, null, HttpMethod.Get);
        }

        /// <summary>
        /// Puts a given object to the API
        /// </summary>
        /// <typeparam name="T">Type of the object being sent</typeparam>
        /// <typeparam name="R">Type of the object being received</typeparam>
        /// <param name="url">URL to post to</param>
        /// <param name="contents">Object to put</param>
        /// <returns>Response object</returns>
        public async Task<R> PutRequest<T, R>(string url, T contents)
        {
            return await SendRequest<T, R>(url, contents, HttpMethod.Put);
        }

        private async Task<R> SendRequest<T, R>(string url, T contents, HttpMethod method)
        {
            url = string.Format("{0}.json?auth={1}", url, AccessToken);

            HttpRequestMessage message = new HttpRequestMessage(method, url);
            if (contents != null)
            {
                string serializedContents = JsonConvert.SerializeObject(contents, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                message.Content = new StringContent(serializedContents, Encoding.UTF8, "application/json");
            }

            HttpResponseMessage response = await _client.SendAsync(message);
            if (!response.IsSuccessStatusCode)
            {
                throw new NestException("Received status code " + response.StatusCode);
            }

            string content = await response.Content.ReadAsStringAsync();
            R result = JsonConvert.DeserializeObject<R>(content);

            return result;
        }
    }
}
