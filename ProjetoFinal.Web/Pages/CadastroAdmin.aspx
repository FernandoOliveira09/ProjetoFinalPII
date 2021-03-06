﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroAdmin.aspx.cs" Inherits="ProjetoFinal.Web.Pages.CadastroAdmin" %>

<html>

<head>
  <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
  <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/css/materialize.min.css">
  <style>
    body {
      display: flex;
      min-height: 100vh;
      flex-direction: column;
    }

    main {
      flex: 1 0 auto;
    }

    body {
      background: #fff;
    }

    .input-field input[type=date]:focus + label,
    .input-field input[type=text]:focus + label,
    .input-field input[type=email]:focus + label,
    .input-field input[type=password]:focus + label {
      color: #1976d2;
    }

    .input-field input[type=date]:focus,
    .input-field input[type=text]:focus,
    .input-field input[type=email]:focus,
    .input-field input[type=password]:focus {
      border-bottom: 2px solid #1976d2;
      box-shadow: none;
    }
      
    .cadastro
    {
        margin-top: -4px;    
    }
  </style>
</head>

<body class="blue darken-4">
  <div class="section"></div>
  <main>
    <center>
      <h2 style="color: #fff" class="cadastro"><span style="font-weight: bolder">SG</span> Manager</h2>

      <h6 class="white-text cadastro">Detectamos que não há nenhum Admin ativo em nosso sistema. <br/>Por favor, insira os seus dados abaixo:</h6>
      <div class="section"></div>

      <div class="container">
        <div class="z-depth-1 grey lighten-4 row" style="display: inline-block; padding: 32px 48px 0px 48px; border: 1px solid #EEE; width: 500px">

          <form class="col s12" method="post" runat="server">
            <div class='row'>
              <div class='col s12'>
              </div>
            </div>

            <div class='row'>
              <div class='input-field col s12 cadastro'>
                
                <asp:TextBox type='text' name='login' id='TxtLogin' value="" runat="server"/>
                <label for='login'>Username<span style="color: red;">*</span></label>
              </div>
            </div>
            
            <div class='row'>
              <div class='input-field col s12 cadastro'>
                
                <asp:TextBox type='text' name='nome' id='TxtNome' value="" runat="server"/>
                <label for='nome'>Nome<span style="color: red;">*</span></label>
              </div>
            </div>

            <div class='row'>
              <div class='input-field col s12 cadastro'>
                
                <asp:TextBox type='email' name='email' id='TxtEmail' value="" runat="server"/>
                <label for='email'>Email<span style="color: red;">*</span></label>
              </div>
            </div>
           
            <div class='row'>
              <div class='input-field col s12 cadastro'>
                <asp:TextBox class='validate' type='password' name='password' id='TxtSenha' runat="server"/>
                <label for='password'>Senha<span style="color: red;">*</span></label>
              </div>
                <asp:Label ID="LblResposta" runat="server" ForeColor="Red"></asp:Label>
            </div>

            <center>
              <div class='row' align="center">
                <asp:LinkButton type='submit' class='col s12 btn btn-large waves-effect blue darken-4' runat="server" Text="Cadastrar" OnClick="BtnCadastrar_Click"></asp:LinkButton>
              </div>
            </center>
          </form>
        </div>
      </div>
    </center>

  </main>

  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.1/jquery.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/js/materialize.min.js"></script>
</body>

</html>
