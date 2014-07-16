namespace NestSharp.Api.Responses
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;

    /// <summary>
    /// Internal response object from Nest
    /// </summary>
    internal class Thermostat : IThermostat
    {
        /// <summary>
        /// Gets or sets the thermostat unique identifier
        /// </summary>
        [JsonProperty("device_id")]
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the country and language preference,
        /// </summary>
        [JsonProperty("locale")]
        public string LocaleString { get; set; }

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
        public string SoftwareVersion { get; set; }

        /// <summary>
        /// Gets or sets the unique structure identifier
        /// </summary>
        [JsonProperty("structure_id")]
        public string StructureId { get; set; }

        /// <summary>
        /// Gets or sets the Display name of the device
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the long display name of the device
        /// </summary>
        [JsonProperty("name_long")]
        public string LongName { get; set; }

        /// <summary>
        /// Gets or sets the time of the last successful 
        /// interaction with the Nest service
        /// </summary>
        [JsonProperty("last_connection")]
        public DateTime LastConnection { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether device is connected 
        /// with the Nest Service
        /// </summary>
        [JsonProperty("is_online")]
        public bool IsOnline { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether system has the ability to heat
        /// </summary>
        [JsonProperty("can_heat")]
        public bool CanHeat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the system has the ability to cool (AC)
        /// </summary>
        [JsonProperty("can_cool")]
        public bool CanCool { get; set; }

        /// <summary>
        /// Gets or sets Celsius or Fahrenheit; used with temperature display
        /// </summary>
        [JsonProperty("temperature_scale")]
        public string TemperatureScaleString { get; set; }

        /// <summary>
        /// Gets the device's temperature scale
        /// </summary>
        public TemperatureScale TemperatureScale 
        {
            get
            {
                return TemperatureScaleString == "C" ? TemperatureScale.Celsius : TemperatureScale.Fahrenheit;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether Emergency Heat is active in 
        /// systems with heat pumps
        /// </summary>
        [JsonProperty("is_using_emergency_heat")]
        public bool IsUsingEmergencyHeat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the system can control 
        /// the fan separately from heating or cooling
        /// </summary>
        [JsonProperty("has_fan")]
        public bool HasFan { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the fan timer is engaged; 
        /// used with 'fan_timer_timeout' to turn on the fan for a (user-specified) preset duration
        /// </summary>
        [JsonProperty("fan_timer_active")]
        public bool IsFanTimerActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the users chose an 
        /// energy-saving temperature
        /// </summary>
        [JsonProperty("has_leaf")]
        public bool HasLeaf { get; set; }

        /// <summary>
        /// Gets or sets the Indicates HVAC system heating/cooling modes
        /// </summary>
        [JsonProperty("hvac_mode")]
        public string HvacModeString { get; set; }

        /// <summary>
        /// Gets the Indicates HVAC system heating/cooling modes
        /// </summary>
        public HvacMode HvacMode
        {
            get
            {
                switch (HvacModeString)
                {
                    case "heat":
                        return HvacMode.Heat;
                    case "cool":
                        return HvacMode.Cool;
                    case "heat-cool":
                        return HvacMode.HeatCool;
                }

                return HvacMode.Off;
            }
        }

        /// <summary>
        /// Gets or sets the desired temperature
        /// </summary>
        [JsonProperty("target_temperature_c")]
        public float TargetTemperatureCelsius { get; set; }

        /// <summary>
        /// Gets or sets the desired temperature
        /// </summary>
        [JsonProperty("target_temperature_f")]
        public int TargetTemperatureFahrenheit { get; set; }

        /// <summary>
        /// Gets or sets the 
        /// </summary>
        [JsonProperty("target_temperature_high_c")]
        public float TargetTemperatureHighCelsius { get; set; }

        /// <summary>
        /// Gets or sets the Maximum target temperature
        /// </summary>
        [JsonProperty("target_temperature_high_f")]
        public int TargetTemperatureHighFahrenheit { get; set; }

        /// <summary>
        /// Gets or sets the Maximum target temperature
        /// </summary>
        [JsonProperty("target_temperature_low_c")]
        public float TargetTemperatureLowCelsius { get; set; }

        /// <summary>
        /// Gets or sets the 
        /// </summary>
        [JsonProperty("target_temperature_low_f")]
        public int TargetTemperatureLowFahrenheit { get; set; }

        /// <summary>
        /// Gets or sets the Minimum target temperature
        /// </summary>
        [JsonProperty("ambient_temperature_c")]
        public float AmbientTemperatureCelsius { get; set; }

        /// <summary>
        /// Gets or sets the Minimum target temperature
        /// </summary>
        [JsonProperty("ambient_temperature_f")]
        public int AmbientTemperatureFahrenheit { get; set; }

        /// <summary>
        /// Gets or sets the Maximum 'away' temperature
        /// </summary>
        [JsonProperty("away_temperature_high_c")]
        public float AwayTemperatureHighCelsius { get; set; }

        /// <summary>
        /// Gets or sets the Maximum 'away' temperature
        /// </summary>
        [JsonProperty("away_temperature_high_f")]
        public int AwayTemperatureHighFahrenheit { get; set; }

        /// <summary>
        /// Gets or sets the Minimum 'away' temperature
        /// </summary>
        [JsonProperty("away_temperature_low_c")]
        public float AwayTemperatureLowCelsius { get; set; }

        /// <summary>
        /// Gets or sets the Minimum 'away' temperature
        /// </summary>
        [JsonProperty("away_temperature_low_f")]
        public int AwayTemperatureLowFahrenheit { get; set; }
    }
}
