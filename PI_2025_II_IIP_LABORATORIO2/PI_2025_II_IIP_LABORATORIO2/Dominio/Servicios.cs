using System;
using System.Collections.Generic;
using static System.Console;
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
        WriteLine("OPERACIÓN DEL TALLER EN EJECUCIÓN.");
    }
}

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    public class Servicios : OperacionTaller, IResumenServicio
    {
        // Encapsulamiento con propiedades públicas y campos internos protegidos
        public string TipoServicio { get; set; }
        public double CostoServicio { get; set; }
        public Empleado EmpleadoServicio { get; set; }
        public Clientes ClienteServicio { get; set; }
        public Automovil AutomovilServicio { get; set; }
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
            WriteLine("SERVICIO TRABAJANDOSE");
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
                WriteLine("SERVICIO FINALIZADO CON ÉXITO");
            }
            else
            {
                WriteLine("EL SERVICIO YA ESTÁ FINALIZADO");
            }
        }

        public void CalcularCostoConISV()
        {
            try
            {
                double impuesto = CostoServicio * 0.15;
                CostoServicio += impuesto;
                WriteLine("SE CALCULÓ EL IMPUESTO DEL 15%");
            }
            catch (Exception e)
            {
                WriteLine("ERROR AL CALCULAR EL ISV");
                WriteLine(e.Message.ToUpper());
            }
        }

        public void ElServicioDuraMasDeUnDia()
        {
            try
            {
                TimeSpan duracion = FechaSalida - FechaIngreso;
                if (duracion.TotalDays >= 1)
                {
                    WriteLine("EL SERVICIO DURÓ MÁS DE UN DÍA");
                }
                else
                {
                    WriteLine("EL SERVICIO FUE REALIZADO EN EL MISMO DÍA");
                }
            }
            catch (Exception e)
            {
                WriteLine("ERROR AL CALCULAR LA DURACIÓN DEL SERVICIO");
                WriteLine(e.Message.ToUpper());
            }
        }

        // Polimorfismo (implementación del método de la interfaz)
        public void ResumenServicio()
        {
            WriteLine("==== RESUMEN DEL SERVICIO ====");
            WriteLine($"CÓDIGO: {CodigoServicio}");
            WriteLine($"TIPO: {TipoServicio}");
            WriteLine($"CLIENTE: {ClienteServicio.NombreCompleto}");
            WriteLine($"EMPLEADO: {EmpleadoServicio.Nombre}");
            WriteLine($"AUTO: {AutomovilServicio.Marca} - {AutomovilServicio.Placa}");
            WriteLine($"FECHA INGRESO: {FechaIngreso.ToShortDateString()}");
            WriteLine($"FECHA SALIDA: {FechaSalida.ToShortDateString()}");
            WriteLine($"COSTO TOTAL CON ISV: L {CostoServicio:F2}");
            WriteLine($"ESTADO: {(EstaFinalizado ? "FINALIZADO" : "EN PROCESO")}");
            WriteLine("==============================");
        }

        // Herencia (override de método base)
        public override void MostrarOperacion()
        {
            WriteLine("SE ESTÁ REALIZANDO UN SERVICIO DE TALLER.");
        }
    }
}
