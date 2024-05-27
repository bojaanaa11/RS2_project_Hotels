using Reservations.Common.Data;
using Reservations.Common.Entities;
using Reservations.Common.Repositories;
using Reservations.GRPC.Protos;
using Reservations.GRPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddScoped<IReservationsContext, ReservationsContext>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddAutoMapper(configuration => {
    configuration.CreateMap<Reservation, GetReservationResponse.Types.Reservation>().ReverseMap();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<UsersReservationService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
