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
    public partial class CadastroTecnico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
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
                LblResposta.Text = Erros.DataVazio;
            }
            //else if (FUFotoTec.Text.Trim() == "")
            //{
            //    LblResposta.Text = Erros.FotoVazio;
            //}

            else
            {
                try
                {
                    tecnico.Nome = TxtNome.Text.Trim();
                    tecnico.Lattes = TxtLattes.Text.Trim();
                    tecnico.Atividade = TextAtividades.Text.Trim();
                    tecnico.Curso = TextCurso.Text.Trim();
                    tecnico.Formacao = TxtFormacao.Text;
                    tecnico.AnoConclusao = Convert.ToDateTime(TxtData.Text.Trim());
                    this.FUFotoTec.SaveAs(Server.MapPath("Imagens/" + FUFotoTec.FileName));
                    tecnico.Foto = "Imagens/" + FUFotoTec.FileName;

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
    }
}