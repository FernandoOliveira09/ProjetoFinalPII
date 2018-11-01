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
    public static class DALDocente_Linha_Pesquisa
    {
        public static void Inserir(MODDocente_Linha_Pesquisa DocenteLinha)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLDocente_Linha_Pesquisa (fk_grupo, fk_docente, fk_linha, data_entrada) "
                + "VALUES (@fk_grupo, @fk_docente, @fk_linha, @data_entrada)";
            comando.Parameters.AddWithValue("@fk_grupo", DocenteLinha.FkGrupo);
            comando.Parameters.AddWithValue("@fk_docente", DocenteLinha.FkDocente);
            comando.Parameters.AddWithValue("@fk_linha", DocenteLinha.FkLinha);
            comando.Parameters.AddWithValue("@data_entrada", DocenteLinha.DataEntrada);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static DataTable Pesquisar(MODGrupoDocente grupoDocente, string tipoPesquisa)
        {
            MySqlCommand comando = new MySqlCommand();
            Conexao.Abrir();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "docente")
            {
                comando.CommandText = "select l.id_linha, l.nome_linha, d.id_docente, d.nome, g.id_grupo, g.nome" 
                    + " from tbllinha_pesquisa l inner join tbldocente_linha_pesquisa dlp on dlp.fk_linha = l.id_linha "
                    + " inner join tblgrupo g on g.id_grupo = dlp.fk_grupo" 
                    + " inner join tbldocente d on dlp.fk_docente = d.id_docente and dlp.fk_docente = @docente" 
                    + " and dlp.fk_grupo = @grupo and dlp.data_saida is null";
                comando.Parameters.AddWithValue("@docente", grupoDocente.FkDocente);
                comando.Parameters.AddWithValue("@grupo", grupoDocente.FkGrupo);
            }

            comando.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dados = new DataTable();

            da.Fill(dados);

            return dados;
        }
    }
}
