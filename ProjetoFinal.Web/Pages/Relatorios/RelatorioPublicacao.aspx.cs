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
    public partial class RelatorioPublicacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregaGrupos();
                CarregaProjetos();
            }
        }

        private void CarregaGrupos()
        {
            MODGrupo grupo = new MODGrupo();

            TxtGrupo.DataSource = BLLGrupo.PesquisarGrupos(grupo, "todos");
            TxtGrupo.DataValueField = "IdGrupo";
            TxtGrupo.DataTextField = "Nome";
            TxtGrupo.DataBind();
        }

        private void CarregaProjetos()
        {
            MODProjetoPesquisa projeto = new MODProjetoPesquisa();

            projeto.FkGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);

            TxtProjeto.DataSource = BLLProjeto_Pesquisa.PesquisarProjetos(projeto, "grupo");
            TxtProjeto.DataValueField = "IdProjeto";
            TxtProjeto.DataTextField = "titulo";
            TxtProjeto.DataBind();
        }

        protected void TxtGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaProjetos();
        }

        protected void ChkProjeto_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkProjeto.Checked == true)
                TxtProjeto.Enabled = true;
            else
                TxtProjeto.Enabled = false;
        }

        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string ano = TxtAno.Text.Trim();

            MODPublicacao publicacao = new MODPublicacao();

            publicacao.FkGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);
            publicacao.TipoPublicacao = TxtTipo.Text.Trim();

            if(ChkProjeto.Checked == true)
            {
                publicacao.FKProjeto = Convert.ToInt32(TxtProjeto.SelectedValue);
                RptConsulta.DataSource = BLLPublicacao.Relatorio(publicacao, ano, "projeto");
            }
            else
            {
                RptConsulta.DataSource = BLLPublicacao.Relatorio(publicacao, ano, "grupo");
            }
                
            RptConsulta.DataBind();
        }
    }
}