using System;
using System.Collections.Generic;
using static System.Console;

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    public class Materiales
    {
        private string nombre;
        private string tipo;
        private decimal costo;
        private string estado;
        private int cantidad;
        private string marca;
        private List<string> descripciones;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío o ser nulo.");
                nombre = value;
            }
        }

        public string Tipo
        {
            get { return tipo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El tipo no puede estar vacío o ser nulo.");
                tipo = value;
            }
        }

        public decimal Costo
        {
            get { return costo; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Costo), value, "El costo no puede ser negativo.");
                costo = value;
            }
        }

        public string Estado
        {
            get { return estado; }
            private set { estado = value; } 
        }

        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Cantidad), value, "La cantidad no puede ser negativa.");
                cantidad = value;
                Estado = cantidad > 0 ? "Disponible" : "Agotado";
            }
        }

        public string Marca
        {
            get { return marca; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La marca no puede estar vacía o ser nula.");
                marca = value;
            }
        }

        public List<string> Descripciones
        {
            get { return descripciones; }
            set => descripciones = value ?? new List<string>();
        }

        public Materiales(string pNombre, string pTipo, decimal pCosto, string pEstado,
            int pCantidad, string pMarca)
        {
            Nombre = pNombre; 
            Tipo = pTipo; 
            Costo = pCosto; 
            Estado = pEstado; 
            Cantidad = pCantidad; 
            Marca = pMarca; 

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

        public override string ToString() =>
            $"Nombre: {Nombre} " +
            $"Tipo: {Tipo} " +
            $"Estado: {Estado} " +
            $"Cantidad: {Cantidad} " +
            $"Costo: {Costo:C}";
    }
}

