<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrLogin.ascx.cs" Inherits="SIISAConc.webControls.login.ctrLogin" %>
<%--<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>--%>



<style type="text/css">
    /* General Styles
----------------------------------------------------------------------------------------------------*/
    html {
        min-height: 100%;
    }

    body {
        height: 100%;
        position: relative;
        font-family: Arial, Helvetica, sans-serif;
        color: #888;
        font-size: 13px;
        line-height: 20px;
        min-width: 998px;
        border-top: 3px solid #919191;
        /*background: url(../../Images/Login/body.png) left top repeat-x;*/
        background-image: url(../../Images/body-bgError.jpg);
        background-repeat:repeat-x;

    }




    #wrapper {
        padding: 70px 0 0 0px;
        height: 100%;
        width: 350px;
        margin: auto;
        position: relative;
        top: 100px;
    }

    #wrappertop {
        background: url(../../Images/Login/wrapper_top.png) no-repeat;
        height: 22px;
    }

    #wrappermiddle {
        background: url(../../Images/Login/wrapper_middle.png) repeat-y;
        height: 240px;
    }

    #wrapperbottom {
        background: url(../../Images/Login/wrapper_bottom.png) no-repeat;
        height: 22px;
    }

    #wrapper h2 {
        margin-left: 20px;
        font-size: 20px;
        font-weight: bold;
        font-family: Myriad Pro;
        text-transform: uppercase;
        position: absolute;
        text-shadow: #fff 2px 2px 2px;
    }

    #username_input {
        margin-left: 25px;
        position: absolute;
        width: 300px;
        height: 50px;
        margin-top: 40px;
    }

    #username_inputleft {
        float: left;
        background: url(../../Images/Login/input_left.png) no-repeat;
        width: 12px;
        height: 50px;
    }

    #username_inputmiddle {
        float: left;
        background: url(../../Images/Login/input_middle.png) repeat-x;
        width: 276px;
        height: 50px;
    }

    #username_inputright {
        float: left;
        background: url(../../Images/Login/input_right.png) no-repeat;
        width: 12px;
        height: 50px;
    }

    .url {
        display: block;
        width: 276px;
        height: 45px;
        background: transparent;
        border: 0;
        color: #000000;
        font-family: helvetica, sans-serif;
        font-size: 14px;
        padding-left: 20px;
    }

    #url_user {
        position: absolute;
        display: block;
        margin-top: -28px;
        float: left;
        padding-right: 10px;
    }

    #password_input {
        margin-left: 25px;
        position: absolute;
        width: 300px;
        height: 50px;
        margin-top: 100px;
    }

    #password_inputleft {
        float: left;
        background: url(../../Images/Login/input_left.png) no-repeat;
        width: 12px;
        height: 50px;
    }

    #password_inputmiddle {
        float: left;
        background: url(../../Images/Login/input_middle.png) repeat-x;
        width: 276px;
        height: 50px;
    }

    #password_inputright {
        float: left;
        background: url(../../Images/Login/input_right.png) no-repeat;
        width: 12px;
        height: 50px;
    }

    #url_password {
        display: block;
        position: absolute;
        margin-top: -32px;
        float: left;
        margin-left: 4px;
    }

    #submit {
        float: left;
        position: relative;
        padding: 0;
        margin-top: 160px;
        margin-left: 25px;
        width: 300px;
        height: 40px;
        border: 0;
    }

    #submit1 {
        position: absolute;
        z-index: 10;
        border: 0;
    }

    #submit2 {
        position: absolute;
        margin-top: 0px;
        border: 0;
    }

    #links_left {
        float: left;
        position: relative;
        padding-top: 5px;
        margin-left: 25px;
    }

        #links_left a {
            color: #0072c6;
            font-size: 11px;
            text-decoration: none;
            transition: color 0.5s linear;
            -moz-transition: color 0.5s linear;
            -webkit-transition: color 0.5s linear;
            -o-transition: color 0.5s linear;
        }

            #links_left a:hover {
                /*color: #292929;*/
                color: #433bb0;
            }

    #links_right {
        float: right;
        position: relative;
        padding-top: 5px;
        margin-right: 25px;
    }

        #links_right a {
            color: #0072c6;
            font-size: 11px;
            text-decoration: none;
            transition: color 0.5s linear;
            -moz-transition: color 0.5s linear;
            -webkit-transition: color 0.5s linear;
            -o-transition: color 0.5s linear;
        }

            #links_right a:hover {
                /*color: #292929;*/
                color: #433bb0;
            }

    #powered {
        float: none;
        position: relative;
        padding-top: 3px;
        margin-right: 5px;
        font-size: 11px;
    }

        #powered a {
            color: #aaa;
            font-size: 11px;
            text-decoration: none;
            transition: color 0.5s linear;
            -moz-transition: color 0.5s linear;
            -webkit-transition: color 0.5s linear;
            -o-transition: color 0.5s linear;
        }

            #powered a:hover {
                color: #0072c6;
            }

    .error {
        font-size: 14px;
        color: #C40018;
    }
