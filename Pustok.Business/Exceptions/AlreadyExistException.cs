using Pustok.Business.Abstactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Exceptions
{
    public class AlreadyExistException(string message = "This item is already exist") : Exception(message), IBaseException
    {
        public int StatusCode { get; set; } = 409;
    }
}
