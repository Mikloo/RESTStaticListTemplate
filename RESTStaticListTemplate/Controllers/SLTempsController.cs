using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RESTStaticListTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SLTempsController : ControllerBase
    {
        public static int nextId = 0;

        private static List<SLTemp> slTempsList = new List<SLTemp>()
        {
            new SLTemp("Mikail", "Fener"),
            new SLTemp("Sahime", "Fener")
        };

        // GET: api/SLTemps
        [HttpGet]
        public List<SLTemp> GetList()
        {
            return slTempsList;
        }

        // GET: api/SLTemps/5
        [HttpGet("{id}")]
        public SLTemp GetById(int id)
        {
            return slTempsList.SingleOrDefault(sltemp => sltemp.Id == id);
        }

        // POST: api/SLTemps
        [HttpPost]
        public HttpResponseMessage Post([FromBody] SLTemp value)
        {
            if (slTempsList.Contains(value))
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
            else
            {
                SLTemp addSlTemp = new SLTemp(value.FirstName, value.LastName);
                addSlTemp.Id = nextId + 1;
                slTempsList.Add(addSlTemp);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
        }

        // PUT: api/SLTemps/5
        [HttpPut("{id}")]
        public void PutSLTemp(int id, [FromBody] SLTemp value)
        {
            int index = slTempsList.FindIndex(sltemp => sltemp.Id == id);
            slTempsList[index] = value;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool DeleteSLTemp(int id)
        {
            return slTempsList.Remove(slTempsList.SingleOrDefault(sltemp => sltemp.Id == id));
        }
    }
}
