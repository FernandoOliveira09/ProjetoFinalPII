using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoFinal.Model;
using ProjetoFinal.BLL;
using ProjetoFinal.Utilitarios;

namespace ProjetoFinal.Web.Pages.Relatorios
{
    public partial class LinhaDocente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregaGrupos();
                CarregaLinhas();
            }
        }

        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string ano = TxtAno.Text.Trim();

            MODDocente_Linha_Pesquisa docenteLinha = new MODDocente_Linha_Pesquisa();

            docenteLinha.FkGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);
            docenteLinha.FkLinha = TxtLinha.SelectedValue.ToString();
            RptConsulta.DataSource = BLLDocente_Linha_Pesquisa.Relatorio(docenteLinha, ano, "docente");
            RptConsulta.DataBind();
        }

        private void CarregaGrupos()
        {
            MODGrupo grupo = new MODGrupo();

            TxtGrupo.DataSource = BLLGrupo.PesquisarGrupos(grupo, "todos");
            TxtGrupo.DataValueField = "IdGrupo";
            TxtGrupo.DataTextField = "Nome";
            TxtGrupo.DataBind();
        }

        private void CarregaLinhas()
        {
            MODGrupoLinha_Pesquisa linha = new MODGrupoLinha_Pesquisa();

            linha.FkGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);

            TxtLinha.DataSource = BLLGrupo_Linha_Pesquisa.Pesquisar(linha, "grupo");
            TxtLinha.DataValueField = "id_linha";
            TxtLinha.DataTextField = "nome_linha";
            TxtLinha.DataBind();
        }

        protected void TxtGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaLinhas();
        }
    }
}