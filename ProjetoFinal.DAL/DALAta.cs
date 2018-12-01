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
    public static class DALAta
    {
        public static void Inserir(MODAta ata)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLREUNIAO_ATA (ata, fk_reuniao) "
                + "VALUES (@ata, @fk_reuniao)";
            comando.Parameters.AddWithValue("@ata", ata.Ata);
            comando.Parameters.AddWithValue("@fk_reuniao", ata.FkReuniao);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void Alterar(MODAta ata)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLREUNIAO_ATA SET ata = @ata "
                + "WHERE id_ata = @id";
            comando.Parameters.AddWithValue("@id", ata.IdAta);
            comando.Parameters.AddWithValue("@ata", ata.Ata);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void Excluir(MODAta ata)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "DELETE FROM TBLREUNIAO_ATA WHERE id_ata = @id ";
            comando.Parameters.AddWithValue("@id", ata.IdAta);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static MODAta PesquisarAta(MODAta ata, string tipoPesquisa)
        {
            MODAta retorno = new MODAta();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "reuniao")
            {
                comando.CommandText = "SELECT id_ata, ata, fk_reuniao FROM tblreuniao_ata WHERE fk_reuniao = @fk";
                comando.Parameters.AddWithValue("@fk", ata.FkReuniao);
            }
        

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODAta ret = new MODAta();
                ret.IdAta = Convert.ToInt32(reader["id_ata"]);
                ret.Ata = reader["ata"].ToString();
                ret.FkReuniao = Convert.ToInt32(reader["fk_reuniao"].ToString());

                retorno.IdAta = ret.IdAta;
                retorno.Ata = ret.Ata;
                retorno.FkReuniao = ret.FkReuniao;
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }
    }
}
