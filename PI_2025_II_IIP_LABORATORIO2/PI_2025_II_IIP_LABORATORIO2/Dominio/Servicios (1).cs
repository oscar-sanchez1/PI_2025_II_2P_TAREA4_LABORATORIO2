using System;
using System.Collections.Generic;
using static System.Console;
using PI_2025_II_IIP_LABORATORIO2.Dominio;
using PI_2025_II_IIP_LABORATORIO2.objetos;

// Interfaz para polimorfismo
public interface IResumenServicio
{
    void ResumenServicio();
}

// Clase base para herencia (Herencia simbólica o futura extensión)
public class OperacionTaller
{
    public virtual void MostrarOperacion()
    {
        Console.WriteLine("OPERACIÓN DEL TALLER EN EJECUCIÓN.");
    }
}

namespace PI_2025_II_IIP_LABORATORIO2.Dominio
{
    public class Servicios : OperacionTaller, IResumenServicio
    {
        // Encapsulamiento con propiedades públicas y campos internos protegidos
        public string TipoServicio { get; set; }
        public double CostoServicio { get; set; }
        public Empleado EmpleadoServicio { get; set; }
        public Clientes ClienteServicio { get; set; }
        public Vehiculos AutomovilServicio { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public List<Materiales> MaterialUsado { get; set; } = new List<Materiales>();
        public bool EstaFinalizado { get; private set; } = false;
        public int CodigoServicio { get; private set; }

        // Constructor
        public Servicios(string tipo, double costo, Empleado emp, Clientes cli, Automovil auto, DateTime ingreso, DateTime salida)
        {
            TipoServicio = tipo;
            CostoServicio = costo;
            EmpleadoServicio = emp;
            ClienteServicio = cli;
            AutomovilServicio = auto;
            FechaIngreso = ingreso;
            FechaSalida = salida;
            CodigoServicio = GenerarCodigoUnico();
            Console.WriteLine("SERVICIO TRABAJANDOSE");
        }

        private static int contador = 1;
        private int GenerarCodigoUnico()
        {
            return contador++;
        }

        public void FinalizarServicio()
        {
            if (!EstaFinalizado)
            {
                EstaFinalizado = true;
                Console.WriteLine("SERVICIO FINALIZADO CON ÉXITO");
            }
            else
            {
                Console.WriteLine("EL SERVICIO YA ESTÁ FINALIZADO");
            }
        }

        public double CalcularCostoConISV()
        {
            try
            {
                double impuesto = CostoServicio * 0.15;
                Console.WriteLine("SE CALCULÓ EL IMPUESTO DEL 15%");
                return CostoServicio + impuesto;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR AL CALCULAR EL ISV");
                Console.WriteLine(e.Message.ToUpper());
                return CostoServicio;
            }
        }

        public void ElServicioDuraMasDeUnDia()
        {
            try
            {
                if (FechaSalida < FechaIngreso)
                {
                    Console.WriteLine("ERROR: LA FECHA DE SALIDA NO PUEDE SER ANTERIOR A LA FECHA DE INGRESO");
                    return;
                }

                TimeSpan duracion = FechaSalida - FechaIngreso;
                if (duracion.TotalDays >= 1)
                {
                    Console.WriteLine("EL SERVICIO DURÓ MÁS DE UN DÍA");
                }
                else
                {
                    Console.WriteLine("EL SERVICIO FUE REALIZADO EN EL MISMO DÍA");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR AL CALCULAR LA DURACIÓN DEL SERVICIO");
                Console.WriteLine(e.Message.ToUpper());
            }
        }

        // Polimorfismo (implementación del método de la interfaz)
        public void ResumenServicio()
        {
            Console.WriteLine("==== RESUMEN DEL SERVICIO ====");
            Console.WriteLine($"CÓDIGO: {CodigoServicio}");
            Console.WriteLine($"TIPO: {TipoServicio}");
            Console.WriteLine($"CLIENTE: {ClienteServicio?.NombreCompleto ?? "N/A"}");
            Console.WriteLine($"EMPLEADO: {EmpleadoServicio?.Nombre ?? "N/A"}");
            Console.WriteLine($"AUTO: {AutomovilServicio?.Marca ?? "N/A"} - {AutomovilServicio?.Placa ?? "N/A"}");
            Console.WriteLine($"FECHA INGRESO: {FechaIngreso.ToShortDateString()}");
            Console.WriteLine($"FECHA SALIDA: {FechaSalida.ToShortDateString()}");
            Console.WriteLine($"COSTO TOTAL CON ISV: L {CalcularCostoConISV():F2}");
            Console.WriteLine($"ESTADO: {(EstaFinalizado ? "FINALIZADO" : "EN PROCESO")}");
            Console.WriteLine("==============================");
        }

        // Herencia (override de método base)
        public override void MostrarOperacion()
        {
            Console.WriteLine("SE ESTÁ REALIZANDO UN SERVICIO DE TALLER.");
        }
    }
}
