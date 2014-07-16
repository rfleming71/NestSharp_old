NestSharp
=========

API for working with the Nest REST API.

Usage
=========
API requires that you create a client on a Nest Developer account before using it. See [Nest Dev Clients]

**Generating a authorization code from a pin**
```C#
string clientId = "clientId";
string clientSecert = "secret";
string pin = "PINPIN";
NestApi api = new NestApi();
string authCode = api.GetAuthorizationCode(clientId, clientSecert, pin);
```

**Setting thermostat target temperature**
```C#
NestApi api = new NestApi();
api.AuthCode = "c.AUTHCODE";
float setTemperature = api.SetThermostatTargetTemperature("deviceId", TemperatureScale.Fahrenheit, 72);
setTemperature = api.SetThermostatTargetTemperature("deviceId", TemperatureScale.Celsius, 23.5f);
```

**Nest developer pages**

[Nest Dev Home]

[Nest Dev Home]:https://developer.nest.com/
[Nest Dev Clients]:https://developer.nest.com/clients