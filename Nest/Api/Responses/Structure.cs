namespace Nest.Api.Responses
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Structure information
    /// </summary>
    internal class Structure : IStructure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Structure" /> class.
        /// </summary>
        /// <param name="eta">Estimated arrival window</param>
        /// <param name="thermostats">Thermostat ids</param>
        /// <param name="smoke_co_alarms">Smoke+CO alarm ids</param>
        public Structure(Eta eta, List<string> thermostats, List<string> smoke_co_alarms)
        {
            Eta = eta;
            if (thermostats != null)
            {
                Thermostats = thermostats;
            }
            else
            {
                Thermostats = new List<string>();
            }

            if (smoke_co_alarms != null)
            {
                SmokeCoAlarms = smoke_co_alarms;
            }
            else
            {
                SmokeCoAlarms = new List<string>();
            }
        }

        /// <summary>
        /// Gets or sets the unique structure identifier
        /// </summary>
        [JsonProperty("structure_id")]
        public string StructureId { get; set; }

        /// <summary>
        /// Gets or sets the array of Thermostats in the structure, by unique identifier
        /// </summary>
        public IEnumerable<string> Thermostats { get; set; }

        /// <summary>
        /// Gets or sets the array of smoke+CO in the structure, by unique identifier
        /// </summary>
        [JsonProperty("smoke_co_alarms")]
        public IEnumerable<string> SmokeCoAlarms { get; set; }

        /// <summary>
        /// Gets or sets the structure state
        /// </summary>
        [JsonProperty("away")]
        public string AwayString { get; set; }

        /// <summary>
        /// Gets the structure state
        /// </summary>
        public AwayState Away
        {
            get
            {
                switch (AwayString)
                {
                    case "away":
                        return AwayState.Away;
                    case "auto-away":
                        return AwayState.AutoAway;
                    case "home":
                        return AwayState.Home;
                }

                return AwayState.Home;
            }
        }

        /// <summary>
        /// Gets or sets the User-defined structure name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the start time of Rush Hour Rewards energy event
        /// </summary>
        [JsonProperty("peak_period_start_time")]
        public DateTime PeakPeriodStartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of Rush Hour Rewards energy event
        /// </summary>
        [JsonProperty("peak_period_end_time")]
        public DateTime PeakPeriodEndTime { get; set; }

        /// <summary>
        /// Gets or sets the time zone at the structure
        /// </summary>
        [JsonProperty("time_zone")]
        public string Timezone { get; set; }

        /// <summary>
        /// Gets or sets the estimated arrival window
        /// </summary>
        public IEta Eta { get; set; }
    }
}
