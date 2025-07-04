using EmpresaConstructora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmpresaConstructora
{
    public class Obra
    { 
        public Persona Propietario { get; set; }
        public JefeObra Jefe { get; set; }
        
        public int CodigoObra { get; set; }

        public string TipoObra { get; set; }

        public int AvanceObra { get; set; }

       public double CostoObra { get; set; }

        public Obra(Persona propietario, JefeObra jefe, int codigoObra, int avanceObra, double costoObra)
        { 
            Propietario = propietario;
            Jefe = jefe;
            CodigoObra = codigoObra;
            AvanceObra = avanceObra;
            CostoObra = costoObra;
        }

        public bool EstaFinalizado()
        { 
            return AvanceObra >= 100;
        }
    }
}



