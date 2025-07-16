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
        public string DNI { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Nacionalidad { get; set; }
        public List<Vehiculos> VehiculosCliente { get; set; } = new List<Vehiculos>();

        public string NombreCompleto => $"{Nombre} {Apellido}";

        public Clientes(string nombre, string apellido, string numeroTelefono, string correoElectronico,
            string dni, int edad, string sexo, string nacionalidad)
            : base(nombre, apellido, numeroTelefono, correoElectronico)
        {
            DNI = dni;
            Edad = edad;
            Sexo = sexo;
            Nacionalidad = nacionalidad;
        }

        //Polimorfismo
        public override void MostrarInformacion()
        {
            base.MostrarInformacion(); // Llama a la implementación base Personas
            WriteLine($"DNI: {DNI}, Edad: {Edad}, Sexo: {Sexo}, Nacionalidad: {Nacionalidad}");
        }

        public void AgregarVehiculo(Vehiculos vehiculoNuevo)
        {
            VehiculosCliente.Add(vehiculoNuevo);
        }

        public void MostrarTodosLosVehiculos()
        {
            foreach (var v in VehiculosCliente)
                v.MostrarInfoVehiculo();
        }

        public double CalcularCostoTotalMantenimiento()
        {
            return VehiculosCliente.Sum(v => v.CalcularCostoMantenimiento());
        }

        public override string ToString()
        {
            return $"{NombreCompleto} - DNI: {DNI}";
        }
    }
}
