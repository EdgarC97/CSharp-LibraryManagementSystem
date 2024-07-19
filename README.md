# Sistema de Gestión de Biblioteca

El Servicio Nacional de Aprendizaje (SENA) ha decidido modernizar el sistema de gestión de su biblioteca. Han contratado a tu equipo de desarrolladores para crear una aplicación que permita registrar, buscar y gestionar los libros y autores de manera eficiente.

## Objetivo del Proyecto

Desarrollar un sistema de gestión de biblioteca que cumpla con los siguientes requisitos:

### Requisitos Funcionales

#### Registro de Libros:

- Crear una clase `Libro` con las siguientes propiedades: `Titulo`, `Autor`, `ISBN`, `AñoPublicacion`, `Genero` y `Precio`.
- Implementar un método que devuelva una descripción detallada del libro.

#### Gestión de Precios:

- Añadir una funcionalidad para aplicar un descuento al precio del libro.

#### Búsqueda de Libros:

- Permitir la búsqueda de libros por género, autor y rango de años de publicación.
- Implementar métodos para agregar y eliminar libros del sistema.

#### Clasificación de Libros:

- Ordenar los libros por año de publicación.

#### Funcionalidades Adicionales:

- Implementar un método que determine si un libro es reciente (publicado en los últimos 5 años).

### Detalles Técnicos

#### Clases y Herencia:

- Crear una clase base `Publicacion` con propiedades `Titulo` y `AñoPublicacion`.
- La clase `Libro` debe heredar de `Publicacion` y añadir propiedades específicas de los libros.

#### Métodos de Búsqueda:

- Implementar métodos de búsqueda utilizando LINQ para encontrar libros por género, autor y rango de años.

#### Interfaz de Usuario:

- Crear una clase `Biblioteca` que gestione una lista de libros y proporcione métodos para agregar, eliminar y buscar libros.

### Entregables

1. Diagrama de clases en Start UML.
2. Interfaz visual para controlar la aplicación web.
3. El proyecto debe tener una trazabilidad en GitHub mediante git Flow.
4. Gestión del proyecto mediante GitHub Projects.

### Temas Puntuales a Tener en Cuenta

- Sobreescritura de propiedades y métodos.

¿Podemos tener una lista de clases?
