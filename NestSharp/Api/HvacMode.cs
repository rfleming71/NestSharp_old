namespace NestSharp.Api
{
    /// <summary>
    /// Indicates HVAC system heating/cooling modes
    /// </summary>
    public enum HvacMode
    {
        /// <summary>
        /// System is off
        /// </summary>
        Off,

        /// <summary>
        /// System is heating only
        /// </summary>
        Heat,

        /// <summary>
        /// System is cooling only
        /// </summary>
        Cool,

        /// <summary>
        /// System is heating and cooling
        /// </summary>
        HeatCool,
    }
}
