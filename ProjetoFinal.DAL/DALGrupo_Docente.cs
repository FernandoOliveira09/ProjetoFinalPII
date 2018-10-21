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
    public static class DALGrupo_Docente
    {
        public static void InserirDocente(MODGrupoDocente grupoDocente)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLGRUPO_Docente (fk_grupo, fk_docente, data_entrada) "
                + "VALUES (@fk_grupo, @fk_docente, @data_entrada)";
            comando.Parameters.AddWithValue("@fk_grupo", grupoDocente.FkGrupo);
            comando.Parameters.AddWithValue("@fk_docente", grupoDocente.FkDocente);
            comando.Parameters.AddWithValue("@data_entrada", grupoDocente.DataEntrada);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void AlterarDataSaidaDocente(MODGrupoDocente grupoDocente)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLGRUPO_Docente SET data_saida = @data where fk_grupo = @grupo and fk_docente = @docente and data_entrada = @data_entrada";
            comando.Parameters.AddWithValue("@data", grupoDocente.DataSaida);
            comando.Parameters.AddWithValue("@grupo", grupoDocente.FkGrupo);
            comando.Parameters.AddWithValue("@docente", grupoDocente.FkDocente);
            comando.Parameters.AddWithValue("@data_entrada", grupoDocente.DataEntrada);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void ExcluirDocente(MODGrupoDocente grupoDocente)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "DELETE FROM TBLGRUPO_Docente where fk_grupo = @grupo and fk_docente = @docente and data_entrada = @data";
            comando.Parameters.AddWithValue("@data", grupoDocente.DataEntrada);
            comando.Parameters.AddWithValue("@grupo", grupoDocente.FkGrupo);
            comando.Parameters.AddWithValue("@tecnico", grupoDocente.FkDocente);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static DataTable Pesquisar(MODGrupoDocente grupoDocente, string tipoPesquisa)
        {
            MySqlCommand comando = new MySqlCommand();
            Conexao.Abrir();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "todos")
            {
                comando.CommandText = "select g.id_grupo, g.nome, g.sigla, g.texto_descricao, s.situacao as Situacao, u.login, u.nome as Lider from tblgrupo g inner join tblgrupo_lider l on l.fk_grupo = g.id_grupo "
                    + "inner join tblusuario u on u.login = l.fk_lider inner join tblsituacao s on s.id_situacao = g.fk_situacao and l.data_saida is null";
            }
            else if (tipoPesquisa == "ativos")
            {
                comando.CommandText = "select d.id_docente, d.nome, d.formacao, d.curso, d.lattes, d.foto, gd.data_entrada from tbldocente d inner join tblgrupo_docente gd on gd.fk_docente = d.id_docente inner join Tblgrupo g on gd.fk_grupo = g.id_grupo "
                    + "and gd.data_saida is null";
            }
            else if (tipoPesquisa == "aguardando")
            {
                comando.CommandText = "select g.id_grupo, g.nome, g.sigla, g.texto_descricao, g.lattes, g.logotipo, s.situacao as Situacao, u.login, u.nome as Lider from tblgrupo g inner join tblgrupo_lider l on l.fk_grupo = g.id_grupo "
                    + "inner join tblusuario u on u.login = l.fk_lider inner join tblsituacao s on s.id_situacao = g.fk_situacao and g.fk_situacao = 3";
            }
            else if (tipoPesquisa == "grupo")
            {
                comando.CommandText = "select g.id_grupo, g.nome, g.sigla, g.texto_descricao, g.lattes, g.logotipo, g.data_inicio as Data, s.situacao as Situacao, u.login, u.nome as Lider, l.data_entrada, l.data_saida from tblgrupo g inner join tblgrupo_lider l on l.fk_grupo = g.id_grupo "
                    + "inner join tblusuario u on u.login = l.fk_lider inner join tblsituacao s on s.id_situacao = g.fk_situacao and l.fk_grupo = @grupo and l.data_saida is null";
                //comando.Parameters.AddWithValue("@grupo", grupoLider.FkGrupo);
            }

            comando.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dados = new DataTable();

            da.Fill(dados);

            return dados;
        }
    }
}
