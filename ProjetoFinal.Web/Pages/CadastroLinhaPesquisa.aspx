<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroLinhaPesquisa.aspx.cs" Inherits="ProjetoFinal.Web.Pages.CadastroLinhaPesquisa" %>

<!DOCTYPE html>
<html lang="pt-br">
<!--================================================================================
	Item Name: Materialize - Material Design Admin Template
	Version: 4.0
	Author: PIXINVENT
	Author URL: https://themeforest.net/user/pixinvent/portfolio
  ================================================================================ -->
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="msapplication-tap-highlight" content="no">
    <meta name="description" content="Materialize is a Material Design Admin Template,It's modern, responsive and based on Material Design by Google. ">
    <meta name="keywords" content="materialize, admin template, dashboard template, flat admin template, responsive admin template,">
    <title>Admin | SG Manager</title>
    <!-- Favicons-->
    <link rel="icon" href="../Content/images/favicon/favicon-32x32.png" sizes="32x32">
    <!-- Favicons-->
    <link rel="apple-touch-icon-precomposed" href="../Content/images/favicon/apple-touch-icon-152x152.png">
    <!-- For iPhone -->
    <meta name="msapplication-TileColor" content="#00bcd4">
    <meta name="msapplication-TileImage" content="../Content/images/favicon/mstile-144x144.png">
    <!-- For Windows Phone -->
    <!-- CORE CSS-->
    <link href="../Content/css//materialize.css" type="text/css" rel="stylesheet">
    <link href="../Content/css//style.css" type="text/css" rel="stylesheet">
    <!-- Custome CSS-->
    <link href="../Content/css/custom/custom.css" type="text/css" rel="stylesheet">
    <!-- INCLUDED PLUGIN CSS ON THIS PAGE -->
    <link href="../Content/vendors/perfect-scrollbar/perfect-scrollbar.css" type="text/css" rel="stylesheet">
    <link href="../Content/vendors/flag-icon/css/flag-icon.min.css" type="text/css" rel="stylesheet">
