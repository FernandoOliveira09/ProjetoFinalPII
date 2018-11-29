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
            string extensao = Path.GetExtension(FUFoto.FileName);
            docente.Nome = TxtNome.Text.Trim();

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
            else if (extensao != ".jpg" && extensao != ".jpeg" && extensao != ".png" && extensao != ".bmp")
            {
                LblResposta.Text = "Arquivo de foto inválido, utilize fotos nas seguintes extensões: .jpg/.jpeg/.png/.bmp";
            }
            else
            {
                try
                {
                    docente.Formacao = TxtFormacaoAcademica.Text.Trim();

                    if(TxtCurso.Enabled == true)
                        docente.Curso = TxtCurso.Text.Trim();
                    docente.DataInclusao = Convert.ToDateTime(TxtData.Text.Trim());
                    docente.Lattes = TxtLattes.Text.Trim();

                    string foto = "Imagens/" + docente.Nome + extensao;
                    if (File.Exists(Server.MapPath(foto)))
                        File.Delete(Server.MapPath(foto));

                    this.FUFoto.SaveAs(Server.MapPath("Imagens/" + FUFoto.FileName));
                    System.IO.File.Move(Server.MapPath("Imagens/" + FUFoto.FileName), Server.MapPath(foto));

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

        protected void TxtFormacaoAcademica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TxtFormacaoAcademica.Text != "Ensino Médio Completo" && TxtFormacaoAcademica.Text != "Ensino Técnico")
                TxtCurso.Enabled = true;
            else
                TxtCurso.Enabled = false;

        }
    }
}