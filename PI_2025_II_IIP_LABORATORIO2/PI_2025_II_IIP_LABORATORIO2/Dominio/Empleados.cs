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
        public string CodigoEmpleado { get; set; }
        public string AreaEspecializacion { get; set; }
        public Fecha FechaContratacion { get; set; }
        public decimal SalarioBase { get; set; }
        public int TrabajosRealizados { get; set; }
        public bool Activo { get; set; }

        public Empleado(string nombre, string apellido, string numeroTelefono, string correoElectronico,
            string codigoEmpleado, string areaEspecializacion, Fecha fechaContratacion, decimal salarioBase, bool activo)
            : base(nombre, apellido, numeroTelefono, correoElectronico)
        {
            CodigoEmpleado = codigoEmpleado;
            AreaEspecializacion = areaEspecializacion;
            FechaContratacion = fechaContratacion;
            SalarioBase = salarioBase;
            Activo = activo;
        }

        public void AgregarTrabajo()
        {
            TrabajosRealizados++;
        }

        public decimal CalcularComisiones()
        {
            return TrabajosRealizados * 500; // Ejemplo
        }

        public decimal CalcularSalarioNeto()
        {
            return SalarioBase + CalcularComisiones();
        }

        public int CalcularAntiguedad()
        {
            var hoy = DateTime.Now;
            return hoy.Year - FechaContratacion.Año;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Código: {CodigoEmpleado}, Área: {AreaEspecializacion}, Salario: {SalarioBase}, Activo: {Activo}");
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} - Código: {CodigoEmpleado}";
        }
    }
}
