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
            NestApi api = new NestApi();

            api.AuthCode = "";
            var response = api.GetAllInformation();
            string deviceId = response.Devices.Thermostats.First().DeviceId;

            api.SetThermostatTargetTemperature(deviceId, TemperatureScale.Celsius, 23.1f);

            response = api.GetAllInformation();
        }
    }
}
