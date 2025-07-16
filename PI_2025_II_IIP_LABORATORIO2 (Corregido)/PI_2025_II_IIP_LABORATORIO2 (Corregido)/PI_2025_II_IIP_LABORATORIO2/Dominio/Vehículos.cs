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
        private string modelo;
        private string placa;
        private string marca;
        private string color;
        private string propietario;
        private List<string> historialMantenimiento;
        private string tipo;
        private int año;
        private List<string> accesorios;
        private decimal costoRevision;
        private decimal costoMantenimiento;

        public string Modelo
        {
            get { return modelo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El modelo no puede estar vacío o ser nulo.");
                modelo = value;
            }
        }

        public string Placa
        {
            get { return placa; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La placa no puede estar vacía o ser nula.");
                placa = value;
            }
        }

        public string Marca
        {
            get { return marca; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La marca no puede estar vacía o ser nula.");
                marca = value;
            }
        }

        public string Color
        {
            get { return color; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El color no puede estar vacío o ser nulo.");
                color = value;
            }
        }

        public string Propietario
        {
            get { return propietario; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El propietario no puede estar vacío o ser nulo.");
                propietario = value;
            }
        }

        public List<string> HistorialMantenimiento
        {
            get { return historialMantenimiento; }
            set => historialMantenimiento = value ?? new List<string>();
        }

        public string Tipo
        {
            get { return tipo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El tipo no puede estar vacío o ser nulo.");
                tipo = value;
            }
        }

        public int Año
        {
            get { return año; }
            set
            {
                if (value < 1886 || value > DateTime.Now.Year) // El primer automóvil fue creado en 1886
                    throw new ArgumentOutOfRangeException(nameof(Año), value, "El año debe ser un valor válido.");
                año = value;
            }
        }

        public List<string> Accesorios
        {
            get { return accesorios; }
            set => accesorios = value ?? new List<string>();
        }

        public decimal CostoRevision
        {
            get { return costoRevision; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(CostoRevision), value, "El costo de revisión no puede ser negativo.");
                costoRevision = value;
            }
        }

        public decimal CostoMantenimiento
        {
            get { return costoMantenimiento; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(CostoMantenimiento), value, "El costo de mantenimiento no puede ser negativo.");
                costoMantenimiento = value;
            }
        }

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
            CostoRevision = 0; 
            CostoMantenimiento = 0; 
        }

        // Polimorfismo
        public virtual void MostrarInfoVehiculo()
        {
            WriteLine($"{"Modelo:",-28} {Modelo}");
            WriteLine($"{"Placa:",-28} {Placa}");
            WriteLine($"{"Marca:",-28} {Marca}");
            WriteLine($"{"Color:",-28} {Color}");
            WriteLine($"{"Tipo:",-28} {Tipo}");
            WriteLine($"{"Año:",-28} {Año}");
            WriteLine($"{"Propietario:",-28} {Propietario}");
            WriteLine($"{"Accesorios:",-28} {string.Join(", ", Accesorios)}");
            WriteLine($"{"Historial de Mantenimiento:",-28} {string.Join("; ", HistorialMantenimiento)}");
        }
        public virtual double CalcularCostoMantenimiento() => (double)(CostoRevision + CostoMantenimiento); 

        public abstract string ObtenerTipoVehiculo();
    }
}

