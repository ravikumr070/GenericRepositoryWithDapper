using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Country;

namespace GenericRepositoryWithDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryService _icountry;

        public CountryController(ICountryService icountry)
        {
            _icountry = _=icountry;
        }
        // GET: api/Country
        [HttpGet]
        public async Task<IEnumerable<Country>> Get()
        {
            var res = await _icountry.GetAllAsync();
            return res;
        }

        // GET: api/Country/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Country> Get(int id)
        {
            var res = await _icountry.FindAsync(id);
            return res;
        }

        // POST: api/Country
        [HttpPost]
        public void Post([FromBody] Country value)
        {
            value.CreateDate = System.DateTime.Now;
            value.IsActive = true;
            value.IsClosed = false;
            _icountry.InsertAsync(value);
         
        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
