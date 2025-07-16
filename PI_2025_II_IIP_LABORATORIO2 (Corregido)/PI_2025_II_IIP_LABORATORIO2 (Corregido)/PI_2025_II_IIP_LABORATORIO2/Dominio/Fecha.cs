using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PI_2025_II_IIP_LABORATORIO2.Dominio
{
    public class Fecha
    {

        public int Año;  
        private int mes; 
        private int dia; 

        public Fecha(int pDia, int pMes, int pAño)
        {
            Año = pAño;
            Mes = pMes;
            Dia = pDia;
        }

        public int Mes
        {
            get { return mes; }
            set
            {
                if (value <= 0 || value > 12)
                {
                    throw new ArgumentOutOfRangeException(nameof(Mes), value, $"{nameof(Mes)} debería de estar entre 1 y 12.");
                }
                mes = value;
            }
        }
        public int Dia
        {
            get { return dia; }
            set
            {
                int[] díasPorMes =
                {
                    0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
                };
                if (value <= 0 || value > díasPorMes[mes])
                {
                    throw new ArgumentOutOfRangeException(nameof(Dia), value, $"{nameof(Dia)} el rango está fuera para este mes/año.");
                }
                if (
                    (Mes == 2 && value == 29) &&
                    !((Año % 4 == 0) && (Año % 100 != 0 || Año % 400 == 0))
                   )
                {
                    throw new ArgumentOutOfRangeException(nameof(Dia), value, $"{nameof(Dia)} el rango está fuera de este mes/año.");
                }
                dia = value;
            }
        }

        public override string ToString() => $"{Dia:D2}/{Mes:D2}/{Año:D4}"; 
    }
}
