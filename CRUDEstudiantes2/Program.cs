using System;
using System.Collections.Generic;

namespace CRUDEstudiantes
{
    class Program
    {
        static List<Estudiante> estudiantes = new List<Estudiante>();
        static int contadorId = 1;

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== CRUD DE ESTUDIANTES ===");
                Console.WriteLine("1. Crear Estudiante");
                Console.WriteLine("2. Listar Estudiantes");
                Console.WriteLine("3. Actualizar Estudiante");
                Console.WriteLine("4. Eliminar Estudiante");
                Console.WriteLine("5. Buscar Estudiante");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opcion: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        CrearEstudiante();
                        break;
                    case 2:
                        ListarEstudiantes();
                        break;
                    case 3:
                        ActualizarEstudiante();
                        break;
                    case 4:
                        EliminarEstudiante();
                        break;
                    case 5:
                        BuscarEstudiante();
                        break;
                    case 6:
                        break;
                }
            } while (opcion != 6);
        }

        static void CrearEstudiante()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede estar vacio!");
                Console.ReadKey();
                return;
            }

            Console.Write("Edad: ");
            int edad;
            if (!int.TryParse(Console.ReadLine(), out edad))
            {
                Console.WriteLine("Edad invalida!");
                Console.ReadKey();
                return;
            }

            if (edad < 0 || edad > 100)
            {
                Console.WriteLine("Edad debe estar entre 0 y 100!");
                Console.ReadKey();
                return;
            }

            Estudiante nuevo = new Estudiante
            {
                Id = contadorId++,
                Nombre = nombre,
                Edad = edad
            };

            estudiantes.Add(nuevo);
            Console.WriteLine("Estudiante creado exitosamente!");
            Console.ReadKey();
        }

        static void ListarEstudiantes()
        {
            if (estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
            }
            else
            {
                foreach (var est in estudiantes)
                {
                    Console.WriteLine($"ID: {est.Id} - Nombre: {est.Nombre} - Edad: {est.Edad}");
                }
            }
            Console.ReadKey();
        }

        static void ActualizarEstudiante()
        {
            Console.Write("ID del estudiante a actualizar: ");
            int id = int.Parse(Console.ReadLine());

            var estudiante = estudiantes.Find(e => e.Id == id);
            if (estudiante != null)
            {
                Console.Write("Nuevo nombre: ");
                estudiante.Nombre = Console.ReadLine();
                Console.Write("Nueva edad: ");
                estudiante.Edad = int.Parse(Console.ReadLine());
                Console.WriteLine("Estudiante actualizado!");
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado.");
            }
            Console.ReadKey();
        }

        static void EliminarEstudiante()
        {
            Console.Write("ID del estudiante a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            var estudiante = estudiantes.Find(e => e.Id == id);
            if (estudiante != null)
            {
                estudiantes.Remove(estudiante);
                Console.WriteLine("Estudiante eliminado!");
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado.");
            }
            Console.ReadKey();
        }

        static void BuscarEstudiante()
        {
            Console.Write("Nombre a buscar: ");
            string nombre = Console.ReadLine();

            var encontrados = estudiantes.FindAll(e => e.Nombre.ToLower().Contains(nombre.ToLower()));

            if (encontrados.Count == 0)
            {
                Console.WriteLine("No se encontraron estudiantes.");
            }
            else
            {
                Console.WriteLine($"Se encontraron {encontrados.Count} estudiante(s):");
                foreach (var est in encontrados)
                {
                    Console.WriteLine($"ID: {est.Id} - Nombre: {est.Nombre} - Edad: {est.Edad}");
                }
            }
            Console.ReadKey();
        }
    }

    class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
}