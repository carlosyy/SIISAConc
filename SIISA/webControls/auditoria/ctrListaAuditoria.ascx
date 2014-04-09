<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrListaAuditoria.ascx.cs" Inherits="SIISAConc.webControls.auditoria.ctrListaAuditoria" %>
<%@ Register Src="~/webControls/concurrencia/ctrAtencEstablecidas.ascx" TagPrefix="uc1" TagName="ctrAtencEstablecidas" %>
<%@ Register Src="~/webControls/estadoAtenc/ctrEstadoAtenc.ascx" TagPrefix="uc1" TagName="ctrEstadoAtenc" %>

<link rel='stylesheet' type='text/css' href="../../CSS/fullcalendar.css" />
<link rel='stylesheet' type='text/css' href="../../CSS/jquery.qtip.css" />
<script data-require="jquery@*" data-semver="2.0.1" src="../../js/jquery-2.0.1.min.js"></script>
<script data-require="jqueryui@1.10.0" data-semver="1.10.0" src="../../js/jquery-ui.js"></script>
<script data-semver="1.6.4" src="../../js/fullcalendar.min.js"></script>
<script src="../../js/jquery.qtip.js"></script>


<script type="text/javascript">
    var mesActAuditoria;
    $(document).ready(function () {       

        var tooltip = $('<div/>').qtip({
            id: 'fullcalendar',
            prerender: true,
            content: {
                text: ' ',
                title: {
                    button: true
                },                
            },
            position: {
                my: 'bottom center',
                at: 'top center',
                target: 'mouse',
                viewport: $('#fullcalendar'),
                adjust: {
                    mouse: false,
                    scroll: false
                }
            },
            show: {
                modal: {
                    on: true,
                    blur: false
                }
            },
            hide: false,
            style: {
                minwidth:300,                
                classes: 'qtip-ligh',                
                //widget: true,
                width: 500
            }            
        }).qtip('api');

        $('#calendar').fullCalendar({
            buttonText: {
                prev: 'Ant',
                next: 'Sig',
                month: 'Mes',
                week: 'Semana',
                day: 'Dia'
            },
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'],
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            //weekends: false,
            height: 650,
            formatDate: "dd/MM/yyyy",
            eventClick: function (data, event, view) {                
                var datosObt = getDatosAuditoria(data.id);                
                var content = "<h3>Documento: " + datosObt.d[0].tipoDoc + " " + datosObt.d[0].docIden + "</h3>" +
                    "<h3>Nombre paciente: " + datosObt.d[0].nombreCompleto + "</h3>" +
                    "<p><b>Fecha de ingreso:</b> " + datosObt.d[0].fecIngreso + "<br />" +
                    "<p><b>Dias estancia:</b> " + datosObt.d[0].diasEstancia + "<b> Dx Ppal:</b> " + datosObt.d[0].codDx + " " + datosObt.d[0].dx + "<br />" +
                    "<p><b>Medico tratante:</b> " + datosObt.d[0].medico + "<b> Estado auditoria:</b> " + datosObt.d[0].estadoAtenc + "<br />" +
                    "<a style='float: right; background:#FACC2E; color:blue; font-weight:bold; border-radius:10%;' href=# onclick=auditar('" + data.id + "')>&nbsp;&nbsp;Auditar&nbsp;&nbsp;</a>";
                tooltip.set({
                    'content.text': content                    
                })
                .reposition(event).show(event);
            },
            dayClick: function () { tooltip.hide() },
            eventResizeStart: function () { tooltip.hide() },
            eventDragStart: function () { tooltip.hide() },                        
            eventMouseover: function (event, jsEvent, view) {                
                
            },

            viewDisplay: function (view) {
                tooltip.hide();
                if (mesActAuditoria != null) {
                    var mesActual = getFechaCalendar();                    
                    if (mesActAuditoria != mesActual) {                        
                        $('#calendar').fullCalendar('removeEvents');
                        fillRadicados(mesActual);
                        mesActAuditoria = mesActual;
                    }
                }                
            },
            
            //dayClick: function (date, view) {
                
            //    $('#calendar').fullCalendar('changeView', 'basicDay');
            //    $('#calendar').fullCalendar('gotoDate', date);
            //},
            header:
            {
                left: 'prev,next',
                center: 'title',
                right: 'month, basicWeek, basicDay'
            },
            eventRender: function (event, element) {
                element.css('cursor', 'pointer');                
                var control = element.find('.fc-event-title');                
                $(control).append("<p1><b>" + event.id + "</b></p1><p1> " + event.nombreCompleto + " </p1><p1 style='background:#FACC2E; color:blue; font-weight:bold; border-radius:50%;'>&nbsp;&nbsp;" + event.diasEstancia + "&nbsp;&nbsp;</p1>");                
            },
            eventAfterAllRender: function (view, element) {
                
            }

        });
        mesActAuditoria = getFechaCalendar();        
        fillRadicados(mesActAuditoria);
    });

    function getResul(result) {
        window.location.href = "../Concurrencia/Auditoria.aspx?rad=" + result;
        return false;
    }

    function auditar(radicado) {
        SIISAConc.WbsSIISAConc.encriptar(radicado, getResul);
    }

    function getFechaCalendar() {
        var dateCalendar = $("#calendar").fullCalendar('getDate');
        return [pad(1), pad(dateCalendar.getMonth() + 1), dateCalendar.getFullYear()].join('/');
    }

    function pad(s) { return (s < 10) ? '0' + s : s; }

    function fillRadicados(mes) {        
        var params = new Object();
        params.idUserAuditoria = 3;        
        params.mesAuditoria = mes;
        params = JSON.stringify(params);

        $.ajax({
            type: "POST",
            url: "ListaAuditoria.aspx/getAuditoriasXMesRadicado",
            data: params,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (data) {                
                $.each(data.d, function () {
                    var eventObject = {                        
                        start: this.fecRadicado.split("/").reverse().join("-"),
                        id: this.radicado,                        
                        nombreCompleto: this.nombreCompleto,
                        diasEstancia: this.diasEstancia,                        
                        color: this.estadoAtenc == "Radicado" ? '#0489B1' : '#A4A4A4'
                    };
                    $('#calendar').fullCalendar('renderEvent', eventObject, true);                    
                });
            }
        });
    }

    function getDatosAuditoria(radicado) {
        var params = new Object();        
        params.radicado = radicado;
        params = JSON.stringify(params);
        var datos;
        $.ajax({
            type: "POST",
            url: "ListaAuditoria.aspx/getDatosAuditoria",
            data: params,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (data) {
                datos = data;
                
            }
        });
        return datos;
    }

    function getResul(result) {
        window.location.href = "../Concurrencia/Auditoria.aspx?rad=" + result;
        return false;
    }
</script>

<style>
    .fc-day-content div {
        /*max-height: 120px;
        overflow-y: auto;*/
    }
    .fc-day-conten {
    width: 100%; 
    height: 550px;
    position: absolute;
    bottom:0;
    overflow-y: scroll;
    }
    h1 {
        background-color: #c7c7c7;
        border-radius: 10px;
        text-align: center;
    }
    /*.fc-other-month .fc-day-content{display:none;}*/
</style>
<h1>LISTA DE RADICADOS ESTABLECIDOS</h1>
<div style="width: 100%">    
    <div id='calendar'></div>
</div>
