<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SIISAConc.Master" AutoEventWireup="true" CodeBehind="concurrencia.aspx.cs" Inherits="SIISAConc.Concurrencia.concurrencia" %>
<%@ Register Src="~/webControls/concurrencia/ctrBusqueda.ascx" TagPrefix="uc1" TagName="ctrBusqueda" %>
<%@ Register Src="~/webControls/entidades/ctrDdlNitNombre.ascx" TagPrefix="uc1" TagName="ctrDdlNitNombre" %>
<%@ Register Src="~/webControls/concurrencia/ctrAtencEstablecidas.ascx" TagPrefix="uc1" TagName="ctrAtencEstablecidas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    <script type="text/javascript">
        function changeTab() {
            switch ($find("<%=tbcAtenciones.ClientID%>").get_activeTabIndex()) {
            case 0:
                var btnOrdenar = document.getElementById('btnOrdenar');
                btnOrdenar.click();
                break;
            case 1:
                var btnGetAtencEstab = document.getElementById('btnGetAtencEstab');
                btnGetAtencEstab.click();
                break;
            default:
            }
        }        
        
    </script>
    <asp:Panel runat="server" ID="pnlEstablecerIPS">
        <asp:TextBox runat="server" ID="txtBusqIPS" AutoPostBack="true" OnTextChanged="txtBusqIPS_TextChanged"></asp:TextBox>
        <cc1:TextBoxWatermarkExtender runat="server" Enabled="True" TargetControlID="txtBusqIPS" WatermarkText="Buscar IPS" WatermarkCssClass="watermarked" ID="txtBusqIPS_TextBoxWatermarkExtender"></cc1:TextBoxWatermarkExtender>
        <asp:UpdatePanel runat="server" ID="uppIPS">
            <ContentTemplate>
                <uc1:ctrDdlNitNombre runat="server" ID="ctrDdlNitNombre" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtBusqIPS" EventName="TextChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Button runat="server" ID="btnBuscar" Text="Buscar Atenciones" OnClick="btnBuscar_Click" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlConcurrencia">
        <cc1:TabContainer ID="tbcAtenciones" ClientIDMode="Static" runat="server" ActiveTabIndex="0" Width="100%" OnClientActiveTabChanged="changeTab">
            <cc1:TabPanel ID="tbpBuscarAtencion" runat="server" HeaderText="Buscar Atencion" TabIndex="0">
                <ContentTemplate>
                    <uc1:ctrBusqueda runat="server" ID="ctrBusqueda" />
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="tbpAtencEstablecidas" runat="server" HeaderText="Atenciones Establecidas" TabIndex="1">
                <ContentTemplate>
                    <uc1:ctrAtencEstablecidas runat="server" id="ctrAtencEstablecidas" />
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </asp:Panel>
</asp:Content>

