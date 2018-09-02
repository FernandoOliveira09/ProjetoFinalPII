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

            try
            {
                List<MODUsuario> user = BLLUsuario.Pesquisar(usuario, 1);
                if (user != null && user.Count > 0)
                {
                    Response.Write("<script>alert('Existe admin!');</script>");

                }
                else
                {
                    Response.Write("<script>alert('Não Existe admin!');</script>");
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

            int tentativas = 0;

            try
            {
                usuario.Login = TxtLogin.Text.Trim();
                string senha = cripto.criptografia(TxtSenha.Text.Trim());

                retorno = BLLUsuario.PesquisarLogin(usuario);

                if (senha == retorno.Senha)
                {
                    Response.Write("<script>alert('Logado com sucesso!');</script>");
                    Response.Redirect("../Pages/Principal.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Não foi possivel autenticar');</script>");
                    tentativas += 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}