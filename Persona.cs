using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaConstructora
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }

        public Persona(string nombre, string apellido, int dni)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
        }

    }
}
