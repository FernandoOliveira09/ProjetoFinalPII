using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Model
{
    public class MODProjetoPesquisa
    {
        public int IdProjeto { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public string Bolsa { get; set; }
        public string NomeBolsa { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int FkDocente { get; set; }
        public int FkGrupo { get; set; }
    }
}
