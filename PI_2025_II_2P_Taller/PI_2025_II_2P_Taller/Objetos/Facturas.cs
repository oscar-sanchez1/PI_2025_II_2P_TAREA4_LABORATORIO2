using System;
using System.Collections.Generic;
using static System.Console;

namespace PI_2025_II_2P_Taller.Objetos
{
    internal class Factura
    {
        // Atributos
        private string dni;
        private string nombreCliente;
        private string nombreEmpleado;
        private decimal subtotal;
        private decimal impuesto;
        private decimal total;
        private DateTime fecha;
        private List<Servicios> serviciosFactura;

        // Lista para almacenar facturas
        private static List<Factura> listaFacturas = new List<Factura>();

        // Propiedades
        public string Dni { get => dni; set => dni = value; }
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string NombreEmpleado { get => nombreEmpleado; set => nombreEmpleado = value; }
        public decimal Subtotal { get => subtotal; }
        public decimal Impuesto { get => impuesto; set => impuesto = value; }
        public decimal Total { get => total; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public List<Servicios> ServiciosFactura { get => serviciosFactura; }

        // Constructor (recibe lista de servicios)
        public Factura(string dni, string nombreCliente, string nombreEmpleado, decimal impuesto, List<Servicios> servicios)
        {
            this.dni = dni;
            this.nombreCliente = nombreCliente;
            this.nombreEmpleado = nombreEmpleado;
            this.impuesto = impuesto;
            this.fecha = DateTime.Now;
            this.serviciosFactura = servicios;

            // Calcular subtotal sumando costos de servicios
            this.subtotal = 0;
            foreach (var s in servicios)
            {
                this.subtotal += s.CostoServicio;
            }

            // Calcular total (subtotal + impuesto)
            this.total = subtotal + (subtotal * impuesto);
        }

        // Crear factura pidiendo servicios por consola
        public static void CrearFactura(List<Servicios> serviciosDisponibles)
        {
            try
            {
                Write("INGRESE EL NOMBRE DEL CLIENTE: ");
                string nombreCliente = ReadLine();

                Write("INGRESE EL DNI: ");
                string dni = ReadLine();

                Write("INGRESE EL NOMBRE DEL EMPLEADO: ");
                string nombreEmpleado = ReadLine();

                Write("INGRESE EL IMPUESTO (EJ: 0.15): ");
                decimal impuesto = Convert.ToDecimal(ReadLine());

                // Mostrar servicios disponibles
                if (serviciosDisponibles.Count == 0)
                {
                    WriteLine("NO HAY SERVICIOS DISPONIBLES PARA FACTURAR.");
                    return;
                }

                WriteLine("SERVICIOS DISPONIBLES:");
                for (int i = 0; i < serviciosDisponibles.Count; i++)
                {
                    WriteLine($"{i + 1}. {serviciosDisponibles[i].TipoServicio} - {serviciosDisponibles[i].CostoServicio:C}");
                }

                List<Servicios> serviciosSeleccionados = new List<Servicios>();
                bool continuar = true;

                while (continuar)
                {
                    Write("INGRESE EL NÚMERO DEL SERVICIO A AGREGAR (0 PARA TERMINAR): ");
                    if (int.TryParse(ReadLine(), out int opcion))
                    {
                        if (opcion == 0)
                        {
                            continuar = false;
                        }
                        else if (opcion > 0 && opcion <= serviciosDisponibles.Count)
                        {
                            serviciosSeleccionados.Add(serviciosDisponibles[opcion - 1]);
                            WriteLine("SERVICIO AGREGADO.");
                        }
                        else
                        {
                            WriteLine("OPCIÓN INVÁLIDA.");
                        }
                    }
                    else
                    {
                        WriteLine("ENTRADA INVÁLIDA, INGRESE UN NÚMERO.");
                    }
                }

                if (serviciosSeleccionados.Count == 0)
                {
                    WriteLine("NO SE SELECCIONARON SERVICIOS. FACTURA NO CREADA.");
                    return;
                }

                Factura factura = new Factura(dni, nombreCliente, nombreEmpleado, impuesto, serviciosSeleccionados);
                listaFacturas.Add(factura);

                WriteLine("FACTURA CREADA CON ÉXITO.");
            }
            catch (FormatException ex)
            {
                WriteLine($"ERROR DE FORMATO: {ex.Message.ToUpper()}");
            }
            catch (Exception ex)
            {
                WriteLine($"ERROR AL CREAR FACTURA: {ex.Message.ToUpper()}");
            }
        }

        // Imprimir factura con servicios detallados
        public void ImprimirFactura()
        {
            WriteLine("-----------------------------");
            WriteLine($"CLIENTE: {nombreCliente.ToUpper()}");
            WriteLine($"DNI: {dni}");
            WriteLine($"EMPLEADO: {nombreEmpleado.ToUpper()}");
            WriteLine($"FECHA: {fecha}");
            WriteLine("SERVICIOS FACTURADOS:");
            foreach (var s in serviciosFactura)
            {
                WriteLine($"- {s.TipoServicio.ToUpper()} : {s.CostoServicio:C}");
            }
            WriteLine($"SUBTOTAL: {subtotal:C}");
            WriteLine($"IMPUESTO: {impuesto:P}");
            WriteLine($"TOTAL: {total:C}");
            WriteLine("-----------------------------");
        }

        // Otros métodos para buscar, imprimir por fechas, etc., se pueden adaptar igual
    }
}
