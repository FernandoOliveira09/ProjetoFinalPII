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
    }
}
