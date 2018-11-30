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
    public partial class CadastroParticipante : System.Web.UI.Page
    {
        static int modo = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MODReuniao reuniao = new MODReuniao();

                reuniao.IdReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);
                reuniao = BLLReuniao.PesquisarReuniao(reuniao, "id_reuniao");
                TxtPauta.Text = reuniao.Pauta;

                MODGrupoDocente grupoDocente = new MODGrupoDocente();
                grupoDocente.FkGrupo = reuniao.FkGrupo;
                RptDocente.DataSource = BLLGrupo_Docente.Pesquisar(grupoDocente, "grupo");
                RptDocente.DataBind();
            }
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODReuniaoParticipante reuniaoParticipante = new MODReuniaoParticipante();
            MODDocente docente = new MODDocente();

            foreach (RepeaterItem dli in RptDocente.Items)
            {
                if (dli.ItemType == ListItemType.Item || dli.ItemType == ListItemType.AlternatingItem)
                {
                    DropDownList ddl = (DropDownList)dli.FindControl("DdlAddParticipante");
                    if (ddl.Text == "Sim")
                    {
                        Label lbl = (Label)dli.FindControl("TxtNomeParticipante");
                        string titulo = lbl.Text;
                        docente.Nome = titulo;

                        docente = BLLDocente.PesquisarDocente(docente, "nome");

                        reuniaoParticipante.FkDocente = docente.IdDocente;
                        reuniaoParticipante.FKReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);

                        BLLReuniaoParticipante.Inserir(reuniaoParticipante);
                        LblResposta.Text = "Participante(s) cadastrado(s) com sucesso!";
                    }
                }
            }
        }
    }
}