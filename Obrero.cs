using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaConstructora
{
    public class Obrero : Persona
    {
        public int Legajo { get; set; }
        public double Sueldo { get; set; }
        public string Cargo { get; set; }

        public Obrero(string nombre, string apellido, int dni, int legajo, double sueldo, string cargo) : base(nombre, apellido, dni)
        {
            Legajo = legajo; 
            Sueldo = sueldo; 
            Cargo = cargo;
        }
    }
}
