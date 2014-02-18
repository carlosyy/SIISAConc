<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="SIISAConc.error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Upss!</title>

    <style type="text/css">
        .error {
            font-size: 28px;
            color: black;
            font-weight: bold;
            width: 550px;
            text-align: center;
            padding-bottom: 0px;
            border-bottom-width: 1px;
            /*border-bottom-style: solid;*/
            border-bottom-color: #C40018;
            padding-top: 30px;
            padding-right: 0px;
            padding-left: 0px;
            height: 70px;
            margin-top: 0px;
            margin-right: auto;
            margin-bottom: 0px;
            margin-left: auto;
        }

        .bodyError {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            color: #333333;
            /*background-color: #C0C0C0;*/
            /*background-image:url(.../img/bgBody404.jpg);*/
            background-image: url(Images/body-bgError.jpg);
            background-repeat: repeat-x;
            background-position: center top;
            background-attachment: scroll;
            margin: 0px;
            padding: 0px;
        }

        #wrap {
            width: 400px;
            text-align: center;
            top: 50%;
            overflow: hidden;
            position: absolute;
            height: 200px;
            left: 50%;
            margin-top: -50px;
            margin-left: -200px;
        }

        #image {
            width: 400px;
            text-align: center;
            top: 50%;
            overflow: hidden;
            position: absolute;
            height: 300px;
            left: 50%;
            margin-top: -300px;
            margin-left: -200px;
        }

        div.fila {
            clear: both;
        }

        div.col {
            float: left;
            padding: 5px;
            border-color: #F0E0A0;
            border-style: solid;
            border-right-width: 0px;
            border-left-width: 0px;
            border-top-width: 0px;
            border-bottom-width: 1px;
            width: auto;
        }

        .footerD {
            width: 100%;
            height: auto;
            position: fixed; /* Fija el contenedor a una posición */
            bottom: 0px; /* El div se sitúa abajo */
            z-index: -88; /* Lo muestra por encima de otros div */
            clear: none;
            overflow: auto;
        }
    </style>
</head>
<body class="bodyError">
    <form id="form1" runat="server">
        <div id="image">
            <img src="Images/errorpage/Under-construction.png" />
        </div>
        <div id="wrap">
            <asp:Label CssClass="error" runat="server" ID="lblError" Text="¡Upss! Pasaron cosas."></asp:Label><br />
            <a href="default.aspx">Ve al inicio</a>
        </div>
        <div style="padding: 70px 0 0 0px; height: 100%; width: 350px; margin: auto; position: relative; top: 100px;">
            <div class="footerD">
                <div class="fila">
                    <div class="col"><a>©2013 Inversiones JCJM |</a></div>
                    <div class="col"><a>Términos |</a></div>
                    <div class="col"><a>Privacidad y cookie |</a></div>
                    <div class="col"><a>Comentarios |</a></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
