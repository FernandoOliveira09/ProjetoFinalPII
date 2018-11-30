using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Model
{
    public class MODAta
    {
        public int IdAta { get; set; }
        public string Ata { get; set; }
        public int FkReuniao { get; set; }
    }
}
