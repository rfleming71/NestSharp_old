namespace NestSharp.Api.Responses
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Collection of devices attached to the account
    /// </summary>
    public class Devices
    {
        /// <summary>
        /// Gets the thermostats for the account
        /// </summary>
        public Dictionary<string, Thermostat> Thermostats { get; internal set; }

        /// <summary>
        /// Gets the Smoke/CO2 alarms for the account
        /// </summary>
        [JsonProperty("smoke_co_alarms")]
        public Dictionary<string, SmokeCo2Alarm> SmokeCoAlarms { get; internal set; }
    }
}
