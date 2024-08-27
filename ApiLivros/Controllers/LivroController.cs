using ApiLivros.Data;
using ApiLivros.Models;
using ApiLivros.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiLivros.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LivroController : ControllerBase
    {
        [HttpGet]
        [Route("livros")]
        public async Task<IActionResult> GetLivros([FromServices]ApplicationDbContext _context)
        {
            var livros = await _context.Livros.AsNoTracking().ToListAsync();
            return Ok(livros);
        }

        [HttpGet]
        [Route("livros/{id}")]
        public async Task<IActionResult> GetLivroById([FromServices]ApplicationDbContext _context, [FromRoute]int id)
        {
            var livro = await _context.Livros.AsNoTracking().FirstOrDefaultAsync(x => x.id == id);
            return livro == null ? NotFound() : Ok(livro);
        }

        [HttpPost("livros")]
        public async Task<IActionResult> CreateLivro([FromServices]ApplicationDbContext _context, [FromBody]LivroModel novoLivro)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var livro = new LivroModel
            {
                titulo = novoLivro.titulo,
                genero = novoLivro.genero,
                avaliacao = novoLivro.avaliacao
            };

            try
            {
                await _context.Livros.AddAsync(livro);
                await _context.SaveChangesAsync();
                return Created($"v1/livros/{livro.id}", livro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("livros/{id}")]
        public async Task<IActionResult> UpdateLivro([FromServices]ApplicationDbContext _context, [FromBody]CreateLivroViewModel livroEditado, [FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var livro = await _context.Livros.FirstOrDefaultAsync(x => x.id == id);

            if (livro == null)
                return NotFound();

            try
            {
                livro.titulo = livroEditado.titulo;
                livro.genero = livroEditado.genero;
                livro.avaliacao = livroEditado.avaliacao;

                _context.Livros.Update(livro);
                await _context.SaveChangesAsync();
                return Ok(livro);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("livros/{id}")]
        public async Task<IActionResult> DeleteLivro([FromServices]ApplicationDbContext _context, [FromRoute]int id)
        {
            var livro = _context.Livros.FirstOrDefault(x => x.id == id);

            if (livro == null)
                return NotFound();

            try
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
