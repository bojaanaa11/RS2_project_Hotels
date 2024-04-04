using CheckInOut.API.Context;
using CheckInOut.API.DTOs;
using CheckInOut.API.Entities;
using CheckInOut.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICheckInOutContext, CheckInOutContext>();
builder.Services.AddScoped<ICheckInOutRepository, CheckInOutRepository>();

builder.Services.AddAutoMapper(configuration =>
        {
            configuration.CreateMap<HotelStayDTO, HotelStay>().ReverseMap();
        });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
