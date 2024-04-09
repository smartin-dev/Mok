using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mok.WebAPI.Models;
using Mok.WebAPI.Repositories;

namespace Mok.WebAPI.Controllers
{

    /// <summary>
    /// Representa un controlador para gestionar libros.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public BookController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        /// <summary>
        /// Obtiene todos los libros.
        /// </summary>
        [HttpGet]
        [Route("/Books")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            try
            {
                var libros = await _bookRepo.GetAllAsync();
                return Ok(libros);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }

        /// <summary>
        /// Recupera un libro por su identificador único.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            try
            {
                var libro = await _bookRepo.GetByIdAsync(id);
                if (libro == null)
                    return NotFound();
                return libro;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
            
        }

        /// <summary>
        /// Crea un libro nuevo.
        /// </summary>
        /// <param name="libro">Los datos del nuevo libro a crear.</param>
        /// <returns>Un ActionResult que contiene el libro creado.</returns>
        [HttpPost]
        public async Task<ActionResult<Book>> Create(Book libro)
        {
            try
            {
                await _bookRepo.AddAsync(libro);
                return CreatedAtAction(nameof(GetById), new { libro });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");

            }

        }

        /// <summary>
        /// Actualiza un libro existente.
        /// </summary>
        /// <param name="id">El ID del libro que se desea actualizar.</param>
        /// <param name="libro">Los datos actualizados del libro.</param>
        /// <returns>Un IActionResult que indica el resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Book libro)
        {
            try
            {
                if (id != libro.Id)
                    return BadRequest();

                await _bookRepo.UpdateAsync(libro);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }

        /// <summary>
        /// Elimina un libro por su identificador único.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _bookRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }

}