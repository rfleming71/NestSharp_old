using Newtonsoft.Json;

namespace NestSharp.Api.Requests
{
    public class ThermostatRequest
    {
        /// <summary>
        /// Gets or sets the thermostat unique identifier
        /// </summary>
        [JsonIgnore]
        public string DeviceId { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether the fan timer is engaged; 
        /// used with 'fan_timer_timeout' to turn on the fan for a (user-specified) preset duration
        /// </summary>
        [JsonProperty("fan_timer_active")]
        public bool? IsFanTimerActive { get; set; }

        /// <summary>
        /// Gets or sets Celsius or Fahrenheit; used with temperature display
        /// </summary>
        [JsonProperty("temperature_scale")]
        internal string TemperatureScaleString { get; set; }

        /// <summary>
        /// Gets the device's temperature scale
        /// </summary>
        [JsonIgnore]
        public TemperatureScale TemperatureScale
        {
            get
            {
                return TemperatureScaleString == "C" ? TemperatureScale.Celsius : TemperatureScale.Fahrenheit;
            }
            set
            {
                TemperatureScaleString = value == TemperatureScale.Celsius ? "C" : "F";
            }
        }

        /// <summary>
        /// Gets or sets the desired temperature
        /// </summary>
        [JsonProperty("target_temperature_c")]
        public float? TargetTemperatureCelsius { get; set; }

        /// <summary>
        /// Gets or sets the desired temperature
        /// </summary>
        [JsonProperty("target_temperature_f")]
        public int? TargetTemperatureFahrenheit { get; set; }

        /// <summary>
        /// Gets or sets the 
        /// </summary>
        [JsonProperty("target_temperature_high_c")]
        public float? TargetTemperatureHighCelsius { get; set; }

        /// <summary>
        /// Gets or sets the Maximum target temperature
        /// </summary>
        [JsonProperty("target_temperature_high_f")]
        public int? TargetTemperatureHighFahrenheit { get; set; }

        /// <summary>
        /// Gets or sets the Maximum target temperature
        /// </summary>
        [JsonProperty("target_temperature_low_c")]
        public float? TargetTemperatureLowCelsius { get; set; }

        /// <summary>
        /// Gets or sets the 
        /// </summary>
        [JsonProperty("target_temperature_low_f")]
        public int? TargetTemperatureLowFahrenheit { get; set; }
        
        /// <summary>
        /// Gets or sets the Indicates HVAC system heating/cooling modes
        /// </summary>
        [JsonProperty("hvac_mode")]
        internal string HvacModeString { get; set; }

        /// <summary>
        /// Gets the Indicates HVAC system heating/cooling modes
        /// </summary>
        [JsonIgnore]
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
                    case "off":
                    default:
                        return HvacMode.Off;
                }
            }
            set
            {
                switch (value)
                {
                    case HvacMode.Heat:
                        HvacModeString = "heat";
                        break;
                    case HvacMode.Cool:
                        HvacModeString = "cool";
                        break;
                    case HvacMode.HeatCool:
                        HvacModeString = "heat-cool";
                        break;
                    case HvacMode.Off:
                        HvacModeString = "off";
                        break;
                }
            }
        }

        /// <summary>
        /// Thermostat custom label.
        /// </summary>
        public string Label { get; set; }
    }
}
