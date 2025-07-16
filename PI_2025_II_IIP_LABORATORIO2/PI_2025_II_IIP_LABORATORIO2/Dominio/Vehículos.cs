using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    public abstract class Vehiculos
    {
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public string Propietario { get; set; }
        public List<string> HistorialMantenimiento { get; set; }
        public string Tipo { get; set; }
        public int Año { get; set; }
        public List<string> Accesorios { get; set; }
        public decimal CostoRevision { get; set; }
        public decimal CostoMantenimiento { get; set; }

        public Vehiculos(string modelo, string placa, string marca, string color, string propietario, string tipo, int año)
        {
            Modelo = modelo;
            Placa = placa;
            Marca = marca;
            Color = color;
            Propietario = propietario;
            Tipo = tipo;
            Año = año;
            HistorialMantenimiento = new List<string>();
            Accesorios = new List<string>();
        }

        public virtual void MostrarInfoVehiculo()
        {
            Console.WriteLine($"{Marca} {Modelo} ({Año}) - Placa: {Placa}, Color: {Color}");
        }

        public virtual double CalcularCostoMantenimiento()
        {
            return (double)CostoMantenimiento;
        }

        public abstract string ObtenerTipoVehiculo();
    }
}

