using Microsoft.AspNetCore.Mvc;
using NotesApp.Models;
using NotesAppBusinessLogic;

namespace NotesApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly ILogger _logger;

    public CategoryController(ILogger<NotesController> logger, ICategoryService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService;
    }

    [HttpPost("addCategory")]
    public ActionResult<Note> AddCategory([FromBody] CategoryDto categoryDto)
    {
        var result = _categoryService.AddCategory(categoryDto);
        if (result == null)
            return BadRequest();
        return Ok(result);
    }

    [HttpPut("editCategory")]
    public ActionResult<bool> EditCategory(Guid id, string editedName)
    {
        var result = _categoryService.EditCategory(id, editedName);
        if (result == null)
            return BadRequest();
        return Ok();
    }

    [HttpDelete("deleteCategory/{id}")]
    public ActionResult<bool> RemoveCategory(Guid id)
    {
        if (!_categoryService.RemoveCategory(id))
            return BadRequest($"Category could not be removed.");
        return Ok($"Category successfully removed.");
    }
}