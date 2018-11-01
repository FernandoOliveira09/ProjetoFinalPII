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
        public static int idDocente, idGrupo;
        public static string grupoNome;
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
            MODProjetoPesquisa projetoPesquisa = new MODProjetoPesquisa();
            List<string> lista = new List<string>();

            if (TxtNome.Text.Trim() == "")
            {
                LblResposta.Text = Erros.TituloVazio;
            }
            else if (TxtDataInicio.Text.Trim() == "")
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else
            {
                projetoPesquisa.FkGrupo = idGrupo;
                projetoPesquisa.FkDocente = Convert.ToInt32(TxtDocenteLider.SelectedValue);
                projetoPesquisa.Titulo = TxtNome.Text.Trim();
                projetoPesquisa.Tipo = TxtTipoProjeto.Text.Trim();

                if (TxtTipoProjeto.Text.Trim() == "Bolsa")
                    projetoPesquisa.Bolsa = TxtTipoBolsa.Text.Trim();

                if (TxtTipoBolsa.Text.Trim() == "Outra")
                    projetoPesquisa.NomeBolsa = TxtNomeBolsa.Text.Trim();

                projetoPesquisa.DataInicio = Convert.ToDateTime(TxtDataInicio.Text.Trim());

                BLLProjeto_Pesquisa.Inserir(projetoPesquisa);
            }

            foreach (RepeaterItem dli in RptLinhas.Items)
            {
                if (dli.ItemType == ListItemType.Item || dli.ItemType == ListItemType.AlternatingItem)
                {
                    DropDownList ddl = (DropDownList)dli.FindControl("DdlAddLinha");
                    if (ddl.Text == "Sim")
                    {

                        Label lbl = (Label)dli.FindControl("TxtNomeLinha");
                        string titulo = lbl.Text;
                        lista.Add(titulo);

                        //Negocio.Inserir(lblNome.Text)
                    }
                }
            }
        }

        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            MODGrupo grupo = new MODGrupo();

            grupo.Nome = TxtPesquisar.Text.Trim();
            RptGrupo.DataSource = BLLGrupo.PesquisarGrupos(grupo, "incompleto");
            RptGrupo.DataBind();
        }

        protected void TxtDocenteLider_SelectedIndexChanged(object sender, EventArgs e)
        {
            MODGrupoDocente grupoDocente = new MODGrupoDocente();
            MODDocente_Linha_Pesquisa docenteLinha = new MODDocente_Linha_Pesquisa();
            MODGrupo grupo = new MODGrupo();
            MODDocente docente = new MODDocente();

            grupo.Nome = grupoNome;

            grupo = BLLGrupo.PesquisarGrupo(grupo, "nome");

            grupoDocente.FkGrupo = grupo.IdGrupo;
            idGrupo = grupo.IdGrupo;

            grupoDocente.FkDocente = Convert.ToInt32(TxtDocenteLider.SelectedValue);

            RptLinhas.DataSource = BLLDocente_Linha_Pesquisa.Pesquisar(grupoDocente, "docente");
            RptLinhas.DataBind();
        }

        protected void BtnAddGrupo_Click(object sender, EventArgs e)
        {
            TxtDocenteLider.Items.Clear();
            MODGrupoDocente grupoDocente = new MODGrupoDocente();
            MODDocente_Linha_Pesquisa docenteLinha = new MODDocente_Linha_Pesquisa();
            MODGrupo grupo = new MODGrupo();
            MODDocente docente = new MODDocente();

            Control botao = (Control)sender;
            RepeaterItem item = (RepeaterItem)botao.Parent;

            Label lbl = (Label)item.FindControl("TxtNomeGrupo");
            string titulo = lbl.Text;
            grupo.Nome = titulo;
            grupoNome = titulo;

            grupo = BLLGrupo.PesquisarGrupo(grupo, "nome");

            grupoDocente.FkGrupo = grupo.IdGrupo;
            idGrupo = grupo.IdGrupo;

            TxtDocenteLider.DataSource = BLLGrupo_Docente.Pesquisar(grupoDocente, "grupo");
            TxtDocenteLider.DataValueField = "id_docente";
            TxtDocenteLider.DataTextField = "nome";
            TxtDocenteLider.DataBind();

            grupoDocente.FkDocente = Convert.ToInt32(TxtDocenteLider.SelectedValue);

            RptLinhas.DataSource = BLLDocente_Linha_Pesquisa.Pesquisar(grupoDocente, "docente");
            RptLinhas.DataBind();
        }
    }
}