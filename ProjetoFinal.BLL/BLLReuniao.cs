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
    public class BLLReuniao
    {
        public static void Inserir(MODReuniao reuniao)
        {
            if (reuniao.Pauta.Trim() == "" || reuniao.Pauta.Length > 100)
                throw new ExcecaoPersonalizada(Erros.PautaVazia);


            DALReuniao.Inserir(reuniao);
        }

        public static List<MODReuniao> Pesquisar(MODReuniao reuniao, string tipoPesquisa)
        {
            return DALReuniao.Pesquisar(reuniao, tipoPesquisa);
        }

        public static MODReuniao PesquisarReuniao(MODReuniao reuniao, string tipoPesquisa)
        {
            return DALReuniao.PesquisarReuniao(reuniao, tipoPesquisa);
        }
    }
}
