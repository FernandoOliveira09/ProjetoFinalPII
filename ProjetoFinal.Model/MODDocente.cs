using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Model
{
    public class MODDocente
    {
        public int IdDocente { get; set; }
        public string Nome { get; set; }
        public string Formacao { get; set; }
        public string Lattes { get; set; }
        public string Curso { get; set; }
        public string Foto { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
