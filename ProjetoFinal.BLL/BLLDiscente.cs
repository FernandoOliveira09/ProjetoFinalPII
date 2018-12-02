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
    public static class BLLDiscente
    {
        public static void InserirDiscente(MODDiscente discente)
        {
            DALDiscente.InserirDiscente(discente);
        }

        public static void InserirDiscenteProjeto(MODProjetoPesquisa_Discente projetoDiscente)
        {
            DALDiscente.InserirDiscenteProjeto(projetoDiscente);
        }

        public static void Alterar(MODDiscente discente)
        {
            DALDiscente.Alterar(discente);
        }

        public static MODDiscente PesquisarDiscente(MODDiscente discente, string tipoPesquisa)
        {
            return DALDiscente.PesquisarDiscente(discente, tipoPesquisa);
        }

        public static List<MODDiscente> Pesquisar(MODDiscente discente, string tipoPesquisa)
        {
            return DALDiscente.Pesquisar(discente, tipoPesquisa);
        }

        public static DataTable PesquisarPorGrupo(MODGrupo grupo)
        {
            return DALDiscente.PesquisarPorGrupo(grupo);
        }

        public static void AlterarVinculoProjeto(MODProjetoPesquisa_Discente projetoDiscente)
        {
            DALDiscente.AlterarVinculoProjeto(projetoDiscente);
        }

        public static DataTable PesquisarProjeto(MODProjetoPesquisa_Discente projetoDiscente, string tipoPesquisa)
        {
            return DALDiscente.PesquisarProjeto(projetoDiscente, tipoPesquisa);
        }
    }
}
