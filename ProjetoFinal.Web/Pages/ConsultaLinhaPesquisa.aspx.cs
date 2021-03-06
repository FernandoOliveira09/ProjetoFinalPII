﻿using System;
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
                CarregaLinhaPesquisa();
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
            MODSubArea_Avaliacao areaSubAvaliacao = new MODSubArea_Avaliacao();
            areaSubAvaliacao.FkAva = TxtAreaAvaliacao.SelectedValue.ToString();

            List<MODSubArea_Avaliacao> lista = new List<MODSubArea_Avaliacao>();
            lista = BLLLinha_Pesquisa.PesquisarSubAreaAvaliacao(areaSubAvaliacao, "avaliacao");

            if (lista.Count == 0)
            {
                TxtSubAreaAvaliacao.Items.Clear();
            }
            else
            {
                TxtSubAreaAvaliacao.DataSource = BLLLinha_Pesquisa.PesquisarSubAreaAvaliacao(areaSubAvaliacao, "avaliacao");
                TxtSubAreaAvaliacao.DataValueField = "Id";
                TxtSubAreaAvaliacao.DataTextField = "Nome";
                TxtSubAreaAvaliacao.DataBind();
            }
        }

        private void CarregaLinhaPesquisa()
        {
            MODLinha_Pesquisa linhaPesquisa = new MODLinha_Pesquisa();
            linhaPesquisa.FkSub = TxtSubAreaAvaliacao.SelectedValue.ToString();

            List<MODLinha_Pesquisa> lista = new List<MODLinha_Pesquisa>();
            lista = BLLLinha_Pesquisa.PesquisarLinhaPesquisa(linhaPesquisa, "subarea");

            RptConsulta.DataSource = lista;
            RptConsulta.DataBind();
        }

        protected void TxtAreaConhecimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaAreaAvaliacao();
            CarregaSubAreaAvaliacao();
            CarregaLinhaPesquisa();
        }

        protected void TxtAreaAvaliacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaSubAreaAvaliacao();
            CarregaLinhaPesquisa();
        }

        protected void TxtSubAreaAvaliacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaLinhaPesquisa();
        }
    }
}