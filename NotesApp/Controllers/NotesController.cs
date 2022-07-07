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
    private readonly ICategoryService _categoryService;
    private readonly IImageService _imageService;
    private readonly IUserService _userService;
    private readonly ILogger _logger;

    public NotesController(ILogger<NotesController> logger,
                           INoteService noteService,
                           ICategoryService categoryService,
                           IImageService imageService,
                           IUserService userService)
    {
        _logger = logger;
        _noteService = noteService;
        _categoryService = categoryService;
        _imageService = imageService;
        _userService = userService;
    }

    [Authorize]
    [HttpPost("addNote")]
    public ActionResult<Note> AddNote([FromForm] NoteDto noteDto)
    {
        var userId = _userService.GetUser(this.User.Identity.Name).Id;
        var category = _categoryService.GetCategory(noteDto.CategoryName);
        if (category == null)
        {
            category = _categoryService.AddCategory(new CategoryDto() {Name = noteDto.CategoryName});
        }
        var image = _imageService.ConvertImageUploadToObject(noteDto.Image);
        var result = _noteService.AddNote(noteDto, category, image, userId);
        if (result == null)
            return BadRequest();
        return Ok(result);
    }

    [Authorize]
    [HttpDelete("deleteNote/{id}")]
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

    [Authorize]
    [HttpGet("getNote/{noteId}")]
    public ActionResult<Note> GetNote(Guid noteId)
    {
        var result = _noteService.GetNote(noteId);
        if (result == null)
            return BadRequest();
        return Ok(result);
    }

    [Authorize]
    [HttpPost("uploadImage")]
    public ActionResult<Image> AddImage([FromForm] ImageDto imageRequest, Guid noteId)
    {
        Image result;

        // ditch the null checks
        var attachedImage = _noteService.GetNote(noteId).Image;
        if (attachedImage == null)
            result = _imageService.AddImage(imageRequest.Image, noteId);
        else
            result = _imageService.EditImage(imageRequest.Image, attachedImage);
        if (result == null)
            return BadRequest();
        return Ok();
    }

    [Authorize]
    [HttpDelete("deleteImage/{imageId}")]
    public ActionResult Note([FromQuery] Guid imageId)
    {
        if (!_imageService.RemoveImage(imageId))
            return BadRequest("Image could not be deleted");
        return Ok("Image deleted successfully");
    }
}