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
    public partial class CadastroGrupo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODUsuario usuario = new MODUsuario();
            MODUsuario usuario2 = new MODUsuario();
            MODGrupo grupo = new MODGrupo();
            MODGrupoLider grupoLider = new MODGrupoLider();
            EnviaEmail enviaEmail = new EnviaEmail();

            if (TxtNome.Text.Trim() == "" || TxtNome.Text.Length > 60)
            {
                LblResposta.Text = Erros.NomeVazio;
            }
            else if (TxtSigla.Text.Trim() == "" || TxtSigla.Text.Length > 10)
            {
                LblResposta.Text = Erros.SiglaVazio;
            }
            else if (TxtData.Text.Trim() == "")
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else
            {
                try
                {
                    grupo.Nome = TxtNome.Text.Trim();
                    grupo.Sigla = TxtSigla.Text.Trim();
                    grupo.FkSituacao = 3;

                    grupoLider.FkGrupo = BLLGrupo.InserirGrupo(grupo);


                    LblResposta.Text = "Grupo cadastrado com sucesso!";
                    grupoLider.FkUsuario = TxtLider.SelectedValue.ToString();
                    grupoLider.DataEntrada = Convert.ToDateTime(TxtData.Text.Trim());

                    BLLGrupo.InserirLider(grupoLider);

                    LblResposta.Text = "Grupo cadastrado com sucesso!";

                    usuario.Login = PegaLogin.RetornaLogin();

                    usuario2 = BLLUsuario.PesquisarLogin(usuario);

                    enviaEmail.EnvioEmailAvisoGrupo(usuario2.Email, grupo.Nome, usuario2.Nome);
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Erro ao inserir!');</script>");
                    throw;
                }
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
    }
}