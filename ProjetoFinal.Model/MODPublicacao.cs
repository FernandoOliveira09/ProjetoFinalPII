using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Model
{
    public class MODPublicacao
    {
        public int IdPublicacao { get; set; }
        public string Titulo { get; set; }
        public string TipoPublicacao { get; set; }
        public string ReferenciaABNT { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int FkGrupo { get; set; }
        public int FKProjeto { get; set; }
        public int FkLinha { get; set; }
        public int FkDocente { get; set; }
    }
}
