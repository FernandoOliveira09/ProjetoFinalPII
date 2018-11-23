using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using MySql.Data.MySqlClient;

namespace ProjetoFinal.DAL
{
    public class DALReuniao
    {
        public static void Inserir(MODReuniao reuniao)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLREUNIAO (pauta, data_reuniao, hora_inicio) "
                + "VALUES (@pauta, @data_reuniao, @hora_inicio)";
            comando.Parameters.AddWithValue("@pauta", reuniao.Pauta);
            comando.Parameters.AddWithValue("@data_reuniao", reuniao.DataReuniao);
            comando.Parameters.AddWithValue("@hora_inicio", reuniao.HoraInicio);
            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void Alterar(MODEquipamento equipamento)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLEQUIPAMENTO SET nome = @nome, descricao = @descricao "
                + "WHERE id_equipamento = @id_equipamento";
            comando.Parameters.AddWithValue("@id_equipamento", equipamento.IdEquipamento);
            comando.Parameters.AddWithValue("@nome", equipamento.Nome);
            comando.Parameters.AddWithValue("@descricao", equipamento.Descricao);


            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static MODReuniao PesquisarReuniao(MODReuniao reuniao, string tipoPesquisa)
        {
            MODReuniao retorno = new MODReuniao();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "id")
            {
                comando.CommandText = "SELECT pauta, data_reuniao, hora_inicio FROM TBLREUNIAO WHERE id_reuniao = @id";
                comando.Parameters.AddWithValue("@id", reuniao.IdReuniao);
            }
            else
            {
                comando.CommandText = "SELECT id_reuniao, pauta, data_reuniao, hora_inicio FROM TBLREUNIAO WHERE pauta = @pauta";
                comando.Parameters.AddWithValue("@pauta", reuniao.Pauta);
            }

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODReuniao ret = new MODReuniao();
                ret.IdReuniao = Convert.ToInt32(reader["id_reuniao"].ToString());
                ret.Pauta = reader["Pauta"].ToString();
                if (reader["data_reuniao"].ToString() != "")
                    ret.DataReuniao = Convert.ToDateTime(reader["data_reuniao"].ToString());
                if (reader["hora_inicio"].ToString() != "")
                    ret.HoraInicio = Convert.ToDateTime(reader["hora_inicio"].ToString());

                retorno.IdReuniao = ret.IdReuniao;
                retorno.Pauta = ret.Pauta;
                retorno.HoraInicio = ret.HoraInicio;

            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static List<MODReuniao> Pesquisar(MODReuniao item, string tipoPesquisa)
        {
            List<MODReuniao> retorno = new List<MODReuniao>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "pauta")
            {
                comando.CommandText = "SELECT pauta, data_reuniao, hora_inicio FROM TBLREUNIAO WHERE pauta = @pauta";
                comando.Parameters.AddWithValue("@pauta", item.Pauta);
            }

            else if (tipoPesquisa == "todos")
            {
                comando.CommandText = "SELECT id_reuniao, pauta, data_reuniao, hora_inicio FROM TBLREUNIAO";
            }
            else
            {
                //    comando.CommandText = "SELECT login, nome, email, lattes, imagem, fk_tipo, fk_status FROM TBLUSUARIO where fk_tipo = 2 and fk_status = 1";
            }

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODReuniao ret = new MODReuniao();
                ret.IdReuniao = Convert.ToInt32(reader["id_reuniao"]);
                ret.Pauta = reader["Pauta"].ToString();
                if (reader["data_reuniao"].ToString() != "")
                    ret.DataReuniao = Convert.ToDateTime(reader["data_reuniao"].ToString());
                if (reader["hora_inicio"].ToString() != "")
                    ret.HoraInicio = Convert.ToDateTime(reader["hora_inicio"].ToString());


                retorno.Add(ret);
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }
    }
}
