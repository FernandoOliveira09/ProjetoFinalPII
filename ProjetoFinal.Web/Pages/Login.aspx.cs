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

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODLogin login = new MODLogin();
            MODLogin retorno = new MODLogin();

            try
            {
                login.Usuario = TxtUsuario.Text.Trim();
                string senha = criptografia(TxtSenha.Text.Trim());

                retorno = BLLLogin.Pesquisar(login);

                if(senha == retorno.Senha)
                {
                    LblResul.Text = "Logado com sucesso!";
                }
                else
                {
                    LblResul.Text = "Usuário ou Senha incorreto!";
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
            SHA1Managed shHash = new SHA1Managed();
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