</head>
<body>
    <!-- Start Page Loading -->
    <div id="loader-wrapper">
        <div id="loader"></div>
        <div class="loader-section section-left"></div>
        <div class="loader-section section-right"></div>
    </div>
    <!-- End Page Loading -->
    <!-- //////////////////////////////////////////////////////////////////////////// -->
    <!-- START HEADER -->
    <header id="header" class="page-topbar">
        <!-- start header nav-->
        <div class="navbar-fixed">
            <nav class="navbar-color blue darken-4">
                <div class="nav-wrapper">
                    <ul class="left">
                        <li>
                            <h1 class="logo-wrapper">
                                <a href="../Pages/Principal.aspx" class="brand-logo darken-1">
                                    <img src="../Content/images/logo/materialize-logo.png" alt="materialize logo">
                                    <span class="logo-text hide-on-med-and-down"><strong>SG</strong> Manager</span>
                                </a>
                            </h1>
                        </li>
                    </ul>
                    <ul class="right hide-on-med-and-down">
                        <li>
                            <a href="javascript:void(0);" class="waves-effect waves-block waves-light toggle-fullscreen">
                                <i class="material-icons">settings_overscan</i>
                            </a>
                        </li>
                        <li>
                        <li>
                            <a href="javascript:void(0);" class="waves-effect waves-block waves-light profile-button" data-activates="profile-dropdown">
                                <span class="avatar-status avatar-online">
                                    <asp:Image ID="ImagemUser2" ImageUrl="../Pages/Imagens/usuario.png" alt="" class="circle responsive-img valign profile-image cyan" runat="server" />
                                    <i></i>
                                </span>
                            </a>
                        </li>
                    </ul>
                    <!-- translation-button -->
                    <!-- profile-dropdown -->
                    <ul id="profile-dropdown" class="dropdown-content">
                        <li>
                            <a href="../Pages/AlteracaoUsuario.aspx" class="grey-text text-darken-1">
                                <i class="material-icons">settings</i> Alterar Informações</a>
                        </li>
                        <li class="divider"></li>
                        <li>
                            <a href="../Pages/Login.aspx?logout=logout" class="grey-text text-darken-1">
                                <i class="material-icons">keyboard_tab</i> Logout</a>
                        </li>
                    </ul>
                </div>
            </nav>
        </div>
        <!-- end header nav-->
    </header>
    <!-- END HEADER -->
    <!-- //////////////////////////////////////////////////////////////////////////// -->
    <!-- START MAIN -->
    <div id="main">
        <!-- START WRAPPER -->
        <div class="wrapper">
            <!-- START LEFT SIDEBAR NAV-->
            <aside id="left-sidebar-nav">
                <ul id="slide-out" class="side-nav fixed leftside-navigation">
                    <li class="user-details cyan darken-2">
                        <div class="row">
                            <div class="col col s4 m4 l4">
                                <asp:Image ID="ImagemUser" ImageUrl="../Pages/Imagens/usuario.png" alt="" class="circle responsive-img valign profile-image cyan" runat="server" />
                                <!--<asp:Image src="../Content/images/avatar/avatar-7.png" alt="" class="circle responsive-img valign profile-image cyan" runat="server"/>-->
                                <!--<img src="../Content/images/avatar/avatar-7.png" alt="" class="circle responsive-img valign profile-image cyan">-->
                            </div>
                            <div class="col col s8 m8 l8">

                                <a class="btn-flat waves-light white-text profile-btn" href="#" data-activates="profile-dropdown-nav">
                                    <asp:Label ID="LblNome" runat="server">Usuário</asp:Label>
                                    <i class="mdi-navigation-arrow-drop-down right"></i></a>
                                <p class="user-roal">
                                    <asp:Label ID="LblFuncao" runat="server">Função</asp:Label>
                                </p>
                            </div>
                        </div>
                    </li>
                    <li class="no-padding">
                        <ul class="collapsible" data-collapsible="accordion">
                            <li class="bold">
                                <a href="Principal.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">pie_chart_outlined</i>
                                    <span class="nav-text">Dashboard</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="ConsultaUsuario.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">group</i>
                                    <span class="nav-text">Usuários</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="ConsultaGrupo.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">group_work</i>
                                    <span class="nav-text">Grupos de Pesquisa</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="../Pages/ConsultaDocente.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">group</i>
                                    <span class="nav-text">Docentes</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="../Pages/ConsultaDiscente.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">group</i>
                                    <span class="nav-text">Discentes</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="../Pages/ConsultaTecnico.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">group</i>
                                    <span class="nav-text">Técnicos</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="../Pages/ConsultaEquipamento.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">settings</i>
                                    <span class="nav-text">Equipamentos</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="../Pages/ConsultaProjetoPesquisa.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">work</i>
                                    <span class="nav-text">Projetos de pesquisa</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="../Pages/ConsultaPublicacao.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">title</i>
                                    <span class="nav-text">Publicações</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="../Pages/SelecionarRelatorio.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">insert_drive_file</i>
                                    <span class="nav-text">Relatórios</span>
                                </a>
                            </li>
                            <li class="bold">
                                <a href="../Pages/ConsultaReuniao.aspx" class="waves-effect waves-cyan">
                                    <i class="material-icons">textsms</i>
                                    <span class="nav-text">Reuniões</span>
                                </a>
                            </li>
                            <li>
                                <a class="collapsible-header">Linhas de pesquisa<i class="material-icons">search</i></a>
                                <div class="collapsible-body">
                                    <ul>
                                        <li><a href="../Pages/ConsultaAreaConhecimento.aspx">Áreas do conhecimento</a></li>
                                        <li><a href="../Pages/ConsultaAreaAvaliacao.aspx">Áreas de avaliação</a></li>
                                        <li><a href="../Pages/ConsultaSubAreaAvaliacao.aspx">Sub áreas de avaliação</a></li>
                                        <li><a href="../Pages/ConsultaLinhaPesquisa.aspx">Linhas de pesquisa</a></li>
                                    </ul>
                                </div>
                            </li>
                        </ul>
                    </li>
                </ul>
                <a href="#" data-activates="slide-out" class="sidebar-collapse btn-floating btn-medium waves-effect waves-light hide-on-large-only">
                    <i class="material-icons">menu</i>
                </a>
            </aside>
            <!-- END LEFT SIDEBAR NAV-->
            <!-- //////////////////////////////////////////////////////////////////////////// -->
            <!-- START CONTENT -->
            <section id="content">
                <!--start container-->
                <section id="content">
                    <!--start container-->
                    <div id="breadcrumbs-wrapper">
                        <!-- Search for small screen -->
                        <div class="header-search-wrapper grey lighten-2 hide-on-large-only">
                            <input type="text" name="Search" class="header-search-input z-depth-2" placeholder="Explore Materialize">
                        </div>
                        <div class="container">
                            <div class="row">
                                <div class="col s10 m6 l6">
                                    <h5 class="breadcrumbs-title">Cadastro de linha de pesquisa</h5>
                                    <ol class="breadcrumbs">
                                        <li><a href="../Pages/Principal.aspx">Dashboard</a></li>
                                        <li><a href="#">Linhas de pesquisa</a></li>
                                        <li><a href="#">Cadastro de linha de pesquisa</a></li>
                                    </ol>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="basic-form" class="section">
                        <div class="row">
                            <div class="col s12 m12 l8">
                                <div class="card-panel">
                                    <h4 class="header2">Insira os dados nos campos abaixo para cadastrar</h4>
                                    <div class="row">
                                        <form class="col s12" runat="server">

                                            <div class="row">
                                                <div class="input-field col s10">
                                                    <label for="TxtAreaConhecimento">Selecione a área de conhecimento<span style="color: red;">*</span></label>
                                                    <br />
                                                    <asp:DropDownList class="input-field" runat="server" ID="TxtAreaConhecimento" AutoPostBack="true" OnSelectedIndexChanged="TxtAreaConhecimento_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="input-field col s1" style="float: left; margin-top: 60px">
                                                    <a class="btn-floating btn-small waves-effect waves-light teal lighten-2" href="../Pages/CadastroAreaConhecimento.aspx"><i class="material-icons left">add</i></a>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="input-field col s8">
                                                    <label for="TxtAreaAvaliacao">Selecione a área de avaliação<span style="color: red;">*</span></label>
                                                    <br />
                                                    <asp:DropDownList class="input-field" runat="server" ID="TxtAreaAvaliacao" AutoPostBack="true" OnSelectedIndexChanged="TxtAreaAvaliacao_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:Label ID="LblAreaAvaliacao" runat="server" ForeColor="Red"></asp:Label>
                                                </div>
                                                <div class="input-field col s2" style="float: left; margin-top: 60px">
                                                    <a class="btn-floating btn-small waves-effect waves-light teal lighten-2" href="../Pages/CadastroAreaAvaliacao.aspx"><i class="material-icons left">add</i></a>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="input-field col s8" style="float: left">
                                                    <label for="TxtLider">Selecione a sub área de avaliação<span style="color: red;">*</span></label>
                                                    <br />
                                                    <asp:DropDownList class="input-field" runat="server" ID="TxtSubAreaAvaliacao">
                                                    </asp:DropDownList>
                                                    <%--<a class="waves-effect waves-light btn"><i class="material-icons left">cloud</i></a>--%>
                                                    <asp:Label ID="LblSubArea" runat="server" ForeColor="Red"></asp:Label>
                                                </div>
                                                <div class="input-field col s2" style="float: left; margin-top: 60px">
                                                    <a class="btn-floating btn-small waves-effect waves-light teal lighten-2" href="../Pages/CadastroSubAreaAvaliacao.aspx"><i class="material-icons left">add</i></a>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="input-field col s6">
                                                    <asp:TextBox ID="TxtIdLinha" type="text" runat="server" MaxLength="10" />
                                                    <label for="TxtIdLinha">Código da linha <span style="color: red;">*</span></label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="input-field col s6">
                                                    <asp:TextBox ID="TxtLinhaPesquisa" type="text" runat="server" />
                                                    <label for="TxtLinhaPesquisa">Nome <span style="color: red;">*</span></label>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="input-field col s12">
                                                    <asp:Label ID="LblResposta" runat="server" ForeColor="Red"></asp:Label>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="input-field col s12">
                                                    <asp:Button ID="BtnCadastrar" class="btn waves-effect waves-light right teal lighten-2" type="submit" name="action" Text="Cadastrar" runat="server" OnClick="BtnCadastrar_Click"></asp:Button>
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--end container-->
                </section>
            </section>
            <!-- END CONTENT -->
            <!-- START RIGHT SIDEBAR NAV-->
            <aside id="right-sidebar-nav">
                <ul id="chat-out" class="side-nav rightside-navigation">
                    <li class="li-hover">
                        <div class="row">
                            <div class="col s12 border-bottom-1 mt-5">
                                <ul class="tabs">
                                    <li class="tab col s4">
                                        <a href="#activity" class="active">
                                            <span class="material-icons">graphic_eq</span>
                                        </a>
                                    </li>
                                    <li class="tab col s4">
                                        <a href="#chatapp">
                                            <span class="material-icons">face</span>
                                        </a>
                                    </li>
                                    <li class="tab col s4">
                                        <a href="#settings">
                                            <span class="material-icons">settings</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                            <div id="settings" class="col s12">
                                <h6 class="mt-5 mb-3 ml-3">GENERAL SETTINGS</h6>
                                <ul class="collection border-none">
                                    <li class="collection-item border-none">
                                        <div class="m-0">
                                            <span class="font-weight-600">Notifications</span>
                                            <div class="switch right">
                                                <label>
                                                    <input checked type="checkbox">
                                                    <span class="lever"></span>
                                                </label>
                                            </div>
                                        </div>
                                        <p>Use checkboxes when looking for yes or no answers.</p>
                                    </li>
                                    <li class="collection-item border-none">
                                        <div class="m-0">
                                            <span class="font-weight-600">Show recent activity</span>
                                            <div class="switch right">
                                                <label>
                                                    <input checked type="checkbox">
                                                    <span class="lever"></span>
                                                </label>
                                            </div>
                                        </div>
                                        <p>The for attribute is necessary to bind our custom checkbox with the input.</p>
                                    </li>
                                    <li class="collection-item border-none">
                                        <div class="m-0">
                                            <span class="font-weight-600">Notifications</span>
                                            <div class="switch right">
                                                <label>
                                                    <input type="checkbox">
                                                    <span class="lever"></span>
                                                </label>
                                            </div>
                                        </div>
                                        <p>Use checkboxes when looking for yes or no answers.</p>
                                    </li>
                                    <li class="collection-item border-none">
                                        <div class="m-0">
                                            <span class="font-weight-600">Show recent activity</span>
                                            <div class="switch right">
                                                <label>
                                                    <input type="checkbox">
                                                    <span class="lever"></span>
                                                </label>
                                            </div>
                                        </div>
                                        <p>The for attribute is necessary to bind our custom checkbox with the input.</p>
                                    </li>
                                    <li class="collection-item border-none">
                                        <div class="m-0">
                                            <span class="font-weight-600">Show your emails</span>
                                            <div class="switch right">
                                                <label>
                                                    <input type="checkbox">
                                                    <span class="lever"></span>
                                                </label>
                                            </div>
                                        </div>
                                        <p>Use checkboxes when looking for yes or no answers.</p>
                                    </li>
                                    <li class="collection-item border-none">
                                        <div class="m-0">
                                            <span class="font-weight-600">Show Task statistics</span>
                                            <div class="switch right">
                                                <label>
                                                    <input type="checkbox">
                                                    <span class="lever"></span>
                                                </label>
                                            </div>
                                        </div>
                                        <p>The for attribute is necessary to bind our custom checkbox with the input.</p>
                                    </li>
                                </ul>
                            </div>
                            <div id="chatapp" class="col s12">
                                <div class="collection border-none">
                                    <a href="#!" class="collection-item avatar border-none">
                                        <img src="../Content/images/avatar/avatar-1.png" alt="" class="circle cyan">
                                        <span class="line-height-0">Elizabeth Elliott </span>
                                        <span class="medium-small right blue-grey-text text-lighten-3">5.00 AM</span>
                                        <p class="medium-small blue-grey-text text-lighten-3">Thank you </p>
                                    </a>
                                    <a href="#!" class="collection-item avatar border-none">
                                        <img src="../Content/images/avatar/avatar-2.png" alt="" class="circle deep-orange accent-2">
                                        <span class="line-height-0">Mary Adams </span>
                                        <span class="medium-small right blue-grey-text text-lighten-3">4.14 AM</span>
                                        <p class="medium-small blue-grey-text text-lighten-3">Hello Boo </p>
                                    </a>
                                    <a href="#!" class="collection-item avatar border-none">
                                        <img src="../Content/images/avatar/avatar-3.png" alt="" class="circle teal accent-4">
                                        <span class="line-height-0">Caleb Richards </span>
                                        <span class="medium-small right blue-grey-text text-lighten-3">9.00 PM</span>
                                        <p class="medium-small blue-grey-text text-lighten-3">Keny ! </p>
                                    </a>
                                    <a href="#!" class="collection-item avatar border-none">
                                        <img src="../Content/images/avatar/avatar-4.png" alt="" class="circle cyan">
                                        <span class="line-height-0">June Lane </span>
                                        <span class="medium-small right blue-grey-text text-lighten-3">4.14 AM</span>
                                        <p class="medium-small blue-grey-text text-lighten-3">Ohh God </p>
                                    </a>
                                    <a href="#!" class="collection-item avatar border-none">
                                        <img src="../Content/images/avatar/avatar-5.png" alt="" class="circle red accent-2">
                                        <span class="line-height-0">Edward Fletcher </span>
                                        <span class="medium-small right blue-grey-text text-lighten-3">5.15 PM</span>
                                        <p class="medium-small blue-grey-text text-lighten-3">Love you </p>
                                    </a>
                                    <a href="#!" class="collection-item avatar border-none">
                                        <img src="../Content/images/avatar/avatar-6.png" alt="" class="circle deep-orange accent-2">
                                        <span class="line-height-0">Crystal Bates </span>
                                        <span class="medium-small right blue-grey-text text-lighten-3">8.00 AM</span>
                                        <p class="medium-small blue-grey-text text-lighten-3">Can we </p>
                                    </a>
                                    <a href="#!" class="collection-item avatar border-none">
                                        <img src="../Content/images/avatar/avatar-7.png" alt="" class="circle cyan">
                                        <span class="line-height-0">Nathan Watts </span>
                                        <span class="medium-small right blue-grey-text text-lighten-3">9.53 PM</span>
                                        <p class="medium-small blue-grey-text text-lighten-3">Great! </p>
                                    </a>
                                    <a href="#!" class="collection-item avatar border-none">
                                        <img src="../Content/images/avatar/avatar-8.png" alt="" class="circle red accent-2">
                                        <span class="line-height-0">Willard Wood </span>
                                        <span class="medium-small right blue-grey-text text-lighten-3">4.20 AM</span>
                                        <p class="medium-small blue-grey-text text-lighten-3">Do it </p>
                                    </a>
                                    <a href="#!" class="collection-item avatar border-none">
                                        <img src="../Content/images/avatar/avatar-9.png" alt="" class="circle teal accent-4">
                                        <span class="line-height-0">Ronnie Ellis </span>
                                        <span class="medium-small right blue-grey-text text-lighten-3">5.30 PM</span>
                                        <p class="medium-small blue-grey-text text-lighten-3">Got that </p>
                                    </a>
                                    <a href="#!" class="collection-item avatar border-none">
                                        <img src="../Content/images/avatar/avatar-1.png" alt="" class="circle cyan">
                                        <span class="line-height-0">Gwendolyn Wood </span>
                                        <span class="medium-small right blue-grey-text text-lighten-3">4.34 AM</span>
                                        <p class="medium-small blue-grey-text text-lighten-3">Like you </p>
                                    </a>
                                    <a href="#!" class="collection-item avatar border-none">
                                        <img src="../Content/images/avatar/avatar-2.png" alt="" class="circle red accent-2">
                                        <span class="line-height-0">Daniel Russell </span>
                                        <span class="medium-small right blue-grey-text text-lighten-3">12.00 AM</span>
                                        <p class="medium-small blue-grey-text text-lighten-3">Thank you </p>
                                    </a>
                                    <a href="#!" class="collection-item avatar border-none">
                                        <img src="../Content/images/avatar/avatar-3.png" alt="" class="circle teal accent-4">
                                        <span class="line-height-0">Sarah Graves </span>
                                        <span class="medium-small right blue-grey-text text-lighten-3">11.14 PM</span>
                                        <p class="medium-small blue-grey-text text-lighten-3">Okay you </p>
                                    </a>
                                    <a href="#!" class="collection-item avatar border-none">
                                        <img src="../Content/images/avatar/avatar-4.png" alt="" class="circle red accent-2">
                                        <span class="line-height-0">Andrew Hoffman </span>
                                        <span class="medium-small right blue-grey-text text-lighten-3">7.30 PM</span>
                                        <p class="medium-small blue-grey-text text-lighten-3">Can do </p>
                                    </a>
                                    <a href="#!" class="collection-item avatar border-none">
                                        <img src="../Content/images/avatar/avatar-5.png" alt="" class="circle cyan">
                                        <span class="line-height-0">Camila Lynch </span>
                                        <span class="medium-small right blue-grey-text text-lighten-3">2.00 PM</span>
                                        <p class="medium-small blue-grey-text text-lighten-3">Leave it </p>
                                    </a>
                                </div>
                            </div>
                            <div id="activity" class="col s12">
                                <h6 class="mt-5 mb-3 ml-3">RECENT ACTIVITY</h6>
                                <div class="activity">
                                    <div class="col s3 mt-2 center-align recent-activity-list-icon">
                                        <i class="material-icons white-text icon-bg-color deep-purple lighten-2">add_shopping_cart</i>
                                    </div>
                                    <div class="col s9 recent-activity-list-text">
                                        <a href="#" class="deep-purple-text medium-small">just now</a>
                                        <p class="mt-0 mb-2 fixed-line-height font-weight-300 medium-small">Jim Doe Purchased new equipments for zonal office.</p>
                                    </div>
                                    <div class="recent-activity-list chat-out-list row mb-0">
                                        <div class="col s3 mt-2 center-align recent-activity-list-icon">
                                            <i class="material-icons white-text icon-bg-color cyan lighten-2">airplanemode_active</i>
                                        </div>
                                        <div class="col s9 recent-activity-list-text">
                                            <a href="#" class="cyan-text medium-small">Yesterday</a>
                                            <p class="mt-0 mb-2 fixed-line-height font-weight-300 medium-small">Your Next flight for USA will be on 15th August 2015.</p>
                                        </div>
                                    </div>
                                    <div class="recent-activity-list chat-out-list row mb-0">
                                        <div class="col s3 mt-2 center-align recent-activity-list-icon medium-small">
                                            <i class="material-icons white-text icon-bg-color green lighten-2">settings_voice</i>
                                        </div>
                                        <div class="col s9 recent-activity-list-text">
                                            <a href="#" class="green-text medium-small">5 Days Ago</a>
                                            <p class="mt-0 mb-2 fixed-line-height font-weight-300 medium-small">Natalya Parker Send you a voice mail for next conference.</p>
                                        </div>
                                    </div>
                                    <div class="recent-activity-list chat-out-list row mb-0">
                                        <div class="col s3 mt-2 center-align recent-activity-list-icon">
                                            <i class="material-icons white-text icon-bg-color amber lighten-2">store</i>
                                        </div>
                                        <div class="col s9 recent-activity-list-text">
                                            <a href="#" class="amber-text medium-small">1 Week Ago</a>
                                            <p class="mt-0 mb-2 fixed-line-height font-weight-300 medium-small">Jessy Jay open a new store at S.G Road.</p>
                                        </div>
                                    </div>
                                    <div class="recent-activity-list row">
                                        <div class="col s3 mt-2 center-align recent-activity-list-icon">
                                            <i class="material-icons white-text icon-bg-color deep-orange lighten-2">settings_voice</i>
                                        </div>
                                        <div class="col s9 recent-activity-list-text">
                                            <a href="#" class="deep-orange-text medium-small">2 Week Ago</a>
                                            <p class="mt-0 mb-2 fixed-line-height font-weight-300 medium-small">voice mail for conference.</p>
                                        </div>
                                    </div>
                                    <div class="recent-activity-list chat-out-list row mb-0">
                                        <div class="col s3 mt-2 center-align recent-activity-list-icon medium-small">
                                            <i class="material-icons white-text icon-bg-color brown lighten-2">settings_voice</i>
                                        </div>
                                        <div class="col s9 recent-activity-list-text">
                                            <a href="#" class="brown-text medium-small">1 Month Ago</a>
                                            <p class="mt-0 mb-2 fixed-line-height font-weight-300 medium-small">Natalya Parker Send you a voice mail for next conference.</p>
                                        </div>
                                    </div>
                                    <div class="recent-activity-list chat-out-list row mb-0">
                                        <div class="col s3 mt-2 center-align recent-activity-list-icon">
                                            <i class="material-icons white-text icon-bg-color deep-purple lighten-2">store</i>
                                        </div>
                                        <div class="col s9 recent-activity-list-text">
                                            <a href="#" class="deep-purple-text medium-small">3 Month Ago</a>
                                            <p class="mt-0 mb-2 fixed-line-height font-weight-300 medium-small">Jessy Jay open a new store at S.G Road.</p>
                                        </div>
                                    </div>
                                    <div class="recent-activity-list row">
                                        <div class="col s3 mt-2 center-align recent-activity-list-icon">
                                            <i class="material-icons white-text icon-bg-color grey lighten-2">settings_voice</i>
                                        </div>
                                        <div class="col s9 recent-activity-list-text">
                                            <a href="#" class="grey-text medium-small">1 Year Ago</a>
                                            <p class="mt-0 mb-2 fixed-line-height font-weight-300 medium-small">voice mail for conference.</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>
                </ul>
            </aside>
            <!-- END RIGHT SIDEBAR NAV-->
        </div>
        <!-- END WRAPPER -->
    </div>
    <!-- END MAIN -->
    <!-- //////////////////////////////////////////////////////////////////////////// -->
    <!-- START FOOTER -->
    <footer class="page-footer gradient-45deg-light-blue-cyan">
        <div class="footer-copyright">
            <div class="container">
                <span>Copyright ©
              <script type="text/javascript">
                  document.write(new Date().getFullYear());
              </script>
                    <span class="right hide-on-small-only">Desenvolvido por Fernando, Reginaldo e Eduardo </span>
            </div>
        </div>
    </footer>
    <!-- END FOOTER -->
    <!-- ================================================
    Scripts
    ================================================ -->
    <!-- jQuery Library -->
    <script type="text/javascript" src="../Content/vendors/jquery-3.2.1.min.js"></script>
    <!--materialize js-->
    <script type="text/javascript" src="../Content/js/materialize.min.js"></script>
    <!--scrollbar-->
    <script type="text/javascript" src="../Content/vendors/perfect-scrollbar/perfect-scrollbar.min.js"></script>
    <!--plugins.js - Some Specific JS codes for Plugin Settings-->
    <script type="text/javascript" src="../Content/js/plugins.js"></script>
    <!--custom-script.js - Add your own theme custom JS-->
    <script type="text/javascript" src="../Content/js/custom-script.js"></script>
    <script>$('.dropdown-trigger').dropdown();</script>
</body>
</html>
