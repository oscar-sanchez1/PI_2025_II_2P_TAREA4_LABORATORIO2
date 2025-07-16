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
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }

        public Fecha(int pDia, int pMes, int pAño)
        {
            Dia = pDia;
            Mes = pMes;
            Año = pAño;
        }

        public override string ToString()
        {
            return $"{Dia:D2}/{Mes:D2}/{Año}";
        }
    }
}
