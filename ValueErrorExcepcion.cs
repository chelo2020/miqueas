using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaConstructora
{
    public class ValueErrorException : Exception
    {
        public ValueErrorException(string mensaje) : base(mensaje)
        {
        }
    }
}