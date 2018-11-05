using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Model
{
    public class MODEquipamento
    {
        public int IdEquipamento { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime AnoInicio { get; set; }
        public DateTime AnoFim { get; set; }

    }
}
