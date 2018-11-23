using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Model
{
    public class MODReuniao
    {
        public int IdReuniao { get; set; }
        public string Pauta { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public string Ata { get; set; }
        public DateTime DataReuniao { get; set; }
        public int FkGrupo { get; set; }

    }
}
