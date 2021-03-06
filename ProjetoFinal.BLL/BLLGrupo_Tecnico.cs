﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using ProjetoFinal.DAL;
using System.Data;

namespace ProjetoFinal.BLL
{
    public static class BLLGrupo_Tecnico
    {
        public static void InserirTecnico(MODGrupoTecnico grupoTecnico)
        {
            DALGrupo_Tecnico.InserirTecnico(grupoTecnico);
        }

        public static void AlterarDataSaidaTecnico(MODGrupoTecnico grupoTecnico)
        {
            DALGrupo_Tecnico.AlterarDataSaidaTecnico(grupoTecnico);
        }

        public static void ExcluirTecnico(MODGrupoTecnico grupoTecnico)
        {
            DALGrupo_Tecnico.ExcluirTecnico(grupoTecnico);
        }

        public static DataTable Pesquisar(MODGrupoTecnico grupoTecnico, string tipoPesquisa)
        {
            return DALGrupo_Tecnico.Pesquisar(grupoTecnico, tipoPesquisa);
        }
    }
}
