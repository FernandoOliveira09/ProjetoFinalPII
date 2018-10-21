using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using ProjetoFinal.DAL;


namespace ProjetoFinal.BLL
{
    public static class BLLGrupo_Linha_Pesquisa
    {
        public static void InserirLinha(MODGrupoLinha_Pesquisa grupoLinha)
        {
            DALGrupoLinha_Pesquisa.InserirLinha(grupoLinha);
        }

        public static void AlterarDataSaidaLinha(MODGrupoLinha_Pesquisa grupoLinha)
        {
            DALGrupoLinha_Pesquisa.AlterarDataSaidaLinha(grupoLinha);
        }

        public static void ExcluirLinha(MODGrupoLinha_Pesquisa grupoLinha)
        {
            DALGrupoLinha_Pesquisa.ExcluirLinha(grupoLinha);
        }
    }
}
