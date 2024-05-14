using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Application.Models;

namespace Rating.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email emailRequest);
    }
}