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
    public partial class EncerrarProjeto : System.Web.UI.Page
    {
        static int idProjeto;
        protected void Page_Load(object sender, EventArgs e)
        {
            MODProjetoPesquisa projeto = new MODProjetoPesquisa();

            if (!IsPostBack)
            {
                projeto.IdProjeto = Convert.ToInt32(Page.Request.QueryString["id"]);
                projeto.Titulo = Page.Request.QueryString["projeto"];

                idProjeto = projeto.IdProjeto;

                TxtNome.Text = projeto.Titulo;

            }
        }

        protected void BtnEncerrar_Click(object sender, EventArgs e)
        {
            MODProjetoPesquisa projeto = new MODProjetoPesquisa();

            if (TxtDataTermino.Text.Trim() == "")
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else
            {
                projeto.IdProjeto = idProjeto;
                projeto.DataTermino = Convert.ToDateTime(TxtDataTermino.Text.Trim());


                BLLProjeto_Pesquisa.AlteracaoEncerrar(projeto);

                LblResposta.Text = "Projeto encerrado com sucesso!";
            }
        }
    }
}