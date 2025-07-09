using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using PI_2025_II_IIP_LABORATORIO2.objetos;

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    public abstract class Carros
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
        public Carros(string pModelo, string pPlaca, string pMarca, string pColor,
            string pPropietario, string pHistorialMantenimiento, string pTipo, int pAño, string pAccesorios)
        {
            Modelo = pModelo;
            Placa = pPlaca;
            Marca = pMarca;
            Color = pColor;
            Propietario = pPropietario;
            HistorialMantenimiento = new List<string> { pHistorialMantenimiento };
            Tipo = pTipo;
            Año = pAño;
            Accesorios = new List<string> { pAccesorios };

            HistorialMantenimiento = new List<string>();
            Accesorios = new List<string>();
        }

        // Método #1: Mostrar toda la información del carro
        public virtual void MostrarInfoCarro()
        {
            WriteLine($"{"Modelo:",-28} {Modelo}\n{"Placa:",-28} {Placa}\n{"Marca:",-28} {Marca}\n{"Color:",-28} {Color}\n{"Tipo:",-28} {Tipo}\n{"Año:",-28} {Año}");
            WriteLine($"{"Propietario:",-28} {Propietario}");
            WriteLine($"{"Accesorios: ",-28} {string.Join(", ", Accesorios)}");
            WriteLine($"{"Historial de Mantenimiento: ",-28} {string.Join("; ", HistorialMantenimiento)}");
        }

        public abstract double CalcularCostoMantenimiento();
        public abstract string ObtenerTipoVehiculo();
        public abstract void MostrarEspecificaciones();

        // Método #2: Agregar un accesorio
        public void AgregarAccesorio(string accesorio)
        {
            if (accesorio == null)
            {
                throw new ArgumentNullException(nameof(accesorio), "El accesorio no puede ser nulo.");
            }
            Accesorios.Add(accesorio);
        }

        // Método #3: Agregar mantenimiento al historial
        public void AgregarMantenimiento(string mantenimiento)
        {
            if (mantenimiento == null)
            {
                throw new ArgumentNullException(nameof(mantenimiento), "El mantenimiento no puede ser nulo.");
            }
            HistorialMantenimiento.Add(mantenimiento);
        }

        public void MostrarHistorialMantenimiento()
        {
            if (HistorialMantenimiento.Count == 0)
            {
                WriteLine("No hay historial de mantenimiento registrado.");
            }
            else
            {
                WriteLine("Historial de Mantenimiento:");
                foreach (var mantenimiento in HistorialMantenimiento)
                {
                    WriteLine($"- {mantenimiento}");
                }
            }
        }

        public void MostrarAccesorios()
        {
            if (Accesorios.Count == 0)
            {
                WriteLine("No hay accesorios registrados.");
            }
            else
            {
                WriteLine("Accesorios:");
                foreach (var accesorio in Accesorios)
                {
                    WriteLine($"- {accesorio}");
                }
            }


        }

        public override string ToString() =>
        $"Modelo: {Modelo}" +
        $"Marca: {Marca}" +
        $"Placa: {Placa}" +
        $"Color: {Color}" +
        $"Dueño: {Propietario}" +
        $"Tipo: {Tipo}" +
        $"Año: {Año}" +
        $"Accesorios: {string.Join(", ", Accesorios)}" +
        $"Historial de Mantenimiento: {string.Join("; ", HistorialMantenimiento)}";





    }
}