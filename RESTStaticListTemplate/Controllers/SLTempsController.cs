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
            // SingleOrDefault = Returnerne et enkelt element eller null hvis der ikke er nogle element 
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
            // FindIndex Finder den ønskende element der passer den kriterie man har sat 
            int index = slTempsList.FindIndex(sltemp => sltemp.Id == id);
            // Ersatter element med det man ønsker 
            slTempsList[index] = value;

            //Delete and insert new customer with the old ID
            //The position in the list is changed to the be the last one
            //Customer oldCustomer = DeleteCustomer(id);
            //if (oldCustomer != null)
            //{
            //    customer.ID = oldCustomer.ID;
            //    cList.Add(customer);
            //}
            //return GetCustomer(id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool DeleteSLTemp(int id)
        {
            // SingleOrDefault = Returnerne et enkelt element eller null hvis der ikke er nogle element 
            return slTempsList.Remove(slTempsList.SingleOrDefault(sltemp => sltemp.Id == id));
        }
    }
}
