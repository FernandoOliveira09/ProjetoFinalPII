<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Projetos.aspx.cs" Inherits="ProjetoFinal.Web.Projetos" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width,
    initial-scale=1.0">
    <title>SG Manager</title>
    <link href="../Content/css/materialize.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script src="../Content/js/materialize.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Inconsolata" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">

</head>

<body style="display: flex; min-height: 100vh; flex-direction: column;">
    <nav>
        <div class="nav-wrapper teal">
            <div class="container">
                <a href="Default.aspx" class="brand-logo">SG Manager</a>
                 <ul id="nav-mobile" class="right hide-on-med-and-down">
                    <li><a href="../Pages/Login.aspx">Login</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="container">
        <div class="row">
            <div class="col s12 container">
                <asp:Repeater ID="RptConsulta" runat="server">
                     <ItemTemplate>
                         <h3 style="text-align: center; margin-top: 40px;"><%# Eval("Titulo") %></h3>
                         <hr />
                         <div class="row">
                             <div class="col-md-4" style="margin-left: 25%">
                                <p>Grupo: <%# Eval("Grupo") %></p>
                                <p>Orientador: <%# Eval("Docente") %></p>
                                <p>Orientado: <%# Eval("Discente") %></p>
                                <p>Data de início: <%# Eval("Data", "{0:d}") %></p>        
                             </div>
                         </div>
                         <div class="row">
                             <div class="col-md-4" >
                                 
                             </div>
                         </div>
                     </ItemTemplate>
                 </asp:Repeater>
            </div>
            <div class="col s12 container">
                <h5 style="text-align: center; margin-top: 40px;">Publicações</h5>
                <asp:Repeater ID="RPTPublicacao" runat="server">
                     <ItemTemplate>
                         <hr />
                         <div class="row">
                             <div class="col-md-4" style="margin-left: 25%">
                                <p>Título: <%# Eval("Titulo") %></p>
                                <p>Linha de Pesquisa: <%# Eval("Linha") %></p>
                                <p>Tipo de publicação: <%# Eval("Tipo") %></p>
                                <p>Data: <%# Eval("Data", "{0:d}") %></p>
                             </div>
                         </div>
                         <div class="row">
                             <div class="col-md-4" >
                                 
                             </div>
                         </div>
                     </ItemTemplate>
                 </asp:Repeater>
            </div>
        </div>
        <hr />
    </div>

    <footer class="page-footer teal" style="bottom: 0; position: fixed; width: 100%">

        <div class="footer-copyright">
            <div class="container">
                © 2018 Copyright Fernando, Reginaldo, Eduardo
                <a class="grey-text text-lighten-4 right" href="Default.aspx">Home</a>
            </div>
        </div>
    </footer>

    <script src="~/Scripts/jquery-2.1.1.min.js"></script>

</body>

</html>
