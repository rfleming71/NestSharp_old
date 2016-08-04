using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NestSharp;
using NestSharp.Api;
using NestSharp.Api.Requests;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var nestSharp = NestSharpBuilder.Authorize("", "", "").Result;
            INestApi nestSharp = NestApiBuilder.WithExistingAccessToken("");
            var devices = nestSharp.GetDeviceInformation().Result;
            var structures = nestSharp.GetStructureInformation().Result;

            /*ThermostatRequest request = new ThermostatRequest();
            request.DeviceId = devices.Thermostats.First().Value.DeviceId;
            request.TemperatureScale = NestSharp.Api.TemperatureScale.Fahrenheit;
            request.TargetTemperatureFahrenheit = 76;
            nestSharp.SetThermostat(request).Wait();*/

            StructureRequest request = new StructureRequest();
            request.StructureId = structures.First().Value.StructureId;
            request.Away = AwayState.Away;
            nestSharp.SetStructure(request).Wait();
        }
    }
}
