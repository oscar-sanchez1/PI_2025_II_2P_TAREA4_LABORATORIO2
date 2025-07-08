using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2025_II_2P_Taller.Objetos
{
    public class Material
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public decimal Costo { get; set; }
        public string Estado { get; set; }
        public int Cantidad { get; set; }
        public string Marca { get; set; }
        public List<Material> Materiales { get; private set; }
        public List<string> Descripciones { get; set; }

        public Material()
        {
            Descripciones = new List<string>();
        }

        public void AgregarDescripcion(string descripcion)
        {
            if (!string.IsNullOrWhiteSpace(descripcion))
            {
                Descripciones.Add(descripcion);
            }
        }

        public void MostrarInfoMaterial()
        {
            Console.WriteLine($"\n=== Información del Material ===");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine($"Costo: {Costo:C}");
            Console.WriteLine($"Estado: {Estado}");
            Console.WriteLine($"Cantidad: {Cantidad}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Descripciones: {(Descripciones.Count > 0 ? string.Join("\n  - ", Descripciones) : "Ninguna")}");
        }
        public void MostrarTodosMateriales()
        {
            if (Materiales.Count == 0)
            {
                Console.WriteLine("\nNo hay materiales registrados.");
                return;
            }

            foreach (var material in Materiales)
            {
                material.MostrarInfoMaterial();
                Console.WriteLine("----------------------------");
            }
        }
    }
}

    
