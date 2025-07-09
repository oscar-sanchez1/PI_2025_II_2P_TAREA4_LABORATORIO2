using System;
using System.Collections.Generic;
using PI_2025_II_IIP_LABORATORIO2.objetos;

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    public class Factura 
    {
        public string NumeroFactura { get; set; }
        public Clientes Cliente { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaEmision { get; set; }
        public List<Servicios> ServiciosFacturados { get; set; }

        public Factura(string numeroFactura, Clientes cliente, decimal montoTotal, DateTime fechaEmision, List<Servicios> serviciosFacturados = null)
        {
            NumeroFactura = numeroFactura;
            Cliente = cliente;
            MontoTotal = montoTotal;
            FechaEmision = fechaEmision;
            ServiciosFacturados = serviciosFacturados ?? new List<Servicios>();
        }

        public void MostrarFactura()
        {
            Console.WriteLine("=== FACTURA ===");
            Console.WriteLine($"Número: {NumeroFactura}");
            Console.WriteLine($"Cliente: {Cliente?.NombreCompleto}");
            Console.WriteLine($"Fecha: {FechaEmision:dd/MM/yyyy}");
            Console.WriteLine($"Monto total: {MontoTotal:C}");
            if (ServiciosFacturados != null && ServiciosFacturados.Count > 0)
            {
                Console.WriteLine("Servicios:");
                foreach (var servicio in ServiciosFacturados)
                {
                    Console.WriteLine($"- {servicio.TipoServicio} ({servicio.CostoServicio:C})");
                }
            }
        }
    }
}
