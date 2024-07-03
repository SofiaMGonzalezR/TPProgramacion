# Proyecto Final de Programacion I 
## Profesor Sebastián Zunini
Realizar un programa que maneje la administración de alumnos de la universidad era el objetivo del Proyecto. 
# Resumen del Código en C#

Este programa en C# administra la información de alumnos y materias en una universidad. Permite realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) para alumnos y materias, y maneja la relación entre ellos.

## Clases Principales

### Alumno
- `Indice`
- `Nombre`
- `Apellido`
- `DNI`
- `FechaNacimiento`
- `Domicilio`
- `EstaActivo`

### Materia
- `Indice`
- `NombreMateria`
- `EstaActiva`

### AlumnoMateria
- `Indice`
- `IndiceAlumno`
- `IndiceMateria`
- `Estado`
- `Nota`
- `Fecha`

## Funcionalidades Principales

### Alumnos
- **Alta Alumno**
  - Crea un nuevo alumno si no existe uno con el mismo DNI. Si el alumno existe y está inactivo, ofrece reactivarlo.
- **Baja Alumno**
  - Marca un alumno como inactivo basándose en el DNI.
- **Modificación Alumno**
  - Permite modificar los datos de un alumno activo, incluyendo nombre, apellido, fecha de nacimiento y domicilio.
- **Mostrar Alumnos Activos**
  - Muestra la lista de alumnos que están activos.
- **Mostrar Alumnos Inactivos**
  - Muestra la lista de alumnos que están inactivos.

### Materias
- **Alta Materia**
  - Crea una nueva materia si no existe una con el mismo nombre. Si la materia existe y está inactiva, ofrece reactivarla.
- **Baja Materia**
  - Marca una materia como inactiva basándose en el nombre.
- **Modificación Materia**
  - Permite modificar el nombre de una materia activa.

## Métodos Auxiliares

### CargarDatos
- Carga los datos de alumnos, materias y relaciones alumno-materia desde archivos de texto (`alumnos.txt`, `materias.txt`, `alumnoMaterias.txt`).

### GuardarDatos
- Guarda los datos de alumnos, materias y relaciones alumno-materia en archivos de texto.

## Menú Principal

El programa presenta un menú principal en consola para interactuar con las funcionalidades mencionadas:

1. Alta Alumno
2. Baja Alumno
3. Modificación Alumno
4. Mostrar Alumnos Activos
5. Mostrar Alumnos Inactivos
6. Alta Materia
7. Baja Materia
8. Modificación Materia
9. Salir

El programa se ejecuta en un bucle infinito, solicitando al usuario que seleccione una opción y ejecutando la funcionalidad correspondiente. Al seleccionar la opción "Salir", los datos se guardan en archivos de texto y el programa termina.
