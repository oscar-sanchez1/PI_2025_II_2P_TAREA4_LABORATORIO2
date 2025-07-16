using PI_2025_II_IIP_LABORATORIO2.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PI_2025_II_IIP_LABORATORIO2.Dominio
{
    public class Menú
    {
        private List<Clientes> clientes;
        private List<Empleado> empleados;
        private List<Materiales> materiales;
        private List<Carros> carros;
        private List<OrdenTrabajo> ordenes;
        private List<Servicios> servicios;
        private int contadorOrdenes;
        private List<Factura> facturas;

        public Menú()
        {
            clientes = new List<Clientes>();
            empleados = new List<Empleado>();
            materiales = new List<Materiales>();
            servicios = new List<Servicios>();
            carros = new List<Carros>();
            ordenes = new List<OrdenTrabajo>();
            facturas = new List<Factura>();
            contadorOrdenes = 1;
        }

        public void AgregarCliente(Clientes cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser nulo.");
            clientes.Add(cliente);
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            if (empleado == null)
                throw new ArgumentNullException(nameof(empleado), "El empleado no puede ser nulo.");
            empleados.Add(empleado);
        }

        public void AgregarMaterial(Materiales material)
        {
            if (material == null)
                throw new ArgumentNullException(nameof(material), "El material no puede ser nulo.");
            materiales.Add(material);
        }

        public void AgregarServicio(Servicios servicio)
        {
            if (servicio == null)
                throw new ArgumentNullException(nameof(servicio), "El servicio no puede ser nulo.");
            servicios.Add(servicio);
        }

        public void AgregarCarro(Carros carro)
        {
            if (carro == null)
                throw new ArgumentNullException(nameof(carro), "El carro no puede ser nulo.");
            carros.Add(carro);
        }

        public void AgregarOrden(OrdenTrabajo orden)
        {
            if (orden == null)
                throw new ArgumentNullException(nameof(orden), "La orden no puede ser nula.");

            orden.NumeroOrden = contadorOrdenes.ToString("D4");
            if (orden.Clientes == null && clientes.Count > 0)
                orden.Clientes = clientes[0];
            if (orden.Carros == null && carros.Count > 0)
                orden.Carros = carros[0];
            if (orden.EmpleadoAsignado == null && empleados.Count > 0)
                orden.EmpleadoAsignado = empleados[0];

            ordenes.Add(orden);
            contadorOrdenes++;
        }

        public void MostrarMenuPrincipal()
        {
            WriteLine("=== Menú Principal ===");
            WriteLine($"Clientes registrados: {clientes.Count}");
            WriteLine($"Empleados registrados: {empleados.Count}");
            WriteLine($"Materiales registrados: {materiales.Count}");
            WriteLine($"Servicios registrados: {servicios.Count}");
            WriteLine($"Carros registrados: {carros.Count}");
            WriteLine($"Órdenes de trabajo registradas: {ordenes.Count}");
            WriteLine($"Órdenes completadas: {ordenes.Count(o => o.Estado == "Completada")}");

            decimal ingresosTotales = 0;
            foreach (var o in ordenes.Where(o => o.Estado == "Completada"))
            {
                if (o.Servicios != null)
                    ingresosTotales += (decimal)o.Servicios.Sum(s => s.CostoServicio);
            }
            WriteLine($"Ingresos totales: {ingresosTotales:C}");
        }

        public void MostrarTodosLosClientes()
        {
            if (clientes.Count == 0)
            {
                WriteLine("No hay clientes registrados.");
                return;
            }
            foreach (var cliente in clientes)
            {
                cliente.MostrarInformacion();
                WriteLine($"Costo total de servicios: {cliente.CalcularCostoTotalMantenimiento():C}");
                cliente.MostrarTodosLosVehiculos();
            }
        }

        public void MostrarTodosLosEmpleados()
        {
            if (empleados.Count == 0)
            {
                WriteLine("No hay empleados registrados.");
                return;
            }
            foreach (var empleado in empleados)
            {
                empleado.MostrarInformacion();
            }
        }

        public void MostrarTodosLosMateriales()
        {
            if (materiales.Count == 0)
            {
                WriteLine("No hay materiales registrados.");
                return;
            }
            decimal valorTotal = 0;
            foreach (var material in materiales)
            {
                material.MostrarInfoMateriales();
                valorTotal += material.CalcularValorTotal();
            }
            WriteLine($"\nValor total de materiales: {valorTotal:C}");
        }

        public void MostrarTodosLosServicios()
        {
            if (servicios.Count == 0)
            {
                WriteLine("No hay servicios registrados.");
                return;
            }
            foreach (var servicio in servicios)
            {
                WriteLine($"Tipo de Servicio: {servicio.TipoServicio}, Costo: {servicio.CostoServicio:C}");
            }
        }

        public void MostrarTodosLosCarros()
        {
            if (carros.Count == 0)
            {
                WriteLine("No hay carros registrados.");
                return;
            }
            foreach (var vehiculo in carros)
            {
                vehiculo.MostrarInfoVehiculo();
                WriteLine($"Costo de mantenimiento: {vehiculo.CalcularCostoMantenimiento():C}\n");
            }
        }

        public void MostrarTodasLasOrdenes()
        {
            if (ordenes.Count == 0)
            {
                WriteLine("No hay órdenes de trabajo registradas.");
                return;
            }
            var ordenesActivas = ordenes.Where(o => o.Estado == "Completada").ToList();
            foreach (var orden in ordenesActivas)
            {
                orden.MostrarOrden();
            }
        }

        public Clientes BuscarClientePorDNI(string dni)
        {
            return clientes.FirstOrDefault(c => c.DNI == dni);
        }

        public Empleado BuscarEmpleadoPorCodigo(string codigo)
        {
            return empleados.FirstOrDefault(e => e.CodigoEmpleado == codigo);
        }

        public Materiales BuscarMaterialPorNombre(string nombre)
        {
            return materiales.FirstOrDefault(m => m.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public Carros BuscarCarroPorPlaca(string placa)
        {
            return carros.FirstOrDefault(c => c.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));
        }

        public Servicios BuscarServicioPorTipo(string tipo)
        {
            return servicios.FirstOrDefault(s => s.TipoServicio.Equals(tipo, StringComparison.OrdinalIgnoreCase));
        }

        public OrdenTrabajo BuscarOrdenPorNumero(string numero)
        {
            return ordenes.FirstOrDefault(o => o.NumeroOrden == numero);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void AgregarFactura(Factura factura)
        {
            if (factura == null)
            {
                Console.WriteLine("Error: La factura no puede ser nula.");
                return;
            }
            if (facturas.Any(f => f.fecha == factura.fecha && f.cliente == factura.cliente))
            {
                Console.WriteLine($"Error: Ya existe una factura para el cliente {factura.cliente} en la fecha {factura.fecha}");
                return;
            }
            facturas.Add(factura);
            Console.WriteLine($"Factura para el cliente {factura.cliente} agregada correctamente.");
        }

        public Factura BuscarFacturaPorNumero(string numeroFactura)
        {
            if (string.IsNullOrEmpty(numeroFactura))
            {
                Console.WriteLine("Error: El número de factura no puede estar vacío.");
                return null;
            }
            // Como Factura no tiene NumeroFactura, se puede buscar por fecha o cliente, o mostrar advertencia
            var factura = facturas.FirstOrDefault(f => f.fecha.ToString("yyyyMMddHHmmss").Equals(numeroFactura, StringComparison.OrdinalIgnoreCase));
            if (factura == null)
            {
                Console.WriteLine($"No se encontró ninguna factura con el número {numeroFactura}");
            }
            return factura;
        }

        public void MostrarTodasLasFacturas()
        {
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("           TODAS LAS FACTURAS");
            Console.WriteLine(new string('=', 50));

            if (facturas.Count == 0)
            {
                Console.WriteLine("No hay facturas registradas.");
                return;
            }

            for (int i = 0; i < facturas.Count; i++)
            {
                Console.WriteLine($"\n--- FACTURA {i + 1} ---");
                facturas[i].mostrarFactura();
                Console.WriteLine(new string('-', 40));
            }

            Console.WriteLine($"\nTotal de facturas: {facturas.Count}");
            Console.WriteLine($"Monto total acumulado: {facturas.Sum(f => f.total):C}");
        }
    }
}