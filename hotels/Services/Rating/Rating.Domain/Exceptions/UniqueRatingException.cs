using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rating.Domain.Exceptions
{
    public class UniqueRatingException : Exception
    {
        public UniqueRatingException(){}

        public UniqueRatingException(string message): base(message){
        }
        public UniqueRatingException(string message, Exception innerException): base(message, innerException){
            
        }
    }
}