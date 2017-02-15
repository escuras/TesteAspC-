<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="outros.aspx.cs" Inherits="Teste.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Informações</title>
    <link rel="stylesheet" type="text/css" href="visual/index.css" />
    <link rel="stylesheet" type="text/css" href="visual/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="visual/bootstrap.min.css" />
    <script src="scripts/jquery-1.10.2.min.js"></script>
    <script src="scripts/bootstrap.js"></script>
    <script src="scripts/bootstrap-min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="scripts/login.js"></script>
</head>
<body style="background-color:dimgray">
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" id="aoutros" runat="server" href="index.aspx">Início</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <% String s = Request.QueryString["v"];
                        if (s == "sobre")
                        {%>
                    <li><a href="outros.aspx?v=contactos">Contatos</a></li>
                    <%}
                        else { %>
                    <li><a href="outros.aspx?v=sobre">Sobre</a></li>
                    <%    } %>
                </ul>
            </div>
        </div>
    </div>
    <div class="container"  style="margin-top:100px">
       <div class="jumbotron" style="text-align:center">
           <%       if (s == "sobre")
                        {%>
                     Realização de um projeto em Asp.Net com C#.
                    <%}
                        else { %>
                    <b>Morada: </b> Rua D. Dinis, 7 Sabugal 6320-364 <br />   
                    <b>Telefone: </b>932817291 <br /> 
                    <b>Email: </b> tozeps@gmail.com    
                    <%    } %>
       </div>
    </div>
</body>
</html>
