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

            comando.CommandText = "INSERT INTO TBLLinha_Pesquisa (id_linha, nome_linha, fk_sub) VALUES (@id, @nome, @fksub)";
            comando.Parameters.AddWithValue("@id", linhaPesquisa.Id);
            comando.Parameters.AddWithValue("@nome", linhaPesquisa.Linha);
            comando.Parameters.AddWithValue("@fksub", linhaPesquisa.FkSub);

            comando.ExecuteNonQuery();

            Conexao.Fechar();

        }

        public static void InserirAreaConhecimento(MODArea_Conhecimento areaConhecimento)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLArea_Conhecimento (id_con, nome_con) VALUES (@id, @nome)";
            comando.Parameters.AddWithValue("@id", areaConhecimento.Id);
            comando.Parameters.AddWithValue("@nome", areaConhecimento.Nome);

            comando.ExecuteNonQuery();

            Conexao.Fechar();

        }

        public static void InserirAreaAvaliacao(MODArea_Avaliacao areaAvaliacao)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLArea_Avaliacao (id_ava, nome_ava, fk_con) VALUES (@id, @nome, @fk)";
            comando.Parameters.AddWithValue("@id", areaAvaliacao.Id);
            comando.Parameters.AddWithValue("@nome", areaAvaliacao.Nome);
            comando.Parameters.AddWithValue("@fk", areaAvaliacao.FkCon);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void InserirSubAreaAvaliacao(MODSubArea_Avaliacao subAreaAvaliacao)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLSub_Area_Avaliacao (id_sub, nome_sub, fk_ava) VALUES (@id, @nome, @fk)";
            comando.Parameters.AddWithValue("@id", subAreaAvaliacao.Id);
            comando.Parameters.AddWithValue("@nome", subAreaAvaliacao.Nome);
            comando.Parameters.AddWithValue("@fk", subAreaAvaliacao.FkAva);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void AlterarAreaConhecimento(MODArea_Conhecimento areaConhecimento, string id)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLArea_Conhecimento SET id_con = @idc, nome_con = @nome where id_con = @id";
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@idc", areaConhecimento.Id);
            comando.Parameters.AddWithValue("@nome", areaConhecimento.Nome);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void AlterarAreaAvaliacao(MODArea_Avaliacao areaAvaliacao, string id)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLArea_Avaliacao SET id_ava = @ida, nome_ava = @nome, fk_con = @fk where id_ava = @id";
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@ida", areaAvaliacao.Id);
            comando.Parameters.AddWithValue("@nome", areaAvaliacao.Nome);
            comando.Parameters.AddWithValue("@fk", areaAvaliacao.FkCon);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void AlterarSubAreaAvaliacao(MODSubArea_Avaliacao subAreaAvaliacao, string id)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLSub_Area_Avaliacao SET id_sub = @ids, nome_sub = @nome, fk_ava = @fk where id_sub = @id";
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@ids", subAreaAvaliacao.Id);
            comando.Parameters.AddWithValue("@nome", subAreaAvaliacao.Nome);
            comando.Parameters.AddWithValue("@fk", subAreaAvaliacao.FkAva);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void AlterarLinhaPesquisa(MODLinha_Pesquisa linhaPesquisa, string id)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLLinha_pesquisa SET id_linha = @idl, nome_linha = @nome, fk_sub = @fk where id_linha = @id";
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@idl", linhaPesquisa.Id);
            comando.Parameters.AddWithValue("@nome", linhaPesquisa.Linha);
            comando.Parameters.AddWithValue("@fk", linhaPesquisa.FkSub);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static List<MODArea_Conhecimento> PesquisarAreaConhecimento(MODArea_Conhecimento item, string tipoPesquisa)
        {
            List<MODArea_Conhecimento> retorno = new List<MODArea_Conhecimento>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if(tipoPesquisa == "todas")
            {
                comando.CommandText = "SELECT id_con, nome_con FROM tblarea_conhecimento";
            }
            else
            {
                comando.CommandText = "SELECT id_con, nome_con FROM tblarea_conhecimento where id_con = @id or nome_con = @nome";
            }
            comando.Parameters.AddWithValue("@id", item.Nome);
            comando.Parameters.AddWithValue("@nome", item.Nome);

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

        public static List<MODArea_Avaliacao> PesquisarAreaAvaliacao(MODArea_Avaliacao item, string tipoPesquisa)
        {
            List<MODArea_Avaliacao> retorno = new List<MODArea_Avaliacao>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "conhecimento")
            {
                comando.CommandText = "SELECT id_ava, nome_ava FROM tblarea_avaliacao where fk_con = @fk_con";
                comando.Parameters.AddWithValue("@fk_con", item.FkCon);
            }
            else if (tipoPesquisa == "existente")
            {
                comando.CommandText = "SELECT id_ava, nome_ava FROM tblarea_avaliacao where id_ava = @id or nome_ava = @nome";
                comando.Parameters.AddWithValue("@id", item.Id);
                comando.Parameters.AddWithValue("@nome", item.Nome);
            }

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

        public static List<MODSubArea_Avaliacao> PesquisarSubAreaAvaliacao(MODSubArea_Avaliacao item, string tipoPesquisa)
        {
            List<MODSubArea_Avaliacao> retorno = new List<MODSubArea_Avaliacao>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "avaliacao")
            {
                comando.CommandText = "SELECT id_sub, nome_sub FROM tblsub_area_avaliacao where fk_ava = @fk_ava";
                comando.Parameters.AddWithValue("@fk_ava", item.FkAva);
            }
            else
            {
                comando.CommandText = "SELECT id_sub, nome_sub FROM tblsub_area_avaliacao where id_sub = @id or nome_sub = @nome";
                comando.Parameters.AddWithValue("@id", item.Id);
                comando.Parameters.AddWithValue("@nome", item.Nome);
            }

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODSubArea_Avaliacao ret = new MODSubArea_Avaliacao();
                ret.Id = reader["id_sub"].ToString();
                ret.Nome = reader["nome_sub"].ToString();

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
            else if (tipoPesquisa == "subarea")
            {
                comando.CommandText = "SELECT id_linha, nome_linha FROM tbllinha_pesquisa where fk_sub = @fk";
                comando.Parameters.AddWithValue("@fk", linhaPesquisa.FkSub);
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

        public static MODArea_Conhecimento PesquisarConhecimento(MODArea_Conhecimento area)
        {
            MODArea_Conhecimento retorno = new MODArea_Conhecimento();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "SELECT id_con, nome_con FROM tblarea_conhecimento where id_con = @id";
            comando.Parameters.AddWithValue("@id", area.Id);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODArea_Conhecimento ret = new MODArea_Conhecimento();
                ret.Id = reader["Id_con"].ToString();
                ret.Nome = reader["nome_con"].ToString();

                retorno.Id = ret.Id;
                retorno.Nome = ret.Nome;
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static MODArea_Avaliacao PesquisarAvaliacao(MODArea_Avaliacao area)
        {
            MODArea_Avaliacao retorno = new MODArea_Avaliacao();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "SELECT id_ava, nome_ava, fk_con FROM tblarea_avaliacao where id_ava = @id";
            comando.Parameters.AddWithValue("@id", area.Id);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODArea_Avaliacao ret = new MODArea_Avaliacao();
                ret.Id = reader["id_ava"].ToString();
                ret.Nome = reader["nome_ava"].ToString();
                ret.FkCon = reader["fk_con"].ToString();

                retorno.Id = ret.Id;
                retorno.Nome = ret.Nome;
                retorno.FkCon = ret.FkCon;
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static MODSubArea_Avaliacao PesquisarSubAvaliacao(MODSubArea_Avaliacao area)
        {
            MODSubArea_Avaliacao retorno = new MODSubArea_Avaliacao();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "SELECT id_sub, nome_sub, fk_ava FROM tblsub_area_avaliacao where id_sub = @id";
            comando.Parameters.AddWithValue("@id", area.Id);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODSubArea_Avaliacao ret = new MODSubArea_Avaliacao();
                ret.Id = reader["id_sub"].ToString();
                ret.Nome = reader["nome_sub"].ToString();
                ret.FkAva = reader["fk_ava"].ToString();

                retorno.Id = ret.Id;
                retorno.Nome = ret.Nome;
                retorno.FkAva = ret.FkAva;
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static MODLinha_Pesquisa PesquisarLinha(MODLinha_Pesquisa area, string tipoPesquisa)
        {
            MODLinha_Pesquisa retorno = new MODLinha_Pesquisa();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "id")
            {
                comando.CommandText = "SELECT id_linha, nome_linha, fk_sub FROM tbllinha_pesquisa where id_linha = @id";
                comando.Parameters.AddWithValue("@id", area.Id);
            }
            else
            {
                comando.CommandText = "SELECT id_linha, nome_linha, fk_sub FROM tbllinha_pesquisa where nome_linha = @nome";
                comando.Parameters.AddWithValue("@nome", area.Linha);
            }
            

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODLinha_Pesquisa ret = new MODLinha_Pesquisa();
                ret.Id = reader["id_linha"].ToString();
                ret.Linha = reader["nome_linha"].ToString();
                ret.FkSub = reader["fk_sub"].ToString();

                retorno.Id = ret.Id;
                retorno.Linha = ret.Linha;
                retorno.FkSub = ret.FkSub;
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }
    }
}
