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

            if(tipoAlteracao == "todos")
            {
                comando.CommandText = "UPDATE TBLGRUPO SET nome = @nome, sigla = @sigla, email = @email, texto_descricao = @texto, " +
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

        public static void AlterarLider(MODGrupoLider grupoLider, string tipoAlteracao)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoAlteracao == "data_saida")
            {
                comando.CommandText = "UPDATE TBLGRUPO_LIDER SET data_saida = @data_saida where id = @id";
                comando.Parameters.AddWithValue("@data_saida", grupoLider.DataSaida);
                comando.Parameters.AddWithValue("@id", grupoLider.Id);
            }
            
            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static MODGrupo PesquisarGrupo(MODGrupo grupo, string tipoPesquisa)
        {
            MODGrupo retorno = new MODGrupo();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if(tipoPesquisa == "nome")
            {
                comando.CommandText = "SELECT id_grupo, nome, sigla, email, texto_descricao, logotipo, lattes, data_inicio, fk_situacao FROM TBLGRUPO WHERE nome = @nome";
                comando.Parameters.AddWithValue("@nome", grupo.Nome);
            }
            else if (tipoPesquisa == "id")
            {
                comando.CommandText = "SELECT id_grupo, nome, sigla, email, texto_descricao, logotipo, lattes, data_inicio, fk_situacao FROM TBLGRUPO WHERE id_grupo = @id";
                comando.Parameters.AddWithValue("@id", grupo.IdGrupo);
            }
            else
            {
                comando.CommandText = "SELECT id_grupo, nome, sigla, email, texto_descricao, logotipo, lattes, data_inicio, fk_situacao FROM TBLGRUPO WHERE sigla = @sigla";
                comando.Parameters.AddWithValue("@sigla", grupo.Sigla);
            }

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODGrupo ret = new MODGrupo();
                ret.IdGrupo = Convert.ToInt32(reader["id_grupo"]);
                ret.Nome = reader["Nome"].ToString();
                ret.Sigla = reader["Sigla"].ToString();
                ret.Email = reader["Email"].ToString();
                ret.Descricao = reader["texto_descricao"].ToString();
                ret.Logotipo = reader["Logotipo"].ToString();
                ret.Lattes = reader["lattes"].ToString();
                if(reader["data_inicio"].ToString() != "")
                    ret.DataInicio = Convert.ToDateTime(reader["data_inicio"].ToString());
                ret.FkSituacao = Convert.ToInt32(reader["fk_situacao"]);

                retorno.IdGrupo = ret.IdGrupo;
                retorno.Nome = ret.Nome;
                retorno.Sigla = ret.Sigla;
                retorno.Email = ret.Email;
                retorno.Descricao = ret.Descricao;
                retorno.Logotipo = ret.Logotipo;
                retorno.Lattes = ret.Lattes;
                retorno.DataInicio = ret.DataInicio;
                retorno.FkSituacao = ret.FkSituacao;
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static MODGrupoLider PesquisarLider(MODGrupoLider grupoLider)
        {
            MODGrupoLider retorno = new MODGrupoLider();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "SELECT id, fk_grupo, fk_lider, data_entrada, data_saida FROM tblgrupo_lider where fk_grupo = @grupo";
            comando.Parameters.AddWithValue("@grupo", grupoLider.FkGrupo);
            

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODGrupoLider ret = new MODGrupoLider();
                ret.Id = Convert.ToInt32(reader["id"]);
                ret.FkGrupo = Convert.ToInt32(reader["fk_grupo"]);
                ret.FkUsuario = reader["fk_lider"].ToString();
                ret.DataEntrada = Convert.ToDateTime(reader["data_entrada"].ToString());
                if (reader["data_saida"].ToString() != "")
                    ret.DataSaida = Convert.ToDateTime(reader["data_saida"].ToString());

                retorno.Id = ret.Id;
                retorno.FkGrupo = ret.FkGrupo;
                retorno.FkUsuario = ret.FkUsuario;
                retorno.DataEntrada = ret.DataEntrada;
                retorno.DataSaida = ret.DataSaida;
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static DataTable Pesquisar(MODGrupoLider grupoLider, string tipoPesquisa)
        {
            MySqlCommand comando = new MySqlCommand();
            Conexao.Abrir();
            comando.Connection = Conexao.conexao;

            if(tipoPesquisa == "todos")
            {
                comando.CommandText = "select g.id_grupo, g.nome, g.sigla, g.texto_descricao, s.situacao as Situacao, u.login, u.nome as Lider from tblgrupo g inner join tblgrupo_lider l on l.fk_grupo = g.id_grupo "
                    + "inner join tblusuario u on u.login = l.fk_lider inner join tblsituacao s on s.id_situacao = g.fk_situacao and l.data_saida is null";
            }
            else if (tipoPesquisa == "ativos")
            {
                comando.CommandText = "select g.id_grupo, g.nome, g.sigla, g.texto_descricao, g.lattes, g.logotipo, s.situacao as Situacao, u.login, u.nome as Lider from tblgrupo g inner join tblgrupo_lider l on l.fk_grupo = g.id_grupo "
                    + "inner join tblusuario u on u.login = l.fk_lider inner join tblsituacao s on s.id_situacao = g.fk_situacao and g.fk_situacao = 1 and l.data_saida is null";
            }
            else if (tipoPesquisa == "aguardando")
            {
                comando.CommandText = "select g.id_grupo, g.nome, g.sigla, g.texto_descricao, g.lattes, g.logotipo, s.situacao as Situacao, u.login, u.nome as Lider from tblgrupo g inner join tblgrupo_lider l on l.fk_grupo = g.id_grupo "
                    + "inner join tblusuario u on u.login = l.fk_lider inner join tblsituacao s on s.id_situacao = g.fk_situacao and g.fk_situacao = 3";
            }
            else if(tipoPesquisa == "grupo")
            {
                comando.CommandText = "select g.id_grupo, g.nome, g.sigla, g.texto_descricao, g.lattes, g.logotipo, g.data_inicio as Data, s.situacao as Situacao, u.login, u.nome as Lider, l.data_entrada, l.data_saida from tblgrupo g inner join tblgrupo_lider l on l.fk_grupo = g.id_grupo "
                    + "inner join tblusuario u on u.login = l.fk_lider inner join tblsituacao s on s.id_situacao = g.fk_situacao and l.fk_grupo = @grupo and l.data_saida is null";
                comando.Parameters.AddWithValue("@grupo", grupoLider.FkGrupo);
            }
            

            comando.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dados = new DataTable();

            da.Fill(dados);

            return dados;
        }

        public static List<MODGrupo> PesquisarGrupos(MODGrupo item, string tipoPesquisa)
        {
            List<MODGrupo> retorno = new List<MODGrupo>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "todos")
            {
                comando.CommandText = "select id_grupo, nome from tblgrupo";
            }
            else if (tipoPesquisa == "nome")
            {
                comando.CommandText = "select id_grupo, nome from tblgrupo where nome = @nome";
                comando.Parameters.AddWithValue("@nome", item.Nome);
            }
            else
            {
                comando.CommandText = "select id_grupo, nome from tblgrupo where nome like @nome";
                comando.Parameters.AddWithValue("@nome", "%" + item.Nome + "%");
            }

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODGrupo ret = new MODGrupo();
                ret.IdGrupo = Convert.ToInt32(reader["id_grupo"].ToString());
                ret.Nome = reader["Nome"].ToString();

                retorno.Add(ret);
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static DataTable Relatorio(MODGrupo grupo, string ano, string tipoPesquisa)
        {
            MySqlCommand comando = new MySqlCommand();
            Conexao.Abrir();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "linha")
            {
                comando.CommandText = "SELECT l.id_linha, l.nome_linha, glp.data_inicio, glp.data_termino from tbllinha_pesquisa l "
                    + "inner join tblgrupo_linha_pesquisa glp on glp.fk_linha = l.id_linha "
                    + "inner join tblgrupo g on glp.fk_grupo = g.id_grupo "
                    + "and glp.fk_grupo = @grupo and glp.data_inicio BETWEEN '" + ano + "-01-01' AND '" + ano + "-12-31'";
                comando.Parameters.AddWithValue("@grupo", grupo.IdGrupo);
            }
            else if (tipoPesquisa == "docente")
            {
                comando.CommandText = "SELECT d.id_docente, d.nome from tbldocente d "
                    + "inner join tblgrupo_docente gd on gd.fk_docente = d.id_docente "
                    + "inner join tblgrupo g on gd.fk_grupo = g.id_grupo "
                    + "and gd.fk_grupo = @grupo and gd.data_entrada BETWEEN '" + ano + "-01-01' AND '" + ano + "-12-31'";
                comando.Parameters.AddWithValue("@grupo", grupo.IdGrupo);
            }
            else if (tipoPesquisa == "tecnico")
            {
                comando.CommandText = "SELECT t.id_tecnico, t.nome from tbltecnico t "
                    + "inner join tblgrupo_tecnico gt on gt.fk_tecnico = t.id_tecnico "
                    + "inner join tblgrupo g on gt.fk_grupo = g.id_grupo "
                    + "and gt.fk_grupo = @grupo and gt.data_entrada BETWEEN '" + ano + "-01-01' AND '" + ano + "-12-31'";
                comando.Parameters.AddWithValue("@grupo", grupo.IdGrupo);
            }
            else if (tipoPesquisa == "equipamento")
            {
                comando.CommandText = "SELECT e.id_equipamento, e.nome, e.descricao from tblequipamento e "
                    + "inner join tblgrupo_equipamento ge on ge.fk_equipamento = e.id_equipamento "
                    + "inner join tblgrupo g on ge.fk_grupo = g.id_grupo "
                    + "and ge.fk_grupo = @grupo and ge.data_inicio BETWEEN '" + ano + "-01-01' AND '" + ano + "-12-31'";
                comando.Parameters.AddWithValue("@grupo", grupo.IdGrupo);
            }
            else if (tipoPesquisa == "projeto")
            {
                comando.CommandText = "SELECT p.id_projeto, p.titulo, p.data_inicio from tblprojeto_pesquisa p "
                    + "inner join tblgrupo g on p.fk_grupo = g.id_grupo "
                    + "and p.fk_grupo = @grupo and p.data_fim BETWEEN '" + ano + "-01-01' AND '" + ano + "-12-31'";
                comando.Parameters.AddWithValue("@grupo", grupo.IdGrupo);
            }


            comando.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dados = new DataTable();

            da.Fill(dados);

            return dados;
        }
    }
}
