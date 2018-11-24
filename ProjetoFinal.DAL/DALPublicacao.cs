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
    public static class DALPublicacao
    {
        public static void Inserir(MODPublicacao publicacao)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if(publicacao.FKProjeto > 0)
            {
                comando.CommandText = "INSERT INTO TBLPublicacao (titulo, tipo_publicacao, referencia_abnt, "
                + "data_publicacao, fk_grupo, fk_projeto, fk_linha, fk_docente) "
                + "VALUES (@titulo, @tipo_publicacao, @referencia_abnt, "
                + "@data_publicacao, @fk_grupo, @fk_projeto, @fk_linha, @fk_docente)";
                comando.Parameters.AddWithValue("@fk_projeto", publicacao.FKProjeto);
            }
            else
            {
                comando.CommandText = "INSERT INTO TBLPublicacao (titulo, tipo_publicacao, referencia_abnt, "
                + "data_publicacao, fk_grupo, fk_linha, fk_docente) "
                + "VALUES (@titulo, @tipo_publicacao, @referencia_abnt, "
                + "@data_publicacao, @fk_grupo, @fk_linha, @fk_docente)";
            }
            
            comando.Parameters.AddWithValue("@titulo", publicacao.Titulo);
            comando.Parameters.AddWithValue("@tipo_publicacao", publicacao.TipoPublicacao);
            comando.Parameters.AddWithValue("@referencia_abnt", publicacao.ReferenciaABNT);
            comando.Parameters.AddWithValue("@data_publicacao", publicacao.DataPublicacao);
            comando.Parameters.AddWithValue("@fk_grupo", publicacao.FkGrupo);            
            comando.Parameters.AddWithValue("@fk_linha", publicacao.FkLinha);
            comando.Parameters.AddWithValue("@fk_docente", publicacao.FkDocente);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static DataTable ConsultaPublicacao(MODPublicacao publicacao, string tipoPesquisa)
        {
            MySqlCommand comando = new MySqlCommand();
            Conexao.Abrir();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "todos")
            {
                comando.CommandText = "select p.id_publicacao, p.titulo as Titulo, g.id_grupo, g.nome as Grupo, pr.id_projeto, pr.titulo as Projeto, d.id_docente, d.nome "
                    + "as Docente, l.id_linha, l.nome_linha as Linha from tblpublicacao p  "
                    + "inner join tblgrupo g on p.fk_grupo = g.id_grupo "
                    + "inner join tblprojeto_pesquisa pr on p.fk_projeto = pr.id_projeto "
                    + "inner join tbldocente d on p.fk_docente = d.id_docente "
                    + "inner join tbllinha_pesquisa l on p.fk_linha = l.id_linha ";
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

            comando.CommandText = "select pu.id_publicacao, pu.titulo as Titulo, d.nome as orientador, l.nome_linha as Linha, pu.tipo_publicacao as Tipo, pu.data_publicacao as Data "
                    + "from tblpublicacao pu "
                    + "inner join tblgrupo g on g.id_grupo = pu.fk_grupo "
                    + "inner join tbldocente d on d.id_docente = pu.fk_docente "
                    + "inner join tbllinha_pesquisa l on l.id_linha = pu.fk_linha and pu.fk_projeto is null and g.sigla = @sigla";

            comando.Parameters.AddWithValue("@sigla", grupo.Sigla);

            comando.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dados = new DataTable();

            da.Fill(dados);

            return dados;
        }

        public static DataTable ConsultaPorProjeto(MODProjetoPesquisa projetoPesquisa)
        {
            MySqlCommand comando = new MySqlCommand();
            Conexao.Abrir();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "select pu.id_publicacao, pu.titulo as Titulo, d.nome as orientador, l.nome_linha as Linha, pu.tipo_publicacao as Tipo, pu.data_publicacao as Data "
                    + "from tblpublicacao pu "
                    + "inner join tblgrupo g on g.id_grupo = pu.fk_grupo "
                    + "inner join tbldocente d on d.id_docente = pu.fk_docente "
                    + "inner join tblprojeto_pesquisa p on p.id_projeto = pu.fk_projeto "
                    + "inner join tbllinha_pesquisa l on l.id_linha = pu.fk_linha and p.id_projeto = @projeto";

            comando.Parameters.AddWithValue("@projeto", projetoPesquisa.IdProjeto);

            comando.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dados = new DataTable();

            da.Fill(dados);

            return dados;
        }

        public static DataTable Relatorio(MODPublicacao publicacao, string ano, string tipoPesquisa)
        {
            MySqlCommand comando = new MySqlCommand();
            Conexao.Abrir();
            comando.Connection = Conexao.conexao;

            if(tipoPesquisa == "grupo")
            {
                comando.CommandText = "select pu.titulo, pu.tipo_publicacao, pu.referencia_abnt, pu.data_publicacao, l.nome_linha, d.nome "
                    + "from tblpublicacao pu "
                    + "inner join tbldocente d on d.id_docente = pu.fk_docente "
                    + "inner join tbllinha_pesquisa l on l.id_linha = pu.fk_linha "
                    + "and pu.fk_grupo = @grupo and pu.fk_projeto is null and pu.tipo_publicacao = @tipo "
                    + "and pu.data_publicacao between '" + ano +"-01-01' and '"+ ano + "-12-31'";

                comando.Parameters.AddWithValue("@grupo", publicacao.FkGrupo);
                comando.Parameters.AddWithValue("@tipo", publicacao.TipoPublicacao);
            }
            else
            {
                comando.CommandText = "select pu.titulo, pu.tipo_publicacao, pu.referencia_abnt, pu.data_publicacao, pr.titulo as Projeto, l.nome_linha, d.nome "
                    + "from tblpublicacao pu "
                    + "inner join tbldocente d on d.id_docente = pu.fk_docente "
                    + "inner join tbllinha_pesquisa l on l.id_linha = pu.fk_linha "
                    + "inner join tblprojeto_pesquisa pr on pr.id_projeto = pu.fk_projeto "
                    + "and pu.fk_grupo = @grupo and pu.fk_projeto = @projeto and pu.tipo_publicacao = @tipo "
                    + "and pu.data_publicacao between '" + ano + "-01-01' and '" + ano + "-12-31'";

                comando.Parameters.AddWithValue("@grupo", publicacao.FkGrupo);
                comando.Parameters.AddWithValue("@projeto", publicacao.FKProjeto);
                comando.Parameters.AddWithValue("@tipo", publicacao.TipoPublicacao);

            }
            
            comando.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dados = new DataTable();

            da.Fill(dados);

            return dados;
        }
    }
}
