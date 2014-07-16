namespace NestSharp.Api.Responses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Top level response from nest
    /// </summary>
    internal class NestResponse : INestResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NestResponse" /> class.
        /// </summary>
        /// <param name="devices">Devices in the system</param>
        /// <param name="structures">Structures in the system</param>
        public NestResponse(Devices devices, Dictionary<string, Structure> structures)
        {
            Devices = devices;
            if (structures != null)
            {
                Structures = structures.Values.ToList();
            }
            else
            {
                Structures = new List<IStructure>();
            }
        }

        /// <summary>
        /// Gets or sets the devices in the systems
        /// </summary>
        public IDevices Devices { get; set; }

        /// <summary>
        /// Gets or sets the structures returned
        /// </summary>
        public IEnumerable<IStructure> Structures { get; set; }
    }
}
