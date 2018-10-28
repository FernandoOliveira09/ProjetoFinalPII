using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoFinal.BLL;
using ProjetoFinal.Model;
using ProjetoFinal.Utilitarios;

namespace ProjetoFinal.Web.Pages.Lider
{
    public partial class VincularDocenteLinhaPesquisa : System.Web.UI.Page
    {
        private static int idDocente;
        private static int idGrupo;
        private static string idLinha;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MODDocente docente = new MODDocente();
                RptDocente.DataSource = BLLDocente.Pesquisar(docente, "todos");
                RptDocente.DataBind();
            }
        }

        protected void TxtPesquisarDocente_Click(object sender, EventArgs e)
        {
            MODDocente docente = new MODDocente();

            docente.Nome = TxtDocente.Text.Trim();           
            RptDocente.DataSource = BLLDocente.Pesquisar(docente, "incompleto");
            RptDocente.DataBind();
        }

        protected void BtnAddDocente_Click(object sender, EventArgs e)
        {
            MODGrupoDocente grupoDocente = new MODGrupoDocente();
            MODDocente docente = new MODDocente();

            Control botao = (Control)sender;
            RepeaterItem item = (RepeaterItem)botao.Parent;

            Label lbl = (Label)item.FindControl("TxtNomeDocente");
            string titulo = lbl.Text;
            docente.Nome = titulo;

            docente = BLLDocente.PesquisarDocente(docente, "nome");
            grupoDocente.FkDocente = docente.IdDocente;
            idDocente = docente.IdDocente;

            RptGrupo.DataSource = BLLGrupo_Docente.Pesquisar(grupoDocente, "docente");
            RptGrupo.DataBind();
        }

        protected void BtnAddGrupo_Click(object sender, EventArgs e)
        {
            MODGrupoLinha_Pesquisa grupoLinha = new MODGrupoLinha_Pesquisa();
            MODGrupo grupo = new MODGrupo();

            Control botao = (Control)sender;
            RepeaterItem item = (RepeaterItem)botao.Parent;

            Label lbl = (Label)item.FindControl("TxtNomeGrupo");
            string titulo = lbl.Text;
            grupo.Nome = titulo;

            grupo = BLLGrupo.PesquisarGrupo(grupo, "nome");
            grupoLinha.FkGrupo = grupo.IdGrupo;
            idGrupo = grupo.IdGrupo;

            RptLinha.DataSource = BLLGrupo_Linha_Pesquisa.Pesquisar(grupoLinha, "grupo");
            RptLinha.DataBind();
        }

        protected void BtnAddLinha_Click(object sender, EventArgs e)
        {
            MODGrupoLinha_Pesquisa grupoLinha = new MODGrupoLinha_Pesquisa();
            MODLinha_Pesquisa linha = new MODLinha_Pesquisa();

            Control botao = (Control)sender;
            RepeaterItem item = (RepeaterItem)botao.Parent;

            Label lbl = (Label)item.FindControl("TxtNomeLinha");
            string titulo = lbl.Text;
            linha.Linha = titulo;

            linha = BLLLinha_Pesquisa.PesquisarLinha(linha, "nome");
            linha.Id = linha.Id;
            
            idLinha = linha.Id;

            TxtData.Enabled = true;
            BtnVincular.Visible = true;
        }

        protected void BtnVincular_Click(object sender, EventArgs e)
        {
            MODDocente_Linha_Pesquisa docenteLinha = new MODDocente_Linha_Pesquisa();

            if (TxtData.Text.Trim() == "")
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else
            {
                docenteLinha.FkDocente = idDocente;
                docenteLinha.FkGrupo = idGrupo;
                docenteLinha.FkLinha = idLinha;
                docenteLinha.DataEntrada = Convert.ToDateTime(TxtData.Text.Trim());

                BLLDocente_Linha_Pesquisa.Inserir(docenteLinha);

                LblResposta.Text = "Linha de pesquisa vinculada com sucesso! ";
            }
        }
    }
}