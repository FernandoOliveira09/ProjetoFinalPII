using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using ProjetoFinal.DAL;

namespace ProjetoFinal.BLL
{
    public static class BLLUsuario
    {
        public static void Inserir(MODUsuario usuario)
        {
            DALUsuario.Inserir(usuario);
        }

        public static List<MODUsuario> Pesquisar(MODUsuario usuario, int tipoPesquisa)
        {
            return DALUsuario.Pesquisar(usuario, tipoPesquisa);
        }

        public static MODUsuario PesquisarLogin(MODUsuario usuario)
        {
            return DALUsuario.PesquisarLogin(usuario);
        }
    }
}
