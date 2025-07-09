using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PI_2025_II_2P_taller.Objetos
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

        public Empleado(string pNombre, string pCodigo, 
            string pAreadeEspecializacion, decimal pSalarioBase,
            DateTime pFechaContratacion, int pTrabajosRealizado, bool pActivo)
        {
            if (string.IsNullOrWhiteSpace(pNombre))
                throw new ArgumentException("El nombre no puede estar vacío o ser nulo.");

            if (string.IsNullOrWhiteSpace(pCodigo))
                throw new ArgumentException("El código del empleado no puede estar vacío o ser nulo.");

            if (SalarioBase < 0)
                throw new ArgumentException("El salario base no puede ser negativo.");

            if (FechaContratacion > DateTime.Now)
                throw new ArgumentException("La fecha de contratación no puede ser en el futuro.");

            Nombre = pNombre;
            CodigoEmpleado = pCodigo;
            AreaEspecializacion = pAreadeEspecializacion;
            SalarioBase = pSalarioBase;
            FechaContratacion = pFechaContratacion;
            TrabajosRealizados = 0;
            Activo = pActivo;   
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
            WriteLine($"\n=== Información del Empleado ===");
            WriteLine($"Código: {CodigoEmpleado}");
            WriteLine($"Nombre: {Nombre}");
            WriteLine($"Área: {AreaEspecializacion}");
            WriteLine($"Fecha Contratación: {FechaContratacion:dd/MM/yyyy}");
            WriteLine($"Antigüedad: {CalcularAntiguedad()} años");
            WriteLine($"Salario Base: L. {SalarioBase:C}");
            WriteLine($"Trabajos Realizados: {TrabajosRealizados}");
            WriteLine($"Comisiones: L. {CalcularComisiones():C}");
            WriteLine($"Salario Neto: L. {CalcularSalarioNeto():C}");
        }

        public override string ToString()=>
                $"Empleado {Nombre} " +
                $"Código: {CodigoEmpleado} " +
                $"Área: {AreaEspecializacion} " +
                $"Fecha de Contratación: {FechaContratacion:dd/MM/yyyy} " +
                $"Salario Base: L. {SalarioBase:C} " +
                $"Trabajos Realizados: {TrabajosRealizados} " +
                $"Activo: {(Activo ? "Sí" : "No")}";


    }
}


