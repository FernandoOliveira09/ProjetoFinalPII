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
    public partial class VincularProjetoEquipamento : System.Web.UI.Page
    {
        private static int idGrupo, idEquipamento;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MODEquipamento equipamento = new MODEquipamento();
                RptEquipamento.DataSource = BLLEquipamento.Pesquisar(equipamento, "todos");
                RptEquipamento.DataBind();
            }

            MODGrupo grupo = new MODGrupo();

            idGrupo = Convert.ToInt32(Page.Request.QueryString["id"]);
            grupo.Nome = Page.Request.QueryString["grupo"];

            TxtGrupo.Text = grupo.Nome;
        }

        protected void BtnVincularEquipamento_Click(object sender, EventArgs e)
        {
            MODGrupo_Equipamento grupoEquipamento = new MODGrupo_Equipamento();

            if (TxtDataInicio.Text.Trim() == "")
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else
            {
                grupoEquipamento.FkGrupo = idGrupo;
                grupoEquipamento.FkEquipamento = idEquipamento;
                grupoEquipamento.DataInicio = Convert.ToDateTime(TxtDataInicio.Text.Trim());

                BLLEquipamento.InserirEquipamentoGrupo(grupoEquipamento);

                LblResposta.Text = "Equipamento vinculado com sucesso!";
            }
        }

        protected void BtnAddEquipamento_Click(object sender, EventArgs e)
        {
            MODGrupo_Equipamento projetoDiscente = new MODGrupo_Equipamento();
            MODEquipamento equipamento = new MODEquipamento();

            Control botao = (Control)sender;
            RepeaterItem item = (RepeaterItem)botao.Parent;

            Label lbl = (Label)item.FindControl("TxtNomeEquipamento");
            string titulo = lbl.Text;
            equipamento.Nome = titulo;

            equipamento = BLLEquipamento.PesquisarEquipamento(equipamento, "nome");

            idEquipamento = equipamento.IdEquipamento;
        }
    }
}