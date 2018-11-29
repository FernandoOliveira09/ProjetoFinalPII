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

            comando.CommandText = "INSERT INTO TBLGRUPO_Linha_Pesquisa (fk_grupo, fk_linha, data_inicio, descricao) "
                + "VALUES (@fk_grupo, @fk_linha, @data_inicio, @descricao)";
            comando.Parameters.AddWithValue("@fk_grupo", grupoLinha.FkGrupo);
            comando.Parameters.AddWithValue("@fk_linha", grupoLinha.FkLinha);
            comando.Parameters.AddWithValue("@data_inicio", grupoLinha.DataEntrada);
            comando.Parameters.AddWithValue("@descricao", grupoLinha.Descricao);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void AlterarDataSaidaLinha(MODGrupoLinha_Pesquisa grupoLinha)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLGRUPO_Linha_Pesquisa  SET data_saida = @data where fk_grupo = @grupo and fk_linha = @linha and data_inicio = @data_inicio";
            comando.Parameters.AddWithValue("@data", grupoLinha.DataSaida);
            comando.Parameters.AddWithValue("@grupo", grupoLinha.FkGrupo);
            comando.Parameters.AddWithValue("@linha", grupoLinha.FkLinha);
            comando.Parameters.AddWithValue("@data_inicio", grupoLinha.DataEntrada);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void ExcluirLinha(MODGrupoLinha_Pesquisa grupoLinha)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "DELETE FROM TBLGRUPO_Linha_Pesquisa  where fk_grupo = @grupo and fk_linha = @linha and data_inicio = @data";
            comando.Parameters.AddWithValue("@data", grupoLinha.DataEntrada);
            comando.Parameters.AddWithValue("@grupo", grupoLinha.FkGrupo);
            comando.Parameters.AddWithValue("@linha", grupoLinha.FkLinha);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static DataTable Pesquisar(MODGrupoLinha_Pesquisa grupoLinha, string tipoPesquisa)
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
                comando.CommandText = "select l.id_linha, l.nome_linha, gl.descricao from tbllinha_pesquisa l inner join tblgrupo_linha_pesquisa gl on gl.fk_linha = l.id_linha inner join Tblgrupo g on gl.fk_grupo = g.id_grupo "
                    + "and gl.data_termino is null";
            }
            else if (tipoPesquisa == "gativos")
            {
                comando.CommandText = "select l.id_linha, l.nome_linha, gl.descricao from tbllinha_pesquisa l inner join tblgrupo_linha_pesquisa gl on gl.fk_linha = l.id_linha inner join Tblgrupo g on gl.fk_grupo = g.id_grupo "
                    + "and gl.data_termino is null and gl.fk_grupo = @grupo";
                comando.Parameters.AddWithValue("@grupo", grupoLinha.FkGrupo);
            }
            else if (tipoPesquisa == "aguardando")
            {
                comando.CommandText = "select g.id_grupo, g.nome, g.sigla, g.texto_descricao, g.lattes, g.logotipo, s.situacao as Situacao, u.login, u.nome as Lider from tblgrupo g inner join tblgrupo_lider l on l.fk_grupo = g.id_grupo "
                    + "inner join tblusuario u on u.login = l.fk_lider inner join tblsituacao s on s.id_situacao = g.fk_situacao and g.fk_situacao = 3";
            }
            else if (tipoPesquisa == "grupo")
            {
                comando.CommandText = "select l.id_linha, l.nome_linha, gl.descricao, gl.data_inicio, gl.data_termino, g.id_grupo from tbllinha_pesquisa l inner join tblgrupo_linha_pesquisa gl " 
                    + "on gl.fk_linha = l.id_linha inner join Tblgrupo g on gl.fk_grupo = g.id_grupo and gl.fk_grupo = @grupo";
                comando.Parameters.AddWithValue("@grupo", grupoLinha.FkGrupo);
            }

            comando.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dados = new DataTable();

            da.Fill(dados);

            return dados;
        }
    }
}
