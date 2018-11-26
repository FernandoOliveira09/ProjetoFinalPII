using System;
using System.Collections.Generic;
using System.IO;
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

            MODUsuario usuario = new MODUsuario();
            usuario.Login = PegaLogin.RetornaLogin();
            usuario = BLLUsuario.PesquisarLogin(usuario);

            ImagemUser.ImageUrl = "../Pages/" + usuario.Imagem;
            ImagemUser2.ImageUrl = "../Pages/" + usuario.Imagem;
            LblNome.Text = usuario.Nome;

            if (usuario.FkTipo == 1)
                LblFuncao.Text = "Administrador";
            else
                LblFuncao.Text = "Lider de Pesquisa";
        }

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            MODUsuario usuario = new MODUsuario();
            Criptografia cripto = new Criptografia();
            EnviaEmail enviaEmail = new EnviaEmail();
            string senha = "";
            string extensao = Path.GetExtension(FUFoto.FileName);
            bool senhaForte = ValidaSenhaForte.ValidaSenha(TxtSenha.Text.Trim());

            if (senhaForte == false)
            {
                LblResposta.Text = Erros.SenhaFraca;
            }
            else if (!FUFoto.HasFile)
            {
                LblResposta.Text = Erros.FotoVazio;
            }
            else if (extensao != ".jpg" && extensao != ".jpeg" && extensao != ".png" && extensao != ".bmp")
            {
                LblResposta.Text = "Arquivo de foto inválido, utilize fotos nas seguintes extensões: .jpg/.jpeg/.png/.bmp";
            }
            else if (TxtLattes.Text.Trim() == "" || TxtLattes.Text.Length > 70)
            {
                LblResposta.Text = Erros.LattesVazio;
            }
            else if (TxtSenha.Text.Trim() == "" || TxtSenha.Text.Length > 12)
            {
                LblResposta.Text = Erros.SenhaVazio;
            }
            else if (TxtSenha2.Text.Trim() == "" || TxtSenha2.Text.Length > 12)
            {
                LblResposta.Text = Erros.Senha2Vazio;
            }
            else if (TxtSenha.Text.Trim() != TxtSenha2.Text.Trim())
            {
                LblResposta.Text = Erros.SenhaInvalida;
            }
            else
            {
                try
                {
                    string foto = "Imagens/" + PegaLogin.RetornaLogin() + extensao;
                    if (File.Exists(Server.MapPath(foto)))
                        File.Delete(Server.MapPath(foto));

                    this.FUFoto.SaveAs(Server.MapPath("Imagens/" + FUFoto.FileName));

                    System.IO.File.Move(Server.MapPath("Imagens/" + FUFoto.FileName), Server.MapPath("Imagens/"+ PegaLogin.RetornaLogin() + extensao));
                    usuario.Imagem = "Imagens/" + PegaLogin.RetornaLogin() + extensao;

                    usuario.Login = PegaLogin.RetornaLogin();
                    usuario.Lattes = TxtLattes.Text.Trim();
                    usuario.DataCadastro = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                    if (TxtSenha.Text.Trim() == TxtSenha2.Text.Trim())
                        senha = TxtSenha.Text.Trim();

                    usuario.Senha = cripto.criptografia(senha);
                    usuario.PrimeiroAcesso = 'n';

                    BLLUsuario.Alterar(usuario);

                    LblResposta.Text = "Usuário alterado com sucesso!";
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Erro ao inserir!');</script>");
                    throw;
                }
            }        
        }
    }
}