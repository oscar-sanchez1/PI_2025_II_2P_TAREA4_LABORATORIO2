using PI_2025_II_2P_taller.Objetos;
using PI_2025_II_2P_Taller.Objetos;
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

        public Menú()
        {
            clientes = new List<Clientes>();
            empleados = new List<Empleado>();
            materiales = new List<Materiales>();
            servicios = new List<Servicios>();
            carros = new List<Carros>();
            ordenes = new List<OrdenTrabajo>();
            contadorOrdenes = 1;
        }

        public void AgregarCliente(Clientes cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser nulo.");
            }
            clientes.Add(cliente);
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            if (empleado == null)
            {
                throw new ArgumentNullException(nameof(empleado), "El empleado no puede ser nulo.");
            }
            empleados.Add(empleado);
        }

        public void AgregarMaterial(Materiales material)
        {
            if (material == null)
            {
                throw new ArgumentNullException(nameof(material), "El material no puede ser nulo.");
            }
            materiales.Add(material);
        }

        public void AgregarServicio(Servicios servicio)
        {
            if (servicio == null)
            {
                throw new ArgumentNullException(nameof(servicio), "El servicio no puede ser nulo.");
            }
            servicios.Add(servicio);
        }

        public void AgregarCarro(Carros carro)
        {
            if (carro == null)
            {
                throw new ArgumentNullException(nameof(carro), "El carro no puede ser nulo.");
            }
            carros.Add(carro);
        }

        public void AgregarOrden(OrdenTrabajo orden)
        {
            if (orden == null)
            {
                throw new ArgumentNullException(nameof(orden), "La orden no puede ser nula.");
            }
            var nuevaOrden = new OrdenTrabajo
            {
                NumeroOrden = contadorOrdenes.ToString("D4"),
                Clientes = clientes.Count > 0 ? clientes[0] : null,
                Carros = carros.Count > 0 ? carros[0] : null,
                EmpleadoAsignado = empleados.Count > 0 ? empleados[0] : null,
            };
            ordenes.Add(nuevaOrden);
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

            decimal ingresosTotales=ordenes.Where (o => o.Estado == "Completada")
                                            .Sum(o => o.Servicios.Sum(s => s.CostoServicio));
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
                cliente.MostrarInfoCliente();
                WriteLine($"Cosa total de servicios: {cliente.CalcularCostoTotalMantenimiento():C}");
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
                valorTotal+= material.CalcularValorTotal();
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
            foreach (var carro in carros)
            {
                carro.MostrarInfoCarro();
                WriteLine($"Costo de mantenimiento: {carro.CalcularCostoMantenimiento():C}\n");
            }
        }

        public void MostrarTodasLasOrdenes()
        {
            var ordenesActivas=ordenes.Where(o => o.Estado == "Completada").ToList();
            if (ordenes.Count == 0)
            {
                WriteLine("No hay órdenes de trabajo registradas.");
                return;
            }
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
    }
}