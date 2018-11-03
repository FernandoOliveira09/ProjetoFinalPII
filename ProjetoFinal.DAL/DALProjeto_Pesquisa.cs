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
    public static class DALProjeto_Pesquisa
    {
        public static int Inserir(MODProjetoPesquisa projetoPesquisa)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLProjeto_pesquisa (titulo, tipo, bolsa, nome_bolsa, data_inicio, data_fim, fk_docente, fk_grupo)" 
                + " VALUES (@titulo, @tipo, @bolsa, @nomebolsa, @data_inicio, @data_fim, @fkdocente, @fkgrupo)";
            comando.Parameters.AddWithValue("@titulo", projetoPesquisa.Titulo);
            comando.Parameters.AddWithValue("@tipo", projetoPesquisa.Tipo);
            comando.Parameters.AddWithValue("@bolsa", projetoPesquisa.Bolsa);
            comando.Parameters.AddWithValue("@nomebolsa", projetoPesquisa.NomeBolsa);
            comando.Parameters.AddWithValue("@data_inicio", projetoPesquisa.DataInicio);
            comando.Parameters.AddWithValue("@data_fim", projetoPesquisa.DataTermino);
            comando.Parameters.AddWithValue("@fkdocente", projetoPesquisa.FkDocente);
            comando.Parameters.AddWithValue("@fkgrupo", projetoPesquisa.FkGrupo);

            comando.ExecuteNonQuery();

            if (comando.LastInsertedId != 0)
                comando.Parameters.Add(new MySqlParameter("ultimoId", comando.LastInsertedId));

            Conexao.Fechar();

            return Convert.ToInt32(comando.Parameters["@ultimoId"].Value);
        }

        public static void InserirLinha(MODProjetoPesquisa_Linha projetoLinha)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLProjeto_linha_pesquisa (fk_projeto, fk_linha)"
                + " VALUES (@fk_projeto, @fk_linha)";
            comando.Parameters.AddWithValue("@fk_projeto", projetoLinha.FkProjeto);
            comando.Parameters.AddWithValue("@fk_linha", projetoLinha.FkLinha);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static MODProjetoPesquisa_Linha PesquisarLinha(MODProjetoPesquisa_Linha projetoLinha)
        {
            MODProjetoPesquisa_Linha retorno = new MODProjetoPesquisa_Linha();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "SELECT * from TBLProjeto_linha_pesquisa WHERE fk_Projeto = @projeto and fk_linha = @linha";
            comando.Parameters.AddWithValue("@projeto", projetoLinha.FkProjeto);
            comando.Parameters.AddWithValue("@linha", projetoLinha.FkLinha);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODProjetoPesquisa_Linha ret = new MODProjetoPesquisa_Linha();
                ret.FkLinha = reader["fk_linha"].ToString();
                ret.FkProjeto = Convert.ToInt32(reader["fk_Projeto"]);


                retorno.FkLinha = ret.FkLinha;
                retorno.FkProjeto = ret.FkProjeto;
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }
    }
}
