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
    [Route("api")]
    public class EventsController : ControllerBase
    {
        private readonly EventDualAppContext _context;

        public EventsController(EventDualAppContext context)
        {
            _context = context;
        }

        [HttpGet("get/{id?}")]
        public async Task<IActionResult> get(int? id)
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

    }

}
