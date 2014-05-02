<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrHallazgos.ascx.cs" Inherits="SIISAConc.webControls.Hallazgos.ctrHallazgos" %>
<%@ Register Src="~/webControls/areasAtencion/ctrAreasAtencion.ascx" TagPrefix="uc1" TagName="ctrAreasAtencion" %>
<%@ Register Src="~/webControls/eventosAdversos/ctrEventosAdversos.ascx" TagPrefix="uc1" TagName="ctrEventosAdversos" %>
<%@ Register Src="~/webControls/noCalidad/ctrNoCalidad.ascx" TagPrefix="uc1" TagName="ctrNoCalidad" %>
<%@ Register Src="~/webControls/inoportunidad/ctrInoportunidad.ascx" TagPrefix="uc1" TagName="ctrInoportunidad" %>
<%@ Register Src="~/webControls/pertinencia/ctrPertinencia.ascx" TagPrefix="uc1" TagName="ctrPertinencia" %>

<link rel="stylesheet" type="text/css" href="../../CSS/jquery.cleditor.css" />
<script type="text/javascript" src="../../js/jquery.cleditor.min.js"></script>

<style type="text/css">
    .modalDialogActual {
        /*position: fixed;*/
        font-family: Arial, Helvetica, sans-serif;
        top: 0;
        right: 0;
        bottom: 0;
        left: 0;
        background: rgba(0,0,0,0.8);
        z-index: 99999;
        display: none;
        -webkit-transition: opacity 400ms ease-in;
        -moz-transition: opacity 400ms ease-in;
        transition: opacity 400ms ease-in;
        pointer-events: none;
    }

        .modalDialogActual:target {
            opacity: 1;
            pointer-events: auto;
        }

        .modalDialogActual > div {
            width: 400px;
            position: relative;
            margin: 10% auto;
            padding: 5px 20px 13px 20px;
            border-radius: 10px;
            background: #fff;
            background: -moz-linear-gradient(#fff, #999);
            background: -webkit-linear-gradient(#fff, #999);
            background: -o-linear-gradient(#fff, #999);
        }

    .close {
        background: #606061;
        color: #FFFFFF;
        line-height: 25px;
        position: absolute;
        right: -12px;
        text-align: center;
        top: -10px;
        width: 24px;
        text-decoration: none;
        font-weight: bold;
        -webkit-border-radius: 12px;
        -moz-border-radius: 12px;
        border-radius: 12px;
        -moz-box-shadow: 1px 1px 3px #000;
        -webkit-box-shadow: 1px 1px 3px #000;
        box-shadow: 1px 1px 3px #000;
    }

        .close:hover {
            background: #00d9ff;
        }
</style>

<script type="text/javascript">

    var efecto = "blind";

    $(document).ready(function () {
        var optionsCleditor = {
            width: 900,// width not including margins, borders or padding
            height: 120, // height not including margins, borders or padding
            controls:     // controls to add to the toolbar
              "bold italic underline strikethrough | font size " +
              "style | color highlight removeformat | bullets numbering | outdent " +
              "indent | alignleft center alignright justify | undo redo | " +
              "image link unlink | cut copy paste | print ",
            colors:       // colors in the color popup
              "FFF FCC FC9 FF9 FFC 9F9 9FF CFF CCF FCF " +
              "CCC F66 F96 FF6 FF3 6F9 3FF 6FF 99F F9F " +
              "BBB F00 F90 FC6 FF0 3F3 6CC 3CF 66C C6C " +
              "999 C00 F60 FC3 FC0 3C0 0CC 36F 63F C3C " +
              "666 900 C60 C93 990 090 399 33F 60C 939 " +
              "333 600 930 963 660 060 366 009 339 636 " +
              "000 300 630 633 330 030 033 006 309 303",
            fonts:        // font names in the font popup
              "Arial,Arial Black,Comic Sans MS,Courier New,Narrow,Garamond," +
              "Georgia,Impact,Sans Serif,Serif,Tahoma,Trebuchet MS,Verdana",
            sizes:        // sizes in the font size popup
              "1,2,3,4,5,6,7",
            styles:       // styles in the style popup
              [["Paragraph", "<p>"], ["Header 1", "<h1>"], ["Header 2", "<h2>"],
                ["Header 3", "<h3>"], ["Header 4", "<h4>"], ["Header 5", "<h5>"],
                ["Header 6", "<h6>"]],
            useCSS: false, // use CSS to style HTML when possible (not supported in ie)
            docType:      // Document type contained within the editor
              '<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">',
            docCSSFile:   // CSS file used to style the document contained within the editor
              "",
            bodyStyle:    // style to assign to document body contained within the editor
              "margin:4px; font:10pt Arial,Verdana; cursor:text"
        };

        var clEditor = $("#txtHallazgo").cleditor(optionsCleditor)[0];



        $("#txtFecHallazgo").datepicker({ dateFormat: 'dd/mm/yy' });
        //$("#divGuardar").css("display", "none");

        hideDivs(0);

        $("#ddlTipoHallazgo").change(function () {
            $("#btnGuardarHall").css("display", "block");
            hideDivs($(this).val());
            //$("#divGuardar").css("display", "block");
            switch ($(this).val()) {
                case "0":
                    $("#divLblHallazgo").text("Hallazgo:");
                    //$("#btnGuardarHall").css("display", "none");
                    break;
                case "1":
                    $("#divLblHallazgo").text("Hallazgo por no pertinencia:");
                    $("#divArea").show(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
                    $("#divNoPertinencia").show(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
                    $("#divHallazgo").show(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
                    break;
                case "2":
                    $("#divLblHallazgo").text("Hallazgo por Inoportunidad:");
                    $("#divArea").show(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
                    $("#divInoportunidad").show(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
                    $("#divHallazgo").show(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
                    break;
                case "3":
                    $("#divLblHallazgo").text("Hallazgo por no calidad:");
                    $("#divArea").show(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
                    $("#divNoCalidad").show(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
                    $("#divHallazgo").show(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
                    break;
                case "4":
                    $("#divLblHallazgo").text("Hallazgo por evento adverso:");
                    $("#divArea").show(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
                    $("#divEventosAdversos").show(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
                    $("#divHallazgo").show(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
                    break;
            }
        });

        function limpiarControlesHall() {
            clEditor.clear();
            $("#ddlTipoHallazgo").val("0");
            $("#ddlPertinencia").val("0");
            $("#ddlInoportunidad").val("0");
            $("#ddlNoCalidad").val("0");
            $("#ddlEventosAdversos").val("0");
            $("#txtFecHallazgo").val("");
            $("#ddlTipoHallazgo").focus();
            $("#ddlAreaAtencion").val("0");
        }


        function hideDivs(tipoHide) {
            var activo = false;

            if (tipoHide == 0) {
                activo = true;
            }

            //$("#divArea").find('*').prop('disabled', activo);
            $("#divHallazgo").find('*').prop('disabled', activo);

            $("#divNoPertinencia").hide(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
            $("#divEventosAdversos").hide(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
            $("#divNoCalidad").hide(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
            $("#divInoportunidad").hide(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
        }

        function addHallazgoAtencion() {
            if (!validarHall()) {

                var params = new Object();

                var sResult = clEditor.$area.val();

                params.hallazgoAtencion = sResult;

                params.tipoHallazgo = $("#ddlTipoHallazgo").val();
                var fecHall = $("#txtFecHallazgo").val().split("/");
                params.fecHallazgo = new Date(fecHall[2], parseFloat(fecHall[1]) - 1, parseFloat(fecHall[0]));
                params.radicado = $("#hfRadicado").val();
                params.idArea = $("#ddlAreaAtencion").val();
                switch (parseInt(params.tipoHallazgo)) {
                    case 1:
                        params.idDatoHallazgo = $("#ddlPertinencia").val();
                        break;
                    case 2:
                        params.idDatoHallazgo = $("#ddlInoportunidad").val();
                        break;
                    case 3:
                        params.idDatoHallazgo = $("#ddlNoCalidad").val();
                        break;
                    case 4:
                        params.idDatoHallazgo = $("#ddlEventosAdversos").val();
                        break;
                }

                params.idUser = 3;//'< % = Session["idUser"].ToString()%> '; //TODO: Cambiar


                params = JSON.stringify(params);


                $.ajax({
                    type: "POST",
                    url: "Auditoria.aspx/AddHallazgoAtencion",
                    data: params,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    success: function (msg) {
                        $("#btnGuardarHall").notify("Se ha agregado el hallazgo satisfactoriamente.", { className: "success", position: "left bottom" });
                        getHallazgosAtencion();
                    },
                    error: function (xmlHttpRequest, textStatus, errorThrown) {
                        alert(textStatus + ": " + xmlHttpRequest.responseText);
                    }
                });
            }
        }

        function validarHall() {
            var noValido = false;

            if ($("#ddlTipoHallazgo").val() == "0") {
                $("#ddlTipoHallazgo").notify("Determine el tipo de hallazgo.");
                noValido = true;
            }
            if ($("#txtFecHallazgo").val() == "") {
                $("#txtFecHallazgo").notify("Determine la fecha del hallazgo.");
                noValido = true;
            }
            if ($("#ddlAreaAtencion").val() == "0") {
                $("#ddlAreaAtencion").notify("Determine la area de atención del hallazgo.");
                noValido = true;
            }
            var textoEditor = clEditor.$area.val();
            if (get_content(textoEditor) == "") {
                $(".cleditorMain").notify("Determine el hallazgo encontrado.");
                noValido = true;
            }
            switch (parseInt($("#ddlTipoHallazgo").val())) {
                case 1:
                    if ($("#ddlPertinencia").val() == "0") {
                        $("#ddlPertinencia").notify("Determine el tipo de pertinencia del hallazgo.");
                        noValido = true;
                    }
                    break;
                case 2:
                    if ($("#ddlInoportunidad").val() == "0") {
                        $("#ddlInoportunidad").notify("Determine el tipo de inoportunidad del hallazgo.");
                        noValido = true;
                    }
                    break;
                case 3:
                    if ($("#ddlNoCalidad").val() == "0") {
                        $("#ddlNoCalidad").notify("Determine el tipo de no calidad del hallazgo.");
                        noValido = true;
                    }
                    break;
                case 4:
                    if ($("#ddlEventosAdversos").val() == "0") {
                        $("#ddlEventosAdversos").notify("Determine el tipo de evento adverso del hallazgo.");
                        noValido = true;
                    }
                    break;
            }
            return noValido;
        }

        function get_content(texto) {
            return texto.replace(/<[^>]*>/g, "");
        }

        function getHallazgosAtencion() {
            limpiarControlesHall();
            var params = new Object();
            params.radicado = $("#hfRadicado").val();
            params = JSON.stringify(params);
            $.ajax({
                type: "POST",
                url: "Auditoria.aspx/getHallazgoAtencionxRadicado",
                data: params,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (msg) {
                    $("[id*=gvHallAtencion] tr").not($("[id*=gvHallAtencion] tr:first-child")).remove();
                    for (var i = 0; i < msg.d.length; i++) {
                        $("#gvHallAtencion").append("<tr><td>" + msg.d[i].nTipoHallazgo + "</td><td>" + msg.d[i].nArea + "</td><td>" + msg.d[i].hallazgoAtencion + "</td><td>" + msg.d[i].nPertinenciaAtencion + "</td><td>" + msg.d[i].nInoportunidadAtencion + "</td><td><img class='generarNotif' onclick='generarNotifHall(this)' style='cursor: pointer; vertical-align: middle;' src='../../Images/icons/bi/refrescar.png' width='20' height='20' id='" + msg.d[i].idhallazgoAtencion +"' /></td></tr>");
                    }
                    //$('#gvHallAtencion').height($('#gvHallAtencion').parent().height());
                },
                error: function (msg) {
                    alert("error " + msg.responseText);
                }
            });
            return false;
        }

        getHallazgosAtencion();

        $("#btnGuardarHall").click(function () {
            addHallazgoAtencion();
        });

        

        $("#btnGenerarNotifHall").click(function () {
            generarNotifHall();
        });


        $("#btnGuardarHall").keypress(function (event) {
            var keyPress = event.keyCode;
            switch (keyPress) {
                case 13:
                case 32:
                    event.preventDefault();
                    addHallazgoAtencion();
                    break;
            }
        });

        //$(".generarNotif").click(function () {
        //    $(this).closest("tr").fadeOut(10000, function () {
        //        $(this).remove();
        //    });
        //});        
    });

    function generarNotifHall(control) {
        if (confirm('Está seguro de generar una notificación con este hallazgo?.')) {
            ModalMail.style.display = 'block';
            ModalMail.style.opacity = '1';
            ModalMail.style.position = 'absolute';
            ModalMail.style.pointerEvents = 'auto';
            //var idServ = control.id;
            $("#TxtAsunto").val("Hallazgo de " + $(control).parent().closest('tr').find('td:eq(0)').text() + " en " + $(control).parent().closest('tr').find('td:eq(3)').text() + " en area " + $(control).parent().closest('tr').find('td:eq(1)').text());
            $("#TxtMsj").val("En el radicado " + $("#hfRadicado").val() + " se encontro el siguiente hallazgo: " + get_content($(control).parent().closest('tr').find('td:eq(2)').text()));

            var params = new Object();
            params.area = $(control).parent().closest('tr').find('td:eq(1)').text();
            params.radicado = $("#hfRadicado").val();
            params = JSON.stringify(params);
            $.ajax({
                type: "POST",
                url: "Auditoria.aspx/getCorreoNotifHallazgo",
                data: params,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {                    
                    $("#TxtPara").val(msg.d);
                },
                error: function (msg) {
                    alert("error " + msg.responseText);
                }
            });
        } 
    }

    function get_content(texto) {
        return texto.replace(/<[^>]*>/g, "");
    }

    function cerrar() {
        ModalMail.style.display = 'none';
    }

    function enviarNotificacion() {
        var okTxts = true;
        if ($("#TxtMsj").val() == "") {
            $("#TxtMsj").notify("Determine el texto del mensaje.")
            okTxts = false;
        }
        if ($("#TxtPara").val() == "") {
            $("#TxtPara").notify("Determine el correo del remitente.")
            okTxts = false;
        }
        if ($("#TxtAsunto").val() == "") {
            $("#TxtAsunto").notify("Determine el asunto del mensaje.")
            okTxts = false;
        }
        if (okTxts) {
            var BtnEnviarMail = document.getElementById("BtnEnviarMail");
            BtnEnviarMail.click();
            //$().notify("Correo enviado.", "sucess");
            //cerrar();
        }
    }
</script>

<div class="tabla">
    <div class="celda celdaTitulo" style="float: left; width: 20%;">
        Tipo Hallazgo encontrado:
    </div>
    <div class="celda celdaControl" style="float: left; width: 15%;">
        <asp:DropDownList runat="server" ID="ddlTipoHallazgo" ClientIDMode="Static" AppendDataBoundItems="true">
            <asp:ListItem Text=".::Seleccione::." Value="0"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="celda celdaTitulo" style="float: left; width: 8%;">
        Area
    </div>
    <div class="celda celdaControl" style="float: left; width: 27%;">
        <uc1:ctrAreasAtencion runat="server" ID="ctrAreasAtencion" />
    </div>
    <div class="celda celdaTitulo" style="float: left; width: 14%;">
        Fecha Hallazgo
    </div>
    <div class="celda celdaControl" style="float: left; width: 13%;">
        <input type="text" id="txtFecHallazgo" readonly class="textBoxCentrado" />
    </div>
    <div class="fila" style="width: 100%;">
        <div id="divNoPertinencia" style="float: left; width: 100%;">
            <div class="celda celdaTitulo" style="float: left; width: 20%;">
                No Pertinencia
            </div>
            <div class="celda celdaControl" style="float: left; width: 79%;">
                <uc1:ctrPertinencia runat="server" ID="ctrPertinencia" />
            </div>
        </div>
        <div id="divInoportunidad" style="float: left; width: 100%;">
            <div class="celda celdaTitulo" style="float: left; width: 20%;">
                Inoportunidad
            </div>
            <div class="celda celdaControl" style="float: left; width: 79%;">
                <uc1:ctrInoportunidad runat="server" ID="ctrInoportunidad" />
            </div>
        </div>
        <div id="divNoCalidad" style="float: left; width: 100%;">
            <div class="celda celdaTitulo" style="float: left; width: 20%;">
                No Calidad
            </div>
            <div class="celda celdaControl" style="float: left; width: 79%;">
                <uc1:ctrNoCalidad runat="server" ID="ctrNoCalidad" />
            </div>
        </div>
        <div id="divEventosAdversos" style="float: left; width: 100%;">
            <div class="celda celdaTitulo" style="float: left; width: 20%;">
                Eventos Adversos
            </div>
            <div class="celda celdaControl" style="float: left; width: 79%;">
                <uc1:ctrEventosAdversos runat="server" ID="ctrEventosAdversos" />
            </div>
        </div>
    </div>
    <div class="fila" id="divHallazgo">
        <div id="divLblHallazgo" class="celda celdaTitulo" style="float: left; height: 120px; width: 20%;">
            Hallazgo:
        </div>
        <div class="celda celdaControl" style="float: left; height: 120px; width: 79%;">
            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtHallazgo" CssClass="textBoxCentrado" TextMode="MultiLine" Height="69px"></asp:TextBox>
        </div>
    </div>
</div>
<div class="fila">
    <div class="celda celdaControl" style="float: left; height: 50px; width: 100%;">
        <div style="float: left">
            Generar notificación  
            
        </div>
        <div style="float: right">
            Guardar
            <img style="cursor: pointer; vertical-align: middle;" alt="Guardar Hallazgo ( Alt + h)" accesskey="h" src="../../Images/icons/bi/guardar.png" width="25" height="25" id="btnGuardarHall" />
        </div>
    </div>
</div>
<div class="fila" style="overflow: auto; height: 300px;">
    <asp:GridView ID="gvHallAtencion" runat="server" AutoGenerateColumns="False" GridLines="Vertical" Style="width: 100%" ClientIDMode="Static">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField HeaderText="Tipo Hallazgo" DataField="" />
            <asp:BoundField HeaderText="Area" DataField="nArea" />
            <asp:BoundField HeaderText="Hallazgo" DataField="hallazgoAtencion" />
            <asp:BoundField HeaderText="Pertinencia" DataField="nPertinenciaAtencion" />
            <asp:BoundField HeaderText="Inoportunidad" DataField="nInoportunidadAtencion" />
            <asp:BoundField HeaderText="Notif" />
        </Columns>
    </asp:GridView>
</div>
<div id="ModalMail" class="modalDialogActual">
    <div>
        <a href="#close" onclick="cerrar();" id="Close" title="Close" class="close">X</a>
        <%--<p>
            <a class="labelform" id="Aviso">Tenga en cuenta que el archivo adjunto contiene un PDF con los detalles de la carta glosa.</a>
            <br />
            <a>Adjuntos:</a>
            <br />
            <asp:TextBox ID="LblNombreArchivoAdjunto" ClientIDMode="Static" Style="display: block; width: 90%;" Enabled="false" runat="server"></asp:TextBox>
        </p>--%>
        <div id="wrapper">
            <div class="FilaDiv">
                <a>De: </a>
                <asp:TextBox ID="TxtDe" Text="infoinvers.jcjm@gmail.com" Style="display: block; width: 90%;" Enabled="false" runat="server"></asp:TextBox>
            </div>
            <div class="FilaDiv">
                <a>Para : </a>
                <asp:TextBox ID="TxtPara" ClientIDMode="Static" Style="width: 90%;" runat="server"></asp:TextBox>
            </div>
            <div class="FilaDiv">
                <a>Asunto : </a>
                <asp:TextBox ID="TxtAsunto" ClientIDMode="Static" Style="width: 90%;" runat="server"></asp:TextBox>
            </div>
            <div class="FilaDiv">
                <a>Mensaje : </a>
                <asp:TextBox ID="TxtMsj" ClientIDMode="Static" Style="height: 150px; text-align: start; -webkit-writing-mode: horizontal-tb; width: 90%;" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
            <div class="FilaDiv" style="text-align:right;">                    
                <button type="button" style="cursor: pointer; height: 30px; margin-right: 30px;" onclick="enviarNotificacion();">
                    &nbsp;Enviar&nbsp;
                    <img src="../../Images/icons/bi/email.png" width="24" height="24" style="vertical-align: middle; text-align: left;" alt="Enviar" /> 
                </button>
                <asp:Button ID="BtnEnviarMail" ClientIDMode="Static" runat="server" Text="Enviar" Style="display: none;" OnClick="BtnEnviarMail_Click" />                
                <%--<label id="LblMsjResult" style="color: #cc0000; display: block"></label>--%>
                
            </div>
            <br />
        </div>
    </div>
</div>
