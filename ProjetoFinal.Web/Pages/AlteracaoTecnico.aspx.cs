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
    public partial class AlteracaoTecnico : System.Web.UI.Page
    {
        private static int idTecnico;
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

            MODTecnico tecnico = new MODTecnico();

            tecnico.IdTecnico = Convert.ToInt32(Page.Request.QueryString["id"]);
            idTecnico = Convert.ToInt32(Page.Request.QueryString["id"]);
            tecnico = BLLTecnico.PesquisarTecnico(tecnico);
            // = tecnico.IdTecnico;

            if (!Page.IsPostBack)
            {
                TxtNome.Text = tecnico.Nome;
                TxtLattes.Text = tecnico.Lattes;
                TextAtividades.Text = tecnico.Atividade;
                TextCurso.Text = tecnico.Curso;
                TxtFormacao.Text = tecnico.Formacao;
                TxtData.Text = tecnico.AnoConclusao.ToString();
                TxtFoto.Text = tecnico.Foto;
                // FUFotoTec.Text = tecnico.Foto;
            }

            //TxtLogo.Visible = false;
        }

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            MODTecnico tecnico = new MODTecnico();

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
            else if (TextCurso.Text.Trim() == "")
            {
                LblResposta.Text = Erros.CursoVazio;
            }
            else if (TxtFormacao.Text.Trim() == "")
            {
                LblResposta.Text = Erros.FormacaoVazia;
            }
            else if (TxtData.Text.Trim() == "")
            {
                
            }
            else
            {
                try
                {
                    if (FUFotoTec.FileName == "")
                    {
                        if (TxtFoto.Text == "")
                        {
                            LblResposta.Text = Erros.FotoVazio;
                        }
                        else
                        {
                            tecnico.Foto = TxtFoto.Text.Trim();
                        }
                    }
                    else
                    {
                        this.FUFotoTec.SaveAs(Server.MapPath("Imagens/" + FUFotoTec.FileName));
                        tecnico.Foto = "Imagens/" + FUFotoTec.FileName;
                    }

                    tecnico.IdTecnico = idTecnico;
                    tecnico.Nome = TxtNome.Text.Trim();
                    tecnico.Lattes = TxtLattes.Text.Trim();
                    tecnico.Atividade = TextAtividades.Text.Trim();
                    tecnico.Curso = TextCurso.Text.Trim();
                    tecnico.Formacao = TxtFormacao.Text;
                    tecnico.AnoConclusao = Convert.ToDateTime(TxtData.Text.Trim());

                    BLLTecnico.Alterar(tecnico);

                    LblResposta.Text = "Tecnico alterado com sucesso!";
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
