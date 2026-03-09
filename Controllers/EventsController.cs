using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventifyAPI.Data;
using EventifyAPI.Models;

namespace EventifyAPI.Controllers;

[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    private readonly EventifyDbContext _context;

    public EventsController(EventifyDbContext context)
    {
        _context = context;
    }

    // GET /api/events
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventItem>>> GetEvents()
    {
        var events = await _context.Events.ToListAsync();
        return Ok(events);
    }

    // GET /api/events/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<EventItem>> GetEvent(int id)
    {
        var eventItem = await _context.Events.FindAsync(id);
        if (eventItem == null)
        {
            return NotFound();
        }
        return Ok(eventItem);
    }

    // POST /api/events
    [HttpPost]
    public async Task<ActionResult<EventItem>> CreateEvent(EventItem eventItem)
    {
        _context.Events.Add(eventItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEvent), new { id = eventItem.Id }, eventItem);
    }

    // DELETE /api/events/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var eventItem = await _context.Events.FindAsync(id);
        if (eventItem == null)
        {
            return NotFound();
        }

        _context.Events.Remove(eventItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}