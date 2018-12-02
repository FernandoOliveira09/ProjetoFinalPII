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
    public partial class DesvincularTecnico : System.Web.UI.Page
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
                MODTecnico tecnico = new MODTecnico();
                tecnico.IdTecnico = Convert.ToInt32(Page.Request.QueryString["id"]);
                tecnico = BLLTecnico.PesquisarTecnico(tecnico);

                TxtNome.Text = tecnico.Nome;

                CarregaGrupos();
            }
        }

        private void CarregaGrupos()
        {
            MODGrupoTecnico grupoTecnico = new MODGrupoTecnico();
            grupoTecnico.FkTecnico = Convert.ToInt32(Page.Request.QueryString["id"]);

            TxtGrupo.DataSource = BLLGrupo_Tecnico.Pesquisar(grupoTecnico, "tecnico");
            TxtGrupo.DataValueField = "Id_grupo";
            TxtGrupo.DataTextField = "Nome";
            TxtGrupo.DataBind();
        }

        protected void Desvincular_Click(object sender, EventArgs e)
        {
            MODGrupoTecnico grupoTecnico = new MODGrupoTecnico();

            if(TxtDataTermino.Text.Trim() == "")
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else if (TxtGrupo.Text.Trim() == "")
            {
                LblResposta.Text = "O grupo é obrigatório!";
            }
            else
            {
                grupoTecnico.FkTecnico = Convert.ToInt32(Page.Request.QueryString["id"]);
                grupoTecnico.FkGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);
                grupoTecnico.DataSaida = Convert.ToDateTime(TxtDataTermino.Text.Trim());

                BLLGrupo_Tecnico.AlterarDataSaidaTecnico(grupoTecnico);

                LblResposta.Text = "Tecnico desvinculado com sucesso!";
            }
        }
    }
}