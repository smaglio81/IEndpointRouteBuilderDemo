# IEndpointRouteBuilder Problem Demo

As reported in [AspNetCore Issue #16638 (Cannot find the AspNetCore Nuget packages for 3.0 (specifically routing))](https://github.com/dotnet/aspnetcore/issues/16638),
it seems like the only way to reference `IEndpointRouteBuilder` from ASP.NET Core 3.1 (SDK 3.1.102) is to setup a project with an
SDK of `Microsoft.NET.SDK.Web` and a `TargetFramework` of `netcoreapp3.1` (example .csproj):

```
<Project Sdk="Microsoft.NET.Sdk.Web">

	<PropertyGroup>
		<TargetFramework>netcoreapp3.1</TargetFramework>
	</PropertyGroup>

</Project>
```

However, if you want to create a shared library (nuget package) which was configured in that
way, then the compiler would produce this error:

```
1>Done building project "IEndpointRouteBuilderDemo-DoesntCompile.csproj" -- FAILED.
1>
1>Build FAILED.
1>
1>CSC : error CS5001: Program does not contain a static 'Main' method suitable for an entry point
```

The error seems pretty logical, seeing that it's trying to target a `netcorapp`, which is assumed to be
an executable application.

But the original question in [AspNetCore Issue #16638 (Cannot find the AspNetCore Nuget packages for 3.0 (specifically routing))](https://github.com/dotnet/aspnetcore/issues/16638)
hasn't been solved. How can you create a class library that references `IEndpointRouteBuilder` successfully?

One thing that can be done right now, is to include a `DummyMain.cs` file, which gets around the error
message. But, that really doesn't feel like the intent of the original AspNetCore team.

```
namespace IEndpointRouteBuilderDemo
{
	public class DummyMain
	{
		public static void Main(string[] args)
		{
		}
	}
}
```

**So, how can `IEndpointRouteBuilder` be referenecd in a class library without needing a `DummyMain.cs`?**