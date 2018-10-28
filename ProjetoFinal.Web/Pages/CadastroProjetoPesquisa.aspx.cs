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
    public partial class CadastroProjetoPesquisa : System.Web.UI.Page
    {
        public static int idDocente, iDGrupo;
        public static string idLinha;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MODGrupo grupo = new MODGrupo();
                RptGrupo.DataSource = BLLGrupo.PesquisarGrupos(grupo, "todos");
                RptGrupo.DataBind();
            }
        }

        protected void BtnAddGrupo_Click(object sender, EventArgs e)
        {
            //MODGrupoDocente grupoDocente = new MODGrupoDocente();
            //MODDocente docente = new MODDocente();

            //Control botao = (Control)sender;
            //RepeaterItem item = (RepeaterItem)botao.Parent;

            //Label lbl = (Label)item.FindControl("TxtNomeGrupo");
            //string titulo = lbl.Text;
            //docente.Nome = titulo;

            //docente = BLLDocente.PesquisarDocente(docente, "nome");
            //grupoDocente.FkDocente = docente.IdDocente;
            //idDocente = docente.IdDocente;

            //RptGrupo.DataSource = BLLGrupo_Docente.Pesquisar(grupoDocente, "docente");
            //RptGrupo.DataBind();
        }
    }
}