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
        public static int Inserir(MODProjetoPesquisa projetoPesquisa)
        {
            return DALProjeto_Pesquisa.Inserir(projetoPesquisa);
        }

        public static void InserirLinha(MODProjetoPesquisa_Linha projetoLinha)
        {
            DALProjeto_Pesquisa.InserirLinha(projetoLinha);
        }

        public static MODProjetoPesquisa_Linha PesquisarLinha(MODProjetoPesquisa_Linha projetoLinha)
        {
            return DALProjeto_Pesquisa.PesquisarLinha(projetoLinha);
        }
    }
}
