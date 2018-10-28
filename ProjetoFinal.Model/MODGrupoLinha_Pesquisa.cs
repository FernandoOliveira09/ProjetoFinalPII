using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Model
{
    public class MODGrupoLinha_Pesquisa
    {
        public int FkGrupo { get; set; }
        public string FkLinha { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public string Descricao { get; set; }
    }
}
