using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace CheckInOut.API.Context
{
    public interface ICheckInOutContext
    {
        NpgsqlConnection GetConnection();
    }
}