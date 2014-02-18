<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrAddEspecialidad.ascx.cs" Inherits="SIISAConc.webControls.especialidad.Ctrespecialidad" %>
<div>
    <table style="width: 520px;">
        <tr>
            <td colspan="5">DETALLE DE ESPECIALIDADES</td>
        </tr>
        <tr>
            <td colspan="5">&nbsp;</td>
        </tr>
        <tr>
            <td>Id</td>
            <td>
                <asp:TextBox ID="txtIdEspecialidad" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>Especialidad</td>
            <td colspan="2">
                <asp:TextBox ID="txtEspecialidad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">SubMayor</td>
            <td colspan="2">
                <asp:TextBox ID="txtSubMayor" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:CheckBox ID="chbActivo" runat="server" Text="Activo" />
            </td>
        </tr>
        <tr>
            <td colspan="2">clase</td>
            <td colspan="3">
                <asp:TextBox ID="txtClase" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:ImageButton runat="server" ValidationGroup="Datos" ImageUrl="~/images/icons/bi/guardar.png" Width="25px" ID="btnGuardar" OnClick="btnGuardar_Click"></asp:ImageButton>
            </td>
        </tr>
    </table>
    <br />
</div>
