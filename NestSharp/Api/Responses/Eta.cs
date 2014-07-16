namespace NestSharp.Api.Responses
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Estimated arrival window
    /// </summary>
    internal class Eta : IEta
    {
        /// <summary>
        /// Gets or sets the unique identifier for this ETA instance
        /// </summary>
        [JsonProperty("trip_id")]
        public string TripId { get; set; }

        /// <summary>
        /// Gets or sets the beginning time of the estimated arrival window
        /// </summary>
        [JsonProperty("estimated_arrival_window_begin")]
        public DateTime EstimatedArrivalWindowBegin { get; set; }

        /// <summary>
        /// Gets or sets the ending time of the estimated arrival window
        /// </summary>
        [JsonProperty("estimated_arrival_window_end")]
        public DateTime EstimatedArrivalWindowEnd { get; set; }
    }
}
