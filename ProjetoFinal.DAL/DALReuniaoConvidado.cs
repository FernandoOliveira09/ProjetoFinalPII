using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using MySql.Data.MySqlClient;

namespace ProjetoFinal.DAL
{
    public static class DALReuniaoConvidado
    {
        public static void Inserir(MODReuniaoConvidado reuniaoConvidado)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO tblreuniao_convidado (nome, fk_reuniao) "
                + "VALUES (@nome, @fk_reuniao)";
            comando.Parameters.AddWithValue("@nome", reuniaoConvidado.Nome);
            comando.Parameters.AddWithValue("@fk_reuniao", reuniaoConvidado.FkReuniao);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void Excluir(MODReuniaoConvidado reuniaoConvidado)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "DELETE FROM TBLREUNIAO_CONVIDADO WHERE id_convidado = @id ";
            comando.Parameters.AddWithValue("@id", reuniaoConvidado.IdConvidado);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static List<MODReuniaoConvidado> Pesquisar(MODReuniaoConvidado item, string tipoPesquisa)
        {
            List<MODReuniaoConvidado> retorno = new List<MODReuniaoConvidado>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "reuniao")
            {
                comando.CommandText = "SELECT id_convidado, nome, fk_reuniao FROM tblreuniao_convidado WHERE fk_reuniao = @fk";
                comando.Parameters.AddWithValue("@fk", item.FkReuniao);
            }


            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODReuniaoConvidado ret = new MODReuniaoConvidado();
                ret.IdConvidado = Convert.ToInt32(reader["id_convidado"]);
                ret.Nome = reader["Nome"].ToString();
                ret.FkReuniao = Convert.ToInt32(reader["Fk_reuniao"]);
                retorno.Add(ret);
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static MODReuniaoConvidado PesquisarConvidado(MODReuniaoConvidado reuniaoConvidado, string tipoPesquisa)
        {
            MODReuniaoConvidado retorno = new MODReuniaoConvidado();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "reuniao")
            {
                comando.CommandText = "SELECT id_convidado, nome, fk_reuniao FROM tblreuniao_convidado WHERE fk_reuniao = @fk";
                comando.Parameters.AddWithValue("@fk", reuniaoConvidado.FkReuniao);
            }
            else 
            {
                comando.CommandText = "SELECT id_convidado, nome, fk_reuniao FROM tblreuniao_convidado WHERE nome = @nome";
                comando.Parameters.AddWithValue("@nome", reuniaoConvidado.Nome);
            }


            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODReuniaoConvidado ret = new MODReuniaoConvidado();
                ret.IdConvidado = Convert.ToInt32(reader["id_convidado"]);
                ret.Nome = reader["nome"].ToString();
                ret.FkReuniao = Convert.ToInt32(reader["fk_reuniao"].ToString());

                retorno.IdConvidado = ret.IdConvidado;
                retorno.Nome = ret.Nome;
                retorno.FkReuniao = ret.FkReuniao;
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }
    }
}
