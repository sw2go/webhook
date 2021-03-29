using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webhook.Controllers
{
    public class Text : ResponseHandler<string, string>
    {
        public async override Task<string> Handle(string request)
        {
            return "OK";
        }
    }


}
