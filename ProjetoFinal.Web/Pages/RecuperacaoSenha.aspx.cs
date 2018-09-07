using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoFinal.BLL;
using ProjetoFinal.Model;
using ProjetoFinal.Utilitarios;


namespace ProjetoFinal.Web.Pages
{
    public partial class RecuperacaoSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            MODUsuario usuario = new MODUsuario();
            MODUsuario retorno = new MODUsuario();
            MODRecuperaSenha recuperaSenha = new MODRecuperaSenha();
            MODRecuperacaoSenha_Usuario recuperacaoSenha_Usuario = new MODRecuperacaoSenha_Usuario();

            Criptografia cripto = new Criptografia();
            EnviaEmail enviaEmail = new EnviaEmail();

            try
            {
                usuario.Login = TxtLogin.Text.Trim();
                retorno = BLLUsuario.PesquisarLogin(usuario);
                usuario.Email = retorno.Email;

                PegaLogin.AtribuiLogin(TxtLogin.Text.Trim());

                string senha = GeradorSenhaAleatoria.GeraSenha();

                recuperaSenha.CodigoRecuperacao = cripto.criptografia(senha);
                recuperaSenha.Ativo = 's';

                BLLRecuperacaoSenha.Inserir(recuperaSenha);

                recuperacaoSenha_Usuario.FkRecuperacao = BLLRecuperacaoSenha.recuperaId();
                recuperacaoSenha_Usuario.FkUsuario = usuario.Login;
                recuperacaoSenha_Usuario.DataAlteracao = System.DateTime.Now;

                BLLRecuperacaoSenha_Usuario.Inserir(recuperacaoSenha_Usuario);

                enviaEmail.EnvioEmailRecuperacao("fernando.oliveira1801@gmail.com", senha, "FernandoO");

                Response.Write("<script>alert('O código de acesso foi enviado ao seu email com sucesso!');</script>");
                Response.Redirect("../Pages/InserirCodigoRecuperacao.aspx");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Erro ao enviar!');</script>");
                throw;
            }
        }
    }
}