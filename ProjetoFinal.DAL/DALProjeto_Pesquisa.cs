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
    public static class DALProjeto_Pesquisa
    {
        public static void Inserir(MODProjetoPesquisa projetoPesquisa)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLProjeto_pesquisa (titulo, tipo, bolsa, nome_bolsa, data_inicio, data_fim, fk_docente, fk_grupo)" 
                + " VALUES (@titulo, @tipo, @bolsa, @nomebolsa, @data_inicio, @data_fim, @fkdocente, @fkgrupo)";
            comando.Parameters.AddWithValue("@titulo", projetoPesquisa.Titulo);
            comando.Parameters.AddWithValue("@tipo", projetoPesquisa.Tipo);
            comando.Parameters.AddWithValue("@bolsa", projetoPesquisa.Bolsa);
            comando.Parameters.AddWithValue("@nomebolsa", projetoPesquisa.NomeBolsa);
            comando.Parameters.AddWithValue("@data_inicio", projetoPesquisa.DataInicio);
            comando.Parameters.AddWithValue("@data_fim", projetoPesquisa.DataTermino);
            comando.Parameters.AddWithValue("@fkdocente", projetoPesquisa.FkDocente);
            comando.Parameters.AddWithValue("@fkgrupo", projetoPesquisa.FkGrupo);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }
    }
}
