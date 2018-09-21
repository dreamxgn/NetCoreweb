using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceC.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
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

        [HttpGet]
        [Route("getdata")]
        public string getdata()
        {
            return "getdata......";
        }

        [HttpGet]
        [Route("waring")]
        public void SendWaring()
        {
            string file = "d:\\error.log";

            System.IO.File.AppendAllText(file, String.Format("Error: {0}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

        }

        /// <summary>
        /// Service健康检查
        /// </summary>
        /// <returns></returns>
        [Route("health")]
        public IActionResult Health()
        {
            return Ok();
        }
    }
}
