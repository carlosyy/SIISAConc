<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SIISAConc.Master" AutoEventWireup="true" CodeBehind="Auditoria.aspx.cs" Inherits="SIISAConc.Concurrencia.Auditoria" %>

<%@ Register Src="~/webControls/auditoria/ctrAuditoria.ascx" TagPrefix="uc1" TagName="ctrAuditoria" %>
<%@ Register Src="~/webControls/concurrencia/ctrHallazgos.ascx" TagPrefix="uc1" TagName="ctrHallazgos" %>
<%@ Register Src="~/webControls/concurrencia/ctrNotas.ascx" TagPrefix="uc1" TagName="ctrNotas" %>
<%@ Register Src="~/webControls/concurrencia/ctrPtesConcur.ascx" TagPrefix="uc1" TagName="ctrPtesConcur" %>
<%@ Register Src="~/webControls/procedimientos/ctrProcedimientos.ascx" TagPrefix="uc1" TagName="ctrProcedimientos" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {
            $("#tabs").tabs();
        });
    </script>
    
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Info Atención</a></li>
            <li><a href="#tabs-2">Procedimientos</a></li>
            <li><a href="#tabs-3">Hallazgo</a></li>
            <li><a href="#tabs-4">Notas</a></li>
            <li><a href="#tabs-5">Pendientes Concurrencia</a></li>
        </ul>
        <div id="tabs-1">
            <uc1:ctrAuditoria runat="server" ID="ctrAuditoria" />
        </div>
        <div id="tabs-2">
            <uc1:ctrProcedimientos runat="server" id="ctrProcedimientos" />
        </div>
        <div id="tabs-3">
            <uc1:ctrHallazgos runat="server" ID="ctrHallazgos" />
        </div>
        <div id="tabs-4">
            <uc1:ctrNotas runat="server" ID="ctrNotas" />
        </div>
        <div id="tabs-5">
            <uc1:ctrPtesConcur runat="server" ID="ctrPtesConcur" />
        </div>
    </div>
</asp:Content>
