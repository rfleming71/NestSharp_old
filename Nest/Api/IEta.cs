namespace Nest.Api
{
    using System;

    /// <summary>
    /// Estimated arrival window
    /// </summary>
    public interface IEta
    {
        /// <summary>
        /// Gets the unique identifier for this ETA instance
        /// </summary>
        string TripId { get; }

        /// <summary>
        /// Gets the beginning time of the estimated arrival window
        /// </summary>
        DateTime EstimatedArrivalWindowBegin { get; }

        /// <summary>
        /// Gets the ending time of the estimated arrival window
        /// </summary>
        DateTime EstimatedArrivalWindowEnd { get; }
    }
}
