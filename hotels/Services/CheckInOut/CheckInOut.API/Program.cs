using System.Reflection;
using CheckInOut.API.Context;
using CheckInOut.API.DTOs;
using CheckInOut.API.Entities;
using CheckInOut.API.Extensions;
using CheckInOut.API.Repositories;
using MassTransit;
using Rating_API.GrpcService;
using Reservations.GRPC.Protos;
using Common.EventBus.Messages.Constants;
using Common.EventBus.Messages.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICheckInOutContext, CheckInOutContext>();
builder.Services.AddScoped<ICheckInOutRepository, CheckInOutRepository>();

builder.Services.AddAutoMapper(configuration =>
        {
            configuration.CreateMap<HotelStayDTO, HotelStay>().ReverseMap();
        });

builder.Services.AddGrpcClient<UsersReservationProtoService.UsersReservationProtoServiceClient>(
        o => o.Address = new Uri(builder.Configuration["GrpcSettings:UserReservationsUrl"])
    );
builder.Services.AddScoped<UsersReservationsGrpcService>();

// EventBus
builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((_, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        cfg.Publish<GuestCheckoutEvent>(p =>
        {
            p.ExchangeType = EventBusConstants.guestcheckout_exchangename;
        });
    });
});

builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => 
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
