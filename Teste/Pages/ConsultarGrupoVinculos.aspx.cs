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
    public partial class ConsultarGrupoVinculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MODGrupoLider grupoLider = new MODGrupoLider();
            MODGrupo grupo = new MODGrupo();

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
                grupo.IdGrupo = Convert.ToInt32(Page.Request.QueryString["id"]);
                grupo = BLLGrupo.PesquisarGrupo(grupo, "id");
                grupoLider.FkGrupo = grupo.IdGrupo;

                //RptConsulta.DataSource = BLLGrupo.Pesquisar(grupoLider, "grupo");
                //RptConsulta.DataBind();

                MODGrupoDocente grupoDocente = new MODGrupoDocente();
                grupoDocente.FkGrupo = grupo.IdGrupo;

                RptDocentes.DataSource = BLLGrupo_Docente.Pesquisar(grupoDocente, "grupo");
                RptDocentes.DataBind();

                MODGrupoTecnico grupoTecnico = new MODGrupoTecnico();
                grupoTecnico.FkGrupo = grupo.IdGrupo;

                RPTTecnicos.DataSource = BLLGrupo_Tecnico.Pesquisar(grupoTecnico, "grupo");
                RPTTecnicos.DataBind();

                MODGrupoLinha_Pesquisa grupoLinha_Pesquisa = new MODGrupoLinha_Pesquisa();
                grupoLinha_Pesquisa.FkGrupo = grupo.IdGrupo;

                RPTLinhas.DataSource = BLLGrupo_Linha_Pesquisa.Pesquisar(grupoLinha_Pesquisa, "grupo");
                RPTLinhas.DataBind();
            }
        }
    }
}