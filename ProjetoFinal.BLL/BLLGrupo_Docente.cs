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
    public static class BLLGrupo_Docente
    {
        public static void InserirDocente(MODGrupoDocente grupoDocente)
        {
            DALGrupo_Docente.InserirDocente(grupoDocente);
        }

        public static void AlterarDataSaidaDocente(MODGrupoDocente grupoDocente)
        {
            DALGrupo_Docente.AlterarDataSaidaDocente(grupoDocente);
        }

        public static void ExcluirDocente(MODGrupoDocente grupoDocente)
        {
            DALGrupo_Docente.ExcluirDocente(grupoDocente);
        }

        public static DataTable Pesquisar(MODGrupoDocente grupoDocente, string tipoPesquisa)
        {
            return DALGrupo_Docente.Pesquisar(grupoDocente, "ativos");
        }
    }
}
