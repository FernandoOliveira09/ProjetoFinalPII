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
    public partial class DesvincularDiscente : System.Web.UI.Page
    {
        static int idProjeto, idDiscente;

        protected void Page_Load(object sender, EventArgs e)
        {
            MODDiscente discente = new MODDiscente();
            MODProjetoPesquisa projeto = new MODProjetoPesquisa();

            if (!IsPostBack)
            {
                projeto.IdProjeto = Convert.ToInt32(Page.Request.QueryString["projeto"]);
                discente.IdDiscente = Convert.ToInt32(Page.Request.QueryString["discente"]);

                idProjeto = projeto.IdProjeto;
                idDiscente = discente.IdDiscente;

                projeto = BLLProjeto_Pesquisa.PesquisarProjeto(projeto);
                discente = BLLDiscente.PesquisarDiscente(discente, "id");

                TxtProjeto.Text = projeto.Titulo;
                TxtNome.Text = discente.Nome;

            }
        }

        protected void BtnAddDiscente_Click(object sender, EventArgs e)
        {
            MODDiscente discente = new MODDiscente();

            Control botao = (Control)sender;
            RepeaterItem item = (RepeaterItem)botao.Parent;

            Label lbl = (Label)item.FindControl("TxtNomeDiscente");
            string titulo = lbl.Text;
            discente.Nome = titulo;

            discente = BLLDiscente.PesquisarDiscente(discente, "nome");

            idDiscente = discente.IdDiscente;

        }

        protected void BtnVincular_Click(object sender, EventArgs e)
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

        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            MODDiscente discente = new MODDiscente();

            discente.Nome = TxtPesquisar.Text.Trim();
            RptDiscente.DataSource = BLLDiscente.Pesquisar(discente, "incompleto");
            RptDiscente.DataBind();
        }

        protected void Desvincular_Click(object sender, EventArgs e)
        {
            MODProjetoPesquisa_Discente projetoDiscente = new MODProjetoPesquisa_Discente();

            if(TxtDataTermino.Text.Trim() == "")
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else
            {
                projetoDiscente.FkDiscente = idDiscente;
                projetoDiscente.FkProjeto = idProjeto;
                projetoDiscente.DataFim = Convert.ToDateTime(TxtDataTermino.Text.Trim());

                BLLDiscente.AlterarVinculoProjeto(projetoDiscente);

                LblResposta.Text = "Discente desvinculado com sucesso!";
            }
        }
    }
}