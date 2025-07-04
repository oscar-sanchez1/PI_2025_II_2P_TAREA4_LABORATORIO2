using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2025_II_2P_TALLER.Objetos
{
    internal class Clientes
    {
        // Propiedades
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int Edad { get; set; }
        public string Nacionalidad { get; set; }
        public string Sexo { get; set; }
        public string DNI { get; set; }
        public List<Carros> CarrosCliente { get; set; }

        // Constructor
        public Clientes()
        {
            CarrosCliente = new List<Carros>();
        }

        // Método 1#: Mostrar toda la información del cliente
        public void MostrarInfoCliente()
        {
            Console.WriteLine($"{"Nombre completo: ",-28} {PrimerNombre} {SegundoNombre} {PrimerApellido} {SegundoApellido}");
            Console.WriteLine($"{"Edad: ",-28} {Edad}\n{"Nacionalidad: ",-28} {Nacionalidad}\n{"Sexo: ",-28} {Sexo}\n{"DNI: ",-29}{DNI}");
            Console.WriteLine($"{"Cantidad de carros:",-28} {CarrosCliente.Count}");
        }

        // Método #2: Agregar un carro nuevo
        public void AgregarCarro(Carros carroNuevo)
        {
            CarrosCliente.Add(carroNuevo);
        }

        // Método #3: Obtener la cantidad de carros del cliente
        public int ObtenerCantidadCarros()
        {
            return CarrosCliente.Count;
        }
    }
}