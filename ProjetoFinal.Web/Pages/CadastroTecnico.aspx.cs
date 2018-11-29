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
    public partial class CadastroTecnico : System.Web.UI.Page
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

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODTecnico tecnico = new MODTecnico();
            string extensao = Path.GetExtension(FUFotoTec.FileName);

            tecnico.Nome = TxtNome.Text.Trim();

            if (TxtNome.Text.Trim() == "" || TxtNome.Text.Length > 50)
            {
                LblResposta.Text = Erros.NomeVazio;
            }
            else if (TxtLattes.Text.Trim() == "" || TxtLattes.Text.Length > 50)
            {
                LblResposta.Text = Erros.LattesVazio;
            }
            else if (TextAtividades.Text.Trim() == "")
            {
                LblResposta.Text = Erros.AtividadeVazia;
            }
            else if (TxtFormacao.Text.Trim() == "")
            {
                LblResposta.Text = Erros.FormacaoVazia;
            }
            else if (TxtData.Text.Trim() == "")
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else if (extensao != ".jpg" && extensao != ".jpeg" && extensao != ".png" && extensao != ".bmp")
            {
                LblResposta.Text = "Arquivo de foto inválido, utilize fotos nas seguintes extensões: .jpg/.jpeg/.png/.bmp";
            }
            else
            {
                try
                {
                    tecnico.Lattes = TxtLattes.Text.Trim();
                    tecnico.Atividade = TextAtividades.Text.Trim();
                    if(TextCurso.Enabled == true)
                        tecnico.Curso = TextCurso.Text.Trim();

                    tecnico.Formacao = TxtFormacao.Text;
                    tecnico.AnoConclusao = Convert.ToDateTime(TxtData.Text.Trim());

                    string foto = "Imagens/" + tecnico.Nome + extensao;
                    if (File.Exists(Server.MapPath(foto)))
                        File.Delete(Server.MapPath(foto));

                    this.FUFotoTec.SaveAs(Server.MapPath("Imagens/" + FUFotoTec.FileName));

                    System.IO.File.Move(Server.MapPath("Imagens/" + FUFotoTec.FileName), Server.MapPath(foto));

                    tecnico.Foto = foto;

                    BLLTecnico.Inserir(tecnico);

                    LblResposta.Text = "Técnico cadastrado com sucesso!";
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Erro ao inserir!');</script>");
                    throw;
                }
            }
        }

        protected void TxtFormacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TxtFormacao.Text != "Ensino Médio Completo" && TxtFormacao.Text != "Ensino Técnico")
                TextCurso.Enabled = true;
            else
                TextCurso.Enabled = false;
        }
    }
}