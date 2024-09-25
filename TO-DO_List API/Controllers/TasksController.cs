using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost("{text}")]
        public async Task<IActionResult> CreateNote(string text)
        {
            var note = new Note(text);
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNote), new { id = note.Id }, note);
        }

        [HttpPost]
        public async Task<IActionResult> UploadList(List<Note> notes)
        {
            //_context.Database.ExecuteSqlRaw("TRUNCATE TABLE notes RESTART IDENTITY;");
            _context.Notes.RemoveRange(_context.Notes);

            _context.Notes.AddRange(notes);
            await _context.SaveChangesAsync();
            return Ok(notes);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> CheckNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);

            if (note == null)
            {
                return BadRequest();
            }
            
            note.IsCompleted = !note.IsCompleted;

            _context.SaveChanges();

            return Ok(note);
        }

        [HttpPut("{id}/{text}")]
        public async Task<IActionResult> ChangeNoteText(int id, string text)
        {
            var note = await _context.Notes.FindAsync(id);

            if (note == null || text == null)
            {
                return BadRequest();
            }

            note.Text = text;
            _context.SaveChanges();

            return Ok(note);
        }
    }
}
