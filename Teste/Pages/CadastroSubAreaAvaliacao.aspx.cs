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
    public partial class CadastroSubAreaAvaliacao: System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {
                CarregaAreaConhecimento();
            }

            CarregaAreaAvaliacao();
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

        protected void TxtAreaConhecimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaAreaAvaliacao();
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODSubArea_Avaliacao subArea = new MODSubArea_Avaliacao();
            MODLinha_Pesquisa linha = new MODLinha_Pesquisa();

            subArea.Id = TxtIdSubArea.Text.Trim();
            subArea.Nome = TxtSubArea.Text.Trim().ToUpper();
            linha.Id = TxtIdSubArea.Text.Trim();
            linha.Linha = TxtSubArea.Text.Trim().ToUpper();
            linha.FkSub = TxtIdSubArea.Text.Trim();

            List<MODSubArea_Avaliacao> lista = new List<MODSubArea_Avaliacao>();
            lista = BLLLinha_Pesquisa.PesquisarSubAreaAvaliacao(subArea, "existente");

            if (TxtIdSubArea.Text.Trim() == "" || TxtIdSubArea.Text.Length > 10)
            {
                LblResposta.Text = Erros.CodigoVazio;
            }
            else if (TxtIdSubArea.Text.Length < 8)
            {
                LblResposta.Text = "O código deve ter ao menos 8 caracteres";
            }
            else if (TxtSubArea.Text.Trim() == "" || TxtSubArea.Text.Length > 80)
            {
                LblResposta.Text = Erros.NomeVazio;
            }
            else if (lista.Count > 0)
            {
                LblResposta.Text = Erros.LinhaExistente;
            }
            else if (TxtAreaAvaliacao.Text == "")
            {
                LblResposta.Text = "A área de avaliação é obrigatória!";
            }
            else
            {
                try
                {
                    subArea.FkAva = TxtAreaAvaliacao.SelectedValue.ToString();

                    BLLLinha_Pesquisa.InserirSubAreaAvaliacao(subArea);
                    BLLLinha_Pesquisa.InserirLinha(linha);

                    LblResposta.Text = "Sub área cadastrada com sucesso!";
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