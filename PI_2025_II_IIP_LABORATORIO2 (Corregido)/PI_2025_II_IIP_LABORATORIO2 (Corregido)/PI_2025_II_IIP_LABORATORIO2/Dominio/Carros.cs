using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    public class Carros : Vehiculos
    {
        private int numeroPuertas;
        private string traccion;

        public int NumeroPuertas
        {
            get { return numeroPuertas; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(NumeroPuertas), value, "El número debe ser mayor que cero.");
                numeroPuertas = value;
            }
        }

        public string Traccion
        {
            get { return traccion; }
            set
            {
                switch (value.ToLower())
                {
                    case "delantera":
                    case "trasera":
                    case "4x4":
                        traccion = value;
                        break;
                    default:
                        throw new ArgumentException("La tracción debe ser 'delantera', 'trasera' o '4x4'.");
                }
            }
        }

        public Carros(string modelo, string placa, string marca, string color, string propietario, string tipo, int año, int numeroPuertas, int puertas, string traccion)
            : base(modelo, placa, marca, color, propietario, tipo, año)
        {
            NumeroPuertas = numeroPuertas;
            Traccion = traccion;
        }

        //Polimorfismo
        public override double CalcularCostoMantenimiento() => base.CalcularCostoMantenimiento(); // Llama a la implementación base Vehículos

        public override string ObtenerTipoVehiculo() => "Carro";

        public override void MostrarInfoVehiculo()
        {
            base.MostrarInfoVehiculo(); // Llama a la implementación base Vehículos
            WriteLine($"{"Cantidad de Puertas:",-28} {NumeroPuertas}");
            WriteLine($"{"Tracción:",-28} {Traccion}");
        }
    }
}

