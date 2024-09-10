using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkAhead.Business.Interfaces;
using ParkAhead.Business.Services;
using ParkAhead.Data;
using ParkAhead.Data.Entity;
using ParkAhead.Data.Repository;

var host = new HostBuilder()
	.ConfigureFunctionsWebApplication()
	.ConfigureServices(services =>
	{
		services.AddScoped<IReservationService, ReservationService>();
		services.AddScoped<IParkingSpotService, ParkingSpotService>();

		services.AddScoped<IRepository<Reservation>, Repository<Reservation>>();	
		services.AddScoped<IRepository<ParkingSpot>, Repository<ParkingSpot>>();	
		services.AddScoped<IRepository<User>, Repository<User>>();

		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		IConfigurationRoot configuration = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json")
			.Build();

		Console.WriteLine(configuration.GetConnectionString("DefaultConnection"));

		services.AddDbContext<ParkAheadDbContext>(options =>
		{
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
		});

        services.AddApplicationInsightsTelemetryWorkerService();
		services.ConfigureFunctionsApplicationInsights();
	})
	.Build();

host.Run();
