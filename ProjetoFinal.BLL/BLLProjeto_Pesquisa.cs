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

        public static DataTable PesquisarLinha(MODProjetoPesquisa_Linha projetoLinha)
        {
            return DALProjeto_Pesquisa.PesquisarLinha(projetoLinha);
        }

        public static MODProjetoPesquisa PesquisarDocente(MODProjetoPesquisa projetoPesquisa)
        {
            return DALProjeto_Pesquisa.PesquisarDocente(projetoPesquisa);
        }

        public static List<MODProjetoPesquisa> PesquisarProjetos(MODProjetoPesquisa item, string tipoPesquisa)
        {
            return DALProjeto_Pesquisa.PesquisarProjetos(item, tipoPesquisa);
        }

        public static DataTable ConsultaProjetos(MODProjetoPesquisa projeto, string tipoPesquisa)
        {
            return DALProjeto_Pesquisa.ConsultaProjetos(projeto, tipoPesquisa);
        }

        public static DataTable ConsultaPorGrupo(MODGrupo grupo)
        {
            return DALProjeto_Pesquisa.ConsultaPorGrupo(grupo);
        }
    }
}
