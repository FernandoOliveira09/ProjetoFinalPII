using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoFinal.BLL;
using ProjetoFinal.Model;
using ProjetoFinal.Utilitarios;

namespace ProjetoFinal.Web.Pages
{
    public partial class VincularProjetoDiscenteEquipamento : System.Web.UI.Page
    {
        private static int idProjeto, idDiscente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MODDiscente discente = new MODDiscente();
                RptDiscente.DataSource = BLLDiscente.Pesquisar(discente, "todos");
                RptDiscente.DataBind();
            }

            MODProjetoPesquisa projeto = new MODProjetoPesquisa();

            idProjeto = Convert.ToInt32(Page.Request.QueryString["id"]);
            projeto.Titulo = Page.Request.QueryString["titulo"];

            TxtProjeto.Text = projeto.Titulo;
        }

        protected void BtnVincularDiscente_Click(object sender, EventArgs e)
        {
            MODProjetoPesquisa_Discente projetoDiscente = new MODProjetoPesquisa_Discente();

            if (TxtDataInicio.Text.Trim() == "")
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else
            {
                projetoDiscente.FkDiscente = idDiscente;
                projetoDiscente.FkProjeto = idProjeto;
                projetoDiscente.DataInicio = Convert.ToDateTime(TxtDataInicio.Text.Trim());

                BLLDiscente.InserirDiscenteProjeto(projetoDiscente);

                LblResposta.Text = "Discente vinculado com sucesso!";
            }
        }

        protected void BtnAddDiscente_Click(object sender, EventArgs e)
        {
            MODProjetoPesquisa_Discente projetoDiscente = new MODProjetoPesquisa_Discente();
            MODDiscente discente = new MODDiscente();

            Control botao = (Control)sender;
            RepeaterItem item = (RepeaterItem)botao.Parent;

            Label lbl = (Label)item.FindControl("TxtNomeDiscente");
            string titulo = lbl.Text;
            discente.Nome = titulo;
            //grupoNome = titulo;

            discente = BLLDiscente.PesquisarDiscente(discente, "nome");

            idDiscente = discente.IdDiscente;
        }
    }
}