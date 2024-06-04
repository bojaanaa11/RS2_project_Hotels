using System.Reflection;
using Common.EventBus.Messages.Constants;
using MassTransit;
using Rating_API.EventBusConsumers;
//using Rating_API.EventBusConsumers;
using Rating.Infrastructure;
using Rating.Application;
using Rating_API.Extensions;
using Rating.Infrastructure.Persistence;

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

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<GuestCheckoutConsumer>();
    config.AddMediator(med => med.AddConsumer(typeof(GuestCheckoutConsumer)));
    config.UsingRabbitMq((ctx, cfg) =>
    {
        
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        cfg.ReceiveEndpoint(EventBusConstants.guestcheckoutqueue, c =>
        {
            c.ConfigureConsumer<GuestCheckoutConsumer>(ctx);
        });
    });
    
});

builder.Services.ConfigureJWT(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
