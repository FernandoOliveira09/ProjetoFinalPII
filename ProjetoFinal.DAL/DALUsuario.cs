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

        public static MODUsuario PesquisarLogin(MODUsuario usuario)
        {
            MODUsuario retorno = new MODUsuario();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "SELECT login, senha, fk_tipo FROM TBLUSUARIO WHERE login = @login";

            comando.Parameters.AddWithValue("@login", usuario.Login);
            comando.Parameters.AddWithValue("@senha", usuario.Senha);
            comando.Parameters.AddWithValue("@fk_tipo", usuario.FkTipo);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODUsuario ret = new MODUsuario();
                ret.Login = reader["Login"].ToString();
                ret.Senha = reader["Senha"].ToString();
                ret.FkTipo = Convert.ToInt32(reader["fk_tipo"]);

                retorno.Login = ret.Login;
                retorno.Senha = ret.Senha;
                retorno.FkTipo = ret.FkTipo;
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static List<MODUsuario> Pesquisar(MODUsuario item, int tipoPesquisa)
        {
            List<MODUsuario> retorno = new List<MODUsuario>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if(tipoPesquisa == 1)
                comando.CommandText = "SELECT login, senha FROM TBLUSUARIO WHERE fk_tipo = 1";
            else if(tipoPesquisa == 2)
                comando.CommandText = "SELECT login, senha, fk_tipo FROM TBLUSUARIO WHERE login = " + item.Login;

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODUsuario ret = new MODUsuario();
                ret.Login = reader["Login"].ToString();
                ret.Senha = reader["Senha"].ToString();
                ret.FkTipo = (int)reader["Fk_Tipo"];

                retorno.Add(ret);
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }
    }
}
