namespace Nest.Api
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Represents a thermostat from Nest
    /// </summary>
    public interface IThermostat
    {
        /// <summary>
        /// Gets the thermostat unique identifier
        /// </summary>
        string DeviceId { get; }

        /// <summary>
        /// Gets the country and language preference,
        /// </summary>
        CultureInfo Locale { get; }

        /// <summary>
        /// Gets the software version
        /// </summary>
        string SoftwareVersion { get; }

        /// <summary>
        /// Gets the unique structure identifier
        /// </summary>
        string StructureId { get; }

        /// <summary>
        /// Gets the Display name of the device
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the long display name of the device
        /// </summary>
        string LongName { get; }

        /// <summary>
        /// Gets the time of the last successful 
        /// interaction with the Nest service
        /// </summary>
        DateTime LastConnection { get; }

        /// <summary>
        /// Gets a value indicating whether device is connected 
        /// with the Nest Service
        /// </summary>
        bool IsOnline { get; }

        /// <summary>
        /// Gets a value indicating whether system has the ability to heat
        /// </summary>
        bool CanHeat { get; }

        /// <summary>
        /// Gets a value indicating whether the system has the ability to cool (AC)
        /// </summary>
        bool CanCool { get; }

        /// <summary>
        /// Gets the device's temperature scale
        /// </summary>
        TemperatureScale TemperatureScale { get; }

        /// <summary>
        /// Gets a value indicating whether Emergency Heat is active in 
        /// systems with heat pumps
        /// </summary>
        bool IsUsingEmergencyHeat { get; }

        /// <summary>
        /// Gets a value indicating whether the system can control 
        /// the fan separately from heating or cooling
        /// </summary>
        bool HasFan { get; }

        /// <summary>
        /// Gets a value indicating whether the fan timer is engaged; 
        /// used with 'fan_timer_timeout' to turn on the fan for a (user-specified) preset duration
        /// </summary>
        bool IsFanTimerActive { get; }

        /// <summary>
        /// Gets a value indicating whether the users chose an 
        /// energy-saving temperature
        /// </summary>
        bool HasLeaf { get; }

        /// <summary>
        /// Gets the Indicates HVAC system heating/cooling modes
        /// </summary>
        HvacMode HvacMode { get; }

        /// <summary>
        /// Gets the desired temperature
        /// </summary>
        float TargetTemperatureCelsius { get; }

        /// <summary>
        /// Gets the desired temperature
        /// </summary>
        int TargetTemperatureFahrenheit { get; }

        /// <summary>
        /// Gets the 
        /// </summary>
        float TargetTemperatureHighCelsius { get; }

        /// <summary>
        /// Gets the Maximum target temperature
        /// </summary>
        int TargetTemperatureHighFahrenheit { get; }

        /// <summary>
        /// Gets the Maximum target temperature
        /// </summary>
        float TargetTemperatureLowCelsius { get; }

        /// <summary>
        /// Gets the 
        /// </summary>
        int TargetTemperatureLowFahrenheit { get; }

        /// <summary>
        /// Gets the Minimum target temperature
        /// </summary>
        float AmbientTemperatureCelsius { get; }

        /// <summary>
        /// Gets the Minimum target temperature
        /// </summary>
        int AmbientTemperatureFahrenheit { get; }

        /// <summary>
        /// Gets the Maximum 'away' temperature
        /// </summary>
        float AwayTemperatureHighCelsius { get; }

        /// <summary>
        /// Gets the Maximum 'away' temperature
        /// </summary>
        int AwayTemperatureHighFahrenheit { get; }

        /// <summary>
        /// Gets the Minimum 'away' temperature
        /// </summary>
        float AwayTemperatureLowCelsius { get; }

        /// <summary>
        /// Gets the Minimum 'away' temperature
        /// </summary>
        int AwayTemperatureLowFahrenheit { get; }
    }
}
