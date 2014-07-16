namespace Nest.Api.Responses
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Collection of devices attached to the account
    /// </summary>
    public class Devices : IDevices
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Devices" /> class.
        /// </summary>
        /// <param name="thermostats">Thermostats in the system</param>
        /// <param name="smoke_co_alarms">Smoke/CO2 alarms in the system</param>
        [JsonConstructor]
        internal Devices(Dictionary<string, Thermostat> thermostats, Dictionary<string, SmokeCo2Alarm> smoke_co_alarms)
        {
            if (thermostats != null)
            {
                Thermostats = thermostats.Values.OfType<IThermostat>().ToList();
            }
            else
            {
                Thermostats = new List<IThermostat>();
            }

            if (smoke_co_alarms != null)
            {
                SmokeCoAlarms = smoke_co_alarms.Values.OfType<ISmokeCo2Alarm>().ToList();
            }
            else
            {
                SmokeCoAlarms = new List<ISmokeCo2Alarm>();
            }
        }

        /// <summary>
        /// Gets the thermostats for the account
        /// </summary>
        public IEnumerable<IThermostat> Thermostats { get; private set; }

        /// <summary>
        /// Gets the Smoke/CO2 alarms for the account
        /// </summary>
        [JsonProperty("smoke_co_alarms")]
        public IEnumerable<ISmokeCo2Alarm> SmokeCoAlarms { get; private set; }
    }
}
