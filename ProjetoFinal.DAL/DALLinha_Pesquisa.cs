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
    public static class DALLinha_Pesquisa
    {
        public static void InserirLinha(MODLinha_Pesquisa linhaPesquisa)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLLinha_Pesquisa (id_linha, nome_linha, fk_ava) VALUES (@id, @nome, @fkava)";
            comando.Parameters.AddWithValue("@id", linhaPesquisa.Id);
            comando.Parameters.AddWithValue("@nome", linhaPesquisa.Linha);
            comando.Parameters.AddWithValue("@fkava", linhaPesquisa.FkAva);

            comando.ExecuteNonQuery();

            Conexao.Fechar();

        }

        public static List<MODArea_Conhecimento> Pesquisar(MODArea_Conhecimento item)
        {
            List<MODArea_Conhecimento> retorno = new List<MODArea_Conhecimento>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "SELECT id_con, nome_con FROM tblarea_conhecimento";
            //comando.Parameters.AddWithValue("@nome", item.Nome);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODArea_Conhecimento ret = new MODArea_Conhecimento();
                ret.Id = reader["id_con"].ToString();
                ret.Nome = reader["nome_con"].ToString();

                retorno.Add(ret);
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static List<MODArea_Avaliacao> PesquisarAreaAvaliacao(string areaConhecimento)
        {
            List<MODArea_Avaliacao> retorno = new List<MODArea_Avaliacao>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "SELECT id_ava, nome_ava FROM tblarea_avaliacao where fk_con = @fk_con";
            comando.Parameters.AddWithValue("@fk_con", areaConhecimento);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODArea_Avaliacao ret = new MODArea_Avaliacao();
                ret.Id = reader["id_ava"].ToString();
                ret.Nome = reader["nome_ava"].ToString();

                retorno.Add(ret);
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static List<MODLinha_Pesquisa> PesquisarLinhaPesquisa(MODLinha_Pesquisa linhaPesquisa, string tipoPesquisa)
        {
            List<MODLinha_Pesquisa> retorno = new List<MODLinha_Pesquisa>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if(tipoPesquisa == "existente")
            {
                comando.CommandText = "SELECT id_linha, nome_linha FROM tbllinha_pesquisa where nome_linha = @nome or id_linha = @id";
                comando.Parameters.AddWithValue("@nome", linhaPesquisa.Linha);
                comando.Parameters.AddWithValue("@id", linhaPesquisa.Id);
            }
            else if (tipoPesquisa == "avaliacao")
            {
                comando.CommandText = "SELECT id_linha, nome_linha FROM tbllinha_pesquisa where fk_ava = @fk";
                comando.Parameters.AddWithValue("@fk", linhaPesquisa.FkAva);
            }

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODLinha_Pesquisa ret = new MODLinha_Pesquisa();
                ret.Id = reader["id_linha"].ToString();
                ret.Linha = reader["nome_linha"].ToString();

                retorno.Add(ret);
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }
    }
}
