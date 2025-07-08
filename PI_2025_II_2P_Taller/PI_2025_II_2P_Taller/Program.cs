using PI_2025_II_2P_Taller.Objetos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2025_II_2P_Taller
{
    internal class Program
    {
        public class TallerMecanico
        {
            public List<Empleado> Empleados { get; private set; }
            public List<Material> Materiales { get; private set; }

            public TallerMecanico()
            {
                Empleados = new List<Empleado>();
                Materiales = new List<Material>();
            }

            public bool AgregarEmpleado(Empleado empleado)
            {
                if (Empleados.Exists(e => e.CodigoEmpleado == empleado.CodigoEmpleado))
                {
                    return false;
                }
                Empleados.Add(empleado);
                return true;
            }

            public bool RegistrarMaterial(Material material)
            {
                if (Materiales.Exists(m => m.Nombre.Equals(material.Nombre, StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }
                Materiales.Add(material);
                return true;
            }

            public void MostrarTodosEmpleados()
            {
                if (Empleados.Count == 0)
                {
                    Console.WriteLine("\nNo hay empleados registrados.");
                    return;
                }

                foreach (var empleado in Empleados)
                {
                    empleado.MostrarInformacion();
                    Console.WriteLine("----------------------------");
                }
            }
            public void MostrarResumenMateriales()
            {
                Console.WriteLine("\n=== Resumen de Materiales ===");
                foreach (var material in Materiales)
                {
                    Console.WriteLine($"{material.Nombre} - Cantidad: {material.Cantidad} - Costo Unitario: {material.Costo:C}");
                }
            }

            internal void MostrarTodosMateriales()
            {
                throw new NotImplementedException();
            }
        }

        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("es-MX");
            TallerMecanico taller = new TallerMecanico();
            string opcion;

            do
            {
                MostrarMenuPrincipal();
                opcion = Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        GestionarEmpleados(taller);
                        break;

                    case "2":
                        GestionarMateriales(taller);
                        break;

                    case "3":
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

                if (opcion != "3")
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (opcion != "3");

            Console.WriteLine("\nGracias por usar el sistema de gestión del taller.");
        }

        static void MostrarMenuPrincipal()
        {
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE TALLER MECÁNICO ===");
            Console.WriteLine("1. Gestión de Empleados");
            Console.WriteLine("2. Gestión de Materiales");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
        }

        static void GestionarEmpleados(TallerMecanico taller)
        {
            string opcion;
            do
            {
                Console.WriteLine("=== GESTIÓN DE EMPLEADOS ===");
                Console.WriteLine("1. Agregar nuevo empleado");
                Console.WriteLine("2. Mostrar todos los empleados");
                Console.WriteLine("3. Registrar trabajo realizado");
                Console.WriteLine("4. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        AgregarNuevoEmpleado(taller);
                        break;

                    case "2":
                        taller.MostrarTodosEmpleados();
                        break;

                    case "3":
                        RegistrarTrabajoEmpleado(taller);
                        break;

                    case "4":
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

                if (opcion != "4")
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (opcion != "4");
        }

        static void AgregarNuevoEmpleado(TallerMecanico taller)
        {
            Empleado empleado = new Empleado();

            Console.WriteLine("=== REGISTRO DE NUEVO EMPLEADO ===");

            Console.Write("Nombre completo: ");
            empleado.Nombre = Console.ReadLine();

            Console.Write("Código de empleado: ");
            empleado.CodigoEmpleado = Console.ReadLine();

            Console.Write("Área de especialización: ");
            empleado.AreaEspecializacion = Console.ReadLine();

            bool fechaValida = false;
            while (!fechaValida)
            {
                Console.Write("Fecha de contratación (dd/mm/aaaa): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
                {
                    empleado.FechaContratacion = fecha;
                    fechaValida = true;
                }
                else
                {
                    Console.WriteLine("Formato de fecha inválido. Intente nuevamente.");
                }
            }

            bool salarioValido = false;
            while (!salarioValido)
            {
                Console.Write("Salario base: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal salario))
                {
                    empleado.SalarioBase = salario;
                    salarioValido = true;
                }
                else
                {
                    Console.WriteLine("Valor inválido para salario. Intente nuevamente.");
                }
            }

            if (taller.AgregarEmpleado(empleado))
            {
                Console.WriteLine("\nEmpleado registrado exitosamente!");
            }
            else
            {
                Console.WriteLine("\nError: Ya existe un empleado con ese código.");
            }
        }

        static void RegistrarTrabajoEmpleado(TallerMecanico taller)
        {
            Console.Write("Ingrese el código del empleado: ");
            string codigo = Console.ReadLine();

            var empleado = taller.Empleados.Find(e => e.CodigoEmpleado == codigo);
            if (empleado != null)
            {
                empleado.AgregarTrabajo();
                Console.WriteLine($"\nTrabajo registrado exitosamente para {empleado.Nombre}");
                Console.WriteLine($"Total de trabajos realizados: {empleado.TrabajosRealizados}");
                Console.WriteLine($"Comisión actual: {empleado.CalcularComisiones():C}");
            }
            else
            {
                Console.WriteLine("\nEmpleado no encontrado.");
            }
        }

        static void GestionarMateriales(TallerMecanico taller)
        {
            string opcion;
            do
            {
                Console.WriteLine("=== GESTIÓN DE MATERIALES ===");
                Console.WriteLine("1. Agregar nuevo material");
                Console.WriteLine("2. Mostrar todos los materiales");
                Console.WriteLine("3. Mostrar resumen de materiales");
                Console.WriteLine("4. Agregar descripción a material");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        AgregarNuevoMaterial(taller);
                        break;

                    case "2":
                        taller.MostrarTodosMateriales();
                        break;

                    case "3":
                        taller.MostrarResumenMateriales();
                        break;

                    case "4":
                        AgregarDescripcionMaterial(taller);
                        break;

                    case "5":
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

                if (opcion != "5")
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (opcion != "5");
        }

        static void AgregarNuevoMaterial(TallerMecanico taller)
        {
            Material material = new Material();

            Console.WriteLine("=== REGISTRO DE NUEVO MATERIAL ===");

            Console.Write("Nombre del material: ");
            material.Nombre = Console.ReadLine();

            Console.Write("Tipo de material: ");
            material.Tipo = Console.ReadLine();

            bool costoValido = false;
            while (!costoValido)
            {
                Console.Write("Costo del material: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal costo))
                {
                    material.Costo = costo;
                    costoValido = true;
                }
                else
                {
                    Console.WriteLine("Valor inválido para costo. Intente nuevamente.");
                }
            }

            Console.Write("Estado del material: ");
            material.Estado = Console.ReadLine();

            bool cantidadValida = false;
            while (!cantidadValida)
            {
                Console.Write("Cantidad de material: ");
                if (int.TryParse(Console.ReadLine(), out int cantidad) && cantidad > 0)
                {
                    material.Cantidad = cantidad;
                    cantidadValida = true;
                }
                else
                {
                    Console.WriteLine("Valor inválido para cantidad. Debe ser un número positivo.");
                }
            }

            Console.Write("Marca del material: ");
            material.Marca = Console.ReadLine();

            string respuesta;
            do
            {
                Console.Write("¿Desea agregar una descripción? (s/n): ");
                respuesta = Console.ReadLine().ToLower();

                if (respuesta == "s")
                {
                    Console.Write("Ingrese la descripción: ");
                    string descripcion = Console.ReadLine();
                    material.AgregarDescripcion(descripcion);
                }
            } while (respuesta == "s");

            if (taller.RegistrarMaterial(material))
            {
                Console.WriteLine("\nMaterial registrado exitosamente!");
            }
            else
            {
                Console.WriteLine("\nError: Ya existe un material con ese nombre.");
            }
        }

        static void AgregarDescripcionMaterial(TallerMecanico taller)
        {
            if (taller.Materiales.Count == 0)
            {
                Console.WriteLine("\nNo hay materiales registrados.");
                return;
            }

            Console.Write("Ingrese el nombre del material: ");
            string nombreMaterial = Console.ReadLine();

            var material = taller.Materiales.Find(m => m.Nombre.Equals(nombreMaterial, StringComparison.OrdinalIgnoreCase));
            if (material != null)
            {
                Console.Write("Ingrese la nueva descripción: ");
                string descripcion = Console.ReadLine();
                material.AgregarDescripcion(descripcion);
                Console.WriteLine("\nDescripción agregada exitosamente!");
            }
            else
            {
                Console.WriteLine("\nMaterial no encontrado.");
            }
        }
    }
}