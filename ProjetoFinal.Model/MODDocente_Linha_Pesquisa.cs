using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Model
{
    public class MODDocente_Linha_Pesquisa
    {
        public int FkGrupo { get; set; }
        public int FkDocente { get; set; }
        public string FkLinha { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
    }
}
