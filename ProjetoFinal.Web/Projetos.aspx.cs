using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoFinal.BLL;
using ProjetoFinal.Model;
using ProjetoFinal.Utilitarios;

namespace ProjetoFinal.Web
{
    public partial class Projetos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MODPublicacao publicacao = new MODPublicacao();
            MODProjetoPesquisa projetoPesquisa = new MODProjetoPesquisa();

            if (!IsPostBack)
            {
                projetoPesquisa.IdProjeto = Convert.ToInt32(Page.Request.QueryString["id"]);
                //projetoPesquisa = BLLProjeto_Pesquisa.(projetoPesquisa, "projeto");
                //grupoLider.FkGrupo = grupo.IdGrupo;

                //this.Title = grupo.Sigla + " - " + grupo.Nome + " - " + "SG Manager";

                RptConsulta.DataSource = BLLProjeto_Pesquisa.ConsultaProjetos(projetoPesquisa, "projeto");
                RptConsulta.DataBind();

                //MODGrupoDocente grupoDocente = new MODGrupoDocente();

                RPTPublicacao.DataSource = BLLPublicacao.ConsultaPorProjeto(projetoPesquisa);
                RPTPublicacao.DataBind();
            }
        }
    }
}