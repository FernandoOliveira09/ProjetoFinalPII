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

        protected void TxtTipoProjeto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TxtTipoProjeto.Text == "Bolsa")
                TxtTipoBolsa.Enabled = true;
            else
                TxtTipoBolsa.Enabled = false;
        }

        protected void TxtTipoBolsa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TxtTipoBolsa.Text == "Outra")
                TxtNomeBolsa.Enabled = true;
            else
                TxtNomeBolsa.Enabled = false;
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            
        }

        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            MODGrupo grupo = new MODGrupo();

            grupo.Nome = TxtPesquisar.Text.Trim();
            RptGrupo.DataSource = BLLGrupo.PesquisarGrupos(grupo, "incompleto");
            RptGrupo.DataBind();
        }

        protected void BtnAddGrupo_Click(object sender, EventArgs e)
        {
            MODGrupoDocente grupoDocente = new MODGrupoDocente();
            MODGrupo grupo = new MODGrupo();

            Control botao = (Control)sender;
            RepeaterItem item = (RepeaterItem)botao.Parent;

            Label lbl = (Label)item.FindControl("TxtNomeGrupo");
            string titulo = lbl.Text;
            grupo.Nome = titulo;

            grupo = BLLGrupo.PesquisarGrupo(grupo, "nome");

            grupoDocente.FkGrupo = grupo.IdGrupo;

            TxtDocenteLider.DataSource = BLLGrupo_Docente.Pesquisar(grupoDocente, "grupo");
            TxtDocenteLider.DataValueField = "id_docente";
            TxtDocenteLider.DataTextField = "nome";
            TxtDocenteLider.DataBind();
        }
    }
}