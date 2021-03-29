using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webhook.Controllers
{
    public class BufferController : Controller
    {
        private IBuffer Buffer { get; set; }

        public BufferController(IBuffer buffer)
        {
            Buffer = buffer;
        }

        [HttpPost]
        [Route("raw/json")]
        public string JsonStringBody([FromBody] string content)
        {
            return content;
        }

        [HttpPost]
        [Route("buffer/{format}")]
        public async Task Raw(string format)
        {
            await ReadBytesFromBody(format);
        }

        [HttpPost]
        [Route("buffer/{format}/echo")]
        public async Task<string> Echo(string format)
        {
            return await ReadBytesFromBody(format);
        }

        public async Task<string> ReadBytesFromBody(string format)
        {
            StringBuilder body = new StringBuilder();

            if (format == "base64")
            {
                using (var ms = new MemoryStream(2048))
                {
                    await Request.Body.CopyToAsync(ms);
                    body.Append( Convert.ToBase64String(ms.ToArray()));
                }
            }
            else
            {
                try
                {
                    var encoding = Encoding.GetEncoding(format);
                    using (StreamReader reader = new StreamReader(Request.Body, encoding))
                    {
                        body.Append(await reader.ReadToEndAsync());
                    }                       
                }
                catch
                {
                    body.AppendLine($"{format} CONVERTER NOT FOUND!");
                    body.AppendLine();
                    body.AppendLine($"Use one of these:");
                    foreach(var e in Encoding.GetEncodings())
                    {
                        body.AppendLine($"{e.Name}");
                    }
                }
            }
            Buffer.Set(Request, body.ToString());
            return body.ToString();
        }

        [HttpGet]
        [Route("/")]
        public RedirectResult init()
        {
            Buffer.Set(null, null);
            return Redirect("/buffer");
        }

        [HttpGet]
        [Route("buffer")]
        public async Task<string> buffer()
        {
            StringBuilder builder = new StringBuilder();

            if (Buffer.HasData)
            {
                builder.AppendLine($"{Buffer.Method} {Buffer.Path}{Buffer.QueryString} {Buffer.Protocol}");

                foreach (KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues> header in Buffer.Headers)
                {
                    builder.AppendLine($"{header.Key}: {string.Join(" ", header.Value)}");
                }
                builder.AppendLine();

                builder.Append(Buffer.Body);
            }
            else 
            {
                builder.AppendLine("POST Request Analyzer");
                builder.AppendLine("---------------------");
                builder.AppendLine();
                builder.AppendLine("Refresh this page to see your latest post to:");
                builder.AppendLine();
                builder.AppendLine($"{Request.Scheme}://{Request.Host}/buffer/utf-8");              
                builder.AppendLine($"{Request.Scheme}://{Request.Host}/buffer/base64");
                builder.AppendLine($"{Request.Scheme}://{Request.Host}/buffer/  ... or any other valid format");               
                builder.AppendLine();
                builder.AppendLine("Append /echo to the url to get the buffer in the post response");
                builder.AppendLine($"{Request.Scheme}://{Request.Host}/buffer/utf-8/echo");
            }
            return builder.ToString();
        }
    }
    
}
