using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using ProjetoFinal.DAL;
using ProjetoFinal.Utilitarios;
using System.Data;

namespace ProjetoFinal.BLL
{
    public static class BLLPublicacao
    {
        public static void Inserir(MODPublicacao publicacao)
        {
            DALPublicacao.Inserir(publicacao);
        }

        public static DataTable ConsultaPublicacao(MODPublicacao publicacao, string tipoPesquisa)
        {
            return DALPublicacao.ConsultaPublicacao(publicacao, tipoPesquisa);
        }

        public static DataTable ConsultaPorGrupo(MODGrupo grupo)
        {
            return DALPublicacao.ConsultaPorGrupo(grupo);
        }

        public static DataTable ConsultaPorProjeto(MODProjetoPesquisa projetoPesquisa)
        {
            return DALPublicacao.ConsultaPorProjeto(projetoPesquisa);
        }

        public static DataTable Relatorio(MODPublicacao publicacao, string ano, string tipoPesquisa)
        {
            return DALPublicacao.Relatorio(publicacao, ano, tipoPesquisa);
        }
    }
}
