<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SIISAConc.Master" AutoEventWireup="true" CodeBehind="concurrencia.aspx.cs" Inherits="SIISAConc.Concurrencia.concurrencia" %>

<%@ Register Src="~/webControls/concurrencia/ctrPtesConcur.ascx" TagPrefix="uc1" TagName="ctrPtesConcur" %>
<%@ Register Src="~/webControls/concurrencia/ctrHallazgos.ascx" TagPrefix="uc1" TagName="ctrHallazgos" %>
<%@ Register Src="~/webControls/concurrencia/ctrBusqueda.ascx" TagPrefix="uc1" TagName="ctrBusqueda" %>
<%@ Register Src="~/webControls/concurrencia/ctrNotas.ascx" TagPrefix="uc1" TagName="ctrNotas" %>
<%@ Register Src="~/webControls/entidades/ctrDdlNitNombre.ascx" TagPrefix="uc1" TagName="ctrDdlNitNombre" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
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
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%">
            <cc1:TabPanel ID="TabPanel0" runat="server" HeaderText="Buscar Atencion" TabIndex="0">
                <ContentTemplate>
                    <uc1:ctrBusqueda runat="server" ID="ctrBusqueda" />
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Notas" TabIndex="1">
                <ContentTemplate>
                    <uc1:ctrNotas runat="server" ID="ctrNotas" />
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Hallazgos" TabIndex="2">
                <ContentTemplate>
                    <uc1:ctrHallazgos runat="server" ID="ctrHallazgos" />
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Requerimientos" Visible="false" TabIndex="3">
                <ContentTemplate>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Pendientes" TabIndex="3">
                <ContentTemplate>
                    <uc1:ctrPtesConcur runat="server" ID="ctrPtesConcur" />
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </asp:Panel>
</asp:Content>

