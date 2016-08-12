using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Jose;
using System.Text;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace aspnetcore_jwt_poc.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post()
        {
            var payload = new Dictionary<string, object>()
            {
                { "sub", "123456" },
                { "exp", 1502554610 },
                { "iss", "http://www.example.com" },
                { "aud", "committee"}
            };

            byte[] secretKey = Encoding.ASCII.GetBytes("r9VjvvJz4BYpDwcPXebs4DfJdLeGY5Xg");
            string SsecretKey = Encoding.ASCII.GetString(secretKey);
            string token = Jose.JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);

            return Ok(token);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
