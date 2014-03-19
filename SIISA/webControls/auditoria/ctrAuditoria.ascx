<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrAuditoria.ascx.cs" Inherits="SIISAConc.webControls.auditoria.ctrAuditoria" %>

<script>
    $(document).ready(function() {
        $('.textBoxCentrado').prop('readonly', true);
    });
    
</script>
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

    .textBoxCentrado {
        margin: 1%;
        text-align: center;
        position: relative;
        width: 94%;
    }
     
</style>

<asp:HiddenField runat="server" ID="hfRadicado" ClientIDMode="Static"/>
<div class="tabla" style="height:100%; width: 100%;">
    <div class="fila" style="width: 17%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Documento
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtDocumento" CssClass="textBoxCentrado" />
        </div>
    </div>
    <div class="fila" style="width: 10%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Tipo Doc
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtTipoDoc" CssClass="textBoxCentrado" />
        </div>
    </div>
    <div class="fila" style="width: 17%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            1er Apellido
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtApellido_a" CssClass="textBoxCentrado" />
        </div>
    </div>
    <div class="fila" style="width: 17%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            2do Apellido
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtApellido_b" CssClass="textBoxCentrado" />
        </div>
    </div>
    <div class="fila" style="width: 17%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            1er Nombre
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtNombre_a" CssClass="textBoxCentrado" />
        </div>
    </div>
    <div class="fila" style="width: 17%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            2do Nombre
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtNombre_b" CssClass="textBoxCentrado" />
        </div>
    </div>
    <div class="fila" style="width: 4%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Sexo
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtSexo" MaxLength="1" CssClass="textBoxCentrado" />
        </div>
    </div>
    <%----------------------------------------------------------------%>
    <div class="fila" style="width: 10%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Fecha ingreso
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtFechaIngreso" CssClass="textBoxCentrado" ClientIDMode="Static" placeholder="dd/MM/yyyy" />
        </div>
    </div>
    <div class="fila" style="width: 10%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Hora Ingreso
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ClientIDMode="Static" CssClass="textBoxCentrado" ID="txtHoraIngreso" />
        </div>
    </div>
    <div class="fila" style="width: 8%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Dias estancia
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox id="txtDiasEstancia" runat="Server" class="textBoxCentrado" />
        </div>
    </div>
    <div class="fila" style="width: 26%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Especialidad
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtEspecialidad" CssClass="textBoxCentrado" />
        </div>
    </div>
    <div class="fila" style="width: 23%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Cod dx Cie
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtDxCie" CssClass="textBoxCentrado" />
        </div>
    </div>
    <div class="fila" style="width: 22%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Cod dx relacionado
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtDxRel" CssClass="textBoxCentrado" />
        </div>
    </div>
    <%----------------------------------------------------------------%>
    <div class="fila" style="width: 10%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Fecha Nacimiento
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtFecNacimiento" CssClass="textBoxCentrado"/>
        </div>
    </div>
    <div class="fila" style="width: 7%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Edad
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox id="txtEdad" runat="Server" class="textBoxCentrado" />
        </div>
    </div>
    <div class="fila" style="width: 10%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Tipo edad
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:DropDownList runat="server" ID="ddlTipoEdad" CssClass="textBoxCentrado">
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
            <asp:TextBox runat="server" ID="txtMedico" CssClass="textBoxCentrado" />
        </div>
    </div>
    <div class="fila" style="width: 32%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Contrato
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtPrograma" CssClass="textBoxCentrado" />
        </div>
    </div>
    <div class="fila" style="width: 15%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Tipo contrato
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:DropDownList runat="server" ID="ddlTipoContrato" CssClass="textBoxCentrado">
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
            <asp:DropDownList runat="server" ID="ddlTipoAtencion" CssClass="textBoxCentrado">
                <asp:ListItem Text=".::Seleccione::." Value="0" />
            </asp:DropDownList>
        </div>
    </div>
    <div class="fila" style="width: 27%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Cama
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox runat="server" ID="txtCama" CssClass="textBoxCentrado" />
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
</div>
