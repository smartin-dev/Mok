using Mok.WebAPI.Models;

namespace Mok.WebAPI.Repositories
{
    /// <summary>
    /// Representa una interfaz de repositorio para gestionar libros.
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Obtiene todos los libros de forma asíncrona.
        /// </summary>
        Task<IEnumerable<Book>> GetAllAsync();

        /// <summary>
        /// Obtiene un libro por su identificador único de forma asíncrona.
        /// </summary>
        Task<Book> GetByIdAsync(int id);

        /// <summary>
        /// Agrega un nuevo libro de forma asíncrona.
        /// </summary>
        Task AddAsync(Book book);

        /// <summary>
        /// Actualiza un libro existente de forma asíncrona.
        /// </summary>
        Task UpdateAsync(Book book);

        /// <summary>
        /// Elimina un libro por su identificador único de forma asíncrona.
        /// </summary>
        Task DeleteAsync(int id);

    }
}
