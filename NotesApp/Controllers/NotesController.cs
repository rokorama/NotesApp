using Microsoft.AspNetCore.Mvc;
using NotesApp.Models;
using NotesAppBusinessLogic;

namespace NotesApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly INoteService _noteService;
    private readonly ILogger _logger;

    public NotesController(ILogger<NotesController> logger, INoteService noteService)
    {
        _logger = logger;
        _noteService = noteService;
    }

    [HttpPost("addNote")]
    public ActionResult<Note> AddNote([FromBody] NoteDto noteDto)
    {
        var result = _noteService.AddNote(noteDto);
        if (result == null)
            return BadRequest();
        return Ok(result);
    }
}