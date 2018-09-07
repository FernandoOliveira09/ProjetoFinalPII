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

        public static void Alterar(MODUsuario usuario)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLUSUARIO SET senha = @senha, lattes = @lattes, "
                + "primeiro_acesso = @primeiro_acesso, imagem = @imagem "
                + "WHERE login = @login";
            comando.Parameters.AddWithValue("@login", usuario.Login);
            comando.Parameters.AddWithValue("@senha", usuario.Senha);
            comando.Parameters.AddWithValue("@lattes", usuario.Lattes);
            comando.Parameters.AddWithValue("@primeiro_acesso", usuario.PrimeiroAcesso);
            comando.Parameters.AddWithValue("@imagem", usuario.Imagem);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void AlterarStatus(MODUsuario usuario)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLUSUARIO SET fk_status = @fk_status WHERE login = @login";
            comando.Parameters.AddWithValue("@login", usuario.Login);
            comando.Parameters.AddWithValue("@fk_status", usuario.FkStatus);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }
    }
}
