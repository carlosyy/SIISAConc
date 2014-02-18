<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrCargueListPacie.ascx.cs" Inherits="SIISAConc.webControls.concurrencia.ctrCargueListPacie" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/webControls/entidades/ctrDdlNitNombre.ascx" TagPrefix="uc1" TagName="ctrDdlNitNombre" %>

<div class="CentrarDivs">            
    <table>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="uppContent" runat="server">
                    <ContentTemplate>
                        <ajax:AjaxFileUpload ID="AjaxFileUpload1" runat="server" OnUploadComplete="AjaxFileUpload1_UploadComplete" />
                        <asp:Label runat="server" ID="lblErrores" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <ajax:AsyncPostBackTrigger ControlID="AjaxFileUpload1" EventName="UploadComplete" />
                    </Triggers>
                </asp:UpdatePanel>                
            </td>
        </tr>
        <tr>
            <td>Buscar Entidad:
            </td>
            <td>
                <asp:TextBox ID="txtBuscarProv" runat="server" Width="135px"></asp:TextBox>
                <asp:ImageButton ID="btnBuscarEntidad" runat="server" ImageUrl="~/Images/lupa.jpg" OnClick="btnBuscarEntidad_Click" ToolTip="Buscar Radicados" Width="25px" />
            </td>
            <td>Entidad:
            </td>
            <td>
                <ajax:UpdatePanel runat="server" ID="uppDropDownEntidades">
                    <ContentTemplate>
                        <uc1:ctrDdlNitNombre runat="server" ID="ctrDdlNitNombre" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnBuscarEntidad" EventName="click" />
                    </Triggers>
                </ajax:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button Text="Cargar" runat="server" ID="btnCargar" OnClick="btnCargar_Click" />
            </td>
        </tr>
    </table>        
    <asp:HiddenField runat="server" ID="hfCarpetaTemporal" />    
    <asp:HiddenField runat="server" ID="hfRuta" ViewStateMode="Enabled" />
</div>
