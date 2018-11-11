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
    public partial class VincularGrupoTecnico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Session.RemoveAll();
                Response.Redirect("../Pages/Login.aspx");
            }

            MODUsuario usuario = new MODUsuario();

            usuario.Login = PegaLogin.RetornaLogin();
            usuario = BLLUsuario.PesquisarLogin(usuario);

            ImagemUser.ImageUrl = "../Pages/" + usuario.Imagem;
            ImagemUser2.ImageUrl = "../Pages/" + usuario.Imagem;
            LblNome.Text = usuario.Nome;

            if (usuario.FkTipo == 1)
                LblFuncao.Text = "Administrador";
            else
                LblFuncao.Text = "Lider de Pesquisa";

            if (!Page.IsPostBack)
            {
                CarregaGrupo();
                CarregaTecnico();
            }
        }

        private void CarregaGrupo()
        {
            MODGrupo grupo = new MODGrupo();

            TxtGrupo.DataSource = BLLGrupo.PesquisarGrupos(grupo, "todos");
            TxtGrupo.DataValueField = "IdGrupo";
            TxtGrupo.DataTextField = "Nome";
            TxtGrupo.DataBind();
        }

        private void CarregaTecnico()
        {
            MODTecnico tecnico = new MODTecnico();

            TxtTecnico.DataSource = BLLTecnico.Pesquisar(tecnico, "todos");
            TxtTecnico.DataValueField = "IdTecnico";
            TxtTecnico.DataTextField = "Nome";
            TxtTecnico.DataBind();
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODGrupoTecnico grupoTecnico = new MODGrupoTecnico();

            if (TxtData.Text.Trim() == "" || TxtData.Text.Length > 50)
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else
            {
                try
                {
                    grupoTecnico.FkTecnico = Convert.ToInt32(TxtTecnico.SelectedValue);
                    grupoTecnico.FkGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);
                    grupoTecnico.DataEntrada = Convert.ToDateTime(TxtData.Text.Trim());

                    BLLGrupo_Tecnico.InserirTecnico(grupoTecnico);

                    LblResposta.Text = "Técnico vinculado com sucesso!";

                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Erro ao inserir!');</script>");
                    throw;
                }
            }
        }
    }
}