using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ErrorModels
{
    public class ValiditonErrorToReturn
    {
        public int StatusCode { get; set; }=(int)HttpStatusCode.BadRequest;
        public string Message { get; set; } = "Validition Failed"!;
        public IEnumerable<ValiditionError> validitionErrors { get; set; }
    }
}
