<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dados.aspx.cs" Inherits="Teste.dados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Produtos associados</title>
    <link rel="stylesheet" type="text/css" href="visual/dados.css" />
    <link rel="stylesheet" type="text/css" href="visual/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="visual/bootstrap.min.css" />
    <script src="scripts/jquery-1.10.2.min.js"></script>
    <script src="scripts/bootstrap.js"></script>
    <script src="scripts/bootstrap-min.js"></script>
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a id="ahome" class="navbar-brand" href="index.aspx?action=logout">Sair</a>
            </div>
        </div>
    </div>
    <form id="form2" runat="server">
        <div>
            <div style="text-align: center; width: 90%; margin: auto; margin-top: 70px; min-width:400px; border-radius: 4px">
                <span>
                    <asp:Button ID="Button1" OnClick="Export" Style="outline:none; float: right; background-color: lightcyan; position: absolute; left: 10%; top: 200px" runat="server" CssClass="btn btn-default" Text="Exportar" />
                </span>
                <span>
                    <img class="img-thumbnail" id="imagemProd" alt="imagem do produto" style="width: 150px; height: 150px; margin: 10px" src="Recurso/palete.png" />
                </span>
            </div>
            <div class="container" style="margin-top: 0px">
                <%=tabela %>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        var allRadios = document.getElementsByName('radio');
        var booRadio;
        var x = 0;
        var tah = document.getElementById("imagemProd");
        for (x = 0; x < allRadios.length; x++) {
            allRadios[x].onclick = function () {
                if (booRadio == this) {
                    this.checked = false;
                    booRadio = null;
                    tah.src = "Recurso/palete.png";
                } else {
                    booRadio = this;
                    var img = this.value;
                    if (img != "/") {
                        if (img[img.length - 1] == "/") {
                            img = img.substring(0, img.length - 1);
                        }
                        tah.src = "" + img;
                    }
                    else {
                        tah.src = "Recurso/sem.jpg";
                    }
                }
            };
        }

        function exit() {
            document.location = "index.aspx?action=logout";
        }
    </script>
</body>
</html>
