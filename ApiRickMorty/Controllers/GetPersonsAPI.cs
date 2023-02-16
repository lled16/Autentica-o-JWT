using ApiRickMorty.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRickMorty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
   
    public class GetPersonsAPI
    {
        public IPersons _persons;

        public GetPersonsAPI(IPersons persons)
        {
            _persons = persons;
        }

        [HttpGet(Name = "GetPersons")]
        [Authorize]
        public string Persons()
        {
            var persons = _persons.getPersons();


            return persons;
        }
    }
}
