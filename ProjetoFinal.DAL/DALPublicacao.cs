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
    public static class DALPublicacao
    {
        public static void Inserir(MODPublicacao publicacao)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLPublicacao (titulo, tipo_publicacao, referencia_abnt, " 
                + "data_publicacao, fk_grupo, fk_projeto, fk_linha, fk_docente) "
                + "VALUES (@titulo, @tipo_publicacao, @referencia_abnt, " 
                + "@data_publicacao, @fk_grupo, @fk_projeto, @fk_linha, @fk_docente)";
            comando.Parameters.AddWithValue("@titulo", publicacao.Titulo);
            comando.Parameters.AddWithValue("@tipo_publicacao", publicacao.TipoPublicacao);
            comando.Parameters.AddWithValue("@referencia_abnt", publicacao.ReferenciaABNT);
            comando.Parameters.AddWithValue("@data_publicacao", publicacao.DataPublicacao);
            comando.Parameters.AddWithValue("@fk_grupo", publicacao.FkGrupo);
            comando.Parameters.AddWithValue("@fk_projeto", publicacao.FKProjeto);
            comando.Parameters.AddWithValue("@fk_linha", publicacao.FkLinha);
            comando.Parameters.AddWithValue("@fk_docente", publicacao.FkDocente);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }
    }
}
