﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoFinal.Model;
using ProjetoFinal.BLL;
using ProjetoFinal.Utilitarios;

namespace ProjetoFinal.Web.Pages.Relatorios
{
    public partial class RelatorioPublicacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Session.RemoveAll();
                Response.Redirect("../../Pages/Login.aspx");
            }

            MODUsuario usuario = new MODUsuario();

            usuario.Login = PegaLogin.RetornaLogin();
            usuario = BLLUsuario.PesquisarLogin(usuario);

            ImagemUser.ImageUrl = "../../Pages/" + usuario.Imagem;
            ImagemUser2.ImageUrl = "../../Pages/" + usuario.Imagem;
            LblNome.Text = usuario.Nome;

            if (usuario.FkTipo == 1)
                LblFuncao.Text = "Administrador";
            else
                LblFuncao.Text = "Lider";

            if (!Page.IsPostBack)
            {
                CarregaGrupos();
            }
        }

        private void CarregaGrupos()
        {
            MODGrupo grupo = new MODGrupo();

            TxtGrupo.DataSource = BLLGrupo.PesquisarGrupos(grupo, "todos");
            TxtGrupo.DataValueField = "IdGrupo";
            TxtGrupo.DataTextField = "Nome";
            TxtGrupo.DataBind();
        }

        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string ano = TxtAno.Text.Trim();

            MODPublicacao publicacao = new MODPublicacao();

            publicacao.FkGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);
            publicacao.TipoPublicacao = TxtTipo.Text.Trim();

            RptConsulta.DataSource = BLLPublicacao.Relatorio(publicacao, ano, "grupo");

            RptConsulta.DataBind();
        }
    }
}