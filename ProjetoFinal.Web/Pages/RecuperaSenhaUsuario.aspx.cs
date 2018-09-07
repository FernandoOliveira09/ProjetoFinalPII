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
    public partial class RecuperaSenhaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            MODUsuario usuario = new MODUsuario();
            Criptografia cripto = new Criptografia();

            bool teste = ValidaSenhaForte.ValidaSenha(TxtSenha.Text.Trim());

            if (teste == false)
                Response.Write("<script>alert('Senha INVÁLIDA!');</script>");

            try
            {
                if(TxtSenha.Text.Trim() == TxtSenha2.Text.Trim())
                {
                    usuario.Login = PegaLogin.RetornaLogin();
                    usuario.Senha = cripto.criptografia(TxtSenha.Text.Trim());
                    usuario.FkStatus = 1;

                    BLLUsuario.AlterarSenha(usuario);

                    Response.Write("<script>alert('Senha recuperada com sucesso!');</script>");

                    Response.Redirect("../Pages/Login.aspx");
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