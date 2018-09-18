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
    public partial class ConsultaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MODUsuario usuario = new MODUsuario();

            if (!IsPostBack)
            {
                RptConsulta.DataSource = BLLUsuario.Pesquisar(usuario, "todos");
                RptConsulta.DataBind();
            }
        }
    }
}