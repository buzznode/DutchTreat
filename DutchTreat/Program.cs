using DutchTreat.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DutchTreat
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = BuildWebHost(args);

			RunSeeding(host);
			host.Run();
			BuildWebHost(args).Run();
		}

		private static void RunSeeding(IWebHost host)
		{
			var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

			using (var scope = scopeFactory.CreateScope())
			{
				var seeder = scope.ServiceProvider.GetService<DutchSeeder>();
				seeder.SeedAsync().Wait();
			}
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration(SetupConfiguration)
				.UseStartup<Startup>()
				.Build();

		private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
		{
			// Remove the default configuration options
			builder.Sources.Clear();
			builder.AddJsonFile("appSettings.json", false, true)
				.AddEnvironmentVariables();
		}
	}
}
