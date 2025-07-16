using System;

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    // Clase Base1
    public class Personas
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroTelefono { get; set; }
        public string CorreoElectronico { get; set; }

        public Personas(string nombre, string apellido, string numeroTelefono, string correoElectronico)
        {
            Nombre = nombre;
            Apellido = apellido;
            NumeroTelefono = numeroTelefono;
            CorreoElectronico = correoElectronico;
        }

        // Polimorfismo
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre} {Apellido}");
            Console.WriteLine($"Teléfono: {NumeroTelefono}");
            Console.WriteLine($"Correo: {CorreoElectronico}");
        }
    }
}
