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

        public static List<MODArea_Conhecimento> Pesquisar(MODArea_Conhecimento item)
        {
            return DALLinha_Pesquisa.Pesquisar(item);
        }

        public static List<MODArea_Avaliacao> PesquisarAreaAvaliacao(string areaConhecimento)
        {
            return DALLinha_Pesquisa.PesquisarAreaAvaliacao(areaConhecimento);
        }

        public static List<MODLinha_Pesquisa> PesquisarLinhaPesquisa(MODLinha_Pesquisa linhaPesquisa, string tipoPesquisa)
        {
            return DALLinha_Pesquisa.PesquisarLinhaPesquisa(linhaPesquisa, tipoPesquisa);
        }
    }
}
