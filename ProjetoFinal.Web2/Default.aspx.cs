using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoFinal.BLL;
using ProjetoFinal.Model;
using ProjetoFinal.Utilitarios;

namespace ProjetoFinal.Web2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MODGrupoLider grupoLider = new MODGrupoLider();

            if (!IsPostBack)
            {
                RptConsulta.DataSource = BLLGrupo.Pesquisar(grupoLider, "ativos");
                RptConsulta.DataBind();
            }
        }
    }
}
