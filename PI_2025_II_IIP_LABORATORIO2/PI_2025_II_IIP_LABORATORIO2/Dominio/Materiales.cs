using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PI_2025_II_2P_taller.Objetos
{
    public class Materiales
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public decimal Costo { get; set; }
        public string Estado { get; set; }
        public int Cantidad { get; set; }
        public string Marca { get; set; }
        public List<string> Descripciones { get; set; }

        public Materiales(string pNombre, string pTipo, decimal pCosto, string pEstado,
            int pCantidad, string pMArca)

        {
            Nombre = pNombre;
            Tipo = pTipo;
            Costo = pCosto;
            Estado = pEstado;
            Cantidad = pCantidad;
            Marca = pMArca;

            Descripciones = new List<string>();
        }

        public void AgregarDescripcion(string descripcion)
        {
            if (!string.IsNullOrWhiteSpace(descripcion))
            {
                Descripciones.Add(descripcion);
            }
        }

        public decimal CalcularValorTotal()
        {
            return Costo * Cantidad;
        }

        public void ActualizarCantidad(int nuevaCantidad)
        {
            if (nuevaCantidad >= 0)
            {
                Cantidad = nuevaCantidad;
                Estado = nuevaCantidad > 0 ? "Disponible" : "Agotado";
            }
        }
        public void MostrarInfoMateriales()
        {
            WriteLine($"\n=== Información del Material ===");
            WriteLine($"Nombre: {Nombre}");
            WriteLine($"Tipo: {Tipo}");
            WriteLine($"Costo: {Costo:C}");
            WriteLine($"Estado: {Estado}");
            WriteLine($"Cantidad: {Cantidad}");
            WriteLine($"Marca: {Marca}");
            WriteLine($"Descripciones: {(Descripciones.Count > 0 ? string.Join("\n  - ", Descripciones) : "Ninguna")}");
        }

        // Corrección: este método ahora recibe la lista de materiales como parámetro
        public static void MostrarTodosMateriales(List<Materiales> listaMateriales)
        {
            if (listaMateriales == null || listaMateriales.Count == 0)
            {
                WriteLine("\nNo hay materiales registrados.");
                return;
            }

            foreach (var material in listaMateriales)
            {
                material.MostrarInfoMateriales();
                WriteLine("----------------------------");
            }
        }

        public override string ToString()=>
             $"Nombre:{Nombre} " +
             $"Tipo: {Tipo} " +
            $"Estado: {Estado} ." +
            $"Cantidad: {Cantidad} " +
            $"Costo: {Costo:C}";
        

    }
}
