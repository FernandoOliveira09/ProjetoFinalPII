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
    public static class DALDiscente
    {
        public static void InserirDiscente(MODDiscente discente)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLDISCENTE (nome, curso, lattes) "
                + "VALUES (@nome, @curso, @lattes)";
            comando.Parameters.AddWithValue("@nome", discente.Nome);
            comando.Parameters.AddWithValue("@curso", discente.Curso);
            comando.Parameters.AddWithValue("@lattes", discente.Lattes);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void InserirDiscenteProjeto(MODProjetoPesquisa_Discente projetoDiscente)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLPROJETO_DISCENTE (fk_projeto, fk_discente, data_inicio) "
                + "VALUES (@fk_projeto, @fk_discente, @data_inicio)";
            comando.Parameters.AddWithValue("@fk_projeto", projetoDiscente.FkProjeto);
            comando.Parameters.AddWithValue("@fk_discente", projetoDiscente.FkDiscente);
            comando.Parameters.AddWithValue("@data_inicio", projetoDiscente.DataInicio);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void Alterar(MODDiscente discente)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLDISCENTE SET nome = @nome, "
                + "curso = @curso, "
                + "lattes = @lattes "
                + "WHERE id_discente = @id";
            comando.Parameters.AddWithValue("@id", discente.IdDiscente);
            comando.Parameters.AddWithValue("@nome", discente.Nome);
            comando.Parameters.AddWithValue("@curso", discente.Curso);
            comando.Parameters.AddWithValue("@lattes", discente.Lattes);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static MODDiscente PesquisarDiscente(MODDiscente discente, string tipoPesquisa)
        {
            MODDiscente retorno = new MODDiscente();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "id")
            {
                comando.CommandText = "SELECT id_discente, nome, curso, lattes FROM TBLDISCENTE WHERE id_discente = @id";
                comando.Parameters.AddWithValue("@id", discente.IdDiscente);
            }
            else
            {
                comando.CommandText = "SELECT id_discente, nome, curso, lattes FROM TBLDISCENTE WHERE nome = @nome";
                comando.Parameters.AddWithValue("@nome", discente.Nome);
            }

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODDiscente ret = new MODDiscente();
                ret.IdDiscente = Convert.ToInt32(reader["id_discente"]);
                ret.Nome = reader["nome"].ToString();
                ret.Curso = reader["curso"].ToString();
                ret.Lattes = reader["lattes"].ToString();

                retorno.IdDiscente = ret.IdDiscente;
                retorno.Nome = ret.Nome;
                retorno.Curso = ret.Curso;
                retorno.Lattes = ret.Lattes;
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static List<MODDiscente> Pesquisar(MODDiscente item, string tipoPesquisa)
        {
            List<MODDiscente> retorno = new List<MODDiscente>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "nome")
            {
                comando.CommandText = "SELECT id_discente, nome, curso, lattes FROM TBLDISCENTE WHERE nome = @nome";
                comando.Parameters.AddWithValue("@nome", item.Nome);
            }
            else if (tipoPesquisa == "incompleto")
            {
                comando.CommandText = "SELECT id_discente, nome, curso, lattes FROM TBLDISCENTE WHERE nome like @nome";
                comando.Parameters.AddWithValue("@nome", "%" + item.Nome + "%");
            }
            else if (tipoPesquisa == "curso")
            {
                comando.CommandText = "SELECT id_discente, nome, curso, lattes FROM TBLDISCENTE WHERE curso = @curso";
                comando.Parameters.AddWithValue("@curso", item.Curso);
            }
            else if (tipoPesquisa == "todos")
            {
                comando.CommandText = "SELECT id_discente, nome, curso, lattes FROM TBLDISCENTE";
            }

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODDiscente ret = new MODDiscente();
                ret.IdDiscente = Convert.ToInt32(reader["id_discente"]);
                ret.Nome = reader["nome"].ToString();
                ret.Curso = reader["curso"].ToString();
                ret.Lattes = reader["lattes"].ToString();

                retorno.Add(ret);
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static DataTable PesquisarPorGrupo(MODGrupo grupo)
        {
            MySqlCommand comando = new MySqlCommand();
            Conexao.Abrir();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "select di.id_discente, di.nome as Nome, di.curso, di.lattes, p.titulo as Projeto from tbldiscente di "
                    + "inner join tblprojeto_discente pd on pd.fk_discente = di.id_discente "
                    + "inner join tblprojeto_pesquisa p on pd.fk_projeto = p.id_projeto "
                    + "inner join tblgrupo g on p.fk_grupo = g.id_grupo and g.sigla = @sigla";

            comando.Parameters.AddWithValue("@sigla", grupo.Sigla);


            comando.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dados = new DataTable();

            da.Fill(dados);

            return dados;
        }

    }
}
