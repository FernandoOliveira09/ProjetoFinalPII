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
    public partial class InserirCodigoRecuperacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            MODUsuario usuario = new MODUsuario();
            MODUsuario retorno = new MODUsuario();
            MODRecuperaSenha recuperaSenha = new MODRecuperaSenha();
            MODRecuperacaoSenha_Usuario recuperacaoSenha_Usuario = new MODRecuperacaoSenha_Usuario();
            Criptografia cripto = new Criptografia();

            try
            {
                string senha = cripto.criptografia(TxtSenha.Text.Trim());

                usuario.Login = PegaLogin.RetornaLogin();

                retorno = BLLUsuario.PesquisarLogin(usuario);
                recuperaSenha.ID = BLLRecuperacaoSenha.recuperaId();

                char status = BLLRecuperacaoSenha.RecuperaStatus(recuperaSenha);

                if(status == 's')
                {
                    string retornoSenha = BLLRecuperacaoSenha.PesquisaRecuperacao(recuperaSenha, retorno);

                    if (retornoSenha == senha)
                    {
                        Response.Redirect("../Pages/RecuperaSenhaUsuario.aspx");
                    }
                    else
                    {

                    }
                }
                else
                {
                    Response.Write("Esse código não está mais disponível para a recuperação de senha");
                }
 
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}