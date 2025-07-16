using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    public class Motos : Vehiculos
    {
        private string tipoManubrio;
        private string alturaAsiento;

        public string TipoManubrio
        {
            get { return tipoManubrio; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El tipo de manubrio no puede estar vacío o ser nulo.");
                tipoManubrio = value;
            }
        }

        public string AlturaAsiento
        {
            get { return alturaAsiento; }
            set
            {
                switch (value.ToLower())
                {
                    case "alto":
                    case "normal":
                    case "bajo":
                        alturaAsiento = value;
                        break;
                    default:
                        throw new ArgumentException("La altura del asiento debe ser 'alto', 'normal' o 'bajo'.");
                }
            }
        }

        public Motos(string modelo, string placa, string marca, string color, string propietario, string tipo, int año, string tipoManubrio, string alturaAsiento)
            : base(modelo, placa, marca, color, propietario, tipo, año)
        {
            TipoManubrio = tipoManubrio;
            AlturaAsiento = alturaAsiento;
        }

        //Polimorfismo
        public override double CalcularCostoMantenimiento() => base.CalcularCostoMantenimiento(); //Llama a la implementación base Vehículos


        public override string ObtenerTipoVehiculo() => "Moto";

        public override void MostrarInfoVehiculo()
        {
            base.MostrarInfoVehiculo(); //Llama a la implementación base Vehículos
            WriteLine($"{"Tipo de Manubrio:",-28} {TipoManubrio}");
            WriteLine($"{"Altura del Asiento:",-28} {AlturaAsiento}");
        }
    }
}

