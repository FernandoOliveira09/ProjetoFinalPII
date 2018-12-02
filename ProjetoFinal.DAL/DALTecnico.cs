using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using MySql.Data.MySqlClient;

namespace ProjetoFinal.DAL
{
    public static class DALTecnico
    {
        public static void Inserir(MODTecnico tecnico)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLTECNICO (nome, lattes, atividade, formacao, curso, data_conclusao, foto) "
                + "VALUES (@nome, @lattes, @atividade, @formacao, @curso, @data_conclusao, @foto)";
            comando.Parameters.AddWithValue("@nome", tecnico.Nome);
            comando.Parameters.AddWithValue("@lattes", tecnico.Lattes);
            comando.Parameters.AddWithValue("@atividade", tecnico.Atividade);
            comando.Parameters.AddWithValue("@formacao", tecnico.Formacao);
            comando.Parameters.AddWithValue("@curso", tecnico.Curso);
            comando.Parameters.AddWithValue("@data_conclusao", tecnico.AnoConclusao);
            comando.Parameters.AddWithValue("@foto", tecnico.Foto);


            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void Alterar(MODTecnico tecnico)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLTecnico SET nome = @nome, lattes = @lattes, atividade = @atividade, "
                + "formacao = @formacao, curso = @curso, data_conclusao = @data_conclusao, foto = @foto "
                + "WHERE id_tecnico = @id_tecnico";
            comando.Parameters.AddWithValue("@id_tecnico", tecnico.IdTecnico);
            comando.Parameters.AddWithValue("@nome", tecnico.Nome);
            comando.Parameters.AddWithValue("@lattes", tecnico.Lattes);
            comando.Parameters.AddWithValue("@atividade", tecnico.Atividade);
            comando.Parameters.AddWithValue("@formacao", tecnico.Formacao);
            comando.Parameters.AddWithValue("@curso", tecnico.Curso);
            comando.Parameters.AddWithValue("@data_conclusao", tecnico.AnoConclusao);
            comando.Parameters.AddWithValue("@foto", tecnico.Foto);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static MODTecnico PesquisarTecnico(MODTecnico tecnico)
        {
            MODTecnico retorno = new MODTecnico();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "SELECT nome, lattes, atividade, formacao, curso, data_conclusao, foto FROM TBLTECNICO WHERE id_tecnico = @id";

            comando.Parameters.AddWithValue("@id", tecnico.IdTecnico);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODTecnico ret = new MODTecnico();
                ret.Nome = reader["Nome"].ToString();
                ret.Lattes = reader["Lattes"].ToString();
                ret.Atividade = reader["Atividade"].ToString();
                ret.Formacao = reader["Formacao"].ToString();
                ret.Curso = reader["Curso"].ToString();
                if (reader["data_conclusao"].ToString() != "")
                    ret.AnoConclusao = Convert.ToDateTime(reader["data_conclusao"].ToString());
                ret.Foto = reader["Foto"].ToString();

                retorno.Nome = ret.Nome;
                retorno.Lattes = ret.Lattes;
                retorno.Atividade = ret.Atividade;
                retorno.Formacao = ret.Formacao;
                retorno.Curso = ret.Curso;
                retorno.AnoConclusao = ret.AnoConclusao;
                retorno.Foto = ret.Foto;
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static List<MODTecnico> Pesquisar(MODTecnico item, string tipoPesquisa)
        {
            List<MODTecnico> retorno = new List<MODTecnico>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "nome")
            {
                comando.CommandText = "SELECT nome, lattes, atividade, formacao, curso, data_conclusao, foto FROM TBLTECNICO WHERE nome = @nome";
                comando.Parameters.AddWithValue("@nome", item.Nome);
            }
            else if (tipoPesquisa == "lattes")
            {
                comando.CommandText = "SELECT nome, lattes, atividade, formacao, curso, data_conclusao, foto FROM TBLTECNICO WHERE lattes = @lattes";
                comando.Parameters.AddWithValue("@lattes", item.Lattes);
            }

            else if (tipoPesquisa == "todos")
            {
                comando.CommandText = "SELECT id_tecnico, nome, lattes, atividade, formacao, curso, data_conclusao, foto FROM TBLTECNICO";
            }
            else
            {
                //    comando.CommandText = "SELECT login, nome, email, lattes, imagem, fk_tipo, fk_status FROM TBLUSUARIO where fk_tipo = 2 and fk_status = 1";
            }

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODTecnico ret = new MODTecnico();
                ret.IdTecnico = Convert.ToInt32(reader["id_tecnico"]);
                ret.Nome = reader["Nome"].ToString();
                ret.Lattes = reader["Lattes"].ToString();
                ret.Atividade = reader["Atividade"].ToString();
                ret.Formacao = reader["Formacao"].ToString();
                ret.Curso = reader["Curso"].ToString();
                if (reader["data_conclusao"].ToString() != "")
                    ret.AnoConclusao = Convert.ToDateTime(reader["data_conclusao"].ToString());
                ret.Foto = reader["Foto"].ToString();

                retorno.Add(ret);
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        /* public static List<MODTecnico> PesquisarAdmin()
         {
             List<MODTecnico> retorno = new List<MODTecnico>();

             Conexao.Abrir();

             MySqlCommand comando = new MySqlCommand();
             comando.Connection = Conexao.conexao;

             comando.CommandText = "SELECT login, fk_tipo FROM TBLUSUARIO WHERE fk_tipo = 1";

             MySqlDataReader reader = comando.ExecuteReader();

             while (reader.Read())
             {
                 MODTecnico ret = new MODTecnico();
                 ret.Login = reader["Login"].ToString();
                 ret.FkTipo = (int)reader["Fk_Tipo"];

                 retorno.Add(ret);
             }

             reader.Close();

             Conexao.Fechar();

             return retorno;
         }*/
    }
}

