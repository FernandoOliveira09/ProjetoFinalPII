using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using MySql.Data.MySqlClient;

namespace ProjetoFinal.DAL
{
    public static class DALGrupo
    {
        public static int InserirGrupo(MODGrupo grupo)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLGRUPO (nome, sigla, fk_situacao) VALUES (@nome, @sigla, @fk_situacao)";
            comando.Parameters.AddWithValue("@nome", grupo.Nome);
            comando.Parameters.AddWithValue("@sigla", grupo.Sigla);
            comando.Parameters.AddWithValue("@fk_situacao", grupo.FkSituacao);

            comando.ExecuteNonQuery();

            if (comando.LastInsertedId != 0)
                comando.Parameters.Add(new MySqlParameter("ultimoId", comando.LastInsertedId));

            Conexao.Fechar();

            return Convert.ToInt32(comando.Parameters["@ultimoId"].Value);
        }

        public static void InserirLider(MODGrupoLider grupoLider)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLGRUPO_LIDER (data_entrada, fk_lider, fk_grupo) VALUES " +
                "(@data_entrada, @fk_lider, @fk_grupo)";
            comando.Parameters.AddWithValue("@data_entrada", grupoLider.DataEntrada);
            comando.Parameters.AddWithValue("@fk_lider", grupoLider.FkUsuario);
            comando.Parameters.AddWithValue("@fk_grupo", grupoLider.FkGrupo);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void AlterarGrupo(MODGrupo grupo, string tipoAlteracao)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if(tipoAlteracao == "Todos")
            {
                comando.CommandText = "UPDATE TBLGRUPO SET nome = @nome, sigla = @sigla, email = @email, texto_descricao = @texto" +
                "logotipo = @logotipo, lattes = @lattes, data_inicio = @data_inicio WHERE id_grupo = @id";
                comando.Parameters.AddWithValue("@nome", grupo.Nome);
                comando.Parameters.AddWithValue("@sigla", grupo.Sigla);
                comando.Parameters.AddWithValue("@email", grupo.Email);
                comando.Parameters.AddWithValue("@texto", grupo.Descricao);
                comando.Parameters.AddWithValue("@logotipo", grupo.Logotipo);
                comando.Parameters.AddWithValue("@lattes", grupo.Lattes);
                comando.Parameters.AddWithValue("@data_inicio", grupo.DataInicio);
                comando.Parameters.AddWithValue("@id", grupo.IdGrupo);
            }
            else
            {
                comando.CommandText = "UPDATE TBLGRUPO SET fk_situacao = @fk_situacao WHERE id_grupo = @id";
                comando.Parameters.AddWithValue("@fk_situacao", grupo.FkSituacao);
                comando.Parameters.AddWithValue("@id", grupo.IdGrupo);
            }
            
            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        
    }
}
