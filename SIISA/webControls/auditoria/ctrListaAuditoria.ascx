<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrListaAuditoria.ascx.cs" Inherits="SIISAConc.webControls.auditoria.ctrListaAuditoria" %>
<%@ Register Src="~/webControls/concurrencia/ctrAtencEstablecidas.ascx" TagPrefix="uc1" TagName="ctrAtencEstablecidas" %>
<%@ Register Src="~/webControls/estadoAtenc/ctrEstadoAtenc.ascx" TagPrefix="uc1" TagName="ctrEstadoAtenc" %>
<link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css">
<script type="text/javascript">    
    $(function () {
        $("#txtFechaAtencion").datepicker({            
            dateFormat: "dd/mm/yy",
            firstDay: 1,
            dayNamesMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"],
            dayNamesShort: ["Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab"],
            monthNames:
                ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio",
                "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
            monthNamesShort:
                ["Ene", "Feb", "Mar", "Abr", "May", "Jun",
                "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"]
        });
    });
    
</script>

<style>

</style>
<h1>LISTA DE RADICADOS ESTABLECIDOS POR DIA</h1>
<div style="width: 100%">
    <div style="float:left; width:50%" >        
        <asp:TextBox runat="server" ID="txtFechaAtencion" ClientIDMode="Static"></asp:TextBox>
    </div>
    <div style="float:left; width:45%" >
        <uc1:ctrEstadoAtenc runat="server" ID="ctrEstadoAtenc" />
    </div>
    <div style="float:left; width:5%">
        <asp:Button runat="server" ID="btnBuscarAtencEstab" OnClick="btnBuscarAtencEstab_Click" Text="Buscar" AccessKey="b" ToolTip="Buscar Atenciones ( Alt + b )" />
    </div>
    <div style="width: 100%">
        <uc1:ctrAtencEstablecidas runat="server" ID="ctrAtencEstablecidas" />
    </div>
</div>
