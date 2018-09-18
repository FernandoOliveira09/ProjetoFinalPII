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
    public static class BLLUsuario
    {
        public static void Inserir(MODUsuario usuario)
        {
            if (usuario.Nome.Trim() == "" || usuario.Nome.Length > 50)
                throw new ExcecaoPersonalizada(Erros.NomeVazio);
            if (usuario.Email.Trim() == "" || usuario.Email.Length > 50)
                throw new ExcecaoPersonalizada(Erros.EmailVazio);
            if (usuario.Login.Trim() == "" || usuario.Login.Length > 15)
                throw new ExcecaoPersonalizada(Erros.LoginVazio);
            if (usuario.Senha.Trim() == "")
                throw new ExcecaoPersonalizada(Erros.SenhaVazio);

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

        public static List<MODUsuario> Pesquisar(MODUsuario usuario, string tipoPesquisa)
        {
            return DALUsuario.Pesquisar(usuario, tipoPesquisa);
        }

        public static MODUsuario PesquisarLogin(MODUsuario usuario)
        {
            return DALUsuario.PesquisarLogin(usuario);
        }

        public static List<MODUsuario> PesquisarAdmin()
        {
            return DALUsuario.PesquisarAdmin();
        }
    }
}
