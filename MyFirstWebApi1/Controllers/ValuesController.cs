using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // controller class for values
    // must be marked as public to be accessed by the web
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        // *** curly braces denote a route parameter
        // we pull api/values from above and then id below
        // if it's coming in dynamically, it needs the curly braces
        // no curly braces is static text within the url
        // curly braces means dynamic, user input
        // front end is the user of the API
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 1000)
            {
                return NotFound("You suck at life.");
            }

            return Ok(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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