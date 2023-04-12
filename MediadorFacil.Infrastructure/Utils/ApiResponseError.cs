using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediadorFacil.Infrastructure.Utils
{
    public class ApiResponseError
    {
        public string ErrorMessage { get; private set; }
        public ApiResponseError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
