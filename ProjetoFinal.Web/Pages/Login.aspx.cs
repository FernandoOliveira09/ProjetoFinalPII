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

        }

        protected void BtnLogar_Click(object sender, EventArgs e)
        {
            MODLogin login = new MODLogin();
            MODLogin retorno = new MODLogin();

            int tentativas = 0;

            try
            {
                
                login.Usuario = TxtLogin.Text.Trim();
                string senha = cripto.criptografia(TxtSenha.Text.Trim());

                retorno = BLLLogin.Pesquisar(login);

                if (senha == retorno.Senha)
                {
                    Response.Write("<script>alert('Logado com sucesso!');</script>");
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