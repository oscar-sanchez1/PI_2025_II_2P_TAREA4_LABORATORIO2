using System;
using System.Collections.Generic;
using static System.Console;
using PI_2025_II_IIP_LABORATORIO2.objetos;


namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    public class Servicios
    {
        // Atributos privados
        private string tipoServicio;
        private decimal costoServicio;
        private string empleadoAsignado;
        private DateTime fechaIngreso;
        private DateTime fechaSalida;
        private string materialUtilizado;

        // Lista para almacenar servicios
        private static List<Servicios> listaServicios = new List<Servicios>();

        // Propiedades
        public string TipoServicio { get => tipoServicio; set => tipoServicio = value; }
        public decimal CostoServicio { get => costoServicio; set => costoServicio = value; }
        public string EmpleadoAsignado { get => empleadoAsignado; set => empleadoAsignado = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public DateTime FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public string MaterialUtilizado { get => materialUtilizado; set => materialUtilizado = value; }

        // Constructor
        public Servicios(string tipoServicio, decimal costoServicio, string empleadoAsignado,
                         DateTime fechaIngreso, DateTime fechaSalida, string materialUtilizado)
        {
            this.tipoServicio = tipoServicio;
            this.costoServicio = costoServicio;
            this.empleadoAsignado = empleadoAsignado;
            this.fechaIngreso = fechaIngreso;
            this.fechaSalida = fechaSalida;
            this.materialUtilizado = materialUtilizado;
        }

        public Servicios(string tipoServicio, decimal costoServicio)
        {
            this.tipoServicio = tipoServicio;
            this.costoServicio = costoServicio;
            this.empleadoAsignado = "N/A";
            this.fechaIngreso = DateTime.Now;
            this.fechaSalida = DateTime.Now;
            this.materialUtilizado = "N/A";
        }

        // Crear servicio (desde consola)
        public static void CrearServicio()
        {
            try
            {
                Write("INGRESE EL TIPO DE SERVICIO: ");
                string tipo = ReadLine();

                Write("INGRESE EL COSTO DEL SERVICIO: ");
                decimal costo = Convert.ToDecimal(ReadLine());

                Write("INGRESE EL EMPLEADO ASIGNADO: ");
                string empleado = ReadLine();

                Write("INGRESE LA FECHA DE INGRESO (YYYY-MM-DD): ");
                DateTime fechaIng = DateTime.Parse(ReadLine());

                Write("INGRESE LA FECHA DE SALIDA (YYYY-MM-DD): ");
                DateTime fechaSal = DateTime.Parse(ReadLine());

                Write("INGRESE EL MATERIAL UTILIZADO: ");
                string material = ReadLine();

                Servicios nuevoServicio = new Servicios(tipo, costo, empleado, fechaIng, fechaSal, material);
                listaServicios.Add(nuevoServicio);

                WriteLine("SERVICIO CREADO CON ÉXITO.");
            }
            catch (FormatException ex)
            {
                WriteLine($"ERROR DE FORMATO: {ex.Message.ToUpper()}");
            }
            catch (Exception ex)
            {
                WriteLine($"ERROR AL CREAR SERVICIO: {ex.Message.ToUpper()}");
            }
        }

        // Buscar servicio por tipo
        public static void BuscarServicio()
        {
            Write("INGRESE EL TIPO DE SERVICIO A BUSCAR: ");
            string buscar = ReadLine();

            foreach (Servicios s in listaServicios)
            {
                if (s.TipoServicio.Equals(buscar, StringComparison.OrdinalIgnoreCase))
                {
                    s.ImprimirServicio();
                    return;
                }
            }

            WriteLine("SERVICIO NO ENCONTRADO.");
        }

        // Imprimir todos los servicios
        public static void ImprimirTodos()
        {
            if (listaServicios.Count == 0)
            {
                WriteLine("NO HAY SERVICIOS REGISTRADOS.");
                return;
            }

            foreach (Servicios s in listaServicios)
            {
                s.ImprimirServicio();
            }
        }

        // Imprimir servicio individual
        public void ImprimirServicio()
        {
            WriteLine("---------------------------");
            WriteLine($"TIPO DE SERVICIO: {tipoServicio.ToUpper()}");
            WriteLine($"COSTO: {costoServicio:C}");
            WriteLine($"EMPLEADO ASIGNADO: {empleadoAsignado.ToUpper()}");
            WriteLine($"FECHA DE INGRESO: {fechaIngreso:d}");
            WriteLine($"FECHA DE SALIDA: {fechaSalida:d}");
            WriteLine($"MATERIAL UTILIZADO: {materialUtilizado}");
            WriteLine("---------------------------");
        }
    }
}
