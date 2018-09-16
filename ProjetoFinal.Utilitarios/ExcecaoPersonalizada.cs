using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Utilitarios
{
    public class ExcecaoPersonalizada : Exception
    {
        public ExcecaoPersonalizada(string msg) : base(msg) { }
    }
}
