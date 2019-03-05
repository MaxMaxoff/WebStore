using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.ServiceHosting.Controllers
{
    /// <summary>
    /// API Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// HTTP Get
        /// </summary>
        /// <returns>api/values</returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// HTTP Get by ID
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>api/value</returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// HTTP Post
        /// </summary>
        /// <param name="value">api/values</param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// HTTP Post by ID
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="value">api/value</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// HTTP Delete by ID
        /// </summary>
        /// <param name="id">id</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
