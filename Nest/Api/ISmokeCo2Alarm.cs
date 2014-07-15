﻿namespace Nest.Api
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Represents a Smoke/CO2 alarm from Nest
    /// </summary>
    public interface ISmokeCo2Alarm
    {
        /// <summary>
        /// Gets or sets the thermostat unique identifier
        /// </summary>
        string DeviceId { get; }

        /// <summary>
        /// Gets the country and language preference,
        /// </summary>
        CultureInfo Locale { get; }

        /// <summary>
        /// Gets or sets the software version
        /// </summary>
        string SoftwareVersion { get; }

        /// <summary>
        /// Gets or sets the unique structure identifier
        /// </summary>
        string StructureId { get; }

        /// <summary>
        /// Gets or sets the Display name of the device
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the long display name of the device
        /// </summary>
        string LongName { get; }

        /// <summary>
        /// Gets or sets the time of the last successful 
        /// interaction with the Nest service
        /// </summary>
        DateTime LastConnection { get; }

        /// <summary>
        /// Gets or sets a value indicating whether device is connected 
        /// with the Nest Service
        /// </summary>
        bool IsOnline { get; }

        /// <summary>
        /// Gets the battery life/health; estimate of time to end of life
        /// </summary>
        BatteryHealth BatteryHealth { get; }

        /// <summary>
        /// Gets the CO2 alarm status
        /// </summary>
        AlarmState CO2AlarmState { get; }

        /// <summary>
        /// Gets the Smoke alarm status
        /// </summary>
        AlarmState SmokeAlarmState { get; }

        /// <summary>
        /// Gets or sets the device status by color in the Nest app UI
        /// </summary>
        string UiColorState { get; }
    }
}