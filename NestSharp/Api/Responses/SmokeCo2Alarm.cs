namespace NestSharp.Api.Responses
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;

    /// <summary>
    /// Internal response object from Nest
    /// </summary>
    public class SmokeCo2Alarm
    {
        /// <summary>
        /// Gets or sets the thermostat unique identifier
        /// </summary>
        [JsonProperty("device_id")]
        public string DeviceId { get; internal set; }

        /// <summary>
        /// Gets or sets the country and language preference,
        /// </summary>
        [JsonProperty("locale")]
        internal string LocaleString { get; set; }

        /// <summary>
        /// Gets the country and language preference,
        /// </summary>
        [JsonIgnore]
        public CultureInfo Locale
        {
            get
            {
                return CultureInfo.GetCultureInfoByIetfLanguageTag(LocaleString);
            }
        }

        /// <summary>
        /// Gets or sets the software version
        /// </summary>
        [JsonProperty("software_version")]
        public string SoftwareVersion { get; internal set; }

        /// <summary>
        /// Gets or sets the unique structure identifier
        /// </summary>
        [JsonProperty("structure_id")]
        public string StructureId { get; internal set; }

        /// <summary>
        /// Gets or sets the Display name of the device
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets or sets the long display name of the device
        /// </summary>
        [JsonProperty("name_long")]
        public string LongName { get; internal set; }

        /// <summary>
        /// Gets or sets the time of the last successful 
        /// interaction with the Nest service
        /// </summary>
        [JsonProperty("last_connection")]
        public DateTime LastConnection { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether device is connected 
        /// with the Nest Service
        /// </summary>
        [JsonProperty("is_online")]
        public bool IsOnline { get; internal set; }

        /// <summary>
        /// Gets or sets the battery life/health; estimate of time to end of life
        /// </summary>
        [JsonProperty("battery_health")]
        internal string BatteryHealthString { get; set; }

        /// <summary>
        /// Gets the battery life/health; estimate of time to end of life
        /// </summary>
        public BatteryHealth BatteryHealth
        {
            get
            {
                return BatteryHealthString == "ok" ? BatteryHealth.OK : BatteryHealth.Replace;
            }
        }

        /// <summary>
        /// Gets or sets the CO2 alarm status
        /// </summary>
        [JsonProperty("co_alarm_state")]
        internal string CoAlarmStateString { get; set; }

        /// <summary>
        /// Gets the CO2 alarm status
        /// </summary>
        public AlarmState CO2AlarmState
        {
            get
            {
                switch (CoAlarmStateString)
                {
                    case "warning":
                        return AlarmState.Warning;
                    case "emergency":
                        return AlarmState.Emergency;
                }

                return AlarmState.OK;
            }
        }

        /// <summary>
        /// Gets or sets the Smoke alarm status
        /// </summary>
        [JsonProperty("smoke_alarm_state")]
        internal string SmokeAlarmStateString { get; set; }

        /// <summary>
        /// Gets the Smoke alarm status
        /// </summary>
        public AlarmState SmokeAlarmState
        {
            get
            {
                switch (SmokeAlarmStateString)
                {
                    case "warning":
                        return AlarmState.Warning;
                    case "emergency":
                        return AlarmState.Emergency;
                }

                return AlarmState.OK;
            }
        }

        /// <summary>
        /// Gets or sets the state of the manual smoke and CO alarm test.
        /// </summary>
        [JsonProperty("is_manual_test_active")]
        public bool IsManualTestActive { get; internal set; }

        /// <summary>
        /// Gets or sets the timestamp of the last successful manual test, in ISO 8601 format.
        /// </summary>
        [JsonProperty("last_manual_test_time")]
        public DateTime? LastManualTestTime { get; internal set; }

        /// <summary>
        /// Gets or sets the device status by color in the Nest app UI
        /// </summary>
        [JsonProperty("ui_color_state")]
        public string UiColorState { get; internal set; }

        [JsonProperty("where_id")]
        public string WhereId { get; internal set; }
    }
}
