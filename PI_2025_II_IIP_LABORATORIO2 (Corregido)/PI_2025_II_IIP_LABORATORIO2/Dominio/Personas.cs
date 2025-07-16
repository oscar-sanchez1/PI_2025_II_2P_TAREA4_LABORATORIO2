using System;

namespace PI_2025_II_IIP_LABORATORIO2.objetos
{
    // Clase Base1
    public class Personas
    {
        private string nombre;
        private string apellido;
        private string numeroTelefono;
        private string correoElectronico;

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

        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El apellido no puede estar vacío o ser nulo.");
                apellido = value;
            }
        }

        public string NumeroTelefono
        {
            get { return numeroTelefono; }
            set
            {
                if (value.Length != 8 || !long.TryParse(value, out _))
                    throw new ArgumentException("El número de teléfono debe contener exactamente 8 dígitos.");
                numeroTelefono = value;
            }
        }

        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                    throw new ArgumentException("El correo electrónico no puede estar vacío y debe contener un '@'.");
                correoElectronico = value;
            }
        }

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
            Console.WriteLine($"Correo Electrónico: {CorreoElectronico}");
        }
    }
}
