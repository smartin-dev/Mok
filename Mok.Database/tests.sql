-- Caso de prueba 1: Inserción de un nuevo libro ("El Quijote")
EXEC sp_InsertBook 'Don Quijote de la Mancha', 'Miguel de Cervantes', 'Novela', '1605-01-01';

-- Caso de prueba 2: Obtener el libro recién insertado por su ID
EXEC sp_GetBookById 1;

-- Caso de prueba 3: Obtener todos los libros
EXEC sp_GetAllBooks;

-- Caso de prueba 4: Actualizar la información del libro recién insertado
EXEC sp_UpdateBook 1, 'Don Quijote de la Mancha', 'Miguel de Cervantes Saavedra', 'Novela clásica', '1605-01-01';

-- Caso de prueba 5: Obtener el libro actualizado por su ID
EXEC sp_GetBookById 1;

-- Caso de prueba 6: Eliminar el libro recién insertado por su ID
EXEC sp_DeleteBook 1;

-- Caso de prueba 7: Intentar obtener el libro eliminado
EXEC sp_GetBookById 1;

-- Caso de prueba 8: Intentar actualizar el libro eliminado
EXEC sp_UpdateBook 1, 'Don Quijote de la Mancha', 'Miguel de Cervantes', 'Novela', '1605-01-01';

-- Caso de prueba 9: Intentar eliminar un libro inexistente
EXEC sp_DeleteBook 999;
