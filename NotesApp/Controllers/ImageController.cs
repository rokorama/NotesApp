using Microsoft.AspNetCore.Mvc;
using NotesApp.Models;
using NotesAppBusinessLogic;

namespace NotesApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    private readonly INoteService _noteService;
    private readonly ILogger _logger;

    public ImageController(ILogger<ImageController> logger, INoteService noteService)
    {
        _logger = logger;
        _noteService = noteService;
    }

    [HttpPost("addImage")]
    public ActionResult<Note> AddNote([FromBody] NoteDto noteDto)
    {
        var result = _noteService.AddImage(new Note(), new Image());
        if (result == null)
            return BadRequest();
        return Ok(result);
    }

    [HttpDelete("deleteImage")]
    public ActionResult<bool> RemoveNote(Guid id)
    {
        if (!_noteService.RemoveNote(id))
            return BadRequest();
        return Ok();
    }

    [HttpPut("editImage")]
    public ActionResult<bool> EditNote(Guid id)
    {
        if (!_noteService.RemoveNote(id))
            return BadRequest();
        return Ok();
    }
}