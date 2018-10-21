using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Model
{
    public class MODTecnico
    {
        public int IdTecnico { get; set; }
        public string Nome { get; set; }
        public string Lattes { get; set; }
        public string Atividade { get; set; }
        public string Curso { get; set; }
        public string Formacao { get; set; }
        public DateTime AnoConclusao { get; set; }
        public string Foto { get; set; }
    }
}
