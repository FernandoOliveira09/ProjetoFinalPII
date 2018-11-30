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
    }
}
