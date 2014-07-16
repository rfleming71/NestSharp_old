namespace NestSharp.Api
{
    /// <summary>
    /// Valid alarm states
    /// </summary>
    public enum AlarmState
    {
        /// <summary>
        /// No Alarm active
        /// </summary>
        OK,

        /// <summary>
        /// Warning - Issue detected
        /// </summary>
        Warning,

        /// <summary>
        /// Emergency - Major issue
        /// </summary>
        Emergency,
    }
}
