<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grupos.aspx.cs" Inherits="ProjetoFinal.Web.Grupos" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width,
    initial-scale=1.0">
    <title>Home - SG Manager</title>
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
                         <h3 style="text-align: center; margin-top: 40px;"><%# Eval("Nome") %> - <%# Eval("Sigla") %></h3>
                         <hr />
                         <div class="row">
                             <div style="float: left">
                                 <asp:Image ID="Image1" style="float:left; margin-left: 20%; margin-top: 10px" ImageUrl=<%# string.Format("../Pages/{0}", Eval("Logotipo"))%> alt="" Width="175" Height="175" class="circle responsive-img valign profile-image cyan" runat="server"/>
                             </div>
                             <div class="col-md-4" style="margin-left: 25%">
                                <p>Lider do grupo: <%# Eval("Lider") %></p>
                                <p>Situação: <%# Eval("Situacao") %></p>
                                <p>Data de início: <%# Eval("Data") %></p>    
                                <p>Link no lattes: <a href="<%# Eval("Lattes") %>" target="_blank"><%# Eval("Lattes") %></a></p>
                                <p>Descrição: <%# Eval("Texto_Descricao") %></p>    
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
