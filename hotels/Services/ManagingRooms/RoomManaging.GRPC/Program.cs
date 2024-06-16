using RoomManaging.Common.Repositories;
using RoomManaging.GRPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddScoped<IRoomManagingRepository, RoomManagingRepository>();
builder.Services.AddStackExchangeRedisCache(
    opt =>
    {
        opt.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<HotelsRoomsService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
