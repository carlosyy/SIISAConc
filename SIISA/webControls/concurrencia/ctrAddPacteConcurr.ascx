<%@ Control AutoEventWireup="true" CodeBehind="ctrAddPacteConcurr.ascx.cs" Inherits="SIISAConc.webControls.concurrencia.CtrAddPacteConcurr" Language="C#" %>
<%@ Register Src="~/webControls/tiposDoc/ctrDdlTiposDoc.ascx" TagPrefix="uc1" TagName="ctrDdlTiposDoc" %>
<%@ Register Src="~/webControls/especialidad/ctrDdlEspecialidad.ascx" TagPrefix="uc1" TagName="ctrDdlEspecialidad" %>

<%@ Register src="../programas/ctrDdlProgramas.ascx" tagname="ctrDdlProgramas" tagprefix="uc2" %>

<style>
    .textBoxCentrado {
        text-align: center;
    }

     .tabla {
         border-style: none;
         border-color: silver;
     }

    .fila {
        float: left;
        width: 10%;
    }

    .celda {
        border-style: solid;
        border-color: silver;
        border-right-width: 1px;
        width: 10%;
    }

    .celdaTitulo {
        background-color: #608199;
        color: white;
        height: 30px;
    }

    .celdaControl {
        height: 25px;
    }

    .calendar {
        position: absolute;
        z-index: 9999;
    }

    .ui-autocomplete {
        position: absolute;
        cursor: default;
        z-index: 999999 !important;        
    }

</style>
<script src="../../js/timePicker.js"></script>

<script>
    
    $().ready(function () {

        $('#txtHoraIngreso').timepicker();
        $('#txtHoraIngreso').prop('readonly', true);

        $('.nombres').change(function () {
            $("input").val(function (i, val) {
                return val.toUpperCase();
            });
        });

        $("#<%=ddlDx1.ClientID%>").change(function () {
            var opcion = $("#hfEditarDx").val();
            switch (opcion) {
            case "1":
                $("#<%=hfCodDxCie.ClientID%>").val($("#ddlDx1").val());
                $("#<%=txtDxCie.ClientID%>").val($("#ddlDx1 option:selected").text());
                break;
            case "2":
                $("#<%=hfCodDxRel.ClientID%>").val($("#ddlDx1").val());
                $("#<%=txtDxRel.ClientID%>").val($("#ddlDx1 option:selected").text());
                break;
            }

        });

        $("#<%=txtFecNacimiento.ClientID%>").change(function() {
            var params = new Object();
            params.fechaNacimiento = $("#<%=txtFecNacimiento.ClientID%>").val();
            params = JSON.stringify(params);

            $.ajax({
                type: "POST",
                url: "concurrencia.aspx/getEdad",
                data: params,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: setEdad,
                error: function(xmlHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + ": " + xmlHttpRequest.responseText);
                }
            });
        });

        $("#<%=txtBusqDx.ClientID%>").change(function() {
            var params = new Object();
            params.busqDx = $("#<%=txtBusqDx.ClientID%>").val();
            params = JSON.stringify(params);

            $.ajax({
                type: "POST",
                url: "concurrencia.aspx/getDx",
                data: params,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: loadDx,
                error: function(xmlHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + ": " + xmlHttpRequest.responseText);
                }
            });
        });

        $("#txtFechaIngreso").change(function () {
            var d1 = $("#txtFechaIngreso").val().split("/");
            var dat1 = new Date(d1[2], parseFloat(d1[1]) - 1, parseFloat(d1[0]));
            var dat2 = new Date();
            
            var fin = dat2.getTime() - dat1.getTime();
            var dias = Math.floor(fin / (1000 * 60 * 60 * 24));

            $("#<%= txtDiasEstancia.ClientID%>").val(dias);
        });

        $("#<%=txtMedico.ClientID%>").autocomplete({
            source: function (request, response) {
                var params = new Object();
                params.nombreMedico = $("#<%=txtMedico.ClientID%>").val();
                params.q = "'" + request.term + "'";
                params.limit = '10';
                params = JSON.stringify(params);

                $.ajax({
                    url: "concurrencia.aspx/getMedicos",
                    data: params,
                    dataType: "json", 
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    error: function(xmlHttpRequest, textStatus, errorThrown) {
                        alert(textStatus + ": " + xmlHttpRequest.responseText);
                    },
                    success: function(data) {
                        response($.map(data.d, function(item) {
                            return {
                                label: item.nombreMedico,
                                value: item.nombreMedico + ""
                            };
                        }));
                    }
                });
            }
        });
    });

    function editarDx(opcionEditar) {
        window.divEditarDx.style.display = 'block';
        window.divEditarDx.style.opacity = '1';
        window.divEditarDx.style.position = 'absolute';
        window.divEditarDx.style.pointerEvents = 'auto';
        $("#<%=hfEditarDx.ClientID%>").val(opcionEditar);
        $("#<%=txtBusqDx.ClientID%>").focus();
        $("#<%=txtBusqDx.ClientID%>").notify("Establezca un filtro para la búsqueda del diagnóstico puede ser el código del CIE10 o una parte del texto.", { className: "info", position: "top" });
    }
    function cerrarEditar() {
        window.divEditarDx.style.display = 'none';
    }

    function escapeEditar() {
        var key = window.event.keyCode;
        if (key == 27) {
            cerrarEditar();
        }
    }

    function guardar() {
        if (validar()) {
            $("#<%=btnGuardar.ClientID%>").click();
        }
    }

    function validar() {
        var valido = true;
        if ($("#<%=txtDocumento.ClientID%>").val() == "") {
            $("#<%=txtDocumento.ClientID%>").notify("Debe establecer el numero de documento.", { className: "error", position: "bottom" });
            valido = false;
        }
        if ($("#<%=txtApellido_a.ClientID%>").val() == "") {
            $("#<%=txtApellido_a.ClientID%>").notify("Debe establecer el primer apellido.", { className: "error", position: "bottom" });
            valido = false;
        }
        if ($("#<%=txtNombre_a.ClientID%>").val() == "") {
            $("#<%=txtNombre_a.ClientID%>").notify("Debe establecer el primer nombre.", { className: "error", position: "bottom" });
            valido = false;
        }
        if ($("#<%=txtFechaIngreso.ClientID%>").val() == "") {
            $("#<%=txtFechaIngreso.ClientID%>").notify("Debe establecer la fecha de ingreso.", { className: "error", position: "bottom" });
            valido = false;
        }
        if ($("#<%=txtFecNacimiento.ClientID%>").val() == "" || $("#txtEdad").val() == "") {
            $("#<%=txtFecNacimiento.ClientID%>").notify("Debe establecer la fecha de nacimiento o la edad del paciente.", { className: "error", position: "bottom" });
            valido = false;
        }
        if ($("#<%=txtDxCie.ClientID%>").val() == "") {
            $("#<%=txtDxCie.ClientID%>").notify("Debe establecer el diagnóstico de ingreso.", { className: "error", position: "bottom" });
            valido = false;
        }
        return valido;
    }

    function setEdad(result) {
        var edad = result.d.split(",");
        $("#txtEdad").val(edad[0]);
        $("#<%=ddlTipoEdad.ClientID%>").val(edad[1]);
    }

    function loadDx(result) {
        //quito los options que pudiera tener previamente el combo
        $("#ddlDx1").html("");
        $("#ddlDx1").append($("<option></option>").attr("value", "0").text(".::Seleccione::."));
        //recorro cada item que devuelve el servicio web y lo añado como un opcion
        $.each(result.d, function() {
            $("#ddlDx1").append($("<option></option>").attr("value", this.codDx).text(this.codYDx));
        });
        $("#ddlDx1").notify("Determine el diagnóstico.", { className: "info", position: "bottom" });
    }

</script>
<h1 style="text-align: center">Ingresar información de paciente hospitalizado
</h1>
<div class="tabla" style="height: 500px; width: 100%;">
    <div class="fila" style="width: 17%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Documento
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtDocumento" CssClass="textBoxCentrado" AutoPostBack="True" OnTextChanged="txtDocumento_OnTextChanged" />
        </div>
    </div>
    <asp:UpdatePanel runat="server" ID="uppAfiliado">
        <ContentTemplate>
            <div class="fila" style="width: 10%;">
                <div class="celda celdaTitulo" style="width: 100%;">
                    Tipo Doc
                </div>
                <div class="celda celdaControl" style="width: 100%;">
                    <uc1:ctrDdlTiposDoc runat="server" ID="ctrDdlTiposDoc" />
                </div>
            </div>
            <div class="fila" style="width: 17%;">
                <div class="celda celdaTitulo" style="width: 100%;">
                    1er Apellido
                </div>
                <div class="celda celdaControl" style="width: 100%;">
                    <asp:TextBox runat="server" CssClass="nombres" ID="txtApellido_a" />
                </div>
            </div>
            <div class="fila" style="width: 17%;">
                <div class="celda celdaTitulo" style="width: 100%;">
                    2do Apellido
                </div>
                <div class="celda celdaControl" style="width: 100%;">
                    <asp:TextBox runat="server" CssClass="nombres" ID="txtApellido_b" />
                </div>
            </div>
            <div class="fila" style="width: 17%;">
                <div class="celda celdaTitulo" style="width: 100%;">
                    1er Nombre
                </div>
                <div class="celda celdaControl" style="width: 100%;">
                    <asp:TextBox runat="server" CssClass="nombres" ID="txtNombre_a" />
                </div>
            </div>
            <div class="fila" style="width: 17%;">
                <div class="celda celdaTitulo" style="width: 100%;">
                    2do Nombre
                </div>
                <div class="celda celdaControl" style="width: 100%;">
                    <asp:TextBox runat="server" CssClass="nombres" ID="txtNombre_b" />
                </div>
            </div>
            <div class="fila" style="width: 4%;">
                <div class="celda celdaTitulo" style="width: 100%;">
                    Sexo
                </div>
                <div class="celda celdaControl" style="width: 100%;">
                    <asp:TextBox runat="server" ID="txtSexo" MaxLength="1" Width="30px" />
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtDocumento" EventName="TextChanged"/>
        </Triggers>
    </asp:UpdatePanel>
    <%----------------------------------------------------------------%>
    <div class="fila" style="width: 10%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Fecha ingreso
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtFechaIngreso" CssClass="textBoxCentrado" ClientIDMode="Static" placeholder="dd/MM/yyyy" Width="100px" />
            <cc1:CalendarExtender ID="txtFechaIngreso_CalendarExtender" Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1" Enabled="True" TargetControlID="txtFechaIngreso">
            </cc1:CalendarExtender>
        </div>
    </div>
    <div class="fila" style="width: 10%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Hora Ingreso
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ClientIDMode="Static" CssClass="textBoxCentrado" ID="txtHoraIngreso" Width="100px" />
        </div>
    </div>
    <div class="fila" style="width: 8%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Dias estancia
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <input id="txtDiasEstancia" runat="Server" class="textBoxCentrado" type="text" style="width: 35px" readonly="readonly" title="ejemplo" />
        </div>
    </div>
    <div class="fila" style="width: 26%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Especialidad
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <uc1:ctrDdlEspecialidad runat="server" ID="ctrDdlEspecialidad" />
        </div>
    </div>
    <div class="fila" style="width: 23%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Cod dx Cie
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtDxCie" Enabled="False" Width="200px" />
            <asp:HiddenField runat="server" ID="hfCodDxCie" ClientIDMode="Static"/>
            <img src="../../Images/icons/bi/editar.png" style="vertical-align: middle; width: 25px; height: 25px; cursor: pointer;" onclick="editarDx(1);" alt="Editar diagnóstico" />
        </div>
    </div>
    <div class="fila" style="width: 22%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Cod dx relacionado
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtDxRel" Enabled="False" Width="200px" />
            <asp:HiddenField runat="server" ID="hfCodDxRel" ClientIDMode="Static"/>
            <img src="../../Images/icons/bi/editar.png" style="vertical-align: middle; width: 25px; height: 25px; cursor: pointer;" onclick="editarDx(2);" alt="Editar diagnóstico;" />
        </div>
    </div>
    <%----------------------------------------------------------------%>
    <div class="fila" style="width: 10%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Fecha Nacimiento
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtFecNacimiento" CssClass="textBoxCentrado" ClientIDMode="Static" placeholder="dd/MM/yyyy" Width="100px" />
            <cc1:CalendarExtender ID="txtFecNacimiento_CalendarExtender" Format="dd/MM/yyyy" Animated="True" CssClass="cal_Theme1" runat="server" Enabled="True" TargetControlID="txtFecNacimiento">
            </cc1:CalendarExtender>
        </div>
    </div>
    <div class="fila" style="width: 7%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Edad
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <input id="txtEdad" runat="Server" class="textBoxCentrado" type="text" style="width: 35px" />
        </div>
    </div>
    <div class="fila" style="width: 10%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Tipo edad
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:DropDownList runat="server" ClientIDMode="Static" ID="ddlTipoEdad">
                <asp:ListItem Text=".::Seleccione::." Value="0" />
                <asp:ListItem Text="Años" Value="1" />
                <asp:ListItem Text="Meses" Value="2" />
                <asp:ListItem Text="Dias" Value="3" />
            </asp:DropDownList>
        </div>
    </div>
    <div class="fila" style="width: 25%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Médico
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtMedico" CssClass="textBoxCentrado" Width="250px" ClientIDMode="Static" />
        </div>
    </div>
    <div class="fila" style="width: 32%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Contrato
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <uc2:ctrDdlProgramas ID="ctrDdlProgramas1" runat="server" />
        </div>
    </div>
    <div class="fila" style="width: 15%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Tipo contrato
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:DropDownList runat="server" ID="ddlTipoContrato">
                <asp:ListItem Text=".::Seleccione::." Value="0" />
                <asp:ListItem Text="Capitado" Value="1" />
            </asp:DropDownList>
        </div>
    </div>
    <%----------------------------------------------------------------%>
    <div class="fila" style="width: 30%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Tipo atención ingreso
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:DropDownList runat="server" ID="ddlTipoAtencion" AppendDataBoundItems="True">
                <asp:ListItem Text=".::Seleccione::." Value="0" />
            </asp:DropDownList>
        </div>
    </div>
    <div class="fila" style="width: 27%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Cama
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtCama" CssClass="textBoxCentrado" Width="80px" />
        </div>
    </div>
    <div class="fila" style="width: 30%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Pabellón
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtPabellon" CssClass="textBoxCentrado" />
        </div>
    </div>
    <button type="button" style="width: 135px; height: 60px; cursor: pointer" onclick="guardar();">
        <img src="../../Images/icons/bi/guardar.png" width="24" height="24" style="vertical-align: middle; horiz-align: left;" alt="Guardar" />Guardar 
    </button>
    <asp:Button ID="btnGuardar" OnClick="btnGuardar_OnClick" ClientIDMode="Static" runat="server" style="display: none;" />
</div>
<div id="divEditarDx" class="modal">
    <div style="margin: 50px;">Editar diagnóstico de paciente        
        <a onclick="cerrarEditar();" id="A2" title="Close" class="close" style="cursor: pointer">X</a>
        <asp:TextBox runat="server" ID="txtBusqDx"  />
        <asp:DropDownList runat="server" ClientIDMode="Static" ID="ddlDx1" Width="300px"/>
        <asp:HiddenField runat="server" ID="hfEditarDx" ClientIDMode="Static"/>
    </div>
</div>
