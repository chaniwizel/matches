using Matches.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Matches.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class MakerController : ControllerBase
    {
        static int x = 2;
        static private List<MatchMaker> makers = new List<MatchMaker>() { new MatchMaker { firstName = "chani", lastName = "wizel", email ="chani05480@gmail.com", phone = "0548542080", id=1 } };
        // GET: api/<MakerController>
        [HttpGet]
        public IEnumerable<MatchMaker> Get()
        {
            return makers;
        }

        // GET api/<MakerController>/5
        [HttpGet("{id}")]
        public MatchMaker Get(int id)
        {
            for (int i = 0; i < makers.Count; i++)
            {
                if (makers[i].id==id)
                {
                    return makers[i];
                }
            }
            Response.StatusCode = 404;
            return new MatchMaker();
        }

        // POST api/<MakerController>
        [HttpPost]
        public void Post([FromBody] MatchMaker value)
        {
            makers.Add(new MatchMaker{firstName=value.firstName, lastName = value.lastName, email = value.email, phone = value.phone, id = x++ });
        }

        // PUT api/<MakerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MatchMaker value)
        {
            var match = makers.Find(match => match.id == id);
            match.phone = value.phone;
            match.firstName = value.firstName;
            match.lastName = value.lastName;
            match.email = value.email;
            
        }

        // DELETE api/<MakerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var match = makers.Find(match => match.id == id);
            makers.Remove(match);
        }
    }
}
