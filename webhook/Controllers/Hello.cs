using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webhook.Controllers
{
    public class Hello : ResponseHandler<HelloRequest, HelloResponse>
    {
        public async override Task<HelloResponse> Handle(HelloRequest request)
        {
            return new HelloResponse
            {
                Greeting = $"Hello, {request.Name}"
            };
        }
    }


    public class HelloRequest
    {
        public string  Name { get; set; }
    }

    public class HelloResponse
    {
        public string Greeting { get; set; }
    }



}
