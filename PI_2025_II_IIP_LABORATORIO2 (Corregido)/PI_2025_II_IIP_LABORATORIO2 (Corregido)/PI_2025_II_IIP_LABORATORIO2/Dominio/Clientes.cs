using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    // Clase Derivada1
    public class Clientes : Personas
    {
        private string dni;
        private int edad;
        private string sexo;
        private string nacionalidad;
        public List<Vehiculos> VehiculosCliente { get; set; } 

        public string DNI
        {
            get { return dni; }
            set
            {
                if (value.Length != 13)
                    throw new ArgumentException("El DNI debe contener exactamente 13 dígitos.");
                dni = value;
            }
        }

        public int Edad
        {
            get { return edad; }
            set
            {
                if (value < 18)
                    throw new ArgumentException("El cliente no puede ser menor de edad.");
                if (value > 90)
                    throw new ArgumentException("Lo siento, señor. Los fósiles no conducen.");
                edad = value;
            }
        }

        public string Sexo
        {
            get { return sexo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El sexo no puede estar vacío o ser nulo.");
                sexo = value;
            }
        }

        public string Nacionalidad
        {
            get { return nacionalidad; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La nacionalidad no puede estar vacía o ser nula.");
                nacionalidad = value;
            }
        }

        public Clientes(string nombre, string apellido, string numeroTelefono, string correoElectronico,
                       string dni, int edad, string sexo, string nacionalidad)
            : base(nombre, apellido, numeroTelefono, correoElectronico)
        {
            DNI = dni; 
            Edad = edad; 
            Sexo = sexo; 
            Nacionalidad = nacionalidad;
            VehiculosCliente = new List<Vehiculos>();
        }

        //Polimorfismo
        public override void MostrarInformacion()
        {
            base.MostrarInformacion(); // Llama a la implementación base Personas
            WriteLine($"DNI: {DNI}");
            WriteLine($"Edad: {Edad} años");
            WriteLine($"Sexo: {Sexo}");
            WriteLine($"Nacionalidad: {Nacionalidad}");
            WriteLine($"Cantidad de vehículos: {VehiculosCliente.Count}");
        }

        public void AgregarVehiculo(Vehiculos vehiculoNuevo)
        {
            if (vehiculoNuevo == null)
            {
                throw new ArgumentNullException(nameof(vehiculoNuevo), "El vehículo no puede ser nulo.");
            }
            VehiculosCliente.Add(vehiculoNuevo);
        }

        public void MostrarTodosLosVehiculos()
        {
            WriteLine($"\nVehículos de {Nombre} {Apellido}");
            if (VehiculosCliente.Count == 0)
            {
                WriteLine("No tiene vehículos registrados.");
            }
            else
            {
                foreach (var vehiculo in VehiculosCliente)
                {
                    vehiculo.MostrarInfoVehiculo();
                    WriteLine($"Costo de mantenimiento: {vehiculo.CalcularCostoMantenimiento():C}\n");
                }
            }
        }

        public double CalcularCostoTotalMantenimiento() => VehiculosCliente.Sum(v => v.CalcularCostoMantenimiento());

        public override string ToString() =>
            $"Cliente: {Nombre} {Apellido} | " +
            $"DNI: {DNI} | " +
            $"Edad: {Edad} | " +
            $"Tel: {NumeroTelefono}";
    }
}