</style>



<script type="text/javascript">
    function ValidaCampos() {
        var x = document.getElementById("TxtPass").value;
        var y = document.getElementById("TextUsuario").value;
        if ((x == null || x == '') && (y == null || y == '')) {

            document.getElementById("LblMsg").innerText = 'Digite los campos';

        }
        else {
            if (x == null || x == '') {
                document.getElementById("LblMsg").innerText = 'La contraseña es necesaria';
            }
            else {
                if (y == null || y == '') {
                    document.getElementById("LblMsg").innerText = 'El nombre de usuario es necesario';
                }
                else {
                    var boton = document.getElementById('BtnIngresar').onclick();
                    return true;
                }
            }

        }


    }


    function saltar(e) {
        tecla = (document.all) ? e.keyCode : e.which;
        if (tecla == 13)
            ValidaCampos();
    }


</script>

<asp:Panel ID="PnlLogin" DefaultButton="BtnIngresar" runat="server">
    <div id="wrapper">
        <div id="wrappertop"></div>
        <div id="wrappermiddle">

            <h2>Inicio de sesión</h2>
            <div id="username_input">
                <div id="username_inputleft"></div>
                <div id="username_inputmiddle">
                    <asp:TextBox ID="TextUsuario" ClientIDMode="Static" CssClass="url" runat="server"></asp:TextBox>
                    <img id="url_user" src="../../Images/Login/mailicon.png" />
                </div>
                <div id="username_inputright"></div>
            </div>
            <div id="password_input">
                <div id="password_inputleft"></div>
                <div id="password_inputmiddle">
                    <asp:TextBox ID="TxtPass" ClientIDMode="Static" CssClass="url" TextMode="Password" runat="server"></asp:TextBox>
                    <img id="url_password" src="../../Images/Login/passicon.png" />
                </div>
                <div id="password_inputright"></div>
            </div>

            <div id="submit">
                <input id="BtnValidaCampos" class="button" type="button" onkeypress="13" value="INGRESAR" onclick="ValidaCampos();" />
                <asp:Button ID="BtnIngresar" clienteid="BtnIngresar" ClientIDMode="Static" CssClass="button" runat="server" Text="Ingresar" OnClick="BtnIngresar_Click" Style="display: none" />
                <br />
                <asp:Label ID="LblMsg" ClientIDMode="Static" CssClass="error" runat="server" Text=""></asp:Label>
            </div>


            <div id="links_left">
                <a href="#">¿Olvidó su contraseña?</a>
            </div>
            <div id="links_right">
                <a href="#">Requerimientos del sistema</a>

            </div>

        </div>
        <div id="wrapperbottom"></div>
        <div id="powered">
            <p>Más soluciones para el sector salud en: <a href="http://www.inversionesjcjm.com" target="_blank">Inversiones JCJM</a></p>
        </div>

       <%-- <div class="footerD">
            <div class="filaDiv">
                <div class="ColDiv"><a>©2013 Inversiones JCJM |</a></div>
                <div class="ColDiv"><a>Términos |</a></div>
                <div class="ColDiv"><a>Privacidad y cookie |</a></div>
                <div class="ColDiv"><a>Comentarios |</a></div>
            </div>
        </div>--%>
    </div>
</asp:Panel>

