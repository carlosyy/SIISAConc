<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrNotas.ascx.cs" Inherits="SIISAConc.webControls.concurrencia.ctrNotas1" %>

<style type="text/css">
    .auto-style1
    {
        width: 34px;
    }
</style>

<table>  
    <tr>
        <td class="auto-style1">
            <asp:Label ID="lblPaciente" runat="server" Text=""></asp:Label>
        </td>    
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtNota" runat="server" Height="157px" TextMode="MultiLine" Width="637px"></asp:TextBox>            
        </td>
    </tr>
    <tr>
        <td>
              
        </td>
    </tr>
    <tr>
        <td>
           
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_OnClick"/>
        </td>
    </tr>
</table>
             

