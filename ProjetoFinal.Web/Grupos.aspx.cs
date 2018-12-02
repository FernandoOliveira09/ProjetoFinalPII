using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoFinal.BLL;
using ProjetoFinal.Model;
using ProjetoFinal.Utilitarios;

namespace ProjetoFinal.Web
{
    public partial class Grupos : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        static int idReuniao;
        protected void Page_Load(object sender, EventArgs e)
        {
            MODGrupoLider grupoLider = new MODGrupoLider();
            MODGrupo grupo = new MODGrupo();

            if (!IsPostBack)
            {
                grupo.Sigla = Page.Request.QueryString["sigla"];
                grupo = BLLGrupo.PesquisarGrupo(grupo, "sigla");
                grupoLider.FkGrupo = grupo.IdGrupo;
                idReuniao = grupo.IdGrupo;

                this.Title = grupo.Sigla + " - " + grupo.Nome + " - " + "SG Manager";

                RptConsulta.DataSource = BLLGrupo.Pesquisar(grupoLider, "grupo");
                RptConsulta.DataBind();

                MODGrupoDocente grupoDocente = new MODGrupoDocente();
                grupoDocente.FkGrupo = grupoLider.FkGrupo;

                RPTDocente.DataSource = BLLGrupo_Docente.Pesquisar(grupoDocente, "gativos");
                RPTDocente.DataBind();

                MODGrupoTecnico grupoTecnico = new MODGrupoTecnico();
                grupoTecnico.FkGrupo = grupoLider.FkGrupo;

                RPTTecnico.DataSource = BLLGrupo_Tecnico.Pesquisar(grupoTecnico, "gativos");
                RPTTecnico.DataBind();

                MODGrupoLinha_Pesquisa grupoLinha_Pesquisa = new MODGrupoLinha_Pesquisa();
                grupoLinha_Pesquisa.FkGrupo = grupoLider.FkGrupo;

                RPTLinha.DataSource = BLLGrupo_Linha_Pesquisa.Pesquisar(grupoLinha_Pesquisa, "gativos");
                RPTLinha.DataBind();

                RPTDiscente.DataSource = BLLDiscente.PesquisarPorGrupo(grupo);
                RPTDiscente.DataBind();

                RPTProjetos.DataSource = BLLProjeto_Pesquisa.ConsultaPorGrupo(grupo);
                RPTProjetos.DataBind();

                RPTPublicacao.DataSource = BLLPublicacao.ConsultaPorGrupo(grupo);
                RPTPublicacao.DataBind();

                RptEquipamento.DataSource = BLLEquipamento.ConsultaPorGrupo(grupo);
                RptEquipamento.DataBind();

                CldReuniao.VisibleDate = DateTime.Today;
            }

            List<MODReuniao> reunioes = new List<MODReuniao>();
            MODReuniao reuniao = new MODReuniao();
            reuniao.FkGrupo = idReuniao;
            reunioes = BLLReuniao.Pesquisar(reuniao, "grupo");
            dt = BLLReuniao.CarregarCalendario(reuniao, "", "grupo");

            if (!Page.IsPostBack)
            {
                string data = CldReuniao.VisibleDate.Year.ToString() + "-" + CldReuniao.VisibleDate.Month.ToString();
                reuniao.IdReuniao = idReuniao;
                RptReuniao.DataSource = BLLReuniao.CarregarCalendario(reuniao, data, "data");
                RptReuniao.DataBind();
            }
            
        }

        protected void CldReuniao_DayRender(object sender, DayRenderEventArgs e)
        {
            string data = "";
            Literal l = new Literal();
            l.Visible = true;
            l.Text = "<br/>";
            e.Cell.Controls.Add(l);

            MODReuniao reuniao = new MODReuniao();

            foreach (DataRow row in dt.Rows)
            {
                data = (Convert.ToDateTime(row[0]).ToShortDateString().ToString());

                if (data == e.Day.Date.ToShortDateString().ToString())
                {
                    e.Cell.BackColor = System.Drawing.Color.Red;
                    e.Cell.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        protected void CldReuniao_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            List<MODReuniao> reunioes = new List<MODReuniao>();
            MODReuniao reuniao = new MODReuniao();
            reuniao.FkGrupo = idReuniao;
            reunioes = BLLReuniao.Pesquisar(reuniao, "grupo");
            dt = BLLReuniao.CarregarCalendario(reuniao, "", "grupo");

            string data = CldReuniao.VisibleDate.Year.ToString() + "-" + CldReuniao.VisibleDate.Month.ToString();
            reuniao.IdReuniao = idReuniao;
            RptReuniao.DataSource = BLLReuniao.CarregarCalendario(reuniao, data, "data");
            RptReuniao.DataBind();
        }
    }
}