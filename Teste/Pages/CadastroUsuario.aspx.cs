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
    public partial class CadastroUsuario : System.Web.UI.Page
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
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODUsuario usuario = new MODUsuario();
            Criptografia cripto = new Criptografia();
            EnviaEmail enviaEmail = new EnviaEmail();

            List<MODUsuario> checaEmail = new List<MODUsuario>();

            if (TxtEmail.Text.Trim() == "" || TxtEmail.Text.Length > 50)
            {
                LblResposta.Text = Erros.EmailVazio;
            }
            else if (TxtNome.Text.Trim() == "" || TxtNome.Text.Length > 50)
            {
                LblResposta.Text = Erros.NomeVazio;
            }
            else if (TxtProntuario.Text.Trim() == "" || TxtProntuario.Text.Length > 15)
            {
                LblResposta.Text = Erros.LoginVazio;
            }
            else
            {
                try
                {
                    usuario.Login = TxtProntuario.Text.Trim();
                    usuario.Nome = TxtNome.Text.Trim();
                    usuario.Email = TxtEmail.Text.Trim();
                    usuario.Imagem = "Imagens/usuario.png";
                    usuario.DataCadastro = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                    if (TxtTipoUsuario.SelectedValue == "Administrador")
                        usuario.FkTipo = 1;
                    else
                        usuario.FkTipo = 2;

                    string senha = GeradorSenhaAleatoria.GeraSenha();

                    usuario.Senha = cripto.criptografia(senha);
                    usuario.FkStatus = 1;
                    usuario.PrimeiroAcesso = 's';

                    checaEmail = BLLUsuario.Pesquisar(usuario, "email");

                    if (checaEmail.Count > 0)
                    {
                        LblResposta.Text = "Endereço de Email já cadastrado anteriormente";
                    }
                    else
                    {
                        BLLUsuario.Inserir(usuario);

                        enviaEmail.EnvioEmail(usuario.Email, usuario.Nome, senha, usuario.Login);

                        LblResposta.Text = "Usuário cadastrado com sucesso!";
                    }
                    
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