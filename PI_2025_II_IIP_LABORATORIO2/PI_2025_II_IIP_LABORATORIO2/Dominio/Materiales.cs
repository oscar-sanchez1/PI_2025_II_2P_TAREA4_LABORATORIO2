using System;
using System.Collections.Generic;
using static System.Console;

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    public class Materiales
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public decimal Costo { get; set; }
        public string Estado { get; set; }
        public int Cantidad { get; set; }
        public string Marca { get; set; }
        public List<string> Descripciones { get; set; } = new List<string>();

        public Materiales(string pNombre, string pTipo, decimal pCosto, string pEstado, int pCantidad, string pMarca)
        {
            Nombre = pNombre;
            Tipo = pTipo;
            Costo = pCosto;
            Estado = pEstado;
            Cantidad = pCantidad;
            Marca = pMarca;
        }

        public void AgregarDescripcion(string descripcion)
        {
            Descripciones.Add(descripcion);
        }

        public decimal CalcularValorTotal()
        {
            return Costo * Cantidad;
        }

        public void ActualizarCantidad(int nuevaCantidad)
        {
            Cantidad = nuevaCantidad;
        }

        public void MostrarInfoMateriales()
        {
            Console.WriteLine($"{Nombre} ({Tipo}) - Marca: {Marca}, Estado: {Estado}, Cantidad: {Cantidad}, Costo: {Costo}");
        }

        public static void MostrarTodosMateriales(List<Materiales> listaMateriales)
        {
            foreach (var m in listaMateriales)
                m.MostrarInfoMateriales();
        }

        public override string ToString()
        {
            return $"{Nombre} - {Tipo} - {Marca}";
        }
    }
}

