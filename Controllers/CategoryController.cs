using Loja.Data;
using Loja.Models;
using Loja.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loja.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [Authorize(Roles = "adm")]
        [HttpPost("category")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] CategoryCreateViewModel model)
        {
            try
            {
                var newCategory = new Category
                {
                    Name = model.Name
                };

                await context.Categories.AddAsync(newCategory);
                await context.SaveChangesAsync();

                return Created($"category/{newCategory.Id}", newCategory);
            }
            catch
            {
                return StatusCode(500, new
                {
                    message = "Erro interno no servidor"
                });
            }
        }

        [Authorize(Roles = "adm")]
        [HttpGet("category")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context)
        {
            try
            {
                var categories = await context.Categories.ToListAsync();

                return Ok(categories);
            }
            catch
            {
                return StatusCode(500, new {message = "Erro no servidor"});
            }            
        }

        [Authorize(Roles = "adm")]
        [HttpPut("category/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromBody] CategoryUpdateViewModel model,
            [FromRoute] int id)
        {
            try
            {
                var category = await context.Categories.FindAsync(id);

                if (category == null)
                    return BadRequest(new { message = "Categoria não existe" });

                category.Name = model.Name; 

                await context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return StatusCode(500, new { message = "Erro no servidor" });
            }
        }

        [Authorize(Roles = "adm")]
        [HttpDelete("category/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,            
            [FromRoute] int id)
        {
            try
            {
                var category = await context.Categories.FindAsync(id);

                if (category == null)
                    return BadRequest(new { message = "Categoria não existe" });

                context.Categories.Remove(category);

                await context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return StatusCode(500, new { message = "Erro no servidor" });
            }
        }
    }
}
