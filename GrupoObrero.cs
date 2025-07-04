using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaConstructora
{
    public class GrupoObrero
    {
        public int CodigoObra { get; set; }
        public List<Obrero> Obreros { get; set; }

        public GrupoObrero(int codigoObra)
        {
            CodigoObra = codigoObra;
            Obreros = new List<Obrero>();
        }
        public bool EstaLibre()
        {   
            return Obreros.Count == 0;
        }
    }
}
