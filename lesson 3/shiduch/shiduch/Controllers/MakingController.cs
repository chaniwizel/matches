using Matches.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Matches.Controllers
{
  
    
    [Route("api/[controller]")]
    [ApiController]
    public class MakingController : ControllerBase
    {
        static private List<MatchMaking> making = new List<MatchMaking>() { new MatchMaking { firstName = "shoshi", lastName = "chen", email = "fg@vbn", phone = "05285485",status=Status.widow, age = 19, id = 1 } };
        // GET: api/<MakingController>
        [HttpGet]
        public IEnumerable<MatchMaking> Get()
        {
            return making;
        }

        // GET api/<MakingController>/5
        [HttpGet("{id}")]
        public MatchMaking Get(int id)
        {
            for (int i = 0; i < making.Count; i++)
            {
                if (making[i].id == id)
                {
                    return making[i];
                }
            }
            Response.StatusCode = 404;
            return new MatchMaking();
        }

        // POST api/<MakingController>
        [HttpPost]
        public void Post([FromBody] MatchMaking value)
        {
            making.Add(new MatchMaking { firstName = value.firstName, lastName = value.lastName, email = value.email, phone = value.phone,age =value.age, status = value.status,id=value.id});

        }

        // PUT api/<MakingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MatchMaking value)
        {
            var make = making.Find(make => make.id == id);
            make.phone = value.phone;
            make.firstName = value.firstName;
            make.lastName = value.lastName;
            make.email = value.email;
            make.status = value.status;
            make.age = value.age;
        }

        // DELETE api/<MakingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var make = making.Find(match => match.id == id);
            making.Remove(make);
        }
    }
}
