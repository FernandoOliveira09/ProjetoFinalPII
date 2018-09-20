using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Model
{
    public class MODGrupo
    {
        public int IdGrupo { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string Email { get; set; }
        public string Descricao { get; set; }
        public string Logotipo { get; set; }
        public string Lattes { get; set; }
        public DateTime DataInicio { get; set; }
        public int FkSituacao { get; set; }
    }
}
