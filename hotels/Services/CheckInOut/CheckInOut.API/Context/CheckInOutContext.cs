using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace CheckInOut.API.Context
{
    public class CheckInOutContext : ICheckInOutContext
    {
        private readonly IConfiguration _configuration;

        public CheckInOutContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        }
    }
}