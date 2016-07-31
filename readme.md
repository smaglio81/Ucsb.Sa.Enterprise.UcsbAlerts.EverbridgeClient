## Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient

This is a partial implementation in C# for the Everbridge REST API, [https://api.everbridge.net/](https://api.everbridge.net/)

Unfortunately, the company does not supply a C# dll for their API. And the Swagger implementation that they have is incomplete and swagger-codegen is unable to produce a C# client dll.

So ... here's the partial implementation of the API that I needed.

This client uses [Ucsb.Sa.Enterprise.ClientExtensions](https://github.com/smaglio81/Ucsb.Sa.Enterprise.ClientExtensions) to manager the ```HttpClient```'s.