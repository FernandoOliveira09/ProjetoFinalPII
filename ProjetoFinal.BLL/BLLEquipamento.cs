using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using ProjetoFinal.DAL;
using ProjetoFinal.Utilitarios;


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

        public static void Alterar(MODEquipamento equipamento)
        {
            DALEquipamento.Alterar(equipamento);
        }

        public static List<MODEquipamento> Pesquisar(MODEquipamento equipamento, string tipoPesquisa)
        {
            return DALEquipamento.Pesquisar(equipamento, tipoPesquisa);
        }

        public static MODEquipamento PesquisarEquipamento(MODEquipamento equipamento)
        {
            return DALEquipamento.PesquisarEquipamento(equipamento);
        }
    }
}


