﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjetoFinal.Web.Pages.Login" %>
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
  </style>
</head>

<body class="blue darken-4">
  <div class="section"></div>
  <main>
    <center>
      <h2 style="color: #fff"><span style="font-weight: bolder">SG</span> Manager</h2>

      <h5 class="white-text">Por favor, faça login na sua conta</h5>
      <div class="section"></div>

      <div class="container">
        <div class="z-depth-1 grey lighten-4 row" style="display: inline-block; padding: 32px 48px 0px 48px; border: 1px solid #EEE;">

          <form class="col s12" method="post" runat="server">
            <div class='row'>
              <div class='col s12'>
              </div>
            </div>

            <div class='row'>
              <div class='input-field col s12'>
                <asp:Textbox type='text' name='login' id='TxtLogin' runat="server"/>
                <label for='email'>Login Administrativo ou Prontuário</label>
              </div>
            </div>

            <div class='row'>
              <div class='input-field col s12 '>
                <asp:Textbox class='validate' type='password' id='TxtSenha' runat="server"/>
                <label for='password'>Senha</label>
              </div>
              <label style='float: right;'>
			    <a class='blue-text' href='../Pages/RecuperacaoSenha.aspx'><b>Esqueceu sua senha?</b></a>
			  </label>
            </div>

            <br />
            <center>
              <div class='row'>
                <asp:LinkButton type='submit' name='btn_login' class='col s12 btn-large waves-effect blue darken-4' Text="Logar" runat="server" OnClick="BtnLogar_Click"></asp:LinkButton>
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