namespace NestSharp.Api.Responses
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;

    /// <summary>
    /// Internal response object from Nest
    /// </summary>
    public class Thermostat
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
        /// Gets or sets a value indicating whether system has the ability to heat
        /// </summary>
        [JsonProperty("can_heat")]
        public bool CanHeat { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether the system has the ability to cool (AC)
        /// </summary>
        [JsonProperty("can_cool")]
        public bool CanCool { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether Emergency Heat is active in 
        /// systems with heat pumps
        /// </summary>
        [JsonProperty("is_using_emergency_heat")]
        public bool IsUsingEmergencyHeat { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether the system can control 
        /// the fan separately from heating or cooling
        /// </summary>
        [JsonProperty("has_fan")]
        public bool HasFan { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether the fan timer is engaged; 
        /// used with 'fan_timer_timeout' to turn on the fan for a (user-specified) preset duration
        /// </summary>
        [JsonProperty("fan_timer_active")]
        public bool IsFanTimerActive { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether the users chose an 
        /// energy-saving temperature
        /// </summary>
        [JsonProperty("has_leaf")]
        public bool HasLeaf { get; internal set; }

        /// <summary>
        /// Gets or sets Celsius or Fahrenheit; used with temperature display
        /// </summary>
        [JsonProperty("temperature_scale")]
        internal string TemperatureScaleString { get; set; }

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
        /// Gets or sets the desired temperature
        /// </summary>
        [JsonProperty("target_temperature_c")]
        public float TargetTemperatureCelsius { get; internal set; }

        /// <summary>
        /// Gets or sets the desired temperature
        /// </summary>
        [JsonProperty("target_temperature_f")]
        public int TargetTemperatureFahrenheit { get; internal set; }

        /// <summary>
        /// Gets or sets the 
        /// </summary>
        [JsonProperty("target_temperature_high_c")]
        public float TargetTemperatureHighCelsius { get; internal set; }

        /// <summary>
        /// Gets or sets the Maximum target temperature
        /// </summary>
        [JsonProperty("target_temperature_high_f")]
        public int TargetTemperatureHighFahrenheit { get; internal set; }

        /// <summary>
        /// Gets or sets the Maximum target temperature
        /// </summary>
        [JsonProperty("target_temperature_low_c")]
        public float TargetTemperatureLowCelsius { get; internal set; }

        /// <summary>
        /// Gets or sets the 
        /// </summary>
        [JsonProperty("target_temperature_low_f")]
        public int TargetTemperatureLowFahrenheit { get; internal set; }

        /// <summary>
        /// Gets or sets the Maximum 'away' temperature
        /// </summary>
        [JsonProperty("away_temperature_high_c")]
        public float AwayTemperatureHighCelsius { get; internal set; }

        /// <summary>
        /// Gets or sets the Maximum 'away' temperature
        /// </summary>
        [JsonProperty("away_temperature_high_f")]
        public int AwayTemperatureHighFahrenheit { get; internal set; }

        /// <summary>
        /// Gets or sets the Minimum 'away' temperature
        /// </summary>
        [JsonProperty("away_temperature_low_c")]
        public float AwayTemperatureLowCelsius { get; internal set; }

        /// <summary>
        /// Gets or sets the Minimum 'away' temperature
        /// </summary>
        [JsonProperty("away_temperature_low_f")]
        public int AwayTemperatureLowFahrenheit { get; internal set; }

        /// <summary>
        /// Gets or sets the Indicates HVAC system heating/cooling modes
        /// </summary>
        [JsonProperty("hvac_mode")]
        internal string HvacModeString { get; set; }

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
        /// Gets or sets the Minimum target temperature
        /// </summary>
        [JsonProperty("ambient_temperature_c")]
        public float AmbientTemperatureCelsius { get; internal set; }

        /// <summary>
        /// Gets or sets the Minimum target temperature
        /// </summary>
        [JsonProperty("ambient_temperature_f")]
        public int AmbientTemperatureFahrenheit { get; internal set; }

        /// <summary>
        /// Humidity, in percent (%) format, measured at the device.
        /// </summary>
        public int Humidity { get; set; }

        /// <summary>
        /// Indicates whether the HVAC system is actively heating, cooling or is off
        /// </summary>
        [JsonProperty("hvac_state")]
        internal string HvacStateString { get; set; }
        public HvacState HvacState
        {
            get
            {
                switch (HvacStateString)
                {
                    case "heating":
                        return HvacState.Heating;
                    case "cooling":
                        return HvacState.Cooling;
                    case "off":
                    default:
                        return HvacState.Off;
                }
            }
        }

        /// <summary>
        /// Where unique identifier.
        /// </summary>
        [JsonProperty("where_id")]
        public string WhereId { get; internal set; }

        /// <summary>
        /// Thermostat Lock status. When true, the Thermostat Lock feature is enabled, and restricts the temperature range to 
        /// these min/max values: locked_temp_min_f, locked_temp_max_f, locked_temp_min_c, and locked_temp_max_c.
        /// </summary>
        [JsonProperty("is_locked")]
        public string IsLocked { get; internal set; }

        /// <summary>
        /// Gets or sets the 
        /// </summary>
        [JsonProperty("locked_temp_min_c")]
        public float LockedTemperatureHighCelsius { get; internal set; }

        /// <summary>
        /// Gets or sets the Maximum target temperature
        /// </summary>
        [JsonProperty("locked_temp_min_f")]
        public int LockedTemperatureHighFahrenheit { get; internal set; }

        /// <summary>
        /// Gets or sets the Maximum target temperature
        /// </summary>
        [JsonProperty("locked_temp_max_c")]
        public float LockedTemperatureLowCelsius { get; internal set; }

        /// <summary>
        /// Gets or sets the 
        /// </summary>
        [JsonProperty("locked_temp_max_f")]
        public int LockedTemperatureLowFahrenheit { get; internal set; }

        /// <summary>
        /// Thermostat custom label.
        /// </summary>
        public string Label { get; internal set; }
    }
}
