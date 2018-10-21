using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Model
{
    public class MODGrupoTecnico
    {
        public int FkGrupo { get; set; }
        public int FkTecnico { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
    }
}
