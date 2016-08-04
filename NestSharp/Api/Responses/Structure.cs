namespace NestSharp.Api.Responses
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Structure information
    /// </summary>
    public class Structure
    {
        /// <summary>
        /// Gets or sets the unique structure identifier
        /// </summary>
        [JsonProperty("structure_id")]
        public string StructureId { get; internal set; }

        /// <summary>
        /// Gets or sets the array of Thermostats in the structure, by unique identifier
        /// </summary>
        public IEnumerable<string> Thermostats { get; internal set; }

        /// <summary>
        /// Gets or sets the array of smoke+CO in the structure, by unique identifier
        /// </summary>
        [JsonProperty("smoke_co_alarms")]
        public IEnumerable<string> SmokeCoAlarms { get; internal set; }

        /// <summary>
        /// Gets or sets the array of camera in the structure, by unique identifier
        /// </summary>
        public IEnumerable<string> Cameras { get; internal set; }

        /// <summary>
        /// Gets or sets the structure state
        /// </summary>
        [JsonProperty("away")]
        internal string AwayString { get; set; }

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
        public string Name { get; internal set; }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; internal set; }

        /// <summary>
        /// Gets or sets the start time of Rush Hour Rewards energy event
        /// </summary>
        [JsonProperty("peak_period_start_time")]
        public DateTime PeakPeriodStartTime { get; internal set; }

        /// <summary>
        /// Gets or sets the end time of Rush Hour Rewards energy event
        /// </summary>
        [JsonProperty("peak_period_end_time")]
        public DateTime PeakPeriodEndTime { get; internal set; }

        /// <summary>
        /// Gets or sets the time zone at the structure
        /// </summary>
        [JsonProperty("time_zone")]
        public string Timezone { get; internal set; }

        /// <summary>
        /// Gets or sets the estimated arrival window
        /// </summary>
        public Eta Eta { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether the structure
        /// is enrolled in rush hour rewards
        /// </summary>
        [JsonProperty("rhr_enrollment")]
        public bool IsEnrolledInRushHourRewards { get; internal set; }
    }
}
