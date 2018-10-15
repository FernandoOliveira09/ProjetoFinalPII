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
    public partial class ConsultaLinhaPesquisa : System.Web.UI.Page
    {
        string valorAvaliacao;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregaAreaConhecimento();
                CarregaAreaAvaliacao(); 
            }

            MODLinha_Pesquisa linhaPesquisa = new MODLinha_Pesquisa();
            linhaPesquisa.FkAva = TxtAreaAvaliacao.SelectedValue.ToString();

            RptConsulta.DataSource = BLLLinha_Pesquisa.PesquisarLinhaPesquisa(linhaPesquisa, "avaliacao");
            RptConsulta.DataBind();

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

            MODLinha_Pesquisa linhaPesquisa = new MODLinha_Pesquisa();
            linhaPesquisa.FkAva = TxtAreaAvaliacao.SelectedValue.ToString();

            RptConsulta.DataSource = BLLLinha_Pesquisa.PesquisarLinhaPesquisa(linhaPesquisa, "avaliacao");
            RptConsulta.DataBind();
        }

        protected void TxtAreaConhecimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaAreaAvaliacao();
        }
    }
}