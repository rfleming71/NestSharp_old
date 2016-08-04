NestSharp
=========

API for working with the Nest REST API.

Usage
=========
API requires that you create a client on a Nest Developer account before using it. See [Nest Dev Clients]

**Build API from a pin**
```C#
string clientId = "clientId";
string clientSecert = "secret";
string pin = "PINPIN";
INestApi nestSharp = await NestSharpBuilder.Authorize(clientSecert, clientId, pin);
```
**Build API from existing AccessToken**
```C#
INestApi nestSharp = NestApiBuilder.WithExistingAccessToken("c.sEmlsiDj9Ssgna0W8MiAQIolv30qguUCv7bXTuUAyReaS30apETDTNGAV2rvkGRuLeUb7o8M9oGBXH7PHShmD9OLS1hqp0FW3JcDlag2WIy0jIPFDo1ArfItpNLIeToQazSG62AOHXhFl6Wt");
```

**Setting thermostat target temperature**
```C#
var devices = await nestSharp.GetDeviceInformation();

ThermostatRequest request = new ThermostatRequest();
request.DeviceId = devices.Thermostats.First().Value.DeviceId;
request.TemperatureScale = NestSharp.Api.TemperatureScale.Fahrenheit;
request.TargetTemperatureFahrenheit = 76;
await nestSharp.SetThermostat(request);
```

**Setting home away temperature**
```C#
var structures = await nestSharp.GetStructureInformation();

StructureRequest request = new StructureRequest();
request.StructureId = structures.First().Value.StructureId;
request.Away = AwayState.Away;
await nestSharp.SetStructure(request);
```

**Nest developer pages**

[Nest Dev Home]

[Nest Dev Home]:https://developer.nest.com/
[Nest Dev Clients]:https://developer.nest.com/clients