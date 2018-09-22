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

            comando.CommandText = "INSERT INTO TBLUSUARIO (login, nome, senha, email, lattes, imagem, primeiro_acesso, data_cadastro, fk_tipo, fk_status) "
                + "VALUES (@login, @nome, @senha, @email, @lattes, @imagem, @primeiro_acesso, @data_cadastro, @fk_tipo, @fk_status)";
            comando.Parameters.AddWithValue("@login", usuario.Login);
            comando.Parameters.AddWithValue("@nome", usuario.Nome);
            comando.Parameters.AddWithValue("@senha", usuario.Senha);
            comando.Parameters.AddWithValue("@email", usuario.Email);
            comando.Parameters.AddWithValue("@lattes", usuario.Lattes);
            comando.Parameters.AddWithValue("@imagem", usuario.Imagem);
            comando.Parameters.AddWithValue("@primeiro_acesso", usuario.PrimeiroAcesso);
            comando.Parameters.AddWithValue("@data_cadastro", usuario.DataCadastro);
            comando.Parameters.AddWithValue("@fk_tipo", usuario.FkTipo);
            comando.Parameters.AddWithValue("@fk_status", usuario.FkStatus);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void Alterar(MODUsuario usuario)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLUSUARIO SET senha = @senha, lattes = @lattes, "
                + "primeiro_acesso = @primeiro_acesso, imagem = @imagem "
                + "WHERE login = @login";
            comando.Parameters.AddWithValue("@login", usuario.Login);
            comando.Parameters.AddWithValue("@senha", usuario.Senha);
            comando.Parameters.AddWithValue("@lattes", usuario.Lattes);
            comando.Parameters.AddWithValue("@primeiro_acesso", usuario.PrimeiroAcesso);
            comando.Parameters.AddWithValue("@imagem", usuario.Imagem);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void AlterarStatus(MODUsuario usuario)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLUSUARIO SET fk_status = @fk_status WHERE login = @login";
            comando.Parameters.AddWithValue("@login", usuario.Login);
            comando.Parameters.AddWithValue("@fk_status", usuario.FkStatus);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void AlterarSenha(MODUsuario usuario)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLUSUARIO SET senha = @senha, fk_status = @fk_status WHERE login = @login";
            comando.Parameters.AddWithValue("@login", usuario.Login);
            comando.Parameters.AddWithValue("@senha", usuario.Senha);
            comando.Parameters.AddWithValue("@fk_status", usuario.FkStatus);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static MODUsuario PesquisarLogin(MODUsuario usuario)
        {
            MODUsuario retorno = new MODUsuario();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "SELECT login, nome, senha, email, imagem, fk_tipo, fk_status, primeiro_acesso FROM TBLUSUARIO WHERE login = @login";

            comando.Parameters.AddWithValue("@login", usuario.Login);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODUsuario ret = new MODUsuario();
                ret.Login = reader["Login"].ToString();
                ret.Nome = reader["Nome"].ToString();
                ret.Senha = reader["Senha"].ToString();
                ret.Email = reader["Email"].ToString();
                ret.Imagem = reader["Imagem"].ToString();
                ret.FkTipo = Convert.ToInt32(reader["fk_tipo"]);
                ret.FkStatus = Convert.ToInt32(reader["fk_status"]);
                ret.PrimeiroAcesso = Convert.ToChar(reader["primeiro_acesso"]);

                retorno.Login = ret.Login;
                retorno.Nome = ret.Nome;
                retorno.Senha = ret.Senha;
                retorno.Email = ret.Email;
                retorno.Imagem = ret.Imagem;
                retorno.FkTipo = ret.FkTipo;
                retorno.FkStatus = ret.FkStatus;
                retorno.PrimeiroAcesso = ret.PrimeiroAcesso;
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static List<MODUsuario> Pesquisar(MODUsuario item, string tipoPesquisa)
        {
            List<MODUsuario> retorno = new List<MODUsuario>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if(tipoPesquisa == "login")
            {
                comando.CommandText = "SELECT login, nome, email, lattes, imagem, fk_tipo, fk_status FROM TBLUSUARIO WHERE login = @login";
                comando.Parameters.AddWithValue("@login", item.Login);
            }
            else if(tipoPesquisa == "email")
            {
                comando.CommandText = "SELECT login, nome, email, lattes, imagem, fk_tipo, fk_status FROM TBLUSUARIO WHERE email = @email";
                comando.Parameters.AddWithValue("@email", item.Email);
            }
            else if (tipoPesquisa == "todos")
            {
                comando.CommandText = "SELECT login, nome, email, lattes, imagem, fk_tipo, fk_status FROM TBLUSUARIO";
            }
            else
            {
                comando.CommandText = "SELECT login, nome, email, lattes, imagem, fk_tipo, fk_status FROM TBLUSUARIO where fk_tipo = 2 and fk_status = 1";
            }

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODUsuario ret = new MODUsuario();
                ret.Login = reader["Login"].ToString();
                ret.Nome = reader["Nome"].ToString();
                ret.Email = reader["Email"].ToString();
                ret.Lattes = reader["Lattes"].ToString();
                ret.Imagem = reader["Imagem"].ToString();
                ret.FkTipo = (int)reader["fk_tipo"];
                ret.FkStatus = (int)reader["fk_status"];

                if (ret.FkTipo == 1)
                    ret.Tipo = "Administrador";
                else
                    ret.Tipo = "Lider de Pesquisa";

                if (ret.FkStatus == 1)
                    ret.Status = "Ativo";
                else if (ret.FkStatus == 2)
                    ret.Status = "Bloqueado";
                else
                    ret.Status = "Desativado";

                retorno.Add(ret);
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static List<MODUsuario> PesquisarAdmin()
        {
            List<MODUsuario> retorno = new List<MODUsuario>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "SELECT login, fk_tipo FROM TBLUSUARIO WHERE fk_tipo = 1";

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODUsuario ret = new MODUsuario();
                ret.Login = reader["Login"].ToString();
                ret.FkTipo = (int)reader["Fk_Tipo"];

                retorno.Add(ret);
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }
    }
}
