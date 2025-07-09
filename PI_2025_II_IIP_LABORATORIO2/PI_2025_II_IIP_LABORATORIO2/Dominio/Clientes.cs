using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using PI_2025_II_IIP_LABORATORIO2.objetos;

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{ 
    public class Clientes
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
        public Clientes(string pPrimerNombre, string pSegundoNombre, string pPrimerApellido, string pSegundoApellido,
            int pEdad, string pNacionalidad, string pSexo, string pDNI)
        {
            PrimerNombre = pPrimerNombre;
            SegundoNombre = pSegundoNombre;
            PrimerApellido = pPrimerApellido;
            SegundoApellido = pSegundoApellido;
            Edad = pEdad;
            Nacionalidad = pNacionalidad;
            Sexo = pSexo;
            DNI = pDNI;
            CarrosCliente = new List<Carros>();
        }

        // Método 1#: Mostrar toda la información del cliente
        public string NombreCompleto =>
            $"{PrimerNombre} {SegundoNombre} {PrimerApellido} {SegundoApellido}";
        public void MostrarInfoCliente()
        {
            WriteLine($"{"Nombre: ",-28} {NombreCompleto}");
            WriteLine($"{"Edad: ",-28} {Edad}\n{"Nacionalidad: ",-28} {Nacionalidad}\n{"Sexo: ",-28} {Sexo}\n{"DNI: ",-29}{DNI}");
            WriteLine($"{"Cantidad de carros:",-28} {CarrosCliente.Count}");
        }

        
        // Método #2: Agregar un carro nuevo
        public void AgregarCarro(Carros carroNuevo)
        {
            if (carroNuevo == null)
            {
                throw new ArgumentNullException(nameof(carroNuevo), "El carro no puede ser nulo.");
            }
            CarrosCliente.Add(carroNuevo);
        }

        public void MostrarTodosLosVehiculos()
        {
            WriteLine($"\n Vehículo de {NombreCompleto}");
            if (CarrosCliente.Count == 0)
            {
                WriteLine("No tiene vehículos registrados.");
            }
            else
            {
                foreach (var carro in CarrosCliente)
                {
                    carro.MostrarInfoCarro();
                    WriteLine($"Costo de mantenimiento: {carro.CalcularCostoMantenimiento():C}\n");
                    
                }
            }
        }

        public double CalcularCostoTotalMantenimiento()
        {
            return CarrosCliente.Sum(v => v.CalcularCostoMantenimiento());
        }


        // Método #3: Obtener la cantidad de carros del cliente
        public int ObtenerCantidadCarros()
        {
            return CarrosCliente.Count;
        }

        public override string ToString()=>
        
            $"Cliente {NombreCompleto} " +
            $"DNI: {DNI}  " +
            $"Edad: {Edad} años " +
            $"Nacionalidad: {Nacionalidad} " +
            $"Sexo: {Sexo}";
        

}


   

    }


