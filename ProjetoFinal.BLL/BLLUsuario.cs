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

        public static void Alterar(MODUsuario usuario)
        {
            DALUsuario.Alterar(usuario);
        }

        public static void AlterarStatus(MODUsuario usuario)
        {
            DALUsuario.AlterarStatus(usuario);
        }

        public static void AlterarSenha(MODUsuario usuario)
        {
            DALUsuario.AlterarSenha(usuario);
        }

        public static List<MODUsuario> Pesquisar(MODUsuario usuario)
        {
            return DALUsuario.Pesquisar(usuario);
        }

        public static MODUsuario PesquisarLogin(MODUsuario usuario)
        {
            return DALUsuario.PesquisarLogin(usuario);
        }
    }
}
