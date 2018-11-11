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


        public static DataTable PesquisarLinha(MODProjetoPesquisa_Linha projetoLinha)
        {
            MySqlCommand comando = new MySqlCommand();
            Conexao.Abrir();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "select l.id_linha, l.nome_linha from tbllinha_pesquisa l " 
                + "inner join tblprojeto_linha_pesquisa pl on pl.fk_linha = l.id_linha " 
                + "inner join tblprojeto_pesquisa p on pl.fk_projeto = p.id_projeto and pl.fk_projeto = @projeto";
            comando.Parameters.AddWithValue("@projeto", projetoLinha.FkProjeto);

            comando.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dados = new DataTable();

            da.Fill(dados);

            return dados;
        }

        public static MODProjetoPesquisa PesquisarDocente(MODProjetoPesquisa projetoPesquisa)
        {
            MODProjetoPesquisa retorno = new MODProjetoPesquisa();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "SELECT fk_docente from TBLProjeto_pesquisa WHERE id_projeto = @projeto";
            comando.Parameters.AddWithValue("@projeto", projetoPesquisa.IdProjeto);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODProjetoPesquisa ret = new MODProjetoPesquisa();
                ret.FkDocente = Convert.ToInt32(reader["fk_docente"]);

                retorno.FkDocente = ret.FkDocente;
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static List<MODProjetoPesquisa> PesquisarProjetos(MODProjetoPesquisa item, string tipoPesquisa)
        {
            List<MODProjetoPesquisa> retorno = new List<MODProjetoPesquisa>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "todos")
            {
                comando.CommandText = "select id_projeto, titulo from tblprojeto_pesquisa";
            }
            else if (tipoPesquisa == "grupo")
            {
                comando.CommandText = "select id_projeto, titulo from tblprojeto_pesquisa where fk_grupo = @grupo";
                comando.Parameters.AddWithValue("@grupo", item.FkGrupo);
            }
            else 
            {
                comando.CommandText = "select id_projeto, titulo from tblprojeto_pesquisa where fk_grupo = @grupo and fk_docente = @docente";
                comando.Parameters.AddWithValue("@grupo", item.FkGrupo);
                comando.Parameters.AddWithValue("@docente", item.FkDocente);
            }

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODProjetoPesquisa ret = new MODProjetoPesquisa();
                ret.IdProjeto = Convert.ToInt32(reader["id_projeto"].ToString());
                ret.Titulo = reader["titulo"].ToString();

                retorno.Add(ret);
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static DataTable ConsultaProjetos(MODProjetoPesquisa projeto, string tipoPesquisa)
        {
            MySqlCommand comando = new MySqlCommand();
            Conexao.Abrir();
            comando.Connection = Conexao.conexao;

            if(tipoPesquisa == "todos")
            {
                comando.CommandText = "select p.id_projeto, p.titulo as Titulo, g.id_grupo, g.nome as Grupo, d.id_docente, d.nome as Docente, di.id_discente, di.nome as Discente from tblprojeto_pesquisa p "
                    + "inner join tbldocente d on p.fk_docente = d.id_docente "
                    + "inner join tblgrupo g on p.fk_grupo = g.id_grupo "
                    + "inner join tblprojeto_discente pd on pd.fk_projeto = p.id_projeto "
                    + "inner join tbldiscente di on pd.fk_discente = di.id_discente";
            }
            else if (tipoPesquisa == "projeto")
            {
                comando.CommandText = "select p.id_projeto, p.titulo as Titulo, p.data_inicio as Data, g.id_grupo, g.nome as Grupo, d.id_docente, d.nome as Docente, di.id_discente, di.nome as Discente from tblprojeto_pesquisa p "
                    + "inner join tbldocente d on p.fk_docente = d.id_docente "
                    + "inner join tblgrupo g on p.fk_grupo = g.id_grupo "
                    + "inner join tblprojeto_discente pd on pd.fk_projeto = p.id_projeto "
                    + "inner join tbldiscente di on pd.fk_discente = di.id_discente and p.id_projeto = @projeto";

                comando.Parameters.AddWithValue("@projeto", projeto.IdProjeto);
            }

            comando.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dados = new DataTable();

            da.Fill(dados);

            return dados;
        }

        public static DataTable ConsultaPorGrupo(MODGrupo grupo)
        {
            MySqlCommand comando = new MySqlCommand();
            Conexao.Abrir();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "select p.id_projeto, p.titulo from tblprojeto_pesquisa p "
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
