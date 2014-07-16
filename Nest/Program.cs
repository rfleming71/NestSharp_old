namespace Nest
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using Nest.Api;
    using Nest.Api.Responses;
    using Newtonsoft.Json;

    /// <summary>
    /// Padding word 1
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Padding word 1
        /// </summary>
        /// <param name="args">Command line args</param>
        public static void Main(string[] args)
        {
            string clientSecret = "";
            string clientId = "";
            string pinCode = "";

            NestApi api = new NestApi();

            api.AuthCode = "";
            var response = api.GetAllInformation();
            string structureId = response.Structures.First().StructureId;

            response = api.GetAllInformation();
        }
    }
}
