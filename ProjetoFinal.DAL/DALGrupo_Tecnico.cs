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
    public static class DALGrupo_Tecnico
    {
        public static void InserirTecnico(MODGrupoTecnico grupoTecnico)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLGRUPO_Tecnico (fk_grupo, fk_tecnico, data_entrada) "
                + "VALUES (@fk_grupo, @fk_tecnico, @data_entrada)";
            comando.Parameters.AddWithValue("@fk_grupo", grupoTecnico.FkGrupo);
            comando.Parameters.AddWithValue("@fk_tecnico", grupoTecnico.FkTecnico);
            comando.Parameters.AddWithValue("@data_entrada", grupoTecnico.DataEntrada);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void AlterarDataSaidaTecnico(MODGrupoTecnico grupoTecnico)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLGRUPO_Tecnico SET data_saida = @data where fk_grupo = @grupo and fk_tecnico = @tecnico, data_entrada = @data_entrada";
            comando.Parameters.AddWithValue("@data", grupoTecnico.DataSaida);
            comando.Parameters.AddWithValue("@grupo", grupoTecnico.FkGrupo);
            comando.Parameters.AddWithValue("@tecnico", grupoTecnico.FkTecnico);
            comando.Parameters.AddWithValue("@data_entrada", grupoTecnico.DataEntrada);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void ExcluirTecnico(MODGrupoTecnico grupoTecnico)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "DELETE FROM TBLGRUPO_Tecnico where fk_grupo = @grupo and fk_tecnico = @tecnico and data_entrada = @data";
            comando.Parameters.AddWithValue("@data", grupoTecnico.DataEntrada);
            comando.Parameters.AddWithValue("@grupo", grupoTecnico.FkGrupo);
            comando.Parameters.AddWithValue("@tecnico", grupoTecnico.FkTecnico);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }
    }
}
