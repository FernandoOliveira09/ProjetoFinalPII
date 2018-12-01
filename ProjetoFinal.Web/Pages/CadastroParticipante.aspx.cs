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
        int modo = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            MODReuniao reuniao = new MODReuniao();
            if (!Page.IsPostBack)
            {
                
                reuniao.IdReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);
                reuniao = BLLReuniao.PesquisarReuniao(reuniao, "id_reuniao");
                TxtPauta.Text = reuniao.Pauta;

                MODReuniaoParticipante reuniaoParticipante = new MODReuniaoParticipante();
                reuniaoParticipante.FKReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);

                List<MODDocente> docente = new List<MODDocente>();

                docente = BLLReuniaoParticipante.PesquisarDocente(reuniaoParticipante, "reuniao");

                if (docente.Count != 0)
                {
                    modo = 2;
                    RptExcluir.DataSource = docente;
                    RptExcluir.DataBind();

                    docente = BLLReuniaoParticipante.PesquisarDocente(reuniaoParticipante, "existente");
                    RptDocente.DataSource = docente;
                    RptDocente.DataBind();
                }
                else
                {
                    MODGrupoDocente grupoDocente = new MODGrupoDocente();
                    grupoDocente.FkGrupo = reuniao.FkGrupo;
                    RptDocente.DataSource = BLLGrupo_Docente.Pesquisar(grupoDocente, "grupo");
                    RptDocente.DataBind();
                }
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

        protected void BtnExcluir_Click(object sender, EventArgs e)
        {
            MODDocente docente = new MODDocente();
            MODReuniaoParticipante reuniaoParticipante = new MODReuniaoParticipante();

            Control botao = (Control)sender;
            RepeaterItem item = (RepeaterItem)botao.Parent;

            Label lbl = (Label)item.FindControl("TxtNomeParticipante");
            string titulo = lbl.Text;
            docente.Nome = titulo;

            docente = BLLDocente.PesquisarDocente(docente, "nome");
            reuniaoParticipante.FkDocente = docente.IdDocente;
            reuniaoParticipante.FKReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);

            string opcao = Request.Form["opcao"];

            if (opcao == "Sim")
            {
                BLLReuniaoParticipante.Excluir(reuniaoParticipante);
                Response.Write("<script>alert('Participante excluido com sucesso!')</script>");
            }

            reuniaoParticipante.FKReuniao = Convert.ToInt32(Page.Request.QueryString["id"]);

            List<MODDocente> docenteLista = new List<MODDocente>();

            docenteLista = BLLReuniaoParticipante.PesquisarDocente(reuniaoParticipante, "reuniao");

            RptExcluir.DataSource = docenteLista;
            RptExcluir.DataBind();

            docenteLista = BLLReuniaoParticipante.PesquisarDocente(reuniaoParticipante, "existente");
            RptDocente.DataSource = docenteLista;
            RptDocente.DataBind();
        }
    }
}