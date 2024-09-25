using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TO_DO_List_API.Data;
using TO_DO_List_API.Data.Models;

namespace TO_DO_List_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;
        private readonly ApplicationDbContext _context;

        public TasksController(ILogger<TasksController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            var notes = await _context.Notes.ToListAsync();

            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);

            return note != null ? Ok(note) : NotFound();
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateNote(string text)
        //{
        //    var note = new Note(text);
        //    _context.Notes.Add(note);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetNoteById), new { id = note.Id }, note);
        //}

    }
}
