using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoFinal.BLL;
using ProjetoFinal.Model;
using ProjetoFinal.Utilitarios;


namespace ProjetoFinal.Web
{
    public partial class Reunioes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MODReuniao reuniao = new MODReuniao();
                reuniao.IdReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);
                reuniao = BLLReuniao.PesquisarReuniao(reuniao, "id_reuniao");

                if(reuniao.HoraFim.ToString() == "01/01/0001 00:00:00")
                {
                    LblResposta.Text = "Não foi possivel exibir a ata da reunião, pois a mesma ainda não foi encerrada!";
                }
                else
                {
                    MODAta ata = new MODAta();
                    ata.FkReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);
                    RptConsulta.DataSource = BLLAta.Pesquisar(ata, "reuniao");
                    RptConsulta.DataBind();
                }              
            }
        }
    }
}