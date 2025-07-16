using System;
using static System.Console;

namespace PI_2025_II_IIP_LABORATORIO2
{
    public interface IGeneradorCAI
    {
        string GenerarNumeroFactura();
    }

    public class CAI : IGeneradorCAI
    {
        public string NumeroCai { get; private set; }
        public int RangoInicial { get; private set; }
        public int RangoFinal { get; private set; }
        public DateTime FechaLimiteEmision { get; private set; }
        public int NumeroDeFactura { get; private set; } = 0;
        public string RtnNegocio { get; private set; }
        public string NombreNegocio { get; private set; }

        public CAI()
        {
            WriteLine("CONFIGURANDO CAI");

            // VALIDACIÓN DE RANGO INICIAL
            while (true)
            {
                WriteLine("INGRESE EL RANGO INICIAL");
                try
                {
                    RangoInicial = int.Parse(ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    WriteLine("ERROR: EL VALOR INGRESADO NO ES UN NÚMERO ENTERO.");
                    WriteLine(e.Message.ToUpper());
                }
                catch (Exception e)
                {
                    WriteLine("ERROR INESPERADO AL INGRESAR EL RANGO INICIAL.");
                    WriteLine(e.Message.ToUpper());
                }
            }

            // VALIDACIÓN DE RANGO FINAL
            while (true)
            {
                WriteLine("INGRESE EL RANGO FINAL");
                try
                {
                    RangoFinal = int.Parse(ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    WriteLine("ERROR: EL VALOR INGRESADO NO ES UN NÚMERO ENTERO.");
                    WriteLine(e.Message.ToUpper());
                }
                catch (Exception e)
                {
                    WriteLine("ERROR INESPERADO AL INGRESAR EL RANGO FINAL.");
                    WriteLine(e.Message.ToUpper());
                }
            }

            // VALIDACIÓN DE FECHA LÍMITE
            while (true)
            {
                WriteLine("INGRESE LA FECHA LÍMITE DE EMISIÓN (DD/MM/AAAA)");
                try
                {
                    FechaLimiteEmision = DateTime.Parse(ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    WriteLine("ERROR: EL FORMATO DE FECHA ES INCORRECTO.");
                    WriteLine(e.Message.ToUpper());
                }
                catch (Exception e)
                {
                    WriteLine("ERROR INESPERADO AL INGRESAR LA FECHA.");
                    WriteLine(e.Message.ToUpper());
                }
            }

            // VALIDACIÓN DE RTN
            while (true)
            {
                WriteLine("INGRESE EL RTN DEL NEGOCIO");
                try
                {
                    string rtn = ReadLine();
                    if (!string.IsNullOrWhiteSpace(rtn))
                    {
                        RtnNegocio = rtn;
                        break;
                    }
                    else
                    {
                        WriteLine("ERROR: EL RTN NO PUEDE ESTAR VACÍO.");
                    }
                }
                catch (Exception e)
                {
                    WriteLine("ERROR INESPERADO AL INGRESAR EL RTN.");
                    WriteLine(e.Message.ToUpper());
                }
            }

            // VALIDACIÓN DE NOMBRE DEL NEGOCIO
            while (true)
            {
                WriteLine("INGRESE EL NOMBRE DEL NEGOCIO");
                try
                {
                    string nombre = ReadLine();
                    if (!string.IsNullOrWhiteSpace(nombre))
                    {
                        NombreNegocio = nombre;
                        break;
                    }
                    else
                    {
                        WriteLine("ERROR: EL NOMBRE NO PUEDE ESTAR VACÍO.");
                    }
                }
                catch (Exception e)
                {
                    WriteLine("ERROR INESPERADO AL INGRESAR EL NOMBRE.");
                    WriteLine(e.Message.ToUpper());
                }
            }
        }

        public bool VerificarSiHayRangoDisponible()
        {
            if (NumeroDeFactura < (RangoFinal - RangoInicial + 1))
            {
                return true;
            }

            WriteLine("RANGO EXCEDIDO. ACTUALIZANDO 100 MÁS.");
            RangoInicial = RangoFinal + 1;
            RangoFinal = RangoInicial + 99;
            NumeroDeFactura = 0;
            return false;
        }

        public void AumentarNumeroFactura()
        {
            NumeroDeFactura++;
        }

        public void DisminuirNumeroFactura()
        {
            if (NumeroDeFactura > 0)
                NumeroDeFactura--;
        }

        public string GenerarNumeroFactura()
        {
            if (VerificarSiHayRangoDisponible())
            {
                AumentarNumeroFactura();
                string factura = "001-001-01" + NumeroDeFactura.ToString("D8");
                NumeroCai = factura;
                return factura;
            }

            WriteLine("NO SE PUEDE GENERAR MÁS FACTURAS POR AHORA.");
            return "";
        }

        public void ImprimirRangoInicialFinal()
        {
            WriteLine($"RANGO INICIAL: 001-001-01{RangoInicial:D8}");
            WriteLine($"RANGO FINAL:   001-001-01{RangoFinal:D8}");
        }
    }
}
