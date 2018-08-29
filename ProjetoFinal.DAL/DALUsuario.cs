using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using MySql.Data.MySqlClient;

namespace ProjetoFinal.DAL
{
    public static class DALUsuario
    {
        public static void Inserir(MODUsuario usuario)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLUSUARIO (login, nome, senha, email, data_cadastro, fk_tipo) " 
                + "VALUES (@login, @nome, @senha, @email, @data_cadastro, @fk_tipo)";
            comando.Parameters.AddWithValue("@login", usuario.Login);
            comando.Parameters.AddWithValue("@nome", usuario.Nome);
            comando.Parameters.AddWithValue("@senha", usuario.Senha);
            comando.Parameters.AddWithValue("@email", usuario.Email);
            comando.Parameters.AddWithValue("@data_cadastro", usuario.DataCadastro);
            comando.Parameters.AddWithValue("@fk_tipo", usuario.FkTipo);

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

        public static MODUsuario Pesquisar(MODUsuario login)
        {
            MODUsuario retorno = new MODUsuario();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "SELECT usuario, senha FROM TBLLOGIN WHERE usuario = @usuario";

            comando.Parameters.AddWithValue("@usuario", login.Usuario);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODUsuario ret = new MODUsuario();
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
