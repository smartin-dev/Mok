## Ejecución local

1. Clona este repositorio en tu máquina local.
2. Abre el proyecto en tu entorno de desarrollo preferido (Visual Studio, Visual Studio Code, etc.).
3. Asegúrate de tener instalado .NET Core SDK en tu máquina.
4. Configura la conexión a la base de datos en el archivo de configuración de la aplicación (appsettings.json).
5. Ejecuta el comando `dotnet restore` para restaurar las dependencias del proyecto.
6. Ejecuta el comando `dotnet build` para compilar el proyecto.
7. Ejecuta el comando `dotnet ef database update` para crear la base de datos utilizando Code First.
8. Ejecuta el comando `dotnet run` para iniciar la aplicación.

## Autenticación

Para autenticarse y obtener un token JWT:

1. Envía una solicitud POST al endpoint `/login` con las credenciales de usuario (nombre de usuario y contraseña) en el cuerpo de la solicitud.
2. Recibirás un token JWT en la respuesta si las credenciales son válidas.

## Uso de los endpoints CRUD

Una vez que hayas obtenido el token JWT, puedes usarlo para acceder a los endpoints CRUD:

- Crea un libro: Envía una solicitud POST al endpoint `/api/books` con los datos del libro en el cuerpo de la solicitud y el token JWT en el encabezado de autorización.
- Lee un libro: Envía una solicitud GET al endpoint `/api/books/{id}` con el id del libro deseado en la URL y el token JWT en el encabezado de autorización.
- Actualiza un libro: Envía una solicitud PUT al endpoint `/api/books/{id}` con los datos actualizados del libro en el cuerpo de la solicitud, el id del libro en la URL y el token JWT en el encabezado de autorización.
- Elimina un libro: Envía una solicitud DELETE al endpoint `/api/books/{id}` con el id del libro a eliminar en la URL y el token JWT en el encabezado de autorización.
