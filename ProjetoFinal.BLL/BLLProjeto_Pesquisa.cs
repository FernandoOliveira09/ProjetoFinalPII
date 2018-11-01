using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using ProjetoFinal.DAL;
using System.Data;

namespace ProjetoFinal.BLL
{
    public static class BLLProjeto_Pesquisa
    {
        public static void Inserir(MODProjetoPesquisa projetoPesquisa)
        {
            DALProjeto_Pesquisa.Inserir(projetoPesquisa);
        }
    }
}
