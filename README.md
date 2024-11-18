# MAUI-API app!

En esta aplicación de .NET MAUI, se consumirá [la presente API](https://fi.jcaguilar.dev/docs/#/) para hacer peticiones **HTTP GET** y **POST**. En la app, se podrá ver la lista de personas registradas en la escuela y registrar alguna nueva al sistema.


# Vista principal

La vista principal hace una petición **GET** con el [siguiente endpoint](https://fi.jcaguilar.dev/v1/escuela/persona) que devuelve todas las personas que están inscritas en la escuela, por lo que la carga inicial puede tardar un poco. Se puede acceder a la siguiente vista (Formulario creación Persona) pulsando el botón **Nueva Persona**.

![enter image description here](https://res.cloudinary.com/dlrmqdoyf/image/upload/v1731890479/ml98p1tszycpoakdpwph.jpg)

## Formulario creación Persona

En esta vista se ofrece un formulario para poder registrar a una persona al sistema; luego de llenar todos los campos, se puede pulsar el botón **Añadir persona** para hacer una petición POST a la API, y que ésta la registre en una base de datos.

![enter image description here](https://res.cloudinary.com/dlrmqdoyf/image/upload/v1731890493/mq4tkbm1ugvhviyohznv.jpg)
