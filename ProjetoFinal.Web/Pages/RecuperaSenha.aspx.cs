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
    public partial class RecuperaSenha : System.Web.UI.Page
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

            MODUsuario usuario2 = new MODUsuario();

            usuario2.Login = Page.Request.QueryString["login"];
            usuario2 = BLLUsuario.PesquisarLogin(usuario2);

            if (!Page.IsPostBack)
            {
                TxtUsuario.Text = usuario2.Nome;
            }
        }

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            MODUsuario usuario = new MODUsuario();
            Criptografia cripto = new Criptografia();
            EnviaEmail enviaEmail = new EnviaEmail();
            string senha = "";
            bool senhaForte = ValidaSenhaForte.ValidaSenha(TxtSenha.Text.Trim());

            if (senhaForte == false)
            {
                LblResposta.Text = Erros.SenhaFraca;
            }
            else if (TxtSenha.Text.Trim() == "" || TxtSenha.Text.Length > 12)
            {
                LblResposta.Text = Erros.SenhaVazio;
            }
            else
            {
                try
                {

                    senha = TxtSenha.Text.Trim();
                    usuario.Senha = cripto.criptografia(senha);
                    usuario.Login = Page.Request.QueryString["login"];

                    BLLUsuario.AlterarSenha2(usuario);

                    LblResposta.Text = "Senha alterado com sucesso!";
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