using Microsoft.EntityFrameworkCore;
using ParkAhead.Business.Interfaces;
using ParkAhead.Business.Services;
using ParkAhead.Data;
using ParkAhead.Data.Entity;
using ParkAhead.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database

builder.Services.AddDbContext<ParkAheadDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#endregion

#region Repository

builder.Services.AddScoped<IRepository<Parking>, Repository<Parking>>();
builder.Services.AddScoped<IRepository<ParkingSpot>, Repository<ParkingSpot>>();
builder.Services.AddScoped<IRepository<ParkingSpotHistory>, Repository<ParkingSpotHistory>>();
builder.Services.AddScoped<IRepository<Reservation>, Repository<Reservation>>();
builder.Services.AddScoped<IRepository<Status>, Repository<Status>>();
builder.Services.AddScoped<IRepository<User>, Repository<User>>();

#endregion

#region AutoMapper

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion

#region Service

builder.Services.AddScoped<IParkingService, ParkingService>();	

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

#region Migrate

using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<ParkAheadDbContext>();
	db.Database.Migrate();
}

#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
