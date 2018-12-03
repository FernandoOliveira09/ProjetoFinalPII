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
    public partial class AlteracaoLider : System.Web.UI.Page
    {
        private int idGrupo;
        private string lider;
        private int idGrupoLider;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CarregaDropDownList();

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

            MODGrupo grupo = new MODGrupo();
            MODGrupoLider grupoLider = new MODGrupoLider();

            grupo.Nome = Page.Request.QueryString["grupo"];

            grupo = BLLGrupo.PesquisarGrupo(grupo, "nome");
            idGrupo = grupo.IdGrupo;
            grupoLider.FkGrupo = idGrupo;
            grupoLider = BLLGrupo.PesquisarLider(grupoLider);
            idGrupoLider = grupoLider.Id;
            usuario.Login = grupoLider.FkUsuario;
            usuario = BLLUsuario.PesquisarLogin(usuario);
            lider = usuario.Login;

            if (!Page.IsPostBack)
            {
                TxtNome.Text = usuario.Nome;
                TxtDataEntrada.Text = grupoLider.DataEntrada.ToShortDateString().ToString();
            }
        }

        private void CarregaDropDownList()
        {
            MODUsuario usuario = new MODUsuario();

            TxtLider.DataSource = BLLUsuario.Pesquisar(usuario, "lider");
            TxtLider.DataValueField = "login";
            TxtLider.DataTextField = "nome";
            TxtLider.DataBind();
        }

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            MODGrupo grupo = new MODGrupo();
            MODGrupoLider grupoLider = new MODGrupoLider();

            if (TxtDataSaida.Text.Trim() == "")
            {
                LblResultado.Text = Erros.DataVazio;
            }
            else if (TxtData.Text.Trim() == "")
            {
                LblResultado.Text = Erros.DataVazio;
            }
            else
            {
                try
                {

                    grupoLider.Id = idGrupoLider;
                    grupoLider.DataSaida = Convert.ToDateTime(TxtDataSaida.Text.Trim());
                    BLLGrupo.AlterarLider(grupoLider, "data_saida");

                    grupoLider.FkUsuario = TxtLider.SelectedValue.ToString();
                    grupoLider.FkGrupo = idGrupo;
                    grupoLider.DataEntrada = Convert.ToDateTime(TxtData.Text.Trim());

                    BLLGrupo.InserirLider(grupoLider);

                    LblResultado.Text = "Lider alterado com sucesso!";
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