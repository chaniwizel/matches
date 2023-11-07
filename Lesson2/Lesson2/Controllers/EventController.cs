using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        static int count = 2;
        static private List<Event> events = new List<Event>() { new Event { Id = 1, Title = "first event", Start = new DateTime(2023, 09, 05), End = new DateTime(2023, 09, 07) } };
        // GET: api/<EventController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

        // GET api/<EventController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] Event value)
        {
            events.Add(new Event { Id=count++,Title="goodLack",Start=value.Start,End=value.End});
        }
        //events.Add(new Event { Id=value.Id,Title=value.Title,Start=value.Start,End=value.End//});
    
        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event value)
        {
            var evn = events.Find(e => e.Id == id);
            evn.Title = value.Title;
            evn.Start = value.Start;
            evn.End = value.End;
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ev = events.Find(e => e.Id == id);
            events.Remove(ev);
        }
    }
}
