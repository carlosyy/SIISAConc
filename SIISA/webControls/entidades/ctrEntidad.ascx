<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrEntidad.ascx.cs" Inherits="SIISAConc.webControls.entidades.ctrAddEntidad" %>
<%@ Register Src="~/webControls/dane/ctrDeptoMpio.ascx" TagPrefix="uc1" TagName="ctrDeptoMpio" %>



<script lang="javascript">
    function ValidarNulosyCeros(source, arguments) {
        // even number?
        if (arguments.Value == 0 || arguments.Value == "")
            arguments.IsValid = false;
        else
            arguments.IsValid = true;
    }
    function ValidarNulos(source, arguments) {
        // even number?
        if (arguments.Value == "")
            arguments.IsValid = false;
        else
            arguments.IsValid = true;
    }
    
</script>
<table class="auto-style1">
    <tr>
        <td class="auto-style2">Tipo Docum:</td>
        <td>
            <asp:DropDownList ID="ddlTipoDoc" runat="server"></asp:DropDownList>            
        </td>
        <td>NIT:</td>
        <td>
            <asp:TextBox ID="txtNIT" runat="server" ValidationGroup="Datos" AutoPostBack="true" OnTextChanged="txtNIT_TextChanged"></asp:TextBox>
            <br />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidarNulosyCeros" ControlToValidate="txtNit" ErrorMessage="Debe ser un numero Valido." ValidateEmptyText="True" ValidationGroup="Datos">Debe ser un numero Valido</asp:CustomValidator>            
        </td>
        <td>D.V.:</td>
        <td>
            <asp:TextBox ID="txtDigVerif" runat="server" Text="0"></asp:TextBox>
            <br /> 
            <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="ValidarNulos" ControlToValidate="txtDigVerif" ErrorMessage="Debe ser un numero Valido." ValidateEmptyText="True" ValidationGroup="Datos">Debe ser un nombre Valido</asp:CustomValidator>                        
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Entidad:</td>
        <td colspan="5">
            <asp:TextBox ID="txtEntidad" runat="server" Width="300px" ValidationGroup="Datos"></asp:TextBox>
            <br /> 
            <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="ValidarNulosyCeros" ControlToValidate="txtNit" ErrorMessage="Debe ser un nombre Valido." ValidateEmptyText="True" ValidationGroup="Datos">Debe ser un nombre Valido</asp:CustomValidator>                        
        </td>
    </tr>
        
    <tr>
        <td class="auto-style2" colspan="6">
            <uc1:ctrDeptoMpio ID="ctrDeptoMpio1" runat="server" />
        </td>
    </tr>
        
    <tr>
        <td class="auto-style2">Dirección:</td>
        <td colspan="5">
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>            
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Telefono:</td>
        <td>
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
        </td>
        <td>Zona:</td>
        <td>
            <asp:DropDownList ID="ddlZona" runat="server"></asp:DropDownList>                        
        </td>
        <td>Región:</td>
        <td>
            <asp:TextBox ID="txtRegion" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">E-Mail:</td>
        <td colspan="5">
            <asp:TextBox ID="txtMail" runat="server" Width="470px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td colspan="5">
            <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" CommandName="Editar" EnableCallBack="true" ImageUrl="~/Images/Editar.png" ToolTip="Editar Entidad" Width="25px" OnClick="btnEditar_Click" />
            <asp:ImageButton ID="btnGuardar" runat="server" ImageUrl="~/Images/guardar.ico" OnClick="btnGuardar_Click" ValidationGroup="Datos" Width="25px" ToolTip="Grabar Entidad" />            
            <asp:ImageButton ID="btnCancelar" runat="server" CommandName="cancelar" Height="29px" ImageUrl="~/Images/Cancelar.ico" OnClick="btnCancelar_Click" Width="26px" ToolTip="Cancelar" />
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table>

