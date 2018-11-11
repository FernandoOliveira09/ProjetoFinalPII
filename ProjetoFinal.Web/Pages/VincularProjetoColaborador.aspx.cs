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
    public partial class VincularProjetoColaborador : System.Web.UI.Page
    {
        public static int idDocente, idProjeto;
        public static string projetoNome;

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

            if (!IsPostBack)
            {
                MODDocente docente = new MODDocente();
                RptColaborador.DataSource = BLLDocente.Pesquisar(docente, "todos");
                RptColaborador.DataBind();
            }

            MODProjetoPesquisa projeto = new MODProjetoPesquisa();

            idProjeto = Convert.ToInt32(Page.Request.QueryString["id"]);
            projeto.Titulo = Page.Request.QueryString["titulo"];

            TxtProjeto.Text = projeto.Titulo;
        }

        protected void BtnVincular_Click(object sender, EventArgs e)
        {
            MODProjetoPesquisa_Colaborador projetoColaborador = new MODProjetoPesquisa_Colaborador();
            MODDocente docente = new MODDocente();

            foreach (RepeaterItem dli in RptColaborador.Items)
            {
                if (dli.ItemType == ListItemType.Item || dli.ItemType == ListItemType.AlternatingItem)
                {
                    DropDownList ddl = (DropDownList)dli.FindControl("DdlAddColaborador");
                    if (ddl.Text == "Sim")
                    {
                        Label lbl = (Label)dli.FindControl("TxtNomeColaborador");
                        string titulo = lbl.Text;
                        docente.Nome = titulo;

                        docente = BLLDocente.PesquisarDocente(docente, "nome");

                        projetoColaborador.FkDocente = docente.IdDocente;
                        projetoColaborador.FkProjeto = idProjeto;

                        BLLDocente.InserirColaboradorProjeto(projetoColaborador);
                        LblResposta.Text = "Colaborador(es) vinculados com sucesso!";
                    }
                }
            }
        }

        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            MODDocente docente = new MODDocente();

            docente.Nome = TxtPesquisarColaborador.Text.Trim();
            RptColaborador.DataSource = BLLDocente.Pesquisar(docente, "incompleto");
            RptColaborador.DataBind();
        }
    }
}