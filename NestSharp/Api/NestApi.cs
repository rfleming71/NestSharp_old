namespace NestSharp.Api
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
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

            HttpWebRequest request = WebRequest.Create(authUrl) as HttpWebRequest;
            request.Method = "POST";

            var requestRsponse = request.GetResponse();
            string responseString;
            using (TextReader reader = new StreamReader(requestRsponse.GetResponseStream()))
            {
                responseString = reader.ReadToEnd();
            }

            AuthResponse response = JsonConvert.DeserializeObject<AuthResponse>(responseString);

            if (!string.IsNullOrWhiteSpace(response.Error))
            {
                string message = string.Format("Error obtaining authorization code. {0}: {1}", response.Error, response.ErrorDescription);
                throw new NestException(message);
            }

            return response.AuthCode;
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
            IEta response = PutResponse<Eta>(url, new { trip_id = tripId, estimated_arrival_window_begin = etaWindowStart, estimated_arrival_window_end = etaWindowStop });
            return response;
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
                object response = PutResponse<object>(url, setting);
                return (int)(response as JObject)["target_temperature_f"];
            }
            else
            {
                // Round to the nearest .5
                targetTemperature = (float)Math.Round(targetTemperature * 2.0f, MidpointRounding.AwayFromZero);
                targetTemperature /= 2;
                setting = new { target_temperature_c = targetTemperature };
                object response = PutResponse<object>(url, setting);
                return (float)(response as JObject)["target_temperature_c"];
            }
        }

        /// <summary>
        /// Sets the away state
        /// </summary>
        /// <param name="structureId">Structure ID to set</param>
        /// <param name="newState">New away state</param>
        /// <returns>Set away state</returns>
        public AwayState SetAwayState(string structureId, AwayState newState)
        {
            if (newState == AwayState.AutoAway)
            {
                throw new NestException("Invalid value for away. Only 'Home' and 'Away' are permitted values.");
            }

            string url = string.Format("structures/{0}", structureId);
            JObject response = PutResponse<object>(url, new { away = newState == AwayState.Away ? "away" : "home" }) as JObject;
            switch ((string)response["away"])
            {
                case "away":
                    return AwayState.Away;
                case "auto-away":
                    return AwayState.AutoAway;
            }

            return AwayState.Home;
        }

        /// <summary>
        /// Posts a given object to the API
        /// </summary>
        /// <typeparam name="T">Type to process the response as</typeparam>
        /// <param name="url">URL to post to</param>
        /// <param name="paramObject">Object to post</param>
        /// <returns>Response object</returns>
        private T PutResponse<T>(string url, object paramObject)
        {
            url = string.Format("{0}.json?auth={1}", url, AuthCode);
            string postBody = JsonConvert.SerializeObject(paramObject);

            HttpWebRequest request = WebRequest.Create(NestDevEndPoint + url) as HttpWebRequest;
            request.Method = "PUT";

            using (TextWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(postBody);
                writer.Flush();
                writer.Close();
            }

            var requestRsponse = request.GetResponse();
            string responseString;
            using (TextReader reader = new StreamReader(requestRsponse.GetResponseStream()))
            {
                responseString = reader.ReadToEnd();
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

            HttpWebRequest request = WebRequest.Create(NestDevEndPoint + url) as HttpWebRequest;
            request.Method = "GET";
            var requestRsponse = request.GetResponse();
            string responseString;
            using (TextReader reader = new StreamReader(requestRsponse.GetResponseStream()))
            {
                responseString = reader.ReadToEnd();
            }

            T response = JsonConvert.DeserializeObject<T>(responseString);

            return response;
        }
    }
}
