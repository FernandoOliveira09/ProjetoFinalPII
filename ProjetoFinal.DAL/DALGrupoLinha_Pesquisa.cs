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
    public static class DALGrupoLinha_Pesquisa
    {
        public static void InserirLinha(MODGrupoLinha_Pesquisa grupoLinha)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLGRUPO_Linha_Pesquisa (fk_grupo, fk_linha, data_entrada, descricao) "
                + "VALUES (@fk_grupo, @fk_linha, @data_entrada, @descricao)";
            comando.Parameters.AddWithValue("@fk_grupo", grupoLinha.FkGrupo);
            comando.Parameters.AddWithValue("@fk_linha", grupoLinha.FkLinha);
            comando.Parameters.AddWithValue("@data_entrada", grupoLinha.DataEntrada);
            comando.Parameters.AddWithValue("@descricao", grupoLinha.Descricao);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void AlterarDataSaidaLinha(MODGrupoLinha_Pesquisa grupoLinha)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLGRUPO_Linha_Pesquisa  SET data_saida = @data where fk_grupo = @grupo and fk_linha = @linha and data_entrada = @data_entrada";
            comando.Parameters.AddWithValue("@data", grupoLinha.DataSaida);
            comando.Parameters.AddWithValue("@grupo", grupoLinha.FkGrupo);
            comando.Parameters.AddWithValue("@linha", grupoLinha.FkLinha);
            comando.Parameters.AddWithValue("@data_entrada", grupoLinha.DataEntrada);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void ExcluirLinha(MODGrupoLinha_Pesquisa grupoLinha)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "DELETE FROM TBLGRUPO_Linha_Pesquisa  where fk_grupo = @grupo and fk_linha = @linha and data_entrada = @data";
            comando.Parameters.AddWithValue("@data", grupoLinha.DataEntrada);
            comando.Parameters.AddWithValue("@grupo", grupoLinha.FkGrupo);
            comando.Parameters.AddWithValue("@linha", grupoLinha.FkLinha);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }
    }
}
