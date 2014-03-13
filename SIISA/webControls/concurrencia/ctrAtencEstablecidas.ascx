<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrAtencEstablecidas.ascx.cs" Inherits="SIISAConc.webControls.concurrencia.CtrAtencEstablecidas" %>
<script type="text/javascript">

    function auditar(control) {
        var radicado = $(control).parent().siblings(":first").text();
        $.notify('Auditar radicado: ' + radicado, 'sucess');
        SIISAConc.WbsSIISAConc.encriptar(radicado, getResul);
        return false;
    }

    function getResul(result) {
        window.location.href = "../Concurrencia/Auditoria.aspx?rad=" + result;
        return false;
    }
</script>
<asp:UpdatePanel runat="server" ID="uppAtencEstab">
    <ContentTemplate>
        <asp:Button runat="server" ClientIDMode="Static" ID="btnGetAtencEstab" OnClick="btnGetAtencEstab_OnClick" Style="display: none;" />
        <asp:GridView ID="gvAuditorias" runat="server" AutoGenerateColumns="False" EmptyDataText="Sin registros" Width="100%" DataKeyNames="idAtencion">
            <Columns>
                <asp:BoundField HeaderText="Radicado" DataField="radicado" />
                <asp:BoundField HeaderText="Identificacion" DataField="docIden" />
                <asp:BoundField HeaderText="Nombre de Usuario" DataField="nombreCompleto" />
                <asp:BoundField HeaderText="Fecha de Ingreso" DataField="fecIngreso" DataFormatString="{0:t}" />
                <asp:BoundField HeaderText="CodDx" DataField="codDx" />
                <asp:BoundField HeaderText="Cama" DataField="cama" />
                <asp:BoundField HeaderText="Tipo de <br />Estancia" DataField="tipoEstancia" HtmlEncode="False" />
                <asp:BoundField HeaderText="Dias <br />Estancia" DataField="diasEstancia" HtmlEncode="False" />
                <asp:BoundField HeaderText="Estado" DataField="estadoRad" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <img id="btnAuditar" src="../../Images/icons/bi/agregarenc.png" style="cursor: pointer" onclick="auditar(this);" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnGetAtencEstab" EventName="Click"/>
    </Triggers>
</asp:UpdatePanel>
