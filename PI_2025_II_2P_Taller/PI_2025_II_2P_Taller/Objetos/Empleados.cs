using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2025_II_2P_Taller.Objetos
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public string CodigoEmpleado { get; set; }
        public string AreaEspecializacion { get; set; }
        public DateTime FechaContratacion { get; set; }
        public decimal SalarioBase { get; set; }
        public int TrabajosRealizados { get; set; }
        public bool Activo { get; private set; }

        public Empleado(decimal salarioBase, DateTime fechaContratacion)
        {
            if (salarioBase < 0)
                throw new ArgumentException("El salario base no puede ser negativo.");

            if (fechaContratacion > DateTime.Now)
                throw new ArgumentException("La fecha de contratación no puede ser en el futuro.");

            SalarioBase = salarioBase;
            FechaContratacion = fechaContratacion;
            TrabajosRealizados = 0;
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
            if (SalarioBase < 0)
                throw new InvalidOperationException("El salario base tiene que ser mayor o igual que cero.");

            return SalarioBase + CalcularComisiones();
        }

        public int CalcularAntiguedad()
        {
            if (FechaContratacion > DateTime.Now)
                throw new InvalidOperationException("La fecha de contratación es inválida.");

            int antiguedad = DateTime.Now.Year - FechaContratacion.Year;
            if (DateTime.Now.Date < FechaContratacion.AddYears(antiguedad)) antiguedad--;
            return antiguedad;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"\n=== Información del Empleado ===");
            Console.WriteLine($"Código: {CodigoEmpleado}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Área: {AreaEspecializacion}");
            Console.WriteLine($"Fecha Contratación: {FechaContratacion:dd/MM/yyyy}");
            Console.WriteLine($"Antigüedad: {CalcularAntiguedad()} años");
            Console.WriteLine($"Salario Base: L. {SalarioBase:C}");
            Console.WriteLine($"Trabajos Realizados: {TrabajosRealizados}");
            Console.WriteLine($"Comisiones: L. {CalcularComisiones():C}");
            Console.WriteLine($"Salario Neto: L. {CalcularSalarioNeto():C}");
        }
    }
}


