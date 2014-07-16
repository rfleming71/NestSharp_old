namespace NestSharp.Api
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Response from the API
    /// </summary>
    public interface INestResponse
    {
        /// <summary>
        /// Gets the devices in the systems
        /// </summary>
        IDevices Devices { get; }

        /// <summary>
        /// Gets the structures in the systems
        /// </summary>
        IEnumerable<IStructure> Structures { get; }
    }
}
