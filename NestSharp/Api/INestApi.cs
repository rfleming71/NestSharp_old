using System.Collections.Generic;
using System.Threading.Tasks;
using NestSharp.Api.Requests;
using NestSharp.Api.Responses;

namespace NestSharp.Api
{
    public interface INestApi
    {
        /// <summary>
        /// Gets all Nest device information
        /// </summary>
        /// <returns>Information about the given nest client's devices</returns>
        Task<Devices> GetDeviceInformation();

        /// <summary>
        /// Gets all structure information
        /// </summary>
        /// <returns>Information about the given nest client</returns>
        Task<Dictionary<string, Structure>> GetStructureInformation();

        /// <summary>
        /// Updates a structure
        /// </summary>
        /// <param name="request">Request information</param>
        /// <returns></returns>
        Task SetStructure(StructureRequest request);

        /// <summary>
        /// Updates a thermostat
        /// </summary>
        /// <param name="request">Request information</param>
        /// <returns></returns>
        Task SetThermostat(ThermostatRequest request);
    }
}