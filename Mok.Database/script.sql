-- Creación de tabla Books
CREATE TABLE Books (
    BookId INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Author VARCHAR(255) NOT NULL,
    Genre VARCHAR(255) NOT NULL,
    PublishDate DATE NOT NULL
);
GO

-- Procedimiento almacenado para insertar un nuevo libro
CREATE PROCEDURE sp_InsertBook
    @Title VARCHAR(255),
    @Author VARCHAR(255),
    @Genre VARCHAR(255),
    @PublishDate DATE
AS
BEGIN
    INSERT INTO Books (Title, Author, Genre, PublishDate)
    VALUES (@Title, @Author, @Genre, @PublishDate);
END;
GO

-- Procedimiento almacenado para obtener un libro por su ID
CREATE PROCEDURE sp_GetBookById
    @BookId INT
AS
BEGIN
    SELECT * FROM Books WHERE BookId = @BookId;
END;
GO

-- Procedimiento almacenado para obtener todos los libros
CREATE PROCEDURE sp_GetAllBooks
AS
BEGIN
    SELECT * FROM Books;
END;
GO

-- Procedimiento almacenado para actualizar la información de un libro
CREATE PROCEDURE sp_UpdateBook
    @BookId INT,
    @Title VARCHAR(255),
    @Author VARCHAR(255),
    @Genre VARCHAR(255),
    @PublishDate DATE
AS
BEGIN
    UPDATE Books
    SET Title = @Title, Author = @Author, Genre = @Genre, PublishDate = @PublishDate
    WHERE BookId = @BookId;
END;
GO

-- Procedimiento almacenado para eliminar un libro por su ID
CREATE PROCEDURE sp_DeleteBook
    @BookId INT
AS
BEGIN
    DELETE FROM Books WHERE BookId = @BookId;
END;
GO