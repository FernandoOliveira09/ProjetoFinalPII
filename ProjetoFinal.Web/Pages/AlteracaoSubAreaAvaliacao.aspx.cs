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
    public partial class AlteracaoSubAreaAvaliacao : System.Web.UI.Page
    {
        private string idArea, idSub;
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

            MODArea_Avaliacao areaAvaliacao = new MODArea_Avaliacao();
            MODSubArea_Avaliacao subArea = new MODSubArea_Avaliacao();

            subArea.Id = Page.Request.QueryString["id"];

            subArea = BLLLinha_Pesquisa.PesquisarSubAvaliacao(subArea);
            idSub = subArea.Id;
            idArea = subArea.FkAva;

            areaAvaliacao.Id = idArea;
            areaAvaliacao = BLLLinha_Pesquisa.PesquisarAvaliacao(areaAvaliacao);

            if (!Page.IsPostBack)
            {
                CarregaAreaConhecimento();
                CarregaAreaAvaliacao();
                TxtIdSubArea.Text = subArea.Id;
                TxtIdSubArea.ReadOnly = true;
                TxtSubArea.Text = subArea.Nome;
                TxtAvaliacao.Text = areaAvaliacao.Nome;
            }            
        }

        protected void TxtSelecao_CheckedChanged(object sender, EventArgs e)
        {
            if (TxtSelecao.Checked == true)
            {
                TxtAreaConhecimento.Enabled = true;
                TxtAreaAvaliacao.Enabled = true;
            }
            else
            {
                TxtAreaConhecimento.Enabled = false;
                TxtAreaAvaliacao.Enabled = false;
            }
                
        }

        private void CarregaAreaConhecimento()
        {
            MODArea_Conhecimento areaConhecimento = new MODArea_Conhecimento();

            TxtAreaConhecimento.DataSource = BLLLinha_Pesquisa.PesquisarAreaConhecimento(areaConhecimento, "todas");
            TxtAreaConhecimento.DataValueField = "Id";
            TxtAreaConhecimento.DataTextField = "Nome";
            TxtAreaConhecimento.DataBind();
        }

        private void CarregaAreaAvaliacao()
        {
            MODArea_Avaliacao areaAvaliacao = new MODArea_Avaliacao();
            areaAvaliacao.FkCon = TxtAreaConhecimento.SelectedValue.ToString();

            List<MODArea_Avaliacao> lista = new List<MODArea_Avaliacao>();
            lista = BLLLinha_Pesquisa.PesquisarAreaAvaliacao(areaAvaliacao, "conhecimento");

            if (lista.Count == 0)
            {
                LblAreaAvaliacao.Text = "Não há áreas de avaliação cadastradas nessa área do conhecimento";
                TxtAreaAvaliacao.Items.Clear();
            }
            else
            {
                LblAreaAvaliacao.Text = "";
                TxtAreaAvaliacao.DataSource = BLLLinha_Pesquisa.PesquisarAreaAvaliacao(areaAvaliacao, "conhecimento");
                TxtAreaAvaliacao.DataValueField = "Id";
                TxtAreaAvaliacao.DataTextField = "Nome";
                TxtAreaAvaliacao.DataBind();
            }
        }

        protected void BtnAlteracao_Click(object sender, EventArgs e)
        {
            MODSubArea_Avaliacao area = new MODSubArea_Avaliacao();

            area.Id = TxtIdSubArea.Text.Trim();
            area.Nome = TxtSubArea.Text.Trim().ToUpper();

            if (TxtSelecao.Checked == true)
            {
                TxtAreaAvaliacao.Enabled = true;
                area.FkAva = TxtAreaAvaliacao.SelectedValue.ToString();
            }
            else
            {
                area.FkAva = idArea;
            }

            if (TxtIdSubArea.Text.Trim() == "" || TxtIdSubArea.Text.Length > 10)
            {
                LblResposta.Text = Erros.CodigoVazio;
            }
            else if (TxtSubArea.Text.Trim() == "" || TxtSubArea.Text.Length > 80)
            {
                LblResposta.Text = Erros.NomeVazio;
            }
            else
            {
                try
                {
                    
                    BLLLinha_Pesquisa.AlterarSubAreaAvaliacao(area, idSub);

                    LblResposta.Text = "Sub área alterada com sucesso!";
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Erro ao inserir!');</script>");
                    throw;
                }
            }
        }

        protected void TxtAreaConhecimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaAreaAvaliacao();
        }
    }
}