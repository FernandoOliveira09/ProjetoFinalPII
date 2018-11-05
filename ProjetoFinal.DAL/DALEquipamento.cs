using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using MySql.Data.MySqlClient;

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

        public static MODEquipamento PesquisarEquipamento(MODEquipamento equipamento)
        {
            MODEquipamento retorno = new MODEquipamento();

            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "SELECT nome, descricao FROM TBLEQUIPAMENTO WHERE id_equipamento = @id";

            comando.Parameters.AddWithValue("@id", equipamento.IdEquipamento);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                MODEquipamento ret = new MODEquipamento();
                ret.Nome = reader["Nome"].ToString();
                ret.Descricao = reader["Descricao"].ToString();

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
    }
}
