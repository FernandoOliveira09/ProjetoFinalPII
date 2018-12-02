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
    public partial class DesvincularDocente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Session.RemoveAll();
                Response.Redirect("../Pages/Login.aspx");
            }

            MODUsuario usuario2 = new MODUsuario();
            usuario2.Login = PegaLogin.RetornaLogin();
            usuario2 = BLLUsuario.PesquisarLogin(usuario2);

            ImagemUser.ImageUrl = "../Pages/" + usuario2.Imagem;
            ImagemUser2.ImageUrl = "../Pages/" + usuario2.Imagem;
            LblNome.Text = usuario2.Nome;

            if (usuario2.FkTipo == 1)
                LblFuncao.Text = "Administrador";
            else
                LblFuncao.Text = "Lider de Pesquisa";

            if (!Page.IsPostBack)
            {
                MODGrupoDocente grupoDocente = new MODGrupoDocente();
                MODDocente docente = new MODDocente();
                grupoDocente.FkDocente = Convert.ToInt32(Page.Request.QueryString["docente"]);
                TxtGrupo.DataSource = BLLGrupo_Docente.Pesquisar(grupoDocente, "docente");
                TxtGrupo.DataValueField = "Id_grupo";
                TxtGrupo.DataTextField = "Nome";
                TxtGrupo.DataBind();

                docente.IdDocente = grupoDocente.FkDocente;
                docente = BLLDocente.PesquisarDocente(docente, "id");
               

                TxtNome.Text = docente.Nome;
            }
        }

        protected void Desvincular_Click(object sender, EventArgs e)
        {
            MODGrupoDocente grupoDocente = new MODGrupoDocente();

            if (TxtDataTermino.Text.Trim() == "")
            {
                LblResposta.Text = "A data de término nao pode ser nula!";
            }
            else
            {
                grupoDocente.FkDocente = Convert.ToInt32(Page.Request.QueryString["docente"]);
                grupoDocente.FkGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);
                grupoDocente.DataSaida = Convert.ToDateTime(TxtDataTermino.Text.Trim());

                BLLGrupo_Docente.AlterarDataSaidaDocente(grupoDocente);

                LblResposta.Text = "Docente desvinculado com sucesso!";
            }
        }
    }
}