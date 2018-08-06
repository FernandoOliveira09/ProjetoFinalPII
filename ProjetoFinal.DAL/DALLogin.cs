using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using MySql.Data.MySqlClient;

namespace ProjetoFinal.DAL
{
    public static class DALLogin
    {
        public static void Inserir(MODLogin login)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLLOGIN (usuario, senha) VALUES (@usuario, @senha)";
            comando.Parameters.AddWithValue("@usuario", login.Usuario);
            comando.Parameters.AddWithValue("@senha", login.Senha);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        //public static void Alterar(MODLogin login)
        //{
        //    Conexao.Abrir();

        //    MySqlCommand comando = new MySqlCommand();
        //    comando.Connection = Conexao.conexao;

        //    comando.CommandText = "UPDATE TBLFUNCAO SET funcao = @funcao WHERE id = @id";
        //    comando.Parameters.AddWithValue("@funcao", funcao.Funcao);
        //    comando.Parameters.AddWithValue("@id", funcao.Id);

        //    comando.ExecuteNonQuery();

        //    Conexao.Fechar();
        //}

        //public static void Excluir(ModFuncao funcao)
        //{
        //    Conexao.Abrir();

        //    MySqlCommand comando = new MySqlCommand();
        //    comando.Connection = Conexao.conexao;

        //    comando.CommandText = "DELETE FROM TBLFUNCAO WHERE id = @id";
        //    comando.Parameters.AddWithValue("@id", funcao.Id);

        //    comando.ExecuteNonQuery();

        //    Conexao.Fechar();
        //}

        public static MODLogin Pesquisar(MODLogin login)
        {
            MODLogin retorno = new MODLogin();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "SELECT usuario, senha FROM TBLLOGIN WHERE usuario = @usuario";

            comando.Parameters.AddWithValue("@usuario", login.Usuario);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODLogin ret = new MODLogin();
                ret.Usuario = reader["USUARIO"].ToString();
                ret.Senha = reader["SENHA"].ToString();

                retorno.Usuario = ret.Usuario;
                retorno.Senha = ret.Senha;
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }
    }
}
