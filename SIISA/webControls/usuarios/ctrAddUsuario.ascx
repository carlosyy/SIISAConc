<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrAddUsuario.ascx.cs" Inherits="SIISAConc.webControls.ctrAddUsuario" %>

<table>
    <tr>
        <td>Documento</td>
        <td class="auto-style1">
            <asp:TextBox ID="txtDocumento" AutoPostBack="true" runat="server" ValidationGroup="grpAddUsuario" Width="150px" OnTextChanged="txtDocumento_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valDocumento" runat="server" ControlToValidate="txtDocumento" ErrorMessage="*" ForeColor="Red" ValidationGroup="grpAddUsuario"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Tratamiento</td>
        <td class="auto-style1">
            <asp:DropDownList ID="ddlTratamiento" runat="server">
                <asp:ListItem Selected="True" Value="1">Sr.</asp:ListItem>
                <asp:ListItem Value="2">Sra.</asp:ListItem>
                <asp:ListItem Value="3">Dr.</asp:ListItem>
                <asp:ListItem Value="4">Dra.</asp:ListItem>
                <asp:ListItem Value="5">Ing.</asp:ListItem>
                <asp:ListItem Value="6">Lic.</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Nombres</td>
        <td class="auto-style1">
            <asp:TextBox ID="txtNombres" runat="server" ValidationGroup="grpAddUsuario" Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valNombres" runat="server" ControlToValidate="txtNombres" ErrorMessage="*" ForeColor="Red" ValidationGroup="grpAddUsuario"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Perfil</td>
        <td class="auto-style1">
            <asp:DropDownList ID="ddlPerfil" runat="server" Width="150px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Sucursal</td>
        <td class="auto-style1">
            <asp:TextBox ID="txtSucursal" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Email</td>
        <td class="auto-style1">
            <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="grpAddUsuario" Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red" ValidationGroup="grpAddUsuario"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="grpAddUsuario"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td>Usuario</td>
        <td class="auto-style1">
            <asp:TextBox ID="txtUsuario" AutoPostBack="true" runat="server" ValidationGroup="grpAddUsuario" Width="150px" OnTextChanged="txtUsuario_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="*" ForeColor="Red" ValidationGroup="grpAddUsuario"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Clave</td>
        <td class="auto-style1">
            <asp:TextBox ID="txtClave" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Imagen</td>
        <td class="auto-style1">
            <asp:FileUpload ID="fulImagen" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="2">            
            <asp:HiddenField ID="hfEstado" runat="server" />
            <asp:ImageButton ID="btnGuardar" runat="server" ImageUrl="~/Images/guardar.ico" OnClick="btnGuardar_Click" ValidationGroup="grpAddUsuario" Width="25px" ToolTip="Grabar Usuario" CommandName="guardar" />            
            <asp:ImageButton ID="btnCancelar" runat="server" CommandName="cancelar" Height="29px" ImageUrl="~/Images/Cancelar.ico" OnClick="btnCancelar_Click" Width="26px" ToolTip="Cancelar" />
            <asp:HiddenField ID="hfUsuario" runat="server" />
            <asp:HiddenField ID="hyd" runat="server" />
            <br />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="lblRespuesta" runat="server" Text="....."></asp:Label>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style1">&nbsp;</td>
    </tr>
</table>

