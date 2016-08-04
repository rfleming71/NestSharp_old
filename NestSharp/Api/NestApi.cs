using System.Collections.Generic;
using System.Threading.Tasks;
using NestSharp.Api.Requests;
using NestSharp.Api.Responses;

namespace NestSharp.Api
{
    internal class NestApi : INestApi
    {
        private readonly IRestClient _client;

        public NestApi(string accessToken)
        {
            _client = new RestClient()
            {
                AccessToken = accessToken,
            };
        }

        /// <summary>
        /// Gets all Nest device information
        /// </summary>
        /// <returns>Information about the given nest client's devices</returns>
        public async Task<Devices> GetDeviceInformation()
        {
            Devices response = await _client.GetRequest<Devices>("devices");
            return response;
        }

        /// <summary>
        /// Gets all structure information
        /// </summary>
        /// <returns>Information about the given nest client</returns>
        public async Task<Dictionary<string, Structure>> GetStructureInformation()
        {
            Dictionary<string, Structure> response = await _client.GetRequest<Dictionary<string, Structure>>("structures");
            return response;
        }

        /// <summary>
        /// Updates a thermostat
        /// </summary>
        /// <param name="request">Request information</param>
        /// <returns></returns>
        public async Task SetThermostat(ThermostatRequest request)
        {
            string url = string.Format("devices/thermostats/{0}", request.DeviceId);
            ThermostatRequest response = await _client.PutRequest<ThermostatRequest, ThermostatRequest>(url, request);
        }

        /// <summary>
        /// Updates a structure
        /// </summary>
        /// <param name="request">Request information</param>
        /// <returns></returns>
        public async Task SetStructure(StructureRequest request)
        {
            string url = string.Format("structures/{0}", request.StructureId);
            StructureRequest response = await _client.PutRequest<StructureRequest, StructureRequest>(url, request);
        }
    }
}
