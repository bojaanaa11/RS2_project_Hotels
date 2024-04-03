using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInOut.API.Exceptions
{
    public class DateException : Exception
    {
        public DateException(){}

        public DateException(string message): base(message){
        }
        public DateException(string message, Exception innerException): base(message, innerException){
            
        }
    }
}