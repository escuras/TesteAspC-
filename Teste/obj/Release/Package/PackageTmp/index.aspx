<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Teste.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teste de C#</title>
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
                <a class="navbar-brand" id="ahome" runat="server" href="#">Login</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li><a href="outros.aspx?v=sobre">Sobre</a></li>
                    <li><a href="outros.aspx?v=contactos">Contatos</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container"  style="margin-top:100px">
        <div class="login-container">
            <div id="output"></div>
            <div class="avatar">
                <img id="foguetao" src="Recurso/avatar.png" style="width: 100px; height: 100px; visibility: visible" class=" img img-circle" />
            </div>
            <div class="form-box">
                <form id="form1" runat="server">
                    <div>
                        <asp:TextBox Style="text-align: center" name="user" ID="Username_" placeholder="username" runat="server"></asp:TextBox>
                        <asp:TextBox Style="text-align: center" type="password" ID="Password_" placeholder="password" runat="server"></asp:TextBox>
                    </div>
                    <div style="margin-top: 20px;">
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                            <asp:Label Style="margin: auto; color: red; width: 100%" ID="LabelError" runat="server" Text="Login inválido" Visible="false"></asp:Label>
                        </asp:PlaceHolder>
                    </div>
                    <div  style="margin-top: 10px;">
                        <asp:Button ID="btlogin" Style="background-color: lightcyan;color:black; margin-top: 50px; margin:auto; cursor: pointer; max-width: 100px" class="btn btn-info btn-block login" OnClick="Make_Login" runat="server" Text="Login" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
