using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using ProjetoFinal.Model;
using ProjetoFinal.BLL;
using ProjetoFinal.Utilitarios;

namespace ProjetoFinal.Web.Pages
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            MODUsuario usuario = new MODUsuario();
            MODUsuario checaUsuario = new MODUsuario();

            try
            {
                List<MODUsuario> user = BLLUsuario.Pesquisar(usuario);
                if (user != null && user.Count <= 0)
                {
                    Response.Redirect("../Pages/CadastroAdmin.aspx");
                }

            }
            catch
            {
                //Response.Write("<script>alert('Erro!');</script>");
            }
        }

        protected void BtnLogar_Click(object sender, EventArgs e)
        {
            MODUsuario usuario = new MODUsuario();
            MODUsuario retorno = new MODUsuario();
            Criptografia cripto = new Criptografia();

            try
            {
                usuario.Login = TxtLogin.Text.Trim();
                string senha = cripto.criptografia(TxtSenha.Text.Trim());

                retorno = BLLUsuario.PesquisarLogin(usuario);
                if(retorno.FkStatus == 1)
                {
                    
                    if (senha == retorno.Senha)
                    {
                        PegaLogin.AtribuiLogin(usuario.Login);
                        PegaLogin.AtribuiStatusLogin(1);
                        if(retorno.PrimeiroAcesso == 's')
                            Response.Redirect("../Pages/AlteracaoUsuario.aspx");
                        else
                            Response.Redirect("../Pages/Principal.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Não foi possivel autenticar');</script>");
                        PegaLogin.AtribuiTentativas();

                        if (PegaLogin.RetornaTentativas() == 5)
                        {
                            usuario.FkStatus = 2;
                            Response.Write("<script>alert('Usuário bloqueado após 5 tentativas!');</script>");
                            BLLUsuario.AlterarStatus(usuario);
                            //Response.Write("");
                        }
                    }
                }
                else if (retorno.FkStatus == 2)
                {
                    Response.Write("<script>alert('Seu usuário está bloqueado, por favor, recupere a sua conta a seguir');</script>");
                    Response.Redirect("../Pages/RecuperacaoSenha.aspx");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}