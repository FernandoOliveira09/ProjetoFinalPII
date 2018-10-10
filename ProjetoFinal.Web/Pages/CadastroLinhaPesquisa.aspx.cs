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
            if(!Page.IsPostBack)
                CarregaAreaConhecimento();

            CarregaAreaAvaliacao();
        }

        private void CarregaAreaConhecimento()
        {
            MODArea_Conhecimento areaConhecimento = new MODArea_Conhecimento();

            TxtAreaConhecimento.DataSource = BLLLinha_Pesquisa.Pesquisar(areaConhecimento);
            TxtAreaConhecimento.DataValueField = "Id";
            TxtAreaConhecimento.DataTextField = "Nome";
            TxtAreaConhecimento.DataBind();
        }

        private void CarregaAreaAvaliacao()
        {
            TxtAreaAvaliacao.DataSource = BLLLinha_Pesquisa.PesquisarAreaAvaliacao(TxtAreaConhecimento.SelectedValue.ToString());
            TxtAreaAvaliacao.DataValueField = "Id";
            TxtAreaAvaliacao.DataTextField = "Nome";
            TxtAreaAvaliacao.DataBind();
        }

        protected void TxtAreaConhecimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaAreaAvaliacao();
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
                LblResposta.Text = Erros.NomeVazio;
            }
            else if(TxtIdLinha.Text.Length < 8)
            {
                LblResposta.Text = "O código deve ter ao menos 8 caracteres";
            }
            else if (TxtLinhaPesquisa.Text.Trim() == "" || TxtLinhaPesquisa.Text.Length > 80)
            {
                LblResposta.Text = Erros.CodigoVazio;
            }
            else if (lista.Count > 0)
            {
                LblResposta.Text = Erros.LinhaExistente;
            }
            else
            {
                try
                {
                    
                    linha.FkAva = TxtAreaAvaliacao.SelectedValue.ToString();

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