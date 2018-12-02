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
    public partial class DesvincularLinha : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {
                MODGrupoLinha_Pesquisa grupoLinha = new MODGrupoLinha_Pesquisa();
                MODLinha_Pesquisa linhaPesquisa = new MODLinha_Pesquisa();
                grupoLinha.FkLinha = Page.Request.QueryString["linha"].ToString();
                TxtGrupo.DataSource = BLLGrupo_Linha_Pesquisa.Pesquisar(grupoLinha, "linha");
                TxtGrupo.DataValueField = "Id_grupo";
                TxtGrupo.DataTextField = "Nome";
                TxtGrupo.DataBind();

                linhaPesquisa.Id = grupoLinha.FkLinha;
                linhaPesquisa = BLLLinha_Pesquisa.PesquisarLinha(linhaPesquisa, "id");

                TxtNome.Text = linhaPesquisa.Linha;
            }
        }

        protected void Desvincular_Click(object sender, EventArgs e)
        {
            MODGrupoLinha_Pesquisa grupoLinha = new MODGrupoLinha_Pesquisa();

            if (TxtDataTermino.Text.Trim() == "")
            {
                LblResposta.Text = "A data de término nao pode ser nula!";
            }
            else if (TxtGrupo.Text.Trim() == "")
            {
                LblResposta.Text = "O grupo é obrigatório!";
            }
            else
            {
                grupoLinha.FkLinha = Page.Request.QueryString["linha"].ToString();
                grupoLinha.FkGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);
                grupoLinha.DataSaida = Convert.ToDateTime(TxtDataTermino.Text.Trim());

                BLLGrupo_Linha_Pesquisa.AlterarDataSaidaLinha(grupoLinha);

                LblResposta.Text = "Linha desvinculada com sucesso!";
            }
        }
    }
}