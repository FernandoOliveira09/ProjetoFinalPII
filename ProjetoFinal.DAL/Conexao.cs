using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjetoFinal.DAL
{
    public static class Conexao
    {
        //cria a variavel de conexao
        internal static MySqlConnection conexao = null;

        //metodo que abre a conexao
        public static void Abrir()
        {
            //instancia a conexao
            conexao = new MySqlConnection();

            //recebe a string de conexao com o banco
            conexao.ConnectionString = @"server=localhost;port=3306;User Id=root;database=sg_manager;password=;SslMode=none";

            conexao.Open();
        }

        //fecha a conexao
        public static void Fechar()
        {
            if (conexao != null)
                conexao.Close();
        }
    }
}
