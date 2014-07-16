namespace NestSharp.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using NestSharp.Api.Responses;
    using NestSharp.Api.Responses.Auth;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// API for talking to Nest
    /// </summary>
    public class NestApi
    {
        /// <summary>
        /// End point to hit for the API
        /// </summary>
        private const string NestDevEndPoint = "https://developer-api.nest.com/";

        /// <summary>
        /// Client used to hit the API
        /// </summary>
        private HttpClient _webClient = new HttpClient() { BaseAddress = new Uri(NestDevEndPoint) };

        /// <summary>
        /// Initializes a new instance of the <see cref="NestApi" /> class.
        /// </summary>
        public NestApi()
        {
        }

        /// <summary>
        /// Gets or sets the authorization code for the nest API
        /// </summary>
        public string AuthCode { get; set; }

        /// <summary>
        /// Converts a pin into an Authorization code
        /// </summary>
        /// <param name="clientId">Nest Client ID</param>
        /// <param name="clientSecret">Nest Client Secret</param>
        /// <param name="pinCode">Authorization pin code</param>
        /// <returns>The new authorization code</returns>
        public string GetAuthorizationCode(string clientId, string clientSecret, string pinCode)
        {
            const string UrlFormat = "https://api.home.nest.com/oauth2/access_token?code={0}&client_id={1}&client_secret={2}&grant_type=authorization_code";

            string authUrl = string.Format(UrlFormat, pinCode, clientId, clientSecret);
            var task = _webClient.PostAsync(authUrl, null);
            task.Wait();

            var resultTask = task.Result.Content.ReadAsStringAsync();
            resultTask.Wait();
            string result = resultTask.Result;

            AuthResponse response = JsonConvert.DeserializeObject<AuthResponse>(result);

            if (!string.IsNullOrWhiteSpace(response.Error))
            {
                string message = string.Format("Error obtaining authorization code. {0}: {1}", response.Error, response.ErrorDescription);
                throw new NestException(message);
            }

            return null;
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

        /// <summary>
        /// Sets the estimated time of arrival
        /// </summary>
        /// <param name="structureId">Structure Identifier</param>
        /// <param name="tripId">Unique ETA trip identifier</param>
        /// <param name="etaWindowStart">Window start time</param>
        /// <param name="etaWindowStop">Window end time</param>
        /// <returns>The set ETA values</returns>
        public IEta SetEta(string structureId, string tripId,  DateTime etaWindowStart, DateTime etaWindowStop)
        {
            if (etaWindowStart < DateTime.Now)
            {
                throw new NestException("ETA window start time cannot be in the past");
            }

            if (etaWindowStop < etaWindowStart)
            {
                throw new NestException("ETA window stop time cannot be before the start time");
            }

            if (string.IsNullOrWhiteSpace(structureId))
            {
                throw new NestException("Structure Id cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(tripId))
            {
                throw new NestException("Trip Id cannot be blank");
            }

            string url = string.Format("structures/{0}/eta", structureId);
            IEta response = PostResponse<Eta>(url, new { trip_id = tripId, estimated_arrival_window_begin = etaWindowStart, estimated_arrival_window_end = etaWindowStop });
            return response;
        }

        void foo()
        {
            NestApi api = new NestApi();
            api.AuthCode = "c.AUTHCODE";
            float setTemperature = api.SetThermostatTargetTemperature("deviceId", TemperatureScale.Fahrenheit, 72);
            setTemperature = api.SetThermostatTargetTemperature("deviceId", TemperatureScale.Celsius, 23.5f);
        }
        
        /// <summary>
        /// Sets the target temperature
        /// </summary>
        /// <param name="deviceId">Device Identifier</param>
        /// <param name="scale">Temperature scale to set</param>
        /// <param name="targetTemperature">Temperature to target</param>
        /// <returns>Temperature set</returns>
        public float SetThermostatTargetTemperature(string deviceId, TemperatureScale scale, float targetTemperature)
        {
            string url = string.Format("devices/thermostats/{0}", deviceId);
            object setting;
            if (scale == TemperatureScale.Fahrenheit)
            {
                // Round to the nearest 1
                targetTemperature = (int)Math.Round(targetTemperature);
                setting = new { target_temperature_f = (int)targetTemperature };
                object response = PostResponse<object>(url, setting);
                return (int)(response as JObject)["target_temperature_f"];
            }
            else
            {
                // Round to the nearest .5
                targetTemperature = (float)Math.Round(targetTemperature * 2.0f, MidpointRounding.AwayFromZero);
                targetTemperature /= 2;
                setting = new { target_temperature_c = targetTemperature };
                object response = PostResponse<object>(url, setting);
                return (float)(response as JObject)["target_temperature_c"];
            }
        }

        /// <summary>
        /// Posts a given object to the API
        /// </summary>
        /// <typeparam name="T">Type to process the response as</typeparam>
        /// <param name="url">URL to post to</param>
        /// <param name="paramObject">Object to post</param>
        /// <returns>Response object</returns>
        private T PostResponse<T>(string url, object paramObject)
        {
            url = string.Format("{0}.json?auth={1}", url, AuthCode);
            string postBody = JsonConvert.SerializeObject(paramObject);
            var getTask = _webClient.PutAsync(url, new StringContent(postBody, Encoding.UTF8, "application/json"));
            getTask.Wait();

            var resultTak = getTask.Result.Content.ReadAsStringAsync();
            resultTak.Wait();
            string responseString = resultTak.Result;

            ErrorResponse error = JsonConvert.DeserializeObject<ErrorResponse>(responseString);
            if (!string.IsNullOrWhiteSpace(error.Error))
            {
                throw new NestException(error.Error);
            }

            T response = JsonConvert.DeserializeObject<T>(responseString);

            return response;
        }

        /// <summary>
        /// Gets the given url from the API
        /// </summary>
        /// <typeparam name="T">Type to process the response as</typeparam>
        /// <param name="url">URL to get</param>
        /// <returns>Response object</returns>
        private T GetResponse<T>(string url)
        {
            url = string.Format("{0}.json?auth={1}", url, AuthCode);
            var getTask = _webClient.GetAsync(url);
            getTask.Wait();

            if (!getTask.Result.IsSuccessStatusCode)
            {
                string message = string.Format("{0}: {1}", getTask.Result.StatusCode, getTask.Result.ReasonPhrase);
                throw new NestException(message);
            }

            var resultTak = getTask.Result.Content.ReadAsStringAsync();
            resultTak.Wait();
            string responseString = resultTak.Result;

            T response = JsonConvert.DeserializeObject<T>(responseString);

            return response;
        }
    }
}
