using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Model
{
    public class MODRecuperacaoSenha_Usuario
    {
        public int? FkRecuperacao { get; set; }
        public string FkUsuario { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
