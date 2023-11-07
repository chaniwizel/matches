using Matches.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Matches.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        static private List<PlaceMeeting> places = new List<PlaceMeeting>() { new PlaceMeeting { isActive = true, namePlace = "event", description = "gukishdgi" } };
        // GET: api/<PlaceController>
        [HttpGet]
        public IEnumerable<PlaceMeeting> Get()
        {
            return places;
        }

        // GET api/<PlaceController>/5
        [HttpGet("{id}")]
        public PlaceMeeting Get(string id)
        {
            for (int i = 0; i < places.Count; i++)
            {
                if (places[i].namePlace == id)
                {
                    return places[i];
                }
            }
            Response.StatusCode = 404;
            return new PlaceMeeting();
        }

        // POST api/<PlaceController>
        [HttpPost]
        public void Post([FromBody] PlaceMeeting value)
        {
            places.Add(new PlaceMeeting { isActive = value.isActive, namePlace = value.namePlace,description=value.description });
        }

        // PUT api/<PlaceController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] PlaceMeeting value)
        {
            var place = places.Find(place => place.namePlace ==id );
            place.description=value.description;
            place.isActive = value.isActive;
            
        }

        // DELETE api/<PlaceController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var place = places.Find(place => place.namePlace == id);
            places.Remove(place);
        }
    }
}
