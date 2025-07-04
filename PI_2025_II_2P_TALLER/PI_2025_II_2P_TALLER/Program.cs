using PI_2025_II_2P_TALLER.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2025_II_2P_TALLER
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Clientes> listaClientes = new List<Clientes>();
            string opcion;

            do
            {
                Console.WriteLine("\n=== Sistema de Taller ===");
                Console.WriteLine("1. Agregar nuevo cliente");
                Console.WriteLine("2. Mostrar todos los clientes y sus carros");
                Console.WriteLine("3. Salir");
                Console.Write("Selecciona una opción: ");
                opcion = Console.ReadLine();
                Console.Clear();
                switch (opcion)
                {
                    case "1":
                        Clientes nuevoCliente = CrearClienteInteractivo();
                        listaClientes.Add(nuevoCliente);
                        break;

                    case "2":
                        MostrarClientes(listaClientes);
                        break;

                    case "3":
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Presione Enter para intentar de nuevo.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            } while (opcion != "3");

            Console.WriteLine("\nGracias por usar el sistema.");
        }

        // Método para crear un cliente pidiendo datos por consola
        static Clientes CrearClienteInteractivo()
        {
            Clientes cliente = new Clientes();

            Console.WriteLine("\n=== Registro de nuevo cliente ===");
            Console.Write("Primer nombre: ");
            cliente.PrimerNombre = Console.ReadLine();
            Console.Write("Segundo nombre: ");
            cliente.SegundoNombre = Console.ReadLine();
            Console.Write("Primer apellido: ");
            cliente.PrimerApellido = Console.ReadLine();
            Console.Write("Segundo apellido: ");
            cliente.SegundoApellido = Console.ReadLine();
            Console.Write("Edad: ");
            cliente.Edad = int.Parse(Console.ReadLine());
            Console.Write("Nacionalidad: ");
            cliente.Nacionalidad = Console.ReadLine();
            Console.Write("Sexo (M/F): ");
            cliente.Sexo = Console.ReadLine();
            Console.Write("DNI: ");
            cliente.DNI = Console.ReadLine();

            string agregarOtroCarro;
            do
            {
                Carros carro = CrearCarroInteractivo();
                cliente.AgregarCarro(carro);

                Console.Write("¿Deseas agregar otro carro a este cliente? (s/n): ");
                agregarOtroCarro = Console.ReadLine().ToLower();

            } while (agregarOtroCarro == "s");
            Console.Clear();
            return cliente;
        }

        // Método para crear un carro pidiendo datos por consola
        static Carros CrearCarroInteractivo()
        {
            Carros carro = new Carros();

            Console.WriteLine("\n=== Registro de nuevo carro ===");
            Console.Write("Modelo: ");
            carro.Modelo = Console.ReadLine();
            Console.Write("Marca: ");
            carro.Marca = Console.ReadLine();
            Console.Write("Placa: ");
            carro.Placa = Console.ReadLine();
            Console.Write("Color: ");
            carro.Color = Console.ReadLine();
            Console.Write("Tipo: ");
            carro.Tipo = Console.ReadLine();
            Console.Write("Año: ");
            carro.Año = int.Parse(Console.ReadLine());
            Console.Write("Nombre del propietario: ");
            carro.Propietario = Console.ReadLine();

            string agregarAccesorio;
            do
            {
                Console.Write("Agregar accesorio (o deja vacío para omitir): ");
                string accesorio = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(accesorio))
                {
                    carro.AgregarAccesorio(accesorio);
                }

                Console.Write("¿Deseas agregar otro accesorio? (s/n): ");
                agregarAccesorio = Console.ReadLine().ToLower();

            } while (agregarAccesorio == "s");

            string agregarMantenimiento;
            do
            {
                Console.Write("Agregar mantenimiento (o deja vacío para omitir): ");
                string mantenimiento = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(mantenimiento))
                {
                    carro.AgregarMantenimiento(mantenimiento);
                }

                Console.Write("¿Deseas agregar otro mantenimiento? (s/n): ");
                agregarMantenimiento = Console.ReadLine().ToLower();

            } while (agregarMantenimiento == "s");
            return carro;
        }

        // Mostrar todos los clientes y sus carros
        static void MostrarClientes(List<Clientes> clientes)
        {
            Console.WriteLine("\n=== Lista de clientes registrados ===");
            if (clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Presione Enter para volver al menú.");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            foreach (var cliente in clientes)
            {
                cliente.MostrarInfoCliente();

                foreach (var carro in cliente.CarrosCliente)
                {
                    Console.WriteLine("--- Carro ---");
                    carro.MostrarInfoCarro();
                }
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Presione Enter para volver al menú.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}