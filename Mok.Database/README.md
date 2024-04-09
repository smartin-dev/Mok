# Prueba Base de Datos: Gestión de Libros

## Instrucciones Generales:

Este proyecto se centra en el desarrollo de una base de datos en SQL Server para gestionar información sobre libros. Debe implementarse un conjunto de procedimientos almacenados que faciliten las operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en la tabla de libros.

## Requerimientos:

### Diseño de la Base de Datos:

Es necesario tener una base de datos creada donde se crearán las tablas. Se ha diseñado una tabla llamada Books con los siguientes campos:

- **BookId** (int, clave primaria, autoincremental)
- **Title** (varchar)
- **Author** (varchar)
- **Genre** (varchar)
- **PublishDate** (date)

### Procedimientos Almacenados:

Se han creado procedimientos almacenados para realizar las operaciones CRUD en la tabla de libros:

- **sp_InsertBook**: Inserta un nuevo libro.
- **sp_GetBookById**: Obtiene un libro por su ID.
- **sp_GetAllBooks**: Obtiene todos los libros.
- **sp_UpdateBook**: Actualiza la información de un libro.
- **sp_DeleteBook**: Elimina un libro por su ID.

## Pruebas:

Se proporciona un script de prueba que demuestra el correcto funcionamiento de cada procedimiento almacenado. Se incluyen casos de prueba para situaciones como inserción de un nuevo libro, obtención de libros, actualización de información y eliminación de libros.

## Documentación:

Se han incluido comentarios en el script SQL para explicar el propósito de cada procedimiento almacenado y la estructura de la base de datos.
