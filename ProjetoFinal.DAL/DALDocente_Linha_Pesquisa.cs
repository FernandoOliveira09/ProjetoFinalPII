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
    public static class DALDocente_Linha_Pesquisa
    {
        public static void Inserir(MODDocente_Linha_Pesquisa DocenteLinha)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLDocente_Linha_Pesquisa (fk_grupo, fk_docente, fk_linha, data_entrada) "
                + "VALUES (@fk_grupo, @fk_docente, @fk_linha, @data_entrada)";
            comando.Parameters.AddWithValue("@fk_grupo", DocenteLinha.FkGrupo);
            comando.Parameters.AddWithValue("@fk_docente", DocenteLinha.FkDocente);
            comando.Parameters.AddWithValue("@fk_linha", DocenteLinha.FkLinha);
            comando.Parameters.AddWithValue("@data_entrada", DocenteLinha.DataEntrada);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }
    }
}
