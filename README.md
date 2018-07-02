# HiRez API
 Paladins [![NuGet](https://img.shields.io/nuget/v/HiRezApi.Paladins.svg)](https://www.nuget.org/packages/HiRezApi.Paladins)
 Realm Royale [![NuGet](https://img.shields.io/nuget/v/HiRezApi.RealmRoyale.svg)](https://www.nuget.org/packages/HiRezApi.RealmRoyale)
 
A .NET library for interaction with the HiRez API supporting the games Paladins and Realm Royale (SMITE might be added in the future).

* Supports PC, PS4 and Xbox endpoints
* .NET Standard 2.0
* Extensible 

Getting started
===============

To get started just install the [Paladins NuGet package](https://www.nuget.org/packages/HiRezApi.Paladins) or [Realm Royale NuGet package](https://www.nuget.org/packages/HiRezApi.RealmRoyale).
If you do not have an auth key [request access](https://fs12.formsite.com/HiRez/form48/secure_index.html) to the HiRez API.

Usage
===============

Initialize the Paladins client by providing a platform (Pc, Xbox, Ps4) and your API credentials:
``` c#
var client = new PaladinsApiClient(Platform.Pc, new HiRezApiCredentials("YourDeveloperId", "YourAuthKey"));
```

Call a specific endpoint synchronous or asynchronous:
``` c#
var player = client.GetPlayer("bugzy");
player = await client.GetPlayerAsync("bugzy"); 
```

Similar for Realm Royale:

Initialize the client by providing a platform (Pc) and your API credentials:
``` c#
var client = new RealmRoyaleApiClient(Platform.Pc, new HiRezApiCredentials("YourDeveloperId", "YourAuthKey"));
var player = await client.GetPlayerAsync("overpowered"); 
```

It's recommended to use the client with a `RetryPolicy` to handle transient API failures:
``` c#
var retryPolicy = new RetryPolicy<HiRezApiRetryStrategy>(new ExponentialBackoffRetryStrategy());
client.SetRetryPolicy(retryPolicy);
```

Example
===============
Browse into [Examples](src/Examples/HiRezApi.Examples.App/Program.cs) or [PaladinsApiTests](src/HiRezApi.Tests/PaladinsApiTests.cs)

Compiling
===============
In order to compile the project, you need at least [Visual Studio 2017 (15.3)](https://www.visualstudio.com/downloads/) with C# 7.1 language features.

License
===============
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
