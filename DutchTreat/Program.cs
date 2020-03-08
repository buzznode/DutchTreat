using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace DutchTreat
{
	public class Program
	{
		//public static void Main( string[] args )
		//{
		//	CreateHostBuilder( args ).Build().Run();
		//}

		//public static IHostBuilder CreateHostBuilder( string[] args ) =>
		//	Host.CreateDefaultBuilder( args )
		//		.ConfigureWebHostDefaults( webBuilder =>
		//		 {
		//			 webBuilder.UseStartup<Startup>();
		//		 } );

		public static void Main( string[] args )
		{
			BuildWebHost( args ).Run();
		}

		public static IWebHost BuildWebHost( string[] args ) =>
			WebHost.CreateDefaultBuilder( args )
				.ConfigureAppConfiguration(SetupConfiguration)
				.UseStartup<Startup>()
				.Build();

		private static void SetupConfiguration( WebHostBuilderContext ctx, IConfigurationBuilder builder )
		{
			// Remove the default configuration options
			builder.Sources.Clear();
			builder.AddJsonFile( "appSettings.json", false, true )
				.AddEnvironmentVariables();
		}
	}
}
