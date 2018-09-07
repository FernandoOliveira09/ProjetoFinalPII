using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using MySql.Data.MySqlClient;

namespace ProjetoFinal.DAL
{
    public static class DALRecuperacaoSenha_Usuario
    {
        public static void Inserir(MODRecuperacaoSenha_Usuario recuperacaoSenha_Usuario)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO tblrecuperacao_senha_usuario (fk_recuperacao, fk_usuario, data_hora_alteracao) "
                + "VALUES (@fk_recuperacao, @fk_usuario, @data_hora_alteracao)";
            comando.Parameters.AddWithValue("@fk_recuperacao", recuperacaoSenha_Usuario.FkRecuperacao);
            comando.Parameters.AddWithValue("@fk_usuario", recuperacaoSenha_Usuario.FkUsuario);
            comando.Parameters.AddWithValue("@data_hora_alteracao", recuperacaoSenha_Usuario.DataAlteracao);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }
    }
}
