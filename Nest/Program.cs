namespace Nest
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using Nest.Api;
    using Nest.Api.Responses;
    using Newtonsoft.Json;

    /// <summary>
    /// Padding word 1
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Padding word 1
        /// </summary>
        /// <param name="args">Command line args</param>
        public static void Main(string[] args)
        {
            string clientSecret = "eQoMDIjhJkbZ1sCBVAKr8Duj2";
            string clientId = "01b1ddfa-c63c-4223-91e1-b82d4237d1a0";
            string pinCode = "K8F93UKC";

            string authUrl = string.Format("https://api.home.nest.com/oauth2/access_token?code={0}&client_id={1}&client_secret={2}&grant_type=authorization_code", pinCode, clientId, clientSecret);

            HttpClient client = new HttpClient();
            /*var task = client.PostAsync(authUrl, null);
            task.Wait();
            var resultTask = task.Result.Content.ReadAsStringAsync();
            resultTask.Wait();
            string result = resultTask.Result;*/

            NestApi api = new NestApi(clientId, clientSecret, pinCode);
            var response = api.GetAllInformation();

            /*string authCode = "c.uqF1hysPmePOoTFbdokAWie33ps1pnND8p4Ez1Ai7RynRJGL8YfpGraUh3IFOOGmq8Ocve1ZfJSfTgvnGDgqIPLZeHK3fWmIOS76kWzWeqeCcxG7ESqQzBnrZjxuPPmBLtfM1YJyEZIRgmtN";
            string deviceUrl = string.Format("https://developer-api.nest.com/devices.json?auth={0}", authCode);
            var task2 = client.GetAsync(deviceUrl);
            task2.Wait();
            var resultTask2 = task2.Result.Content.ReadAsStringAsync();
            resultTask2.Wait();
            string responseString = resultTask2.Result;

            NestResponse response = JsonConvert.DeserializeObject<NestResponse>(responseString);*/
        }
    }
}
