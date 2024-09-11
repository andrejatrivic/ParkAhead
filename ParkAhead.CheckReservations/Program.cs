using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkAhead.Business.Interfaces;
using ParkAhead.Business.Services;
using ParkAhead.Data.Entity;
using ParkAhead.Data.Repository;

var host = new HostBuilder()
	.ConfigureFunctionsWebApplication()
	.ConfigureServices(services =>
	{
		services.AddHttpClient();

		services.AddScoped<IReservationService, ReservationService>();
		services.AddScoped<IParkingSpotService, ParkingSpotService>();

		services.AddScoped<IRepository<Reservation>, Repository<Reservation>>();
		services.AddScoped<IRepository<ParkingSpot>, Repository<ParkingSpot>>();
		services.AddScoped<IRepository<User>, Repository<User>>();

		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		services.AddApplicationInsightsTelemetryWorkerService();
		services.ConfigureFunctionsApplicationInsights();
	})
	.Build();

host.Run();
