<%@ Control AutoEventWireup="true" CodeBehind="ctrAddPacteConcurr.ascx.cs" Inherits="SIISAConc.webControls.concurrencia.CtrAddPacteConcurr" Language="C#" %>
<%@ Register Src="~/webControls/tiposDoc/ctrDdlTiposDoc.ascx" TagPrefix="uc1" TagName="ctrDdlTiposDoc" %>
<%@ Register Src="~/webControls/especialidad/ctrDdlEspecialidad.ascx" TagPrefix="uc1" TagName="ctrDdlEspecialidad" %>
<%@ Register Src="~/webControls/dx/ctrDdlDx.ascx" TagPrefix="uc1" TagName="ctrDdlDx" %>

<style>
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
</style>
<script>
    function editarDx(opcionEditar) {
        divEditarDx.style.display = 'block';
        divEditarDx.style.opacity = '1';
        divEditarDx.style.position = 'absolute';
        divEditarDx.style.pointerEvents = 'auto';
        document.getElementById('hfEditarDx').value = opcionEditar;
    }
    function cerrarEditar() {
        divEditarDx.style.display = 'none';
        var btnEditarDx = document.getElementById('btnEditarDx');
        btnEditarDx.click();
    }

    function escapeEditar() {
        var key = window.event.keyCode;
        if (key == 27) {
            cerrarEditar();
        }
    }

    function guardar() {
        var btnGuardar = document.getElementById('btnGuardar');
        btnGuardar.click();
    }
</script>
<h1 style="text-align: center">Ingresar información de paciente hospitalizado
</h1>
<div class="tabla" style="height: 500px; width: 100%;">
    <%--<div class="fila" style="width: 10%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Consecutivo Ingreso
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtConsecutivo" Width="35px" />
        </div>
    </div>--%>
    <div class="fila" style="width: 17%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Documento
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtDocumento" AutoPostBack="True" OnTextChanged="txtDocumento_OnTextChanged" />
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
            <div class="fila" style="width: 15%;">
                <div class="celda celdaTitulo" style="width: 100%;">
                    1er Apellido
                </div>
                <div class="celda celdaControl" style="width: 100%;">
                    <asp:TextBox runat="server" ID="txtApellido_a" />
                </div>
            </div>
            <div class="fila" style="width: 15%;">
                <div class="celda celdaTitulo" style="width: 100%;">
                    2do Apellido
                </div>
                <div class="celda celdaControl" style="width: 100%;">
                    <asp:TextBox runat="server" ID="txtApellido_b" />
                </div>
            </div>
            <div class="fila" style="width: 15%;">
                <div class="celda celdaTitulo" style="width: 100%;">
                    1er Nombre
                </div>
                <div class="celda celdaControl" style="width: 100%;">
                    <asp:TextBox runat="server" ID="txtNombre_a" />
                </div>
            </div>
            <div class="fila" style="width: 15%;">
                <div class="celda celdaTitulo" style="width: 100%;">
                    2do Nombre
                </div>
                <div class="celda celdaControl" style="width: 100%;">
                    <asp:TextBox runat="server" ID="txtNombre_b" />
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
            <asp:TextBox runat="server" ID="txtFechaIngreso" placeholder="dd/MM/yyyy" Width="100px" />
            <cc1:CalendarExtender ID="txtFechaIngreso_CalendarExtender" Format="dd/MM/yyyy" runat="server" CssClass="calendar" Enabled="True" TargetControlID="txtFechaIngreso">
            </cc1:CalendarExtender>
        </div>
    </div>
    <%--<div class="fila" style="width: 10%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Fecha egreso
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtFechaEgreso" placeholder="dd/MM/yyyy" Width="100px" />
            <cc1:CalendarExtender ID="txtFechaEgreso_CalendarExtender" Format="dd/MM/yyyy" Animated="True" CssClass="calendar" runat="server" Enabled="True" TargetControlID="txtFechaEgreso">
            </cc1:CalendarExtender>
        </div>
    </div>--%>
    <div class="fila" style="width: 8%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Dias estancia
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtDiasEstancia" Enabled="False" Width="35px" />
        </div>
    </div>
    <div class="fila" style="width: 25%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Especialidad
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <uc1:ctrDdlEspecialidad runat="server" ID="ctrDdlEspecialidad" />
        </div>
    </div>
    <div class="fila" style="width: 22%;">
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
            <asp:TextBox runat="server" ID="txtFecNacimiento" placeholder="dd/MM/yyyy" Width="100px" />
            <cc1:CalendarExtender ID="txtFecNacimiento_CalendarExtender" Format="dd/MM/yyyy" Animated="True" CssClass="calendar" runat="server" Enabled="True" TargetControlID="txtFecNacimiento">
            </cc1:CalendarExtender>
        </div>
    </div>
    <div class="fila" style="width: 7%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Edad
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtEdad" Width="45px" />
        </div>
    </div>
    <div class="fila" style="width: 10%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Tipo edad
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:DropDownList runat="server" ID="ddlTipoEdad">
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
            <asp:TextBox runat="server" ID="txtMedico" Width="250px" />
        </div>
    </div>
    <div class="fila" style="width: 40%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Nit
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:DropDownList runat="server" ID="ddlContrato"/>
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
    <div class="fila" style="width: 20%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Tipo atención ingreso
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtTipoAtencionIngreso" />
        </div>
    </div>
    <div class="fila" style="width: 17%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Cama
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtCama" Width="80px" />
        </div>
    </div>
    <div class="fila" style="width: 20%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Pabellón
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtPabellon" />
        </div>
    </div>
    <%--<div class="fila" style="width: 20%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Tipo atención egreso
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtTipoAtencionEgreso" />
        </div>
    </div>--%>
    <%--<div class="fila" style="width: 20%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Motivo salida
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:DropDownList runat="server" ID="ddlMotivoSalida">
                <asp:ListItem Text=".::Seleccione::." Value="0" />
                <asp:ListItem Text="Dado de alta" Value="1" />
                <asp:ListItem Text="Traslado" Value="2" />
            </asp:DropDownList>
        </div>
    </div>--%>
    <button type="button" style="width: 135px; height: 26px; cursor: pointer" onclick="guardar();">
        <img src="../../Images/icons/bi/guardar.png" style="vertical-align: middle; horiz-align: left; width: 25px; height: 25px" alt="Guardar" />Guardar 
    </button>
    <asp:Button ID="btnGuardar" OnClick="btnGuardar_OnClick" ClientIDMode="Static" runat="server" style="display: none;" />
</div>
<div id="divEditarDx" onkeyup="escapeEditar();" class="modal">
    <div style="margin: 50px;">Editar diagnóstico de paciente        
        <a onclick="cerrarEditar();" id="A2" title="Close" class="close" style="cursor: pointer">X</a>
        <asp:UpdatePanel runat="server" ID="uppEditarDx" ChildrenAsTriggers="False" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:TextBox runat="server" ID="txtBusqDx" AutoPostBack="True" OnTextChanged="txtBusqDx_OnTextChanged" />
                <uc1:ctrDdlDx runat="server" ID="ctrDdlDx1" />
                <asp:HiddenField runat="server" ID="hfEditarDx" ClientIDMode="Static"/>
                <asp:Button ClientIDMode="Static" ID="btnEditarDx" runat="server" OnClick="btnEditarDx_OnClick" Style="display: none" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtBusqDx" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="btnEditarDx" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
