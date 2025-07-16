
using PI_2025_II_IIP_LABORATORIO2.Dominio;
using PI_2025_II_IIP_LABORATORIO2.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    public class OrdenTrabajo
    {
        public string NumeroOrden {  get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaFinalización { get; set; }
        public Clientes Clientes { get; set; }
        public Carros Carros { get; set; }
        public Empleado EmpleadoAsignado { get; set; }
        public List<Servicios> Servicios { get; set; }
        public string Estado { get; set; } 
        public string Observaciones { get; set; }

        public OrdenTrabajo()
        {
            Servicios = new List<Servicios>();
            FechaCreacion = DateTime.Now;
            Estado = "Pendiente";
        }

        public void MostrarOrden()
        {
            WriteLine($"\n ORDEN DE TRABAJO #{NumeroOrden}");
            WriteLine($"{"Fecha de Creación:",-28} {FechaCreacion}");
            WriteLine($"{"Estado:",-28} {Estado}");
            WriteLine($"{"Cliente:",-28} {Clientes}");
            WriteLine($"{"Carro:",-28} {Carros.Modelo}, {Carros.Marca},{Carros.Color}, con placa: {Carros.Placa} )");
            WriteLine($"{"Empleado Asignado:",-28} {EmpleadoAsignado.Nombre}");
            WriteLine($"{"Servicios:",-28} {Servicios.Count} servicios asignados");
            WriteLine ($"{"Costo Total:",-28} {Servicios.Sum(s => s.CostoServicio):C}");

            WriteLine("\nServicios:");
            foreach (var servicio in Servicios)
            {
                WriteLine($"- {servicio.TipoServicio} ({servicio.CostoServicio:C})");
            }


        }

        


    }
}
