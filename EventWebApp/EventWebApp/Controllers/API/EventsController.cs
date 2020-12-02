using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EventWebApp.Data;

namespace EventWebApp.Controllers.API
{
    [ApiController]
    [Route("api")]
    public class EventsController : ControllerBase
    {
        private readonly EventDualAppContext _context;

        public EventsController(EventDualAppContext context)
        {
            _context = context;
        }

        [HttpGet("get/{id?}")]
        public ActionResult<string> get(int? id)
        {
            if (id == null)
            {
                return Ok(_context.Events.ToList());
            }

            var @event =  _context.Events
                .FirstOrDefault(m => m.ID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

    }

}
