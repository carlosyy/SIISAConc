<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SIISAConc.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="concurrencia.aspx.cs" Inherits="SIISAConc.Concurrencia.concurrencia" %>
<%@ Register Src="~/webControls/concurrencia/ctrBusqueda.ascx" TagPrefix="uc1" TagName="ctrBusqueda" %>
<%@ Register Src="~/webControls/entidades/ctrDdlNitNombre.ascx" TagPrefix="uc1" TagName="ctrDdlNitNombre" %>
<%@ Register Src="~/webControls/concurrencia/ctrAtencEstablecidas.ascx" TagPrefix="uc1" TagName="ctrAtencEstablecidas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("a#tab2").click(function () {
                var btnGetAtencEstab = document.getElementById('btnGetAtencEstab');
                btnGetAtencEstab.click();
            });
            $("#tabs").tabs();
        });
    </script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css">
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
        <div id="tabs">
          <ul>
            <li><a href="#tabs-1">Buscar atenciones</a></li>
            <li><a id="tab2" href="#tabs-2">Atenciones establecidas</a></li>
          </ul>
          <div id="tabs-1">
            <uc1:ctrBusqueda runat="server" ID="ctrBusqueda" />
          </div>
          <div id="tabs-2">
            <uc1:ctrAtencEstablecidas runat="server" id="ctrAtencEstablecidas" />
          </div>
        </div>
    </asp:Panel>
</asp:Content>

