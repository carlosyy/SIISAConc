<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrDeptoMpio.ascx.cs" Inherits="SIISAConc.webControls.dane.ctrDeptoMpio" %>
<table class="auto-style1">
    <tr>
        <td class="auto-style2">Depto:</td>
        <td colspan="2">
            <asp:DropDownList ID="ddlDepartamento" runat="server" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>            
        </td>
        <td>Municipio:</td>
        <td colspan="2">
            <asp:DropDownList ID="ddlMunicipio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged"></asp:DropDownList>            
        </td>    
     </tr>
</table>
<asp:TextBox ID="codDane" runat="server" Visible="False"></asp:TextBox>