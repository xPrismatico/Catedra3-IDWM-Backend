# Catedra3-IDWM-Backend

# API para Gestión de Usuarios y Posts

Este proyecto corresponde a una API para la gestión de usuarios y posts, desarrollado como parte de la asignatura **Introducción al Desarrollo Web Móvil**.

---

## Requerimientos

- **[ASP.NET Core 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)**
- **[Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)**
- **[Postman](https://www.postman.com/downloads/)** para probar la API

---

## Clonar el Repositorio

Dentro de una carpeta en donde decidas alojar el proyecto, escribe "cmd" en la dirección de dicha carpeta.

Una vez abierta la consola en dicha dirección, escribe el comando para abrir Visual Studio Code:

```bash
code .
```

Clona el repositorio utilizando la Terminal de Visual Studio Code (CTRL + J) con el siguiente comando:

```bash
git clone https://github.com/xPrismatico/Catedra3-IDWM-Backend
```

---

## Restaurar el Proyecto

Ejecuta los siguientes comandos en la Terminal de Visual Studio Code (CTRL + J):

1. Navega a la carpeta del proyecto:

   ```bash
   cd Catedra3-IDWM-Backend
   ```

2. Restaura los paquetes de NuGet:

   ```bash
   dotnet restore
   ```

3. Asegúrate de agregar los paquetes necesarios:

   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.4
   dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.4
   dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.4
   dotnet add package DotNetEnv
   dotnet add package Bogus
   ```

---

## Ejecutar la Aplicación

Para iniciar la API, usa el siguiente comando:

```bash
dotnet run
```

Esto iniciará el servidor en la URL por defecto:

```
http://localhost:5015
```

Asegúrate de que este puerto esté disponible.

---

## Configurar la Base de Datos

El proyecto utiliza SQLite como base de datos. La configuración de la conexión ya está incluida en el archivo `Program.cs`:

```csharp
string connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") ?? "Data Source=database.db";
```

No se requiere ninguna configuración adicional. Al iniciar el proyecto, se generará automáticamente una base de datos local llamada `database.db`.

---

## Probar la API con Postman o Swagger

Puedes utilizar Postman o Swagger para interactuar con los endpoints de la API. A continuación se describen algunos endpoints principales:

### 1. Registro de Usuario

- **Método HTTP:** POST
- **URL:** `http://localhost:5015/api/auth/register`
- **Cuerpo de la Solicitud (Body):** JSON

#### Formato del Body:

```json
{
  "email": "correo@example.com",
  "password": "Password123"
}
```

#### Ejemplo de Respuesta (201 Created):

```json
{
  "id": 1,
  "email": "correo@example.com"
}
```

#### Posibles Errores:

- **400 Bad Request:**

  - Si el email ya está registrado:

    ```json
    {
      "error": "El email 'correo@example.com' ya está registrado."
    }
    ```

  - Si la contraseña no cumple con los requisitos:

    ```json
    {
      "error": "La contraseña debe tener al menos 6 caracteres y contener al menos 1 número."
    }
    ```

---

### 2. Inicio de Sesión

- **Método HTTP:** POST
- **URL:** `http://localhost:5015/api/auth/login`
- **Cuerpo de la Solicitud (Body):** JSON

#### Formato del Body:

```json
{
  "email": "correo@example.com",
  "password": "Password123"
}
```

#### Ejemplo de Respuesta (200 OK):

```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
}
```

#### Posibles Errores:

- **401 Unauthorized:**

    ```json
    {
      "error": "Credenciales inválidas."
    }
    ```

---

### 3. Crear un Post

- **Método HTTP:** POST
- **URL:** `http://localhost:5015/api/posts`
- **Cuerpo de la Solicitud (Body):** JSON con archivo de imagen adjunto.

#### Formato del Body:

```json
{
  "title": "Mi primer post",
  "image": "archivo-imagen.jpg"
}
```

#### Ejemplo de Respuesta (201 Created):

```json
{
  "id": 1,
  "title": "Mi primer post",
  "publishDate": "2025-01-01T12:00:00",
  "imageUrl": "https://cloudinary.com/mi-imagen.jpg"
}
```

#### Posibles Errores:

- **400 Bad Request:**

    ```json
    {
      "error": "Formato de imagen no válido. Solo se permiten JPG o PNG."
    }
    ```

---

## Extensiones Recomendadas para Visual Studio Code

- **C#:** Para soporte en desarrollo con .NET.
- **SQLite Viewer:** Para visualizar la base de datos SQLite generada.

