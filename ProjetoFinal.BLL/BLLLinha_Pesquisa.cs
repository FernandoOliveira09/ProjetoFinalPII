using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using ProjetoFinal.DAL;

namespace ProjetoFinal.BLL
{
    public static class BLLLinha_Pesquisa
    {
        public static void InserirLinha(MODLinha_Pesquisa linhaPesquisa)
        {
            DALLinha_Pesquisa.InserirLinha(linhaPesquisa);
        }

        public static void InserirAreaConhecimento(MODArea_Conhecimento areaConhecimento)
        {
            DALLinha_Pesquisa.InserirAreaConhecimento(areaConhecimento);
        }

        public static void InserirAreaAvaliacao(MODArea_Avaliacao areaAvaliacao)
        {
            DALLinha_Pesquisa.InserirAreaAvaliacao(areaAvaliacao);
        }

        public static void InserirSubAreaAvaliacao(MODSubArea_Avaliacao subAreaAvaliacao)
        {
            DALLinha_Pesquisa.InserirSubAreaAvaliacao(subAreaAvaliacao);
        }

        public static void AlterarAreaConhecimento(MODArea_Conhecimento areaConhecimento, string id)
        {
            DALLinha_Pesquisa.AlterarAreaConhecimento(areaConhecimento, id);
        }

        public static void AlterarAreaAvaliacao(MODArea_Avaliacao areaAvaliacao, string id)
        {
            DALLinha_Pesquisa.AlterarAreaAvaliacao(areaAvaliacao, id);
        }

        public static void AlterarSubAreaAvaliacao(MODSubArea_Avaliacao subAreaAvaliacao, string id)
        {
            DALLinha_Pesquisa.AlterarSubAreaAvaliacao(subAreaAvaliacao, id);
        }

        public static void AlterarLinhaPesquisa(MODLinha_Pesquisa linhaPesquisa, string id)
        {
            DALLinha_Pesquisa.AlterarLinhaPesquisa(linhaPesquisa, id);
        }

        public static List<MODArea_Conhecimento> PesquisarAreaConhecimento(MODArea_Conhecimento item, string tipoPesquisa)
        {
            return DALLinha_Pesquisa.PesquisarAreaConhecimento(item, tipoPesquisa);
        }

        public static List<MODArea_Avaliacao> PesquisarAreaAvaliacao(MODArea_Avaliacao item, string tipoPesquisa)
        {
            return DALLinha_Pesquisa.PesquisarAreaAvaliacao(item, tipoPesquisa);
        }

        public static List<MODSubArea_Avaliacao> PesquisarSubAreaAvaliacao(MODSubArea_Avaliacao item, string tipoPesquisa)
        {
            return DALLinha_Pesquisa.PesquisarSubAreaAvaliacao(item, tipoPesquisa);
        }

        public static List<MODLinha_Pesquisa> PesquisarLinhaPesquisa(MODLinha_Pesquisa linhaPesquisa, string tipoPesquisa)
        {
            return DALLinha_Pesquisa.PesquisarLinhaPesquisa(linhaPesquisa, tipoPesquisa);
        }

        public static MODArea_Conhecimento PesquisarConhecimento(MODArea_Conhecimento area)
        {
            return DALLinha_Pesquisa.PesquisarConhecimento(area);
        }

        public static MODArea_Avaliacao PesquisarAvaliacao(MODArea_Avaliacao area)
        {
            return DALLinha_Pesquisa.PesquisarAvaliacao(area);
        }

        public static MODSubArea_Avaliacao PesquisarSubAvaliacao(MODSubArea_Avaliacao area)
        {
            return DALLinha_Pesquisa.PesquisarSubAvaliacao(area);
        }

        public static MODLinha_Pesquisa PesquisarLinha(MODLinha_Pesquisa area, string tipoPesquisa)
        {
            return DALLinha_Pesquisa.PesquisarLinha(area , tipoPesquisa);
        }
    }
}
