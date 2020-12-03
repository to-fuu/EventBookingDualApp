using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventBookWeb.Models;
using EventWebApp.Data;

namespace EventWebApp.Controllers.API
{
    [ApiController]
    [Route("api/events")]
    public class APIEventsController : ControllerBase
    {
        private readonly EventDualAppContext _context;

        public APIEventsController(EventDualAppContext context)
        {
            _context = context;
        }

        [HttpGet("get/{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return Ok(await _context.Events.ToListAsync());
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Event>> Create([FromBody] Event @event)
        {
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(@event.EventName), new { id = @event.ID }, @event);
        }

        [HttpPost("edit/{id?}")]
        public async Task<ActionResult<Event>> Edit(int id, [FromBody] Event @event)
        {

          
            if (!EventExists(id))
            {
                return NotFound();
            }

            @event.ID = id;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                    return Ok(nameof(@event.EventName) + "Updated");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return NotFound();

        }

        [HttpPost("delete/{id?}")]
        public async Task<ActionResult<Event>> Delete(int? id)
        {

            var @event = await _context.Events.FindAsync(id);

            if (!EventExists(@event.ID))
            {
                return NotFound();
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }

        [HttpPost("clearAll")]
        public async Task<ActionResult<Event>> Clear(int? id)
        {

            var @eventAll = _context.Events; 

            _context.RemoveRange(@eventAll);
            await _context.SaveChangesAsync();
            return Ok("Cleared");
        }



        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.ID == id);
        }

    }


}
