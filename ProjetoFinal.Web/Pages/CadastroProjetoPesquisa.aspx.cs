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
        public static int idDocente, idGrupo, idProjeto;
        public static string grupoNome;
        public static string idLinha;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Session.RemoveAll();
                Response.Redirect("../Pages/Login.aspx");
            }

            MODUsuario usuario = new MODUsuario();

            usuario.Login = PegaLogin.RetornaLogin();
            usuario = BLLUsuario.PesquisarLogin(usuario);

            ImagemUser.ImageUrl = "../Pages/" + usuario.Imagem;
            ImagemUser2.ImageUrl = "../Pages/" + usuario.Imagem;
            LblNome.Text = usuario.Nome;

            if (usuario.FkTipo == 1)
                LblFuncao.Text = "Administrador";
            else
                LblFuncao.Text = "Lider de Pesquisa";

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
            {
                TxtTipoBolsa.Enabled = true;
            }
            else
            {
                TxtTipoBolsa.Enabled = false;
                TxtNomeBolsa.Enabled = false;
            }            
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
            MODProjetoPesquisa_Linha projetoLinha = new MODProjetoPesquisa_Linha();
            MODLinha_Pesquisa linhaPesquisa = new MODLinha_Pesquisa();

            bool existeLinha = false;

            if (TxtNome.Text.Trim() == "")
            {
                LblResposta.Text = Erros.TituloVazio;
            }
            else if (TxtDataInicio.Text.Trim() == "")
            {
                LblResposta.Text = Erros.DataVazio;
            }
            else if (TxtDocenteLider.Text.Trim() == "")
            {
                LblLiderExiste.Text = "Não há lider vínculado nesse grupo!";
            }
            else
            {
                foreach (RepeaterItem dli in RptLinhas.Items)
                {
                    if (dli.ItemType == ListItemType.Item || dli.ItemType == ListItemType.AlternatingItem)
                    {
                        DropDownList ddl = (DropDownList)dli.FindControl("DdlAddLinha");
                        if (ddl.Text == "Sim")
                        {
                            existeLinha = true;
                        }
                    }
                }

                if(existeLinha == false)
                {
                    LblResposta.Text = "O Projeto deve ter pelo menos uma linha de pesquisa!";
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

                    idProjeto = BLLProjeto_Pesquisa.Inserir(projetoPesquisa);
                }               
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
                        linhaPesquisa.Linha = titulo;

                        linhaPesquisa = BLLLinha_Pesquisa.PesquisarLinha(linhaPesquisa, "nome");

                        projetoLinha.FkLinha = linhaPesquisa.Id;
                        projetoLinha.FkProjeto = idProjeto;

                        BLLProjeto_Pesquisa.InserirLinha(projetoLinha);
                        LblResposta.Text = "Projeto cadastrado com sucesso!";
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
            MODDocente_Linha_Pesquisa docenteLinha = new MODDocente_Linha_Pesquisa();
            MODGrupo grupo = new MODGrupo();
            MODDocente docente = new MODDocente();

            grupo.Nome = grupoNome;
            grupo = BLLGrupo.PesquisarGrupo(grupo, "nome");

            docenteLinha.FkGrupo = grupo.IdGrupo;
            idGrupo = grupo.IdGrupo;

            docenteLinha.FkDocente = Convert.ToInt32(TxtDocenteLider.SelectedValue);

            RptLinhas.DataSource = BLLDocente_Linha_Pesquisa.Pesquisar(docenteLinha, "docente");
            RptLinhas.DataBind();

            if (BLLDocente_Linha_Pesquisa.Pesquisar(docenteLinha, "docente").Rows.Count == 0)
            {
                LblLiderExiste.Text = "Não há linhas vínculadas a esse lider!";
            }
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

            if (TxtDocenteLider.Text.Trim() == "")
            {
                LblLiderExiste.Text = "Não há lider vínculado nesse grupo!";
            }

            docenteLinha.FkDocente = Convert.ToInt32(TxtDocenteLider.SelectedValue);

            RptLinhas.DataSource = BLLDocente_Linha_Pesquisa.Pesquisar(docenteLinha, "docente");
            RptLinhas.DataBind();

            if (BLLDocente_Linha_Pesquisa.Pesquisar(docenteLinha, "docente").Rows.Count == 0)
            {
                LblLiderExiste.Text = "Não há linhas vínculadas a esse lider!";
            }
        }
    }
}