using System.Reflection;
using Rating.Infrastructure;
using Rating.Application;
using Rating_API.Extensions;
using Rating.Infrastructure.Persistence;
using Rating.Infrastructure.Persistence.EntityConfigurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.MigrateDatabase<RatingContext>((context, services) =>
{
    var logger = services.GetRequiredService<ILogger<RatingContextSeed>>();
    RatingContextSeed.SeedAsync(context, logger).Wait();
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
