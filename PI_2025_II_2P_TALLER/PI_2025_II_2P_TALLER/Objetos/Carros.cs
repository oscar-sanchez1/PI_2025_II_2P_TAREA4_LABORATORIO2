using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2025_II_2P_TALLER.Objetos
{
    internal class Carros
    {
        // Propiedades
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public string Propietario { get; set; }
        public List<string> HistorialMantenimiento { get; set; }
        public string Tipo { get; set; }
        public int Año { get; set; }
        public List<string> Accesorios { get; set; }

        // Constructor
        public Carros()
        {
            HistorialMantenimiento = new List<string>();
            Accesorios = new List<string>();
        }

        // Método #1: Mostrar toda la información del carro
        public void MostrarInfoCarro()
        {
            Console.WriteLine($"{"Modelo:",-28} {Modelo}\n{"Placa:",-28} {Placa}\n{"Marca:",-28} {Marca}\n{"Color:",-28} {Color}\n{"Tipo:",-28} {Tipo}\n{"Año:",-28} {Año}");
            Console.WriteLine($"{"Propietario:",-28} {Propietario}");
            Console.WriteLine($"{"Accesorios: ",-28} {string.Join(", ", Accesorios)}");
            Console.WriteLine($"{"Historial de Mantenimiento: ",-28} {string.Join("; ", HistorialMantenimiento)}");
        }

        // Método #2: Agregar un accesorio
        public void AgregarAccesorio(string accesorio)
        {
            Accesorios.Add(accesorio);
        }

        // Método #3: Agregar mantenimiento al historial
        public void AgregarMantenimiento(string mantenimiento)
        {
            HistorialMantenimiento.Add(mantenimiento);
        }
    }
}