﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Model;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjetoFinal.DAL
{
    public static class DALGrupo_Tecnico
    {
        public static void InserirTecnico(MODGrupoTecnico grupoTecnico)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "INSERT INTO TBLGRUPO_Tecnico (fk_grupo, fk_tecnico, data_entrada) "
                + "VALUES (@fk_grupo, @fk_tecnico, @data_entrada)";
            comando.Parameters.AddWithValue("@fk_grupo", grupoTecnico.FkGrupo);
            comando.Parameters.AddWithValue("@fk_tecnico", grupoTecnico.FkTecnico);
            comando.Parameters.AddWithValue("@data_entrada", grupoTecnico.DataEntrada);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void AlterarDataSaidaTecnico(MODGrupoTecnico grupoTecnico)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "UPDATE TBLGRUPO_Tecnico SET data_saida = @data where fk_grupo = @grupo and fk_tecnico = @tecnico and data_saida is null";
            comando.Parameters.AddWithValue("@data", grupoTecnico.DataSaida);
            comando.Parameters.AddWithValue("@grupo", grupoTecnico.FkGrupo);
            comando.Parameters.AddWithValue("@tecnico", grupoTecnico.FkTecnico);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }

        public static void ExcluirTecnico(MODGrupoTecnico grupoTecnico)
        {
            Conexao.Abrir();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.conexao;

            comando.CommandText = "DELETE FROM TBLGRUPO_Tecnico where fk_grupo = @grupo and fk_tecnico = @tecnico and data_entrada = @data";
            comando.Parameters.AddWithValue("@data", grupoTecnico.DataEntrada);
            comando.Parameters.AddWithValue("@grupo", grupoTecnico.FkGrupo);
            comando.Parameters.AddWithValue("@tecnico", grupoTecnico.FkTecnico);

            comando.ExecuteNonQuery();

            Conexao.Fechar();
        }



        public static DataTable Pesquisar(MODGrupoTecnico grupoTecnico, string tipoPesquisa)
        {
            MySqlCommand comando = new MySqlCommand();
            Conexao.Abrir();
            comando.Connection = Conexao.conexao;

            if (tipoPesquisa == "ativos")
            {
                comando.CommandText = "select t.id_tecnico, t.nome, t.formacao, t.curso, t.lattes, t.foto, gt.data_entrada from tbltecnico t inner join tblgrupo_tecnico gt on gt.fk_tecnico = t.id_tecnico inner join Tblgrupo g on gt.fk_grupo = g.id_grupo "
                    + "and gt.data_saida is null and g.sigla = @sigla";
            }
            else if (tipoPesquisa == "gativos")
            {
                comando.CommandText = "select t.id_tecnico, t.nome, t.formacao, t.curso, t.lattes, t.foto, gt.data_entrada from tbltecnico t inner join tblgrupo_tecnico gt on gt.fk_tecnico = t.id_tecnico inner join Tblgrupo g on gt.fk_grupo = g.id_grupo "
                    + "and gt.data_saida is null and gt.fk_grupo = @grupo";
                comando.Parameters.AddWithValue("@grupo", grupoTecnico.FkGrupo);
            }
            else if (tipoPesquisa == "tecnico")
            {
                comando.CommandText = "select g.id_grupo, g.nome, gt.data_entrada from tblgrupo g inner join tblgrupo_tecnico gt "
                     + "on gt.fk_grupo = g.id_grupo inner join tbltecnico t on gt.fk_tecnico = t.id_tecnico and gt.fk_tecnico = @tecnico and gt.data_saida is null ";
                comando.Parameters.AddWithValue("@tecnico", grupoTecnico.FkTecnico);
            }

            comando.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable dados = new DataTable();

            da.Fill(dados);

            return dados;
        }
    }
}
