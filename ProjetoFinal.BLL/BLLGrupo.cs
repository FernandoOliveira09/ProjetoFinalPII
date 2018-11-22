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
    public static class BLLGrupo
    {
        public static int InserirGrupo(MODGrupo grupo)
        {
            return DALGrupo.InserirGrupo(grupo);
        }

        public static void InserirLider(MODGrupoLider grupoLider)
        {
            DALGrupo.InserirLider(grupoLider);
        }

        public static void AlterarGrupo(MODGrupo grupo, string tipoAlteracao)
        {
            DALGrupo.AlterarGrupo(grupo, tipoAlteracao);
        }

        public static void AlterarLider(MODGrupoLider grupoLider, string tipoAlteracao)
        {
            DALGrupo.AlterarLider(grupoLider, tipoAlteracao);
        }

        public static DataTable Pesquisar(MODGrupoLider grupoLider, string tipoPesquisa)
        {
            return DALGrupo.Pesquisar(grupoLider, tipoPesquisa);
        }

        public static MODGrupo PesquisarGrupo(MODGrupo grupo, string tipoPesquisa)
        {
            return DALGrupo.PesquisarGrupo(grupo, tipoPesquisa);
        }

        public static List<MODGrupo> PesquisarGrupos(MODGrupo item, string tipoPesquisa)
        {
            return DALGrupo.PesquisarGrupos(item, tipoPesquisa);
        }

        public static MODGrupoLider PesquisarLider(MODGrupoLider grupoLider)
        {
            return DALGrupo.PesquisarLider(grupoLider);
        }

        public static DataTable Relatorio(MODGrupo grupo, string ano, string tipoPesquisa)
        {
            return DALGrupo.Relatorio(grupo, ano, tipoPesquisa);
        }
    }
}
