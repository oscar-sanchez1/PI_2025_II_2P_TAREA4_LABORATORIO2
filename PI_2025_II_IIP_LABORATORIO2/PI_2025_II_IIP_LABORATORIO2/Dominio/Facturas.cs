using System;
using System.Collections.Generic;
using PI_2025_II_IIP_LABORATORIO2.objetos;
using static System.Console;

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    public class Factura
    {
        //DECLARACION DE CRACTERISTICAS
        //public string PrimerNombre { get; set; }
        public string cliente { get; set; }
        public List<Servicios> servicios { get; set; } = new List<Servicios>();
        public string dni { get; set; }
        public string rtn { get; set; } = "CONSUMIDOR FINAL";
        public double impuesto { get; set; } = 0.15; // 15% de impuesto
        public DateTime fecha { get; set; } = DateTime.Now;
        public CAI cai { get; set; }
        public double subTotal { get; set; } = 0;
        public double total { get; set; } = 0;
        public double descuento { get; set; } = 0; // Descuento por pronto pago
        public string empleado { get; set; }

        //CONSTRUCTOR
        public Factura(string pCliente, string pDni, CAI pCai, string pEmpleado)
        {
            cliente = pCliente;
            dni = pDni;
            cai = pCai;
            empleado = pEmpleado;

        }

        //METODOS
        public void mostrarFactura()
        {




            WriteLine("------FACTURA------");
            WriteLine($"{cai.NombreNegocio})");
            WriteLine($"{cai.RtnNegocio}");
            WriteLine($"{cliente}");
            WriteLine($"{cai.GenerarNumeroFactura()}");
            WriteLine($"{fecha.ToString()}");
            foreach (var servicio in servicios)
            {
                WriteLine($"{servicio.TipoServicio} ------ {servicio.CostoServicio}");
            }
            WriteLine($"Subtotal: {calcularSubtotal()}");
            if (descuento > 0)
            {
                WriteLine($"Descuento: {descuento}");
            }
            else
            {
                WriteLine("NO APLICA DESCUENTO");
            }


            WriteLine($"IMPUESTO: {(impuesto * 100).ToString()}%");
            WriteLine($"Total: {calcularTotal()}");
            WriteLine($"Servicio realizado por: {empleado}");

        }
        private double calcularSubtotal()
        {
            foreach (var servicio in servicios)
            {

                this.subTotal = this.subTotal + servicio.CostoServicio;
            }
            return this.subTotal;
        }
        private double calcularTotal()
        {
            this.total = this.subTotal * (1.0 + this.impuesto);
            return this.total;
        }

    }







}



