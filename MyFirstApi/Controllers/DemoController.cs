using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        // GET: api/Demo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Demo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Demo
        [HttpPost]
        public string Post(object value)
        {
            return "Resource added";
        }

        // PUT: api/Demo/5
        [HttpPut("{id}")]
        public string Put(int id )
        {
            return "resource added";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Remove(int id)
        {
            return "resource deleted";
        }
    }
}
