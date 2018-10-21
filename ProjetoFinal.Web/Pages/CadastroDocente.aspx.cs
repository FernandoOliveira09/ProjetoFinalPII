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
    public partial class CadastroDocente : System.Web.UI.Page
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

        protected void BtnCadastrar_Click1(object sender, EventArgs e)
        {
            MODDocente docente = new MODDocente();

            if (TxtNome.Text.Trim() == "" || TxtNome.Text.Length > 50)
            {
                LblResposta.Text = Erros.NomeVazio;
            }
            else if (TxtFormacaoAcademica.Text.Trim() == "" || TxtFormacaoAcademica.Text.Length > 50)
            {
                LblResposta.Text = Erros.FormacaoVazia;
            }
            else if (TxtData.Text.Trim() == "" || TxtData.Text.Length > 15)
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else if (TxtLattes.Text.Trim() == "")
            {
                LblResposta.Text = Erros.LattesVazio;
            }
            else if (TxtCurso.Text.Trim() == "")
            {
                LblResposta.Text = Erros.CursoVazio;
            }
            else if (!FUFoto.HasFile)
            {
                LblResposta.Text = Erros.FotoVazio;
            }
            else
            {
                try
                {
                    docente.Nome = TxtNome.Text.Trim();
                    docente.Formacao = TxtFormacaoAcademica.Text.Trim();
                    docente.Curso = TxtCurso.Text.Trim();
                    docente.DataInclusao = Convert.ToDateTime(TxtData.Text.Trim());
                    docente.Lattes = TxtLattes.Text.Trim();
                    this.FUFoto.SaveAs(Server.MapPath("Imagens/" + FUFoto.FileName));
                    docente.Foto = "Imagens/" + FUFoto.FileName;

                    BLLDocente.InserirDocente(docente);

                    LblResposta.Text = "Docente cadastrado com sucesso!";

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