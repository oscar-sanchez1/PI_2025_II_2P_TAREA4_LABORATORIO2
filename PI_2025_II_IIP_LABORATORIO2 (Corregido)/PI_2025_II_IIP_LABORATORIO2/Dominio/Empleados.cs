using PI_2025_II_IIP_LABORATORIO2.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    // Clase Derivada2
    public class Empleado : Personas
    {
        private string codigoEmpleado;
        private string areaEspecializacion;
        private decimal salarioBase;
        private int trabajosRealizados;

        public string CodigoEmpleado
        {
            get { return codigoEmpleado; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El código de empleado no puede estar vacío o ser nulo.");
                codigoEmpleado = value;
            }
        }

        public string AreaEspecializacion
        {
            get { return areaEspecializacion; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El área de especialización no puede estar vacía o ser nula.");
                areaEspecializacion = value;
            }
        }

        public Fecha FechaContratacion { get; set; } // Se mantiene como está

        public decimal SalarioBase
        {
            get { return salarioBase; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El salario base no puede ser negativo.");
                salarioBase = value;
            }
        }

        public int TrabajosRealizados
        {
            get { return trabajosRealizados; }
            private set { trabajosRealizados = value; } // Solo se puede modificar internamente
        }

        public bool Activo { get; private set; }

        public Empleado(string nombre, string apellido, string numeroTelefono, string correoElectronico,
                       string codigoEmpleado, string areaEspecializacion,
                       Fecha fechaContratacion, decimal salarioBase, bool activo)
            : base(nombre, apellido, numeroTelefono, correoElectronico)
        {
            CodigoEmpleado = codigoEmpleado; // Utiliza la propiedad con validación
            AreaEspecializacion = areaEspecializacion; // Utiliza la propiedad con validación
            FechaContratacion = fechaContratacion; // Se mantiene como está
            SalarioBase = salarioBase; // Utiliza la propiedad con validación
            TrabajosRealizados = 0; // Inicializa a 0
            Activo = activo; // Se asigna directamente
        }

        public void AgregarTrabajo()
        {
            if (!Activo)
                throw new InvalidOperationException("No se pueden agregar trabajos a un empleado inactivo.");

            TrabajosRealizados++;
        }

        public decimal CalcularComisiones()
        {
            return TrabajosRealizados * 50;
        }

        public decimal CalcularSalarioNeto()
        {
            return SalarioBase + CalcularComisiones();
        }

        public int CalcularAntiguedad()
        {
            int antiguedad = DateTime.Now.Year - FechaContratacion.Año;
            if (DateTime.Now.Month < FechaContratacion.Mes ||
                (DateTime.Now.Month == FechaContratacion.Mes && DateTime.Now.Day < FechaContratacion.Dia))
                antiguedad--;
            return antiguedad;
        }

        //Polimorfio
        public override void MostrarInformacion()
        {
            base.MostrarInformacion(); // Llama a la implementación base Personas
            WriteLine($"Código: {CodigoEmpleado}");
            WriteLine($"Área: {AreaEspecializacion}");
            WriteLine($"Fecha Contratación: {FechaContratacion}");
            WriteLine($"Antigüedad: {CalcularAntiguedad()} años");
            WriteLine($"Salario Base: L. {SalarioBase:C}");
            WriteLine($"Trabajos Realizados: {TrabajosRealizados}");
            WriteLine($"Comisiones: L. {CalcularComisiones():C}");
            WriteLine($"Salario Neto: L. {CalcularSalarioNeto():C}");
            WriteLine($"Estado: {(Activo ? "Activo" : "Inactivo")}");
        }

        public override string ToString() =>
            $"Empleado: {Nombre} {Apellido} | " +
            $"Código: {CodigoEmpleado} | " +
            $"Área: {AreaEspecializacion} | " +
            $"Salario: {SalarioBase:C}";
    }
}
