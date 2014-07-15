namespace Nest.Api
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Collection of devices attached to the account
    /// </summary>
    public interface IDevices
    {
        /// <summary>
        /// Gets the Smoke/CO2 alarms for the account
        /// </summary>
        IEnumerable<ISmokeCo2Alarm> SmokeCoAlarms { get; }

        /// <summary>
        /// Gets the thermostats for the account
        /// </summary>
        IEnumerable<IThermostat> Thermostats { get; }
    }
}
