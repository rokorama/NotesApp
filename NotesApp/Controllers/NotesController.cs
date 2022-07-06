using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Authentication;
using NotesApp.Models;
using NotesAppBusinessLogic;

namespace NotesApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly INoteService _noteService;
    private readonly IUserService _userService;
    private readonly ILogger _logger;

    public NotesController(ILogger<NotesController> logger, INoteService noteService, IUserService userService)
    {
        _logger = logger;
        _noteService = noteService;
        _userService = userService;
    }

    [Authorize]
    [HttpPost("addNote")]
    public ActionResult<Note> AddNote([FromBody] NoteDto noteDto)
    {
        var userId = _userService.GetUser(this.User.Identity.Name).Id;
        var result = _noteService.AddNote(noteDto, userId);
        if (result == null)
            return BadRequest();
        return Ok(result);
    }

    [Authorize]
    [HttpDelete("deleteNote")]
    public ActionResult<bool> RemoveNote(Guid id)
    {
        if (!_noteService.RemoveNote(id))
            return BadRequest();
        return Ok();
    }

    [Authorize]
    [HttpPut("editNote")]
    public ActionResult<bool> EditNote(Guid id, Note editedNote)
    {
        var result = _noteService.EditNote(id, editedNote);
        if (result == null)
            return BadRequest();
        return Ok();
    }
}