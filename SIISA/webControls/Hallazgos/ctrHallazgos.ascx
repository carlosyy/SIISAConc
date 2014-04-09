<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrHallazgos.ascx.cs" Inherits="SIISAConc.webControls.Hallazgos.ctrHallazgos" %>
<%@ Register Src="~/webControls/areasAtencion/ctrAreasAtencion.ascx" TagPrefix="uc1" TagName="ctrAreasAtencion" %>
<%@ Register Src="~/webControls/eventosAdversos/ctrEventosAdversos.ascx" TagPrefix="uc1" TagName="ctrEventosAdversos" %>
<%@ Register Src="~/webControls/noCalidad/ctrNoCalidad.ascx" TagPrefix="uc1" TagName="ctrNoCalidad" %>
<%@ Register Src="~/webControls/inoportunidad/ctrInoportunidad.ascx" TagPrefix="uc1" TagName="ctrInoportunidad" %>
<%@ Register Src="~/webControls/pertinencia/ctrPertinencia.ascx" TagPrefix="uc1" TagName="ctrPertinencia" %>

<link rel="stylesheet" type="text/css" href="../../CSS/jquery.cleditor.css" />
<script type="text/javascript" src="../../js/jquery.cleditor.min.js"></script>

<script type="text/javascript">

    var efecto = "blind";

    $(document).ready(function () {
        $("#txtHallazgo").cleditor({
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
        });

        hideDivs(0);

        $("#ddlTipoHallazgo").change(function () {
            hideDivs($(this).val());
            
            switch ($(this).val()) {
                case "0":
                    $("#divLblHallazgo").text("Hallazgo:");
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
    });

    function hideDivs(tipoHide) {
        var activo = false;

        if (tipoHide == 0) {
            activo = true;
            //$("#txtHallazgo").clear();
        }

        $("#divArea").find('*').prop('disabled', activo);
        $("#divHallazgo").find('*').prop('disabled', activo);        

        $("#divNoPertinencia").hide(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
        $("#divEventosAdversos").hide(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
        $("#divNoCalidad").hide(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });        
        $("#divInoportunidad").hide(efecto, 800).animate({ opacity: 1 }, { duration: 800, queue: false });
    }
</script>

<div class="tabla" style="height: 500px; width: 100%;">
    <div class="fila" style="width: 100%;">
        Hallazgo encontrado en:
        <asp:DropDownList runat="server" ID="ddlTipoHallazgo" ClientIDMode="Static" AppendDataBoundItems="true">
            <asp:ListItem Text=".::Seleccione::." Value="0"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="fila" id="divArea" style="width: 100%;">
        <div class="celda celdaTitulo" style="float:left; width: 20%;">
            Area
        </div>
        <div class="celda celdaControl" style="float:left; width: 79%;">
            <uc1:ctrAreasAtencion runat="server" ID="ctrAreasAtencion" />
        </div>
    </div>
    <div class="fila" id="divNoPertinencia" style="width: 100%;">
        <div class="celda celdaTitulo" style="float:left; width: 20%;">
            No Pertinencia
        </div>
        <div class="celda celdaControl" style="float:left; width: 79%;">
            <uc1:ctrPertinencia runat="server" ID="ctrPertinencia" />
        </div>
    </div>
    <div class="fila" id="divInoportunidad" style="width: 100%;">
        <div class="celda celdaTitulo" style="float:left; width: 20%;">
            Inoportunidad
        </div>
        <div class="celda celdaControl" style="float:left; width: 79%;">
            <uc1:ctrInoportunidad runat="server" ID="ctrInoportunidad" />
        </div>
    </div>
    <div class="fila" id="divNoCalidad" style="width: 100%;">
        <div class="celda celdaTitulo" style="float:left; width: 20%;">
            No Calidad
        </div>
        <div class="celda celdaControl" style="float:left; width: 79%;">
            <uc1:ctrNoCalidad runat="server" ID="ctrNoCalidad" />
        </div>
    </div>
    <div class="fila" id="divEventosAdversos" style="width: 100%;">
        <div class="celda celdaTitulo" style="float:left; width: 20%;">
            Eventos Adversos
        </div>
        <div class="celda celdaControl" style="float:left; width: 79%;">
            <uc1:ctrEventosAdversos runat="server" ID="ctrEventosAdversos" />
        </div>
    </div>
    <div class="fila" id="divHallazgo" style="width: 100%;">
        <div id="divLblHallazgo" class="celda celdaTitulo" style="float:left; height:120px; width: 20%;">
            Hallazgo:
        </div>
        <div class="celda celdaControl" style="float:left; height:120px; width: 79%;">
            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtHallazgo" CssClass="textBoxCentrado" TextMode="MultiLine" Height="69px"></asp:TextBox>
            
        </div>
    </div>
</div>

<table style="width: 100%">
    <tr>
        <td colspan="3">            
            <asp:ImageButton ID="btnGuardar" runat="server" ImageUrl="" OnClick="btnGuardar_Click" Width="40px" AccessKey="G" ToolTip="Guardar Hallazgo ( Alt + G)" Height="40px" />
        </td>
    </tr>
    <tr>
        <td colspan="3">            
            <asp:GridView ID="gvServAtencConcur" runat="server" AutoGenerateColumns="False" GridLines="Vertical" OnRowCommand="gvServAtencConcur_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="Area" DataField="nArea" />
                    <asp:BoundField HeaderText="No Pertinencia" DataField="nPertinenciaAtencion" />
                    <asp:BoundField HeaderText="Inoportunidad" DataField="nInoportunidadAtencion" />
                    <asp:BoundField HeaderText="No Calidad" DataField="nNoCalidadAtencion" />
                    <asp:BoundField HeaderText="Eventos Adversos" DataField="nEventosAdversosAtencion" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" CommandName="Editar" ImageUrl="~/Images/EnviarCorreo.png" AlternateText="Editar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
