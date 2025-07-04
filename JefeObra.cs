using EmpresaConstructora;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaConstructora
{
    public class JefeObra : Obrero
    {
        public double Bonificacion { get; set; }
        public string Obra { get; set; }
        public GrupoObrero Grupos { get; set; }

        public JefeObra(string nombre, string apellido, int dni, int legajo, double sueldo, string cargo, double bonificacion, string obra, GrupoObrero grupos):base(nombre, apellido, dni, legajo, sueldo, cargo)
        {
            Bonificacion = bonificacion;
            Obra = obra;
            Grupos = grupos;
        }
    }

}