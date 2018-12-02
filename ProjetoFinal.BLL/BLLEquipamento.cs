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
    public class BLLEquipamento
    {
        public static void Inserir(MODEquipamento equipamento)
        {
            if (equipamento.Nome.Trim() == "" || equipamento.Nome.Length > 100)
                throw new ExcecaoPersonalizada(Erros.NomeVazio);
            if (equipamento.Descricao.Trim() == "")
                throw new ExcecaoPersonalizada(Erros.DescricaoVazio);

            DALEquipamento.Inserir(equipamento);
        }

        public static void InserirEquipamentoGrupo(MODGrupo_Equipamento grupoEquipamento)
        {
            DALEquipamento.InserirEquipamentoGrupo(grupoEquipamento);
        }

        public static void AlterarDataSaidaEquipamento(MODGrupo_Equipamento grupoEquipamento)
        {
            DALEquipamento.AlterarDataSaidaEquipamento(grupoEquipamento);
        }

        public static void Alterar(MODEquipamento equipamento)
        {
            DALEquipamento.Alterar(equipamento);
        }

        public static List<MODEquipamento> Pesquisar(MODEquipamento equipamento, string tipoPesquisa)
        {
            return DALEquipamento.Pesquisar(equipamento, tipoPesquisa);
        }

        public static MODEquipamento PesquisarEquipamento(MODEquipamento equipamento, string tipoPesquisa)
        {
            return DALEquipamento.PesquisarEquipamento(equipamento, tipoPesquisa);
        }

        public static DataTable ConsultaPorGrupo(MODGrupo grupo)
        {
            return DALEquipamento.ConsultaPorGrupo(grupo);
        }

        public static DataTable PesquisarGrupo(MODGrupo_Equipamento grupoEquipamento, string tipoPesquisa)
        {
            return DALEquipamento.PesquisarGrupo(grupoEquipamento, tipoPesquisa);
        }
    }
}


