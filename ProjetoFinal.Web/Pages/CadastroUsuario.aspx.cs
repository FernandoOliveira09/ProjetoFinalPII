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

        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODUsuario usuario = new MODUsuario();
            Criptografia cripto = new Criptografia();

            try
            {
                usuario.Login = TxtProntuario.Text.Trim();
                usuario.Nome = TxtNome.Text.Trim();
                usuario.Email = TxtEmail.Text.Trim();
                usuario.DataCadastro = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                
                if (TxtTipoUsuario.SelectedValue == "Administrador")
                    usuario.FkTipo = 1;
                else
                    usuario.FkTipo = 2;

                usuario.Senha = cripto.criptografia(GeradorSenhaAleatoria.GeraSenha()); 

                BLLUsuario.Inserir(usuario);

                Response.Write("<script>alert('Usuário cadastrado com sucesso!');</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Erro ao inserir!');</script>");
                throw;
            }
        }
    }
}