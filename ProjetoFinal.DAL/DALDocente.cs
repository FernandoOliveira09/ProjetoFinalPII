using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjetoFinal.DAL
{
    public static class DALDocente
    {
        public static void InserirDocente(MODDocente docente)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLDOCENTE (nome, formacao, curso, lattes, foto, data_conclusao) "
                + "VALUES (@nome, @formacao, @curso, @lattes, @foto, @data_conclusao)";
            comando.Parameters.AddWithValue("@nome", docente.Nome);
            comando.Parameters.AddWithValue("@formacao", docente.Formacao);
            comando.Parameters.AddWithValue("@curso", docente.Curso);
            comando.Parameters.AddWithValue("@lattes", docente.Lattes);
            comando.Parameters.AddWithValue("@foto", docente.Foto);
            comando.Parameters.AddWithValue("@data_conclusao", docente.DataInclusao);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void Alterar(MODDocente docente)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLDOCENTE SET nome = @nome, "
                + "formacao = @formacao, "
                + "lattes = @lattes, "
                + "foto = @foto, "
                + "data_conclusao = @data_conclusao "
                + "WHERE id_docente = @id";
            comando.Parameters.AddWithValue("@id", docente.IdDocente);
            comando.Parameters.AddWithValue("@nome", docente.Nome);
            comando.Parameters.AddWithValue("@formacao", docente.Formacao);
            comando.Parameters.AddWithValue("@lattes", docente.Lattes);
            comando.Parameters.AddWithValue("@foto", docente.Foto);
            comando.Parameters.AddWithValue("@data_conclusao", docente.DataInclusao);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static MODDocente PesquisarDocente(MODDocente docente, string tipoPesquisa)
        {
            MODDocente retorno = new MODDocente();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if(tipoPesquisa == "id")
            {
                comando.CommandText = "SELECT id_docente, nome, formacao, data_conclusao, lattes, foto FROM TBLDOCENTE WHERE id_docente = @id";
                comando.Parameters.AddWithValue("@id", docente.IdDocente);
            }
            else
            {
                comando.CommandText = "SELECT id_docente, nome, formacao, data_conclusao, lattes, foto FROM TBLDOCENTE WHERE nome = @nome";
                comando.Parameters.AddWithValue("@nome", docente.Nome);
            }

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODDocente ret = new MODDocente();
                ret.IdDocente = Convert.ToInt32(reader["id_docente"]);
                ret.Nome = reader["nome"].ToString();
                ret.Formacao = reader["formacao"].ToString();
                if (reader["data_conclusao"].ToString() != "")
                    ret.DataInclusao = Convert.ToDateTime(reader["data_conclusao"].ToString());
                ret.Lattes = reader["lattes"].ToString();
                ret.Foto = reader["foto"].ToString();

                retorno.IdDocente = ret.IdDocente;
                retorno.Nome = ret.Nome;
                retorno.Formacao = ret.Formacao;
                retorno.DataInclusao = ret.DataInclusao;
                retorno.Lattes = ret.Lattes;
                retorno.Foto = ret.Foto;
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static List<MODDocente> Pesquisar(MODDocente item, string tipoPesquisa)
        {
            List<MODDocente> retorno = new List<MODDocente>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "nome")
            {
                comando.CommandText = "SELECT id_docente, nome, formacao, data_conclusao, lattes, foto FROM TBLDOCENTE WHERE nome = @nome";
                comando.Parameters.AddWithValue("@nome", item.Nome);
            }
            else if (tipoPesquisa == "incompleto")
            {
                comando.CommandText = "SELECT id_docente, nome, formacao, data_conclusao, lattes, foto FROM TBLDOCENTE WHERE nome like @nome";
                comando.Parameters.AddWithValue("@nome", "%" + item.Nome + "%");
            }
            else if (tipoPesquisa == "formacao")
            {
                comando.CommandText = "SELECT id_docente, nome, formacao, data_conclusao, lattes, foto FROM TBLDOCENTE WHERE formacao = @formacao";
                comando.Parameters.AddWithValue("@formacao", item.Formacao);
            }
            else if (tipoPesquisa == "todos")
            {
                comando.CommandText = "SELECT id_docente, nome, formacao, data_conclusao, lattes, foto FROM TBLDOCENTE";
            }

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODDocente ret = new MODDocente();
                ret.IdDocente = Convert.ToInt32(reader["id_docente"]);
                ret.Nome = reader["nome"].ToString();
                ret.Formacao = reader["formacao"].ToString();
                if (reader["data_conclusao"].ToString() != "")
                    ret.DataInclusao = Convert.ToDateTime(reader["data_conclusao"].ToString());
                ret.Lattes = reader["lattes"].ToString();
                ret.Foto = reader["foto"].ToString();

                //retorno.IdDocente = ret.IdDocente;
                //retorno.Nome = ret.Nome;
                //retorno.Formacao = ret.Formacao;
                //retorno.DataInclusao = ret.DataInclusao;
                //retorno.Lattes = ret.Lattes;
                //retorno.Foto = ret.Foto;

                retorno.Add(ret);
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }
    }
}

