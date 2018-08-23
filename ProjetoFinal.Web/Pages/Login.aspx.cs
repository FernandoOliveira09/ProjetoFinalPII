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

            try
            {
                login.Usuario = TxtLogin.Text.Trim();
                string senha = criptografia(TxtSenha.Text.Trim());

                retorno = BLLLogin.Pesquisar(login);

                if (senha == retorno.Senha)
                {
                    Response.Write("<script>alert('Logado com sucesso!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Login e/ou senha incorretos');</script>");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string criptografia(string senha)
        {
            UnicodeEncoding ue = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = ue.GetBytes(senha);
            SHA256Managed shHash = new SHA256Managed();
            string strHex = "";
            HashValue = shHash.ComputeHash(MessageBytes);

            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }

            return strHex;
        }
    }
}