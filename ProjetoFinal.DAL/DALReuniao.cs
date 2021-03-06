﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjetoFinal.DAL
{
    public class DALReuniao
    {
        public static void Inserir(MODReuniao reuniao)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLREUNIAO (pauta, data_reuniao, hora_inicio, fk_grupo) "
                + "VALUES (@pauta, @data_reuniao, @hora_inicio, @fk_grupo)";
            comando.Parameters.AddWithValue("@pauta", reuniao.Pauta);
            comando.Parameters.AddWithValue("@data_reuniao", reuniao.DataReuniao);
            comando.Parameters.AddWithValue("@hora_inicio", reuniao.HoraInicio);
            comando.Parameters.AddWithValue("@fk_grupo", reuniao.FkGrupo);
            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void Alterar(MODReuniao reuniao)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLREUNIAO SET pauta = @pauta, data_reuniao = @data_reuniao, hora_inicio = @hora_inicio, hora_fim = @hora_fim "
                + "WHERE id_reuniao = @id_reuniao";
            comando.Parameters.AddWithValue("@id_reuniao", reuniao.IdReuniao);
            comando.Parameters.AddWithValue("@pauta", reuniao.Pauta);
            comando.Parameters.AddWithValue("@data_reuniao", reuniao.DataReuniao);
            comando.Parameters.AddWithValue("@hora_inicio", reuniao.HoraInicio);
            comando.Parameters.AddWithValue("@hora_fim", reuniao.HoraFim);


            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static MODReuniao PesquisarReuniao(MODReuniao reuniao, string tipoPesquisa)
        {
            MODReuniao retorno = new MODReuniao();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "id_reuniao")
            {
                comando.CommandText = "SELECT id_reuniao, pauta, data_reuniao, hora_inicio, hora_fim, fk_grupo FROM TBLREUNIAO WHERE id_reuniao = @id_reuniao";
                comando.Parameters.AddWithValue("@id_reuniao", reuniao.IdReuniao);
            }
            else
            {
                comando.CommandText = "SELECT id_reuniao, pauta, data_reuniao, hora_inicio, hora_fim, fk_grupo FROM TBLREUNIAO WHERE pauta = @pauta";
                comando.Parameters.AddWithValue("@pauta", reuniao.Pauta);
            }

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODReuniao ret = new MODReuniao();
                ret.IdReuniao = Convert.ToInt32(reader["id_reuniao"].ToString());
                ret.Pauta = reader["Pauta"].ToString();
                ret.FkGrupo = Convert.ToInt32(reader["fk_grupo"].ToString());
                if (reader["data_reuniao"].ToString() != "")
                    ret.DataReuniao = Convert.ToDateTime(reader["data_reuniao"].ToString());
                if (reader["hora_inicio"].ToString() != "")
                    ret.HoraInicio = Convert.ToDateTime(reader["hora_inicio"].ToString());
                if (reader["hora_fim"].ToString() != "")
                    ret.HoraFim = Convert.ToDateTime(reader["hora_fim"].ToString());

                retorno.IdReuniao = ret.IdReuniao;
                retorno.Pauta = ret.Pauta;
                retorno.DataReuniao = ret.DataReuniao;
                retorno.HoraInicio = ret.HoraInicio;
                retorno.HoraFim = ret.HoraFim;
                retorno.FkGrupo = ret.FkGrupo;
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
                comando.CommandText = "SELECT id_reuniao, pauta, data_reuniao, hora_inicio, hora_fim, fk_grupo FROM TBLREUNIAO WHERE pauta = @pauta";
                comando.Parameters.AddWithValue("@pauta", item.Pauta);
            }
            else if (tipoPesquisa == "grupo")
            {
                comando.CommandText = "SELECT id_reuniao, pauta, data_reuniao, hora_inicio, hora_fim, fk_grupo FROM TBLREUNIAO WHERE fk_grupo = @grupo";
                comando.Parameters.AddWithValue("@grupo", item.FkGrupo);
            }
            else if (tipoPesquisa == "reuniao")
            {
                comando.CommandText = "SELECT id_reuniao, pauta, data_reuniao, hora_inicio, hora_fim, fk_grupo FROM TBLREUNIAO WHERE id_reuniao = @reuniao";
                comando.Parameters.AddWithValue("@reuniao", item.IdReuniao);
            }
            else if (tipoPesquisa == "todos")
            {
                comando.CommandText = "SELECT id_reuniao, pauta, data_reuniao, hora_inicio, hora_fim, fk_grupo FROM TBLREUNIAO";
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
                ret.FkGrupo = Convert.ToInt32(reader["fk_grupo"]);
                ret.Pauta = reader["Pauta"].ToString();
                if (reader["data_reuniao"].ToString() != "")
                    ret.DataReuniao = Convert.ToDateTime(reader["data_reuniao"].ToString());
                if (reader["hora_inicio"].ToString() != "")
                    ret.HoraInicio = Convert.ToDateTime(reader["hora_inicio"].ToString());
                if (reader["hora_fim"].ToString() != "")
                    ret.HoraFim = Convert.ToDateTime(reader["hora_fim"].ToString());

                retorno.Add(ret);
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static DataTable CarregarCalendario(MODReuniao reuniao, string data, string tipoPesquisa)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;
            if(tipoPesquisa == "grupo")
            {
                comando.CommandText = "SELECT data_reuniao, pauta, hora_inicio, hora_fim, id_reuniao, fk_grupo FROM TBLREUNIAO WHERE fk_grupo = @grupo";
                comando.Parameters.AddWithValue("@grupo", reuniao.FkGrupo);
            }
            else
            {
                comando.CommandText = "SELECT data_reuniao, pauta, hora_inicio, hora_fim, id_reuniao, fk_grupo " 
                    + "FROM TBLREUNIAO WHERE fk_grupo = @grupo and data_reuniao between '" + data + "-01' and '" + data + "-31'";
                comando.Parameters.AddWithValue("@grupo", reuniao.FkGrupo);

            }

            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            da.Fill(dt);

            return dt;
        }
    }
}
