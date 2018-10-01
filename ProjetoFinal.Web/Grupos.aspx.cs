﻿using System;
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
    public partial class Grupos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MODGrupoLider grupoLider = new MODGrupoLider();
            MODGrupo grupo = new MODGrupo();

            if (!IsPostBack)
            {
                grupo.Sigla = Page.Request.QueryString["sigla"];
                grupo = BLLGrupo.PesquisarGrupo(grupo, "sigla");
                grupoLider.FkGrupo = grupo.IdGrupo;

                this.Title = grupo.Sigla + " - " + grupo.Nome + " - " + "SG Manager";

                RptConsulta.DataSource = BLLGrupo.Pesquisar(grupoLider, "grupo");
                RptConsulta.DataBind();
            }
        }
    }
}