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
    public partial class AlteracaoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Session.RemoveAll();
                Response.Redirect("../Pages/Login.aspx");
            }
        }

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            MODUsuario usuario = new MODUsuario();
            Criptografia cripto = new Criptografia();
            EnviaEmail enviaEmail = new EnviaEmail();
            string senha = "";

            try
            {
                var mensagem = string.Empty;
                if (this.FUFoto.HasFile)
                {
                    this.FUFoto.SaveAs(Server.MapPath("Imagens/" + FUFoto.FileName));
                    usuario.Imagem = "Imagens/" + FUFoto.FileName;
                    mensagem = "Imagem gravada com sucesso!";
                }
                else
                    mensagem = "Selecione uma imagem!";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert(' " + mensagem + "')", true);

                usuario.Login = PegaLogin.RetornaLogin();
                usuario.Lattes = TxtLattes.Text.Trim();
                usuario.DataCadastro = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                if(TxtSenha.Text.Trim() == TxtSenha2.Text.Trim())
                    senha = TxtSenha.Text.Trim();

                usuario.Senha = cripto.criptografia(senha);
                usuario.PrimeiroAcesso = 'n';

                BLLUsuario.Alterar(usuario);

                Response.Write("<script>alert('Usuário alterado com sucesso!');</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Erro ao inserir!');</script>");
                throw;
            }
        }
    }
}