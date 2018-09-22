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

        public static DataTable Pesquisar(MODGrupoLider grupoLider)
        {
            return DALGrupo.Pesquisar(grupoLider);
        }
    }
}
