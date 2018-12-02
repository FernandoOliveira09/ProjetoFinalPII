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
    public class DALEquipamento
    {
        public static void Inserir(MODEquipamento equipamento)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLEQUIPAMENTO (nome, descricao) "
                + "VALUES (@nome, @descricao)";
            comando.Parameters.AddWithValue("@nome", equipamento.Nome);
            comando.Parameters.AddWithValue("@descricao", equipamento.Descricao);
            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void InserirEquipamentoGrupo(MODGrupo_Equipamento grupoEquipamento)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLGRUPO_EQUIPAMENTO (fk_grupo, fk_equipamento, data_inicio) "
                + "VALUES (@fk_grupo, @fk_equipamento, @data_inicio)";
            comando.Parameters.AddWithValue("@fk_grupo", grupoEquipamento.FkGrupo);
            comando.Parameters.AddWithValue("@fk_equipamento", grupoEquipamento.FkEquipamento);
            comando.Parameters.AddWithValue("@data_inicio", grupoEquipamento.DataInicio);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void AlterarDataSaidaEquipamento(MODGrupo_Equipamento grupoEquipamento)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLGRUPO_Equipamento SET data_fim = @data where fk_grupo = @grupo and fk_equipamento = @equipamento and data_fim is null";
            comando.Parameters.AddWithValue("@data", grupoEquipamento.DataFim);
            comando.Parameters.AddWithValue("@grupo", grupoEquipamento.FkGrupo);
            comando.Parameters.AddWithValue("@equipamento", grupoEquipamento.FkEquipamento);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void Alterar(MODEquipamento equipamento)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLEQUIPAMENTO SET nome = @nome, descricao = @descricao "
                + "WHERE id_equipamento = @id_equipamento";
            comando.Parameters.AddWithValue("@id_equipamento", equipamento.IdEquipamento);
            comando.Parameters.AddWithValue("@nome", equipamento.Nome);
            comando.Parameters.AddWithValue("@descricao", equipamento.Descricao);


            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static MODEquipamento PesquisarEquipamento(MODEquipamento equipamento, string tipoPesquisa)
        {
            MODEquipamento retorno = new MODEquipamento();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if(tipoPesquisa == "id")
            {
                comando.CommandText = "SELECT id_equipamento, nome, descricao FROM TBLEQUIPAMENTO WHERE id_equipamento = @id";
                comando.Parameters.AddWithValue("@id", equipamento.IdEquipamento);
            }
            else
            {
                comando.CommandText = "SELECT id_equipamento, nome, descricao FROM TBLEQUIPAMENTO WHERE nome = @nome";
                comando.Parameters.AddWithValue("@nome", equipamento.Nome);
            }

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODEquipamento ret = new MODEquipamento();
                ret.IdEquipamento = Convert.ToInt32(reader["id_equipamento"].ToString());
                ret.Nome = reader["Nome"].ToString();
                ret.Descricao = reader["Descricao"].ToString();

                retorno.IdEquipamento = ret.IdEquipamento;
                retorno.Nome = ret.Nome;
                retorno.Descricao = ret.Descricao;

            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static List<MODEquipamento> Pesquisar(MODEquipamento item, string tipoPesquisa)
        {
            List<MODEquipamento> retorno = new List<MODEquipamento>();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "nome")
            {
                comando.CommandText = "SELECT nome, descricao FROM TBLEQUIPAMENTO WHERE nome = @nome";
                comando.Parameters.AddWithValue("@nome", item.Nome);
            }

            else if (tipoPesquisa == "todos")
            {
                comando.CommandText = "SELECT id_equipamento, nome, descricao FROM TBLEQUIPAMENTO";
            }
            else
            {
                //    comando.CommandText = "SELECT login, nome, email, lattes, imagem, fk_tipo, fk_status FROM TBLUSUARIO where fk_tipo = 2 and fk_status = 1";
            }

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODEquipamento ret = new MODEquipamento();
                ret.IdEquipamento = Convert.ToInt32(reader["id_equipamento"]);
                ret.Nome = reader["nome"].ToString();
                ret.Descricao = reader["descricao"].ToString();


                retorno.Add(ret);
            }

            reader.Close();

            Conexao.Fechar();

            return retorno;
        }

        public static DataTable ConsultaPorGrupo(MODGrupo grupo)
        {
            MySqlCommand comando = new MySqlCommand();
            Conexao.Abrir();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "select e.id_equipamento, e.nome, e.descricao "
                    + "from tblequipamento e "
                    + "inner join tblgrupo_equipamento ge on ge.fk_equipamento = e.id_equipamento "
                    + "inner join tblgrupo g on ge.fk_grupo = g.id_grupo and ge.data_fim is null and g.sigla = @sigla";

            comando.Parameters.AddWithValue("@sigla", grupo.Sigla);

            comando.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dados = new DataTable();

            da.Fill(dados);

            return dados;
        }


        public static DataTable PesquisarGrupo(MODGrupo_Equipamento grupoEquipamento, string tipoPesquisa)
        {
            MySqlCommand comando = new MySqlCommand();
            Conexao.Abrir();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "equipamento")
            {
                comando.CommandText = "select g.id_grupo, g.nome, ge.data_inicio, ge.data_fim from tblgrupo g inner join tblgrupo_equipamento ge on ge.fk_grupo = g.id_grupo inner join tblequipamento e on ge.fk_equipamento = e.id_equipamento and ge.fk_equipamento = @equipamento and ge.data_fim is null";
                comando.Parameters.AddWithValue("@equipamento", grupoEquipamento.FkEquipamento);
            }

            comando.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dados = new DataTable();

            da.Fill(dados);

            return dados;
        }
    }
}
