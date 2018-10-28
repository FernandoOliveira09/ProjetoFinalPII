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
    public partial class CadastroAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //MODUsuario usuario = new MODUsuario();

            //try
            //{
            //    List<MODUsuario> user = BLLUsuario.PesquisarAdmin();
            //    if (user == null || user.Count <= 0)
            //    {
            //        Response.Redirect("../Pages/Login.aspx");
            //    }

            //}
            //catch
            //{
            //    //Response.Write("<script>alert('Erro!');</script>");
            //}
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODUsuario usuario = new MODUsuario();
            Criptografia cripto = new Criptografia();

            bool senhaForte = ValidaSenhaForte.ValidaSenha(TxtSenha.Text.Trim());

            List<MODUsuario> checaEmail = new List<MODUsuario>();

            if (senhaForte == false)
            {
                LblResposta.Text = Erros.SenhaFraca;
            }
            else if (TxtEmail.Text.Trim() == "" || TxtEmail.Text.Length > 50)
            {
                LblResposta.Text = Erros.EmailVazio;
            }
            else if (TxtNome.Text.Trim() == "" || TxtNome.Text.Length > 50)
            {
                LblResposta.Text = Erros.NomeVazio;
            }
            else if (TxtLogin.Text.Trim() == "" || TxtLogin.Text.Length > 15)
            {
                LblResposta.Text = Erros.LoginVazio;
            }
            else if (TxtSenha.Text.Trim() == "")
            {
                LblResposta.Text = Erros.SenhaVazio;
            }
            else
            {
                try
                {
                    usuario.Login = TxtLogin.Text.Trim();
                    usuario.Nome = TxtNome.Text.Trim();
                    usuario.Email = TxtEmail.Text.Trim();
                    usuario.Imagem = "Imagens/usuario.png";
                    usuario.Senha = cripto.criptografia(TxtSenha.Text.Trim());
                    usuario.DataCadastro = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    usuario.FkTipo = 1;
                    usuario.FkStatus = 1;
                    usuario.PrimeiroAcesso = 's';

                    checaEmail = BLLUsuario.Pesquisar(usuario, "email");

                    if (checaEmail.Count > 0)
                    {
                        LblResposta.Text = "Endereço de Email já cadastrado anteriormente";
                    }
                    else
                    {
                        BLLUsuario.Inserir(usuario);

                        LblResposta.Text = "Administrador cadastrado com sucesso!";

                        Response.Redirect("../Pages/Principal.aspx");
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
}