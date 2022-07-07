using System;
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
    public ActionResult<Note> AddNote([FromForm] NoteDto noteDto)
    {
        var userId = _userService.GetUser(this.User.Identity.Name).Id;
        var category = _noteService.GetCategory(noteDto.CategoryName);
        if (category == null)
        {
            category = _noteService.AddCategory(new CategoryDto() {Name = noteDto.CategoryName});
        }
        var image = _noteService.ConvertImageUploadToObject(noteDto.Image);
        var result = _noteService.AddNote(noteDto, category, image, userId);
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

    [Authorize]
    [HttpGet("getNotes")]
    public ActionResult<ICollection<Note>> GetNotes()
    {
        var userId = _userService.GetUser(this.User.Identity.Name).Id;
        var result = _noteService.GetNotes(userId);
        if (result == null)
            return BadRequest();
        return Ok(result);
    }

    [HttpPost("uploadImage")]
    public ActionResult AddImage([FromForm] ImageDto imageRequest)
    {
        using var memoryStream = new MemoryStream();
        imageRequest.Image.CopyTo(memoryStream);
        var imageBytes = memoryStream.ToArray();
        var entry = new Image()
        {
            Data = imageBytes,
            ContentType = imageRequest.Image.ContentType
        };
        var result = _noteService.AddImage(entry);
        if (result == null)
            return BadRequest();
        return Ok();
    }
}