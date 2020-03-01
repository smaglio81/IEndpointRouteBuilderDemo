using System;
using Microsoft.AspNetCore.Routing;

namespace IEndpointRouteBuilderDemo
{
	public static class IEndpointRouteBuilderExtensions
	{

		public static IEndpointRouteBuilder MapSaHealthChecks(this IEndpointRouteBuilder endpoints)
		{
			// do stuff

			return endpoints;
		}
	}
}
