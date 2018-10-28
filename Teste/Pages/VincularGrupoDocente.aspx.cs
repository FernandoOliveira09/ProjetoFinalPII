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
    public partial class VincularGrupoDocente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregaGrupo();
                CarregaDocente();
            }
                
        }

        private void CarregaGrupo()
        {
            MODGrupo grupo = new MODGrupo();

            TxtGrupo.DataSource = BLLGrupo.PesquisarGrupos(grupo, "todos");
            TxtGrupo.DataValueField = "IdGrupo";
            TxtGrupo.DataTextField = "Nome";
            TxtGrupo.DataBind();
        }

        private void CarregaDocente()
        {
            MODDocente docente = new MODDocente();

            TxtDocente.DataSource = BLLDocente.Pesquisar(docente, "todos");
            TxtDocente.DataValueField = "IdDocente";
            TxtDocente.DataTextField = "Nome";
            TxtDocente.DataBind();
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MODGrupoDocente grupoDocente = new MODGrupoDocente();

            if (TxtData.Text.Trim() == "" || TxtData.Text.Length > 50)
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else
            {
                try
                {
                    grupoDocente.FkDocente = Convert.ToInt32(TxtDocente.SelectedValue);
                    grupoDocente.FkGrupo = Convert.ToInt32(TxtGrupo.SelectedValue);
                    grupoDocente.DataEntrada = Convert.ToDateTime(TxtData.Text.Trim());

                    BLLGrupo_Docente.InserirDocente(grupoDocente);

                    LblResposta.Text = "Docente vinculado com sucesso!";

                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Erro ao inserir!');</script>");
                    throw;
                }
            }
        }
    }
}