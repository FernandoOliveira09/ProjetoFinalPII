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

        //public static MODGrupo PesquisarGrupo(MODGrupo grupo)
        //{
        //    MySqlCommand comando = new MySqlCommand();
        //    comando.Connection = Conexao.conexao;

        //    comando.CommandText = "select ";



        //    Conexao.Abrir();
        //    comando.CommandType = CommandType.Text;
        //    MySqlDataAdapter da = new MySqlDataAdapter(comando);
        //    DataTable dados = new DataTable();

        //    da.Fill(dados);

        //    return dados;
        //}

        public static DataTable Pesquisar(MODGrupoLider grupoLider, string tipoPesquisa)
        {
            MySqlCommand comando = new MySqlCommand();
            Conexao.Abrir();
            comando.Connection = Conexao.conexao;

            if(tipoPesquisa == "todos")
            {
                comando.CommandText = "select g.id_grupo, g.nome, g.sigla, g.texto_descricao, s.situacao as Situacao, u.login, u.nome as Lider from tblgrupo g inner join tblgrupo_lider l on l.fk_grupo = g.id_grupo "
                    + "inner join tblusuario u on u.login = l.fk_lider inner join tblsituacao s on s.id_situacao = g.fk_situacao";
            }
            else if (tipoPesquisa == "ativos")
            {
                comando.CommandText = "select g.id_grupo, g.nome, g.sigla, g.texto_descricao, g.lattes, g.logotipo, s.situacao as Situacao, u.login, u.nome as Lider from tblgrupo g inner join tblgrupo_lider l on l.fk_grupo = g.id_grupo "
                    + "inner join tblusuario u on u.login = l.fk_lider inner join tblsituacao s on s.id_situacao = g.fk_situacao and g.fk_situacao = 1";
            }
            else if (tipoPesquisa == "aguardando")
            {
                comando.CommandText = "select g.id_grupo, g.nome, g.sigla, g.texto_descricao, g.lattes, g.logotipo, s.situacao as Situacao, u.login, u.nome as Lider from tblgrupo g inner join tblgrupo_lider l on l.fk_grupo = g.id_grupo "
                    + "inner join tblusuario u on u.login = l.fk_lider inner join tblsituacao s on s.id_situacao = g.fk_situacao and g.fk_situacao = 3";
            }
            else if(tipoPesquisa == "grupo")
            {
                comando.CommandText = "select g.id_grupo, g.nome, g.sigla, g.texto_descricao, g.lattes, g.logotipo, g.data_inicio as Data, s.situacao as Situacao, u.login, u.nome as Lider from tblgrupo g inner join tblgrupo_lider l on l.fk_grupo = g.id_grupo "
                    + "inner join tblusuario u on u.login = l.fk_lider inner join tblsituacao s on s.id_situacao = g.fk_situacao and l.fk_grupo = @grupo";
                comando.Parameters.AddWithValue("@grupo", grupoLider.FkGrupo);
            }
                
            comando.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dados = new DataTable();

            da.Fill(dados);

            return dados;
        }

        //public static List<MODGrupo> Pesquisar(MODGrupo item, string tipoPesquisa)
        //{
        //    List<MODUsuario> retorno = new List<MODUsuario>();

        //    Conexao.Abrir();

        //    MySqlCommand comando = new MySqlCommand();
        //    comando.Connection = Conexao.conexao;

        //    if (tipoPesquisa == "todos")
        //    {
        //        comando.CommandText = "select g.id_grupo, g.nome, g.sigla, g.fk_situacao, u.login from tblgrupo g inner join tblgrupo_lider l on l.fk_grupo = g.id_grupo " +
        //            "inner join tblusuario u on u.login = l.fk_lider and l.fk_lider = @lider and l.fk_grupo = @grupo";
        //        comando.Parameters.AddWithValue("@lider", item.);
        //        comando.Parameters.AddWithValue("@grupo", item.Login);
        //    }
        //    else if (tipoPesquisa == "email")
        //    {
        //        comando.CommandText = "SELECT login, nome, email, lattes, imagem, fk_tipo, fk_status FROM TBLUSUARIO WHERE email = @email";
        //        comando.Parameters.AddWithValue("@email", item.Email);
        //    }
        //    else
        //    {
        //        comando.CommandText = "SELECT login, nome, email, lattes, imagem, fk_tipo, fk_status FROM TBLUSUARIO";
        //    }

        //    MySqlDataReader reader = comando.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        MODUsuario ret = new MODUsuario();
        //        ret.Login = reader["Login"].ToString();
        //        ret.Nome = reader["Nome"].ToString();
        //        ret.Email = reader["Email"].ToString();
        //        ret.Lattes = reader["Lattes"].ToString();
        //        ret.Imagem = reader["Imagem"].ToString();
        //        ret.FkTipo = (int)reader["fk_tipo"];
        //        ret.FkStatus = (int)reader["fk_status"];

        //        if (ret.FkTipo == 1)
        //            ret.Tipo = "Administrador";
        //        else
        //            ret.Tipo = "Lider de Pesquisa";

        //        if (ret.FkStatus == 1)
        //            ret.Status = "Ativo";
        //        else if (ret.FkStatus == 2)
        //            ret.Status = "Bloqueado";
        //        else
        //            ret.Status = "Desativado";

        //        retorno.Add(ret);
        //    }

        //    reader.Close();

        //    Conexao.Fechar();

        //    return retorno;
        //}
    }
}
