using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using PI_2025_II_IIP_LABORATORIO2.Dominio;

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Menú taller = new Menú();
                MostrarMenu(taller);

        }
        static void MostrarMenu(Menú taller)
        {
            int opcion;
            do
            {
                Clear();
                WriteLine("=== MENÚ PRINCIPAL ===");
                WriteLine("1. Listar todos los clientes");
                WriteLine("2. Listar todos los empleados");
                WriteLine("3. Listar todos los materiales");
                WriteLine("4. Listar todos los carros");
                WriteLine("5. Listar todas las órdenes");
                WriteLine("6. Buscar cliente por DNI");
                WriteLine("7. Buscar empleado por código");
                WriteLine("8. Agregar cliente");
                WriteLine("9. Agregar carro");
                WriteLine("10. Agregar factura");
                WriteLine("11. Listar facturas");
                WriteLine("12. Buscar factura por número");
                WriteLine("0. Salir");
                Write("Seleccione una opción: ");
                if (!int.TryParse(ReadLine(), out opcion)) opcion = -1;

                Clear();
                switch (opcion)
                {
                    case 1:
                        taller.MostrarTodosLosClientes();
                        break;
                    case 2:
                        taller.MostrarTodosLosEmpleados();
                        break;
                    case 3:
                        taller.MostrarTodosLosMateriales();
                        break;
                    case 4:
                        taller.MostrarTodosLosCarros();
                        break;
                    case 5:
                        taller.MostrarTodasLasOrdenes();
                        break;
                    case 6:
                        Write("Ingrese el DNI del cliente: ");
                        string dni = ReadLine();
                        var cliente = taller.BuscarClientePorDNI(dni);
                        if (cliente != null)
                            cliente.MostrarInformacion();
                        else
                            WriteLine("Cliente no encontrado.");
                        break;
                    case 7:
                        Write("Ingrese el código del empleado: ");
                        string codigo = ReadLine();
                        var empleado = taller.BuscarEmpleadoPorCodigo(codigo);
                        if (empleado != null)
                            empleado.MostrarInformacion();
                        else
                            WriteLine("Empleado no encontrado.");
                        break;
                    case 8:
                        // Agregar cliente
                        Write("Primer nombre: ");
                        string primerNombre = ReadLine();
                        Write("Segundo nombre: ");
                        string segundoNombre = ReadLine();
                        Write("Primer apellido: ");
                        string primerApellido = ReadLine();
                        Write("Segundo apellido: ");
                        string segundoApellido = ReadLine();
                        Write("Edad: ");
                        int edad = int.TryParse(ReadLine(), out int e) ? e : 0;
                        Write("Nacionalidad: ");
                        string nacionalidad = ReadLine();
                        Write("Sexo: ");
                        string sexo = ReadLine();
                        Write("DNI: ");
                        string nuevoDni = ReadLine();

                        var nuevoCliente = new Clientes(
                            primerNombre + " " + segundoNombre, // nombre
                            primerApellido + " " + segundoApellido, // apellido
                            "", // número de teléfono
                            "", // correo electrónico
                            nuevoDni, // dni (string)
                            edad,     // edad (int)
                            sexo,     // sexo (string)
                            nacionalidad // nacionalidad (string)
                        );
                        taller.AgregarCliente(nuevoCliente);
                        WriteLine("Cliente agregado correctamente.");
                        break;
                    case 9:
                        // Agregar carro
                        Write("Modelo: ");
                        string modelo = ReadLine();
                        Write("Placa: ");
                        string placa = ReadLine();
                        Write("Marca: ");
                        string marca = ReadLine();
                        Write("Color: ");
                        string color = ReadLine();
                        Write("Propietario (DNI): ");
                        string propietarioDni = ReadLine();
                        var propietario = taller.BuscarClientePorDNI(propietarioDni);
                        if (propietario == null)
                        {
                            WriteLine("Propietario no encontrado.");
                            break;
                        }
                        Write("Tipo: ");
                        string tipo = ReadLine();
                        Write("Año: ");
                        int año = int.TryParse(ReadLine(), out int a) ? a : 0;
                        Write("Accesorios (separados por coma): ");
                        string accesorios = ReadLine();
                        Write("Número de puertas: ");
                        int numeroPuertas = int.TryParse(ReadLine(), out int np) ? np : 4;
                        Write("Tipo de transmisión (Manual/Automática): ");
                        string tipoTransmision = ReadLine();
                        Write("¿Tiene aire acondicionado? (s/n): ");
                        bool aireAcondicionado = ReadLine().ToLower() == "s";
                        Write("Tipo de combustible: ");
                        string tipoCombustible = ReadLine();
                        var carro = new Carros(
                            modelo, placa, marca, color, propietario.NombreCompleto, tipo, año, numeroPuertas, numeroPuertas, tipoTransmision
                        );
                        taller.AgregarCarro(carro);
                        propietario.AgregarVehiculo(carro);
                        WriteLine("Carro agregado correctamente.");
                        break;
                    case 10:
                        // Agregar factura
                        Write("Número de factura: ");
                        string numeroFactura = ReadLine();
                        Write("DNI del cliente: ");
                        string dniFactura = ReadLine();
                        var clienteFactura = taller.BuscarClientePorDNI(dniFactura);
                        if (clienteFactura == null)
                        {
                            WriteLine("Cliente no encontrado.");
                            break;
                        }
                        Write("Monto total: ");
                        decimal monto = decimal.TryParse(ReadLine(), out decimal m) ? m : 0;
                        List<Servicios> servicios = new List<Servicios>();
                        Write("¿Desea agregar servicios? (s/n): ");
                        if (ReadLine().ToLower() == "s")
                        {
                            string tipoServicio;
                            decimal costo;
                            do
                            {
                                Write("Tipo de servicio: ");
                                tipoServicio = ReadLine();
                                Write("Costo del servicio: ");
                                costo = decimal.TryParse(ReadLine(), out decimal cs) ? cs : 0;

                                servicios.Add(new Servicios(tipoServicio, (double)costo, null, null, null, DateTime.Now, DateTime.Now));
                                Write("¿Agregar otro servicio? (s/n): ");
                            } while (ReadLine().ToLower() == "s");
                        }
                        var factura = new Factura(
                            clienteFactura.NombreCompleto, // pCliente
                            clienteFactura.DNI,            // pDni
                            null,                          // pCai (ajusta si tienes un objeto CAI)
                            ""                             // pEmpleado (ajusta si tienes un empleado)
                        );
                        
                        taller.AgregarFactura(factura);
                        WriteLine("Factura agregada correctamente.");
                        break;
                    case 11:
                        // Listar facturas
                        taller.MostrarTodasLasFacturas();
                        break;
                    case 12:
                        // Buscar factura por número
                        Write("Ingrese el número de factura: ");
                        string numFac = ReadLine();
                        var fac = taller.BuscarFacturaPorNumero(numFac);
                        if (fac != null)
                            fac.mostrarFactura();
                        else
                            WriteLine("Factura no encontrada.");
                        break;
                    case 0:
                        WriteLine("Saliendo...");
                        break;
                    default:
                        WriteLine("Opción no válida.");
                        break;
                }
                if (opcion != 0)
                {
                    WriteLine("\nPresione cualquier tecla para continuar...");
                    ReadKey();
                }
            } while (opcion != 0);
        }
    }
}
