namespace Nest.Api
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Structure information
    /// </summary>
    public interface IStructure
    {
        /// <summary>
        /// Gets the unique structure identifier
        /// </summary>
        string StructureId { get; }

        /// <summary>
        /// Gets the array of Thermostats in the structure, by unique identifier
        /// </summary>
        IEnumerable<string> Thermostats { get; }

        /// <summary>
        /// Gets the array of smoke+CO in the structure, by unique identifier
        /// </summary>
        IEnumerable<string> SmokeCoAlarms { get; }

        /// <summary>
        /// Gets the structure state
        /// </summary>
        AwayState Away { get; }

        /// <summary>
        /// Gets the User-defined structure name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the country
        /// </summary>
        string CountryCode { get; }

        /// <summary>
        /// Gets the start time of Rush Hour Rewards energy event
        /// </summary>
        DateTime PeakPeriodStartTime { get; }

        /// <summary>
        /// Gets the end time of Rush Hour Rewards energy event
        /// </summary>
        DateTime PeakPeriodEndTime { get; }

        /// <summary>
        /// Gets the time zone at the structure
        /// </summary>
        string Timezone { get; }

        /// <summary>
        /// Gets the estimated arrival window
        /// </summary>
        IEta Eta { get; }
    }
}
