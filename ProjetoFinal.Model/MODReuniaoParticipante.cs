using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Model
{
    public class MODReuniaoParticipante
    {
        public int IdParticipante { get; set; }
        public int FkDocente { get; set; }
        public int FKReuniao { get; set; }
    }
}
