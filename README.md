# 🎟️ LumiFilm - Sistema de Gestión para un Cine

Bienvenido/a a **LumiFilm**, una aplicación backend desarrollada en ASP.NET Core para gestionar los servicios principales de un cine: películas, sesiones, tickets y más. Esta plataforma permite integrar la funcionalidad de venta de entradas y reservas en línea para ofrecer una experiencia completa a los usuarios. 🍿

## 🚀 Objetivo del Proyecto
Este proyecto busca proporcionar un backend sólido y escalable para un sistema de cine, con las siguientes características clave:

- **Gestión de recursos:** películas, sesiones, salas, asientos y tickets.
- **Consumo API REST:** endpoints bien estructurados para facilitar la integración con el frontend.
- **Validación robusta:** manejo de errores y casos límite para garantizar la fiabilidad del sistema.
- **Modularidad:** código estructurado en diferentes controladores para facilitar el mantenimiento y la expansión.

Este repositorio corresponde **únicamente al backend** del proyecto.

## 🔧 Funcionalidades

- 🎥 **Películas:** Crear, listar, buscar y gestionar películas con sus respectivos datos.
- 🏢 **Salas:** Gestión de salas de cine, incluyendo inicialización automática de salas disponibles.
- 🕒 **Sesiones:** Crear y gestionar sesiones, incluyendo la generación automática de asientos.
- 🎫 **Entradas:** Gestión de precios y tipos de entradas.
- 💺 **Tickets y Reservas:** Crear tickets y reservar asientos, asegurando que no se dupliquen las reservas.
- 🌐 **Endpoints REST:** Integración con sistemas externos o frontend mediante endpoints RESTful.


## 🛠️ Tecnologías y Herramientas Utilizadas

### Backend:
- **ASP.NET Core:** Framework principal para el desarrollo del backend.
- **C#:** Lenguaje de programación utilizado.

### Herramientas:
- **Visual Studio:** IDE principal para el desarrollo.
- **Git y GitHub:** Para control de versiones con metodología **GitFlow**.
- **Swagger:** Documentación interactiva para probar los endpoints.
- **Docker**: Para contenerización y despliegue.

### Infraestructura:
- **AWS EC2**: 
  - Contenerización del **frontend** y **backend** utilizando Docker.

## 🚀 Iniciar el Proyecto
Sigue estos pasos para configurar el proyecto en tu máquina local:

### 1️⃣ Clonar el repositorio
````bash
      git clone https://github.com/tu-repositorio/reto_back.git
````

### 2️⃣ Configurar dependencias
Abre el proyecto en Visual Studio y restaura las dependencias necesarias.

### 3️⃣ Iniciar el servidor
Presiona F5 o utiliza el siguiente comando para ejecutar el proyecto:

````bash
      dotnet run
````
### 4️⃣ Probar la API
Dirígete a **http://localhost:{puerto}/swagger** para interactuar con los endpoints desde la documentación de Swagger.

### 📄 Endpoints Disponibles
Endpoint Método	Descripción
- **/api/Pelicula GET**	Listar todas las películas.
- **/api/Pelicula/{id} GET** Obtener una película por ID.
- **/api/Sesion	GET** Listar todas las sesiones.
- **/api/Sesion/pelicula/{idPelicula} GET**	Listar sesiones por ID de película.
- **/api/Asiento/sesion/{sesionId} GET** Listar asientos por sesión.
- **/api/Ticket	POST** Crear un ticket con validación de asientos reservados.
Consulta más detalles sobre los endpoints en la documentación de Swagger.


## 📂 Estructura del Proyecto

``plaintext

BACK/
├── .git/                            # Carpeta de control de versiones Git
├── Controllers/                     # Controladores de la lógica del negocio
│   ├── AsientosController.cs     
│   ├── EntradaController.cs
│   ├── PeliculaController.cs     
│   ├── SalaController.cs         
│   ├── SesionController.cs       
│   ├── TicketController.cs       
├── Models/                          # Modelos de datos de la aplicación
│   ├── Asiento.cs               
│   ├── Entrada.cs               
│   ├── Pago.cs                   
│   ├── Pelicula.cs             
│   ├── Sala.cs                   
│   ├── Sesion.cs                 
│   ├── Ticket.cs                
├── Properties/                     # Configuración específica del proyecto
│   ├── launchSettings.json         # Configuración de lanzamiento para depuración
├── Utils/                          # Utilidades y funciones auxiliares
│   ├── ExceptionsErrors.cs         # Manejo de excepciones personalizadas
├── appsettings.json                # Configuración general de la aplicación
├── appsettings.Development.json    # Configuración específica para desarrollo
├── Dockerfile                      # Configuración para construir una imagen de Docker
├── .dockerignore                   # Archivos y carpetas ignorados por Docker
├── .gitignore                      # Archivos y carpetas ignorados por Git
├── Program.cs                      # Punto de entrada principal de la aplicación
├── Reto-Back.csproj                # Archivo del proyecto C#
├── README.md                       # Documentación del proyecto
├── bin/                            # Binarios generados al compilar
│   └── Debug/                      # Compilaciones en modo depuración
├── obj/                            # Archivos temporales generados al compilar
├── .git/                           # Información de control de versiones de Git
