-- Insertar un nuevo libro ("El Quijote")
EXEC sp_InsertBook 'Don Quijote de la Mancha', 'Miguel de Cervantes', 'Novela', '1605-01-01';

-- Obtener un libro por su ID 
EXEC sp_GetBookById 1;

-- Obtener todos los libros
EXEC sp_GetAllBooks;

-- Actualizar la información de un libro (suponiendo que el ID del libro a actualizar es 1)
EXEC sp_UpdateBook 1, 'Don Quijote de la Mancha', 'Miguel de Cervantes', 'Novela clásica', '1605-01-01';

-- Eliminar un libro por su ID 
EXEC sp_DeleteBook 1;