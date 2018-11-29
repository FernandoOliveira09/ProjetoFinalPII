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
    public partial class CadastroLinhaPesquisa : System.Web.UI.Page
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
                CarregaAreaAvaliacao();
                CarregaSubAreaAvaliacao();
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
                LblAreaAvaliacao.Text = "Não há sub áreas cadastradas nessa área de avaliação";
                TxtAreaAvaliacao.Items.Clear();
            }
            else
            {
                TxtAreaAvaliacao.DataSource = BLLLinha_Pesquisa.PesquisarAreaAvaliacao(areaAvaliacao, "conhecimento");
                TxtAreaAvaliacao.DataValueField = "Id";
                TxtAreaAvaliacao.DataTextField = "Nome";
                TxtAreaAvaliacao.DataBind();
            }            
        }

        private void CarregaSubAreaAvaliacao()
        {
            MODSubArea_Avaliacao subArea = new MODSubArea_Avaliacao();
            subArea.FkAva = TxtAreaAvaliacao.SelectedValue.ToString();

            List<MODSubArea_Avaliacao> lista = new List<MODSubArea_Avaliacao>();
            lista = BLLLinha_Pesquisa.PesquisarSubAreaAvaliacao(subArea, "avaliacao");

            if(lista.Count == 0)
            {
                LblSubArea.Text = "Não há sub áreas cadastradas nessa área de avaliação";
                TxtSubAreaAvaliacao.Items.Clear();
            }
            else
            {
                LblSubArea.Text = "";
                TxtSubAreaAvaliacao.DataSource = BLLLinha_Pesquisa.PesquisarSubAreaAvaliacao(subArea, "avaliacao");
                TxtSubAreaAvaliacao.DataValueField = "Id";
                TxtSubAreaAvaliacao.DataTextField = "Nome";
                TxtSubAreaAvaliacao.DataBind();
            }  
        }

        protected void TxtAreaConhecimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaAreaAvaliacao();
            CarregaSubAreaAvaliacao();
        }

        protected void TxtAreaAvaliacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaSubAreaAvaliacao();
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODLinha_Pesquisa linha = new MODLinha_Pesquisa();

            linha.Id = TxtIdLinha.Text.Trim();
            linha.Linha = TxtLinhaPesquisa.Text.Trim().ToUpper();

            List<MODLinha_Pesquisa> lista = new List<MODLinha_Pesquisa>();
            lista = BLLLinha_Pesquisa.PesquisarLinhaPesquisa(linha, "existente");

            if (TxtIdLinha.Text.Trim() == "" || TxtIdLinha.Text.Length > 10)
            {
                LblResposta.Text = Erros.CodigoVazio;
            }
            else if(TxtIdLinha.Text.Length < 8)
            {
                LblResposta.Text = "O código deve ter ao menos 8 caracteres";
            }
            else if (TxtLinhaPesquisa.Text.Trim() == "" || TxtLinhaPesquisa.Text.Length > 80)
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
            else if(TxtSubAreaAvaliacao.Text == "")
            {
                LblResposta.Text = "A sub área é obrigatória!";
            }
            else
            {
                try
                {
                    
                    linha.FkSub = TxtSubAreaAvaliacao.SelectedValue.ToString();

                    BLLLinha_Pesquisa.InserirLinha(linha);

                    LblResposta.Text = "Linha de pesquisa cadastrada com sucesso!";
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