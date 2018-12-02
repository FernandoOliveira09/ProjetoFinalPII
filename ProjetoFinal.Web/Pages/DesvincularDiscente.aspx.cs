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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Session.RemoveAll();
                Response.Redirect("../Pages/Login.aspx");
            }

            MODUsuario usuario2 = new MODUsuario();
            usuario2.Login = PegaLogin.RetornaLogin();
            usuario2 = BLLUsuario.PesquisarLogin(usuario2);

            ImagemUser.ImageUrl = "../Pages/" + usuario2.Imagem;
            ImagemUser2.ImageUrl = "../Pages/" + usuario2.Imagem;
            LblNome.Text = usuario2.Nome;

            if (usuario2.FkTipo == 1)
                LblFuncao.Text = "Administrador";
            else
                LblFuncao.Text = "Lider de Pesquisa";

            MODDiscente discente = new MODDiscente();
            MODProjetoPesquisa projeto = new MODProjetoPesquisa();
            MODProjetoPesquisa_Discente projetoDiscente = new MODProjetoPesquisa_Discente();

            if (!Page.IsPostBack)
            {

                projetoDiscente.FkDiscente = Convert.ToInt32(Page.Request.QueryString["discente"]);
                TxtProjeto.DataSource = BLLDiscente.PesquisarProjeto(projetoDiscente, "discente");
                TxtProjeto.DataValueField = "Id_projeto";
                TxtProjeto.DataTextField = "Titulo";
                TxtProjeto.DataBind();

                discente.IdDiscente = Convert.ToInt32(Page.Request.QueryString["discente"]);
                discente = BLLDiscente.PesquisarDiscente(discente, "id");


                TxtNome.Text = discente.Nome;
            }
        }

        protected void Desvincular_Click(object sender, EventArgs e)
        {
            MODProjetoPesquisa_Discente projetoDiscente = new MODProjetoPesquisa_Discente();

            if (TxtDataTermino.Text.Trim() == "")
            {
                LblResposta.Text = "A data de término nao pode ser nula!";
            }
            else
            {
                projetoDiscente.FkDiscente = Convert.ToInt32(Page.Request.QueryString["discente"]);
                projetoDiscente.FkProjeto = Convert.ToInt32(TxtProjeto.SelectedValue);
                projetoDiscente.DataFim = Convert.ToDateTime(TxtDataTermino.Text.Trim());

                BLLDiscente.AlterarVinculoProjeto(projetoDiscente);

                LblResposta.Text = "Discente desvinculado com sucesso!";
            }
        }
    }
}