using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using MySql.Data.MySqlClient;

namespace ProjetoFinal.DAL
{
    public static class DALRecuperacaoSenha
    {
        public static void Inserir(MODRecuperaSenha recuperaSenha)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO tblrecuperacao_senha (codigo_recuperacao, ativo) "
                + "VALUES (@codigo_recuperacao, @ativo)";
            comando.Parameters.AddWithValue("@codigo_recuperacao", recuperaSenha.CodigoRecuperacao);
            comando.Parameters.AddWithValue("@ativo", recuperaSenha.Ativo);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static string PesquisaRecuperacao(MODRecuperaSenha recuperaSenha, MODUsuario usuario)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "select r.codigo_recuperacao from tblrecuperacao_senha r inner join tblrecuperacao_senha_usuario u on r.id_recuperacao = fk_recuperacao "
                + "inner join tblusuario user on user.login = u.fk_usuario and user.login = @login and r.id_recuperacao = @id";
            comando.Parameters.AddWithValue("@id", recuperaSenha.ID);
            comando.Parameters.AddWithValue("@login", usuario.Login);

            string codigo = comando.ExecuteScalar().ToString();

            Conexao.Fechar();

            return codigo;
        }

        public static int recuperaId()
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "select max(id_recuperacao) from tblrecuperacao_senha";

            int id = Convert.ToInt32(comando.ExecuteScalar());

            Conexao.Fechar();

            return id; 
        }

        public static char RecuperaStatus(MODRecuperaSenha recuperaSenha)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "select ativo from tblrecuperacao_senha where id_recuperacao = " + recuperaSenha.ID;

            char status = Convert.ToChar(comando.ExecuteScalar());

            Conexao.Fechar();

            return status;
        }

        public static void AlterarStatus(MODRecuperaSenha recuperaSenha)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE tblrecuperacao_senha SET ativo = @ativo WHERE id_recuperacao = @id";
            comando.Parameters.AddWithValue("@id", recuperaSenha.ID);
            comando.Parameters.AddWithValue("@ativo", recuperaSenha.Ativo);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }
    }
}
