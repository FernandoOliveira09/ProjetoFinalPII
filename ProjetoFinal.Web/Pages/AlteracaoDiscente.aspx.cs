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
    public partial class AlteracaoDiscente : System.Web.UI.Page
    {
        private static int idDiscente;

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

            MODDiscente discente = new MODDiscente();

            discente.IdDiscente = Convert.ToInt32(Page.Request.QueryString["discente"]);
            idDiscente = Convert.ToInt32(Page.Request.QueryString["discente"]);
            discente = BLLDiscente.PesquisarDiscente(discente, "id");
            //idDiscente = discente.IdDiscente;

            if (!Page.IsPostBack)
            {
                TxtNome.Text = discente.Nome;
                TxtCurso.Text = discente.Curso;
                TxtLattes.Text = discente.Lattes;
            }

        }

        protected void BtnAlterar_Click1(object sender, EventArgs e)
        {

        }

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            MODDiscente discente = new MODDiscente();

            if (TxtNome.Text.Trim() == "" || TxtNome.Text.Length > 50)
            {
                LblResposta.Text = Erros.NomeVazio;
            }
            else if (TxtCurso.Text.Trim() == "" || TxtCurso.Text.Length > 50)
            {
                LblResposta.Text = Erros.FormacaoVazia;
            }
            else if (TxtLattes.Text.Trim() == "")
            {
                LblResposta.Text = Erros.LattesVazio;
            }
            else
            {
                try
                {
                    discente.IdDiscente = idDiscente;
                    discente.Nome = TxtNome.Text.Trim();
                    discente.Curso = TxtCurso.Text.Trim();
                    discente.Lattes = TxtLattes.Text.Trim();

                    BLLDiscente.Alterar(discente);

                    LblResposta.Text = "Discente alterado com sucesso!";

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