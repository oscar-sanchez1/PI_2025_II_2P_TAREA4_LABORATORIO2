
using PI_2025_II_IIP_LABORATORIO2.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    public class Automovil : Carros
    {
        public int NumeroPuertas { get; set; }
        public string TipoTransmision { get; set; }
        public bool AireAcondicionado { get; set; }
        public string TipoCombustible { get; set; }

        public Automovil(
            string modelo, string placa, string marca, string color, string propietario, string historialMantenimiento, string tipo, int año, string accesorios,
            int pNumeroPuertas, string pTipoTransmision, bool pAireAcondicionado, string pTipoCombustible)
            : base(modelo, placa, marca, color, propietario, historialMantenimiento, tipo, año, accesorios)
        {
            NumeroPuertas = pNumeroPuertas;
            TipoTransmision = pTipoTransmision;
            AireAcondicionado = pAireAcondicionado;
            TipoCombustible = pTipoCombustible;
        }

        public override void MostrarInfoCarro()
        {
            Console.WriteLine("=== AUTOMÓVIL ===");
            base.MostrarInfoCarro();
            Console.WriteLine($"{"Puertas:",-25} {NumeroPuertas}");
            Console.WriteLine($"{"Transmisión:",-25} {TipoTransmision}");
            Console.WriteLine($"{"Aire Acondicionado:",-25} {(AireAcondicionado ? "Sí" : "No")}");
            Console.WriteLine($"{"Combustible:",-25} {TipoCombustible}");

        }

        public override double CalcularCostoMantenimiento()
        {
            double costoBase = 800.0;
            double costoAC = AireAcondicionado ? 150.0 : 0.0;
            double costoTransmision = TipoTransmision == "Automática" ? 100.0 : 0.0;
            double costoHistorial = HistorialMantenimiento.Count * 75;
            return costoBase + costoAC + costoTransmision + costoHistorial;
        }

        public override string ObtenerTipoVehiculo()
        {
            return "Automóvil";
        }

        public override void MostrarEspecificaciones()
        {
            Console.WriteLine("Especificaciones del Automóvil:");
            Console.WriteLine($"- Configuración: {NumeroPuertas} puertas");
            Console.WriteLine($"- Transmisión: {TipoTransmision}");
            Console.WriteLine($"- Combustible: {TipoCombustible}");
            Console.WriteLine($"- Clima: {(AireAcondicionado ? "Incluido" : "No incluido")}");
        }
    }
}
