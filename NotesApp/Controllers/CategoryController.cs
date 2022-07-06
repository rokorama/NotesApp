using Microsoft.AspNetCore.Mvc;
using NotesApp.Models;
using NotesAppBusinessLogic;

namespace NotesApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly INoteService _noteService;
    private readonly ILogger _logger;

    public CategoryController(ILogger<NotesController> logger, INoteService noteService)
    {
        _logger = logger;
        _noteService = noteService;
    }

    [HttpPost("addCategory")]
    public ActionResult<Note> AddNote([FromBody] CategoryDto categoryDto)
    {
        var result = _noteService.AddCategory(categoryDto);
        if (result == null)
            return BadRequest();
        return Ok(result);
    }

    [HttpPut("editCategory")]
    public ActionResult<bool> EditCategory(Guid id, string editedName)
    {
        var result = _noteService.EditCategory(id, editedName);
        if (result == null)
            return BadRequest();
        return Ok();
    }

    [HttpDelete("deleteCategory")]
    public ActionResult<bool> RemoveCategory(Guid id)
    {
        if (!_noteService.RemoveCategory(id))
            return BadRequest();
        return Ok();
    }
}