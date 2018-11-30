using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Model
{
    public class MODReuniaoConvidado
    {
        public int IdConvidado { get; set; }
        public string Nome { get; set; }
        public int FkReuniao { get; set; }
    }
}
