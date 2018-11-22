using System;
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
    public partial class RelatorioEquipamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregaGrupos();
            }
        }

        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string ano = TxtAno.Text.Trim();

            MODGrupo grupo = new MODGrupo();

            grupo.IdGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);
            RptConsulta.DataSource = BLLGrupo.Relatorio(grupo, ano, "equipamento");
            RptConsulta.DataBind();
        }

        private void CarregaGrupos()
        {
            MODGrupo grupo = new MODGrupo();

            TxtGrupo.DataSource = BLLGrupo.PesquisarGrupos(grupo, "todos");
            TxtGrupo.DataValueField = "IdGrupo";
            TxtGrupo.DataTextField = "Nome";
            TxtGrupo.DataBind();
        }
    }
}