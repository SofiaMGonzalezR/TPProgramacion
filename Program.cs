using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Alumno> alumnos = new List<Alumno>();
    static List<Materia> materias = new List<Materia>();
    static List<AlumnoMateria> alumnoMaterias = new List<AlumnoMateria>();

    static void Main()
    {
        CargarDatos();

        while (true)
        {
            Console.WriteLine("1. Alta Alumno");
            Console.WriteLine("2. Baja Alumno");
            Console.WriteLine("3. Modificación Alumno");
            Console.WriteLine("4. Mostrar Alumnos Activos");
            Console.WriteLine("5. Mostrar Alumnos Inactivos");
            Console.WriteLine("6. Alta Materia");
            Console.WriteLine("7. Baja Materia");
            Console.WriteLine("8. Modificación Materia");
            Console.WriteLine("9. Salir");

            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    AltaAlumno();
                    break;
                case "2":
                    BajaAlumno();
                    break;
                case "3":
                    ModificacionAlumno();
                    break;
                case "4":
                    MostrarAlumnos(true);
                    break;
                case "5":
                    MostrarAlumnos(false);
                    break;
                case "6":
                    AltaMateria();
                    break;
                case "7":
                    BajaMateria();
                    break;
                case "8":
                    ModificacionMateria();
                    break;
                case "9":
                    GuardarDatos();
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static void AltaAlumno()
    {
        Console.WriteLine("Ingrese el DNI del alumno:");
        string dni = Console.ReadLine();
        Alumno alumnoExistente = alumnos.Find(a => a.DNI == dni);

        if (alumnoExistente != null)
        {
            if (alumnoExistente.EstaActivo)
            {
                Console.WriteLine("Error: Ya existe un alumno con este DNI activo.");
            }
            else
            {
                Console.WriteLine("El alumno con este DNI está inactivo. ¿Desea reactivarlo? (S/N)");
                if (Console.ReadLine().ToUpper() == "S")
                {
                    alumnoExistente.EstaActivo = true;
                    Console.WriteLine("Alumno reactivado.");
                }
            }
            return;
        }

        Alumno nuevoAlumno = new Alumno();
        nuevoAlumno.Indice = alumnos.Count > 0 ? alumnos[alumnos.Count - 1].Indice + 1 : 1;
        nuevoAlumno.DNI = dni;

        Console.WriteLine("Ingrese el nombre del alumno:");
        nuevoAlumno.Nombre = Console.ReadLine();
        Console.WriteLine("Ingrese el apellido del alumno:");
        nuevoAlumno.Apellido = Console.ReadLine();
        Console.WriteLine("Ingrese la fecha de nacimiento (AAAA-MM-DD):");
        nuevoAlumno.FechaNacimiento = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el domicilio del alumno:");
        nuevoAlumno.Domicilio = Console.ReadLine();
        nuevoAlumno.EstaActivo = true;

        alumnos.Add(nuevoAlumno);
        Console.WriteLine("Alumno dado de alta.");
    }


    static void BajaAlumno()
    {
        Console.WriteLine("Ingrese el DNI del alumno a dar de baja:");
        string dni = Console.ReadLine();
        Alumno alumno = alumnos.Find(a => a.DNI == dni && a.EstaActivo);

        if (alumno != null)
        {
            alumno.EstaActivo = false;
            Console.WriteLine("Alumno dado de baja.");
        }
        else
        {
            Console.WriteLine("No se encontró un alumno activo con ese DNI.");
        }
    }


    static void ModificacionAlumno()
    {
        Console.WriteLine("Ingrese el DNI del alumno a modificar:");
        string dni = Console.ReadLine();
        Alumno alumno = alumnos.Find(a => a.DNI == dni && a.EstaActivo);

        if (alumno != null)
        {
            Console.WriteLine("Ingrese el nuevo nombre (Dejar en blanco si desea mantener el nombre actual):");
            string nombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nombre)) alumno.Nombre = nombre;

            Console.WriteLine("Ingrese el nuevo apellido (Dejar en blanco si desea mantener el apellido actual):");
            string apellido = Console.ReadLine();
            if (!string.IsNullOrEmpty(apellido)) alumno.Apellido = apellido;

            Console.WriteLine("Ingrese la nueva fecha de nacimiento (Dejar en blanco si desea mantener la fecha actual):");
            string fechaNacimiento = Console.ReadLine();
            if (!string.IsNullOrEmpty(fechaNacimiento)) alumno.FechaNacimiento = DateTime.Parse(fechaNacimiento);

            Console.WriteLine("Ingrese el nuevo domicilio (Dejar en blanco si desea mantener la fecha actual):");
            string domicilio = Console.ReadLine();
            if (!string.IsNullOrEmpty(domicilio)) alumno.Domicilio = domicilio;

            Console.WriteLine("Datos del alumno modificados.");
        }
        else
        {
            Console.WriteLine("No se encontró un alumno activo con ese DNI.");
        }
    }


    static void MostrarAlumnos(bool activos)
    {
        List<Alumno> lista = alumnos.FindAll(a => a.EstaActivo == activos);

        if (lista.Count == 0)
        {
            Console.WriteLine(activos ? "No hay alumnos activos." : "No hay alumnos inactivos.");
        }
        else
        {
            foreach (Alumno alumno in lista)
            {
                Console.WriteLine(alumno.ToString());
            }
        }
    }

    static void AltaMateria()
    {
        Console.WriteLine("Ingrese el nombre de la materia:");
        string nombreMateria = Console.ReadLine();
        Materia materiaExistente = materias.Find(m => m.NombreMateria == nombreMateria);

        if (materiaExistente != null)
        {
            if (materiaExistente.EstaActiva)
            {
                Console.WriteLine("Error: Ya existe una materia con este nombre que está activa.");
            }
            else
            {
                Console.WriteLine("La materia con este nombre está inactiva. ¿Desea reactivarla? (S/N)");
                if (Console.ReadLine().ToUpper() == "S")
                {
                    materiaExistente.EstaActiva = true;
                    Console.WriteLine("Materia reactivada.");
                }
            }
            return;
        }

        Materia nuevaMateria = new Materia();
        nuevaMateria.Indice = materias.Count > 0 ? materias[materias.Count - 1].Indice + 1 : 1;
        nuevaMateria.NombreMateria = nombreMateria;
        nuevaMateria.EstaActiva = true;

        materias.Add(nuevaMateria);
        Console.WriteLine("Materia dada de alta.");
    }

    static void BajaMateria()
    {
        Console.WriteLine("Ingrese el nombre de la materia a dar de baja:");
        string nombreMateria = Console.ReadLine();
        Materia materia = materias.Find(m => m.NombreMateria == nombreMateria && m.EstaActiva);

        if (materia != null)
        {
            materia.EstaActiva = false;
            Console.WriteLine("Materia dada de baja.");
        }
        else
        {
            Console.WriteLine("No se encontró una materia activa con ese nombre.");
        }
    }


    static void ModificacionMateria()
    {
        Console.WriteLine("Ingrese el nombre de la materia a modificar:");
        string nombreMateria = Console.ReadLine();
        Materia materia = materias.Find(m => m.NombreMateria == nombreMateria && m.EstaActiva);

        if (materia != null)
        {
            Console.WriteLine("Ingrese el nuevo nombre de la materia (Dejar en blanco si desea mantener el nombre actual):");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoNombre)) materia.NombreMateria = nuevoNombre;

            Console.WriteLine("Datos de la materia modificados.");
        }
        else
        {
            Console.WriteLine("No se encontró una materia activa con ese nombre.");
        }
    }

    static void CargarDatos()
    {
        if (File.Exists("alumnos.txt"))
        {
            using (StreamReader reader = new StreamReader("alumnos.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    alumnos.Add(Alumno.FromString(line));
                }
            }
        }

        if (File.Exists("materias.txt"))
        {
            using (StreamReader reader = new StreamReader("materias.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    materias.Add(Materia.FromString(line));
                }
            }
        }

        if (File.Exists("alumnoMaterias.txt"))
        {
            using (StreamReader reader = new StreamReader("alumnoMaterias.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    alumnoMaterias.Add(AlumnoMateria.FromString(line));
                }
            }
        }
    }

    static void GuardarDatos()
    {
        using (StreamWriter writer = new StreamWriter("alumnos.txt"))
        {
            foreach (Alumno alumno in alumnos)
            {
                writer.WriteLine(alumno.ToString());
            }
        }

        using (StreamWriter writer = new StreamWriter("materias.txt"))
        {
            foreach (Materia materia in materias)
            {
                writer.WriteLine(materia.ToString());
            }
        }

        using (StreamWriter writer = new StreamWriter("alumnoMaterias.txt"))
        {
            foreach (AlumnoMateria alumnoMateria in alumnoMaterias)
            {
                writer.WriteLine(alumnoMateria.ToString());
            }
        }
    }
}


