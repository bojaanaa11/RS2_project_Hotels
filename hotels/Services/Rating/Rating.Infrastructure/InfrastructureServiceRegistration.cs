using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rating.Application.Contracts.Factories;
using Rating.Application.Contracts.Infrastructure;
using Rating.Application.Contracts.Persistence;
using Rating.Application.Features.Ratings.Queries.ViewModels;
using Rating.Application.Models;
using Rating.Infrastructure.Factories;
using Rating.Infrastructure.Mail;
using Rating.Infrastructure.Persistence.EntityConfigurations;
using Rating.Infrastructure.Repositories;
using Rating.Infrastructure.Persistence;

namespace Rating.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RatingContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("RatingConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IRatingProcessRepository, RatingProcessRepository>();

            //services.AddScoped<IHotelRatingCollectionFactory, HotelRatingCollectionFactory>();
            //services.AddScoped<IHotelRatingCollectionViewModelFactory, HotelRatingCollectionViewModelFactory>();
            services.AddScoped<IHotelReviewFactory,HotelReviewFactory>();
            services.AddScoped<IHotelReviewViewModelFactory,HotelReviewViewModelFactory>();
            services.AddScoped<IRatingProcessFactory, RatingProcessFactory>();
            services.AddScoped<IRatingProcessViewModelFactory, RatingProcessViewModelFactory>();
            
            services.Configure<EmailSettings>(c =>
            {
                var config = configuration.GetSection("EmailSettings");
                c.Mail = config["Mail"];
                c.DisplayName = config["DisplayName"];
                c.Password = config["Password"];
                c.Host = config["Host"];
                c.Port = int.Parse(config["Port"]);
            });
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}