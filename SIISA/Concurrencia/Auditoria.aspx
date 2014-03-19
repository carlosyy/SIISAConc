<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SIISAConc.Master" AutoEventWireup="true" CodeBehind="Auditoria.aspx.cs" Inherits="SIISAConc.Concurrencia.Auditoria" %>

<%@ Register Src="~/webControls/auditoria/ctrAuditoria.ascx" TagPrefix="uc1" TagName="ctrAuditoria" %>
<%@ Register Src="~/webControls/concurrencia/ctrHallazgos.ascx" TagPrefix="uc1" TagName="ctrHallazgos" %>
<%@ Register Src="~/webControls/concurrencia/ctrNotas.ascx" TagPrefix="uc1" TagName="ctrNotas" %>
<%@ Register Src="~/webControls/concurrencia/ctrPtesConcur.ascx" TagPrefix="uc1" TagName="ctrPtesConcur" %>
<%@ Register Src="~/webControls/procedimientos/ctrProcedimientos.ascx" TagPrefix="uc1" TagName="ctrProcedimientos" %>
<%@ Register Src="~/webControls/dx/CtrDxLista.ascx" TagPrefix="uc1" TagName="CtrDxLista" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">        
        #divInfo {            
            height: 8%;            
            overflow: hidden;
            width: 100%;
        }
        #divTabs {            
            height: 84%;
            overflow: hidden;
            width: 100%;
        }
        #tabsInfo{
            height: 95%;
        }
        #liRad{
            float: right !important;            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">    
    <script type="text/javascript">
        $(document).ready(function () {
            $('#tabInfo').height($('#tabInfo').parent().height() * 0.9);
            $('#divTabs').height($('#divTabs').parent().height() * 0.9);
            $('#tabsAuditoria').height($('#tabsAuditoria').parent().height());
            $('#tabs-1A').height($('#tabs-1A').parent().height());            
            //$('#tabs-1A').height($('#tabsAuditoria').parent().height());
            $("a#tabRad").click(function () {
                $('#tabsInfo').tabs('select', 0);
            });
            
            $("#tabsAuditoria").tabs();
            $("#tabsInfo").tabs();
            
            $(this).mousemove(function () {                
                $("#tabRad").text("Radicado: " + $("#hfRadicado").val());
                $(this).unbind("mousemove");
            });

            var collapsed = false;
            $('#btnExpandir').click(function () {
                percent = 0.30;
                velocidad = 1500;
                add_height = (percent * $('#tabInfo').parent().height()) + 'px';

                if (!collapsed) {
                    $('#btnExpandir').attr('src', '../Images/icons/bi/menos.png');
                    $('#divInfo').animate({ 'height': '+=' + add_height }, velocidad);
                    $('#divTabs').animate({ 'height': '-=' + add_height }, velocidad);
                } else {
                    $('#btnExpandir').attr('src', '../Images/icons/bi/mas.png');
                    $('#divInfo').animate({ 'height': '-=' + add_height }, velocidad);
                    $('#divTabs').animate({ 'height': '+=' + add_height }, velocidad);
                }
                collapsed = !collapsed;
            });

            
        });
    </script>    
    <div id="tabsInfo">
        <ul>
            <li><a href="#tabInfo">
                <img alt="Expandir" id="btnExpandir" src="../Images/icons/bi/mas.png" style="cursor: pointer" width="25" height="25" />Info Atención</a></li>
            <li id="liRad"><a id="tabRad" href="#tabs-5A">Radicado: </a></li>
        </ul>
        <div id="tabInfo">
            <div id="divInfo">
                <uc1:ctrAuditoria runat="server" ID="ctrAuditoria" />
            </div>
            <div id="divTabs">
                <div id="tabsAuditoria" style="overflow:hidden; width:100%">
                    <ul>
                        <li><a href="#tabs-1A">Procedimientos</a></li>
                        <li><a href="#tabs-2A">Diagnósticos</a></li>
                        <li><a href="#tabs-3A">Hallazgo</a></li>
                        <li><a href="#tabs-4A">Notas</a></li>
                        <li><a href="#tabs-5A">Pendientes Concurrencia</a></li>
                    </ul>
                    <div id="tabs-1A" style="overflow:hidden;" >
                        <uc1:ctrProcedimientos runat="server" ID="ctrProcedimientos" />
                    </div>
                    <div id="tabs-2A" style="overflow:hidden;" >
                        <uc1:CtrDxLista runat="server" id="CtrDxLista" />
                    </div>
                    <div id="tabs-3A">
                        <uc1:ctrHallazgos runat="server" ID="ctrHallazgos" />
                    </div>
                    <div id="tabs-4A">
                        <uc1:ctrNotas runat="server" ID="ctrNotas" />
                    </div>
                    <div id="tabs-5A">
                        <uc1:ctrPtesConcur runat="server" ID="ctrPtesConcur" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
