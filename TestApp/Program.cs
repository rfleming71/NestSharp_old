using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NestSharp.Api;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NestApi api = new NestApi();
            api.AuthCode = "c.";
            
            var structureId = api.GetStructureInformation().First().StructureId;

            var newState = api.SetAwayState(structureId, AwayState.Away);
            newState = api.SetAwayState(structureId, AwayState.Home);
            newState = api.SetAwayState(structureId, AwayState.AutoAway);
        }
    }
}
