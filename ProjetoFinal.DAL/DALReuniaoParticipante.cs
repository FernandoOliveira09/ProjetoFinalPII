using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using MySql.Data.MySqlClient;

namespace ProjetoFinal.DAL
{
    public static class DALReuniaoParticipante
    {
        public static void Inserir(MODReuniaoParticipante reuniaoParticipante)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO tblreuniao_participante (fk_docente, fk_reuniao) "
                + "VALUES (@fk_docente, @fk_reuniao)";
            comando.Parameters.AddWithValue("@fk_docente", reuniaoParticipante.FkDocente);
            comando.Parameters.AddWithValue("@fk_reuniao", reuniaoParticipante.FKReuniao);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void Excluir(MODReuniaoParticipante reuniaoParticipante)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "DELETE FROM TBLREUNIAO_PARTICIPANTE WHERE fk_docente = @docente and fk_reuniao = @reuniao";
            comando.Parameters.AddWithValue("@docente", reuniaoParticipante.FkDocente);
            comando.Parameters.AddWithValue("@reuniao", reuniaoParticipante.FKReuniao);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static List<MODDocente> PesquisarDocente(MODReuniaoParticipante item, string tipoPesquisa)
        {
            List<MODDocente> retorno = new List<MODDocente>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "reuniao")
            {
                comando.CommandText = "SELECT d.id_docente, d.nome from tbldocente d  "
                    + "inner join tblreuniao_participante rd on rd.fk_docente = d.id_docente and rd.fk_reuniao = @reuniao";
            }
            else
            {
                comando.CommandText = "SELECT * FROM tbldocente d "
                    + "inner join tblgrupo_docente gd "
                    + "on gd.fk_docente = d.id_docente "
                    + "WHERE d.id_docente NOT IN(SELECT fk_docente FROM tblreuniao_participante where fk_reuniao = @reuniao)";
            }
            

            comando.Parameters.AddWithValue("@reuniao", item.FKReuniao);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODDocente ret = new MODDocente();
                ret.IdDocente = Convert.ToInt32(reader["id_docente"]);
                ret.Nome = reader["Nome"].ToString();
                retorno.Add(ret);
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }
    }
}
