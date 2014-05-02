<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrFugas.ascx.cs" Inherits="SIISAConc.webControls.fugas.ctrFugas" %>
<%@ Register Src="~/webControls/fugas/ctrDdlTipoFuga.ascx" TagPrefix="uc1" TagName="ctrDdlTipoFuga" %>

<script>
    $(document).ready(function () {
        $('#divGrillaProc').height($('#divGrillaProc').parent().height() * 0.7);

        $("#txtBusqServFuga").change(function () {
            if ($(this).val().length > 5) {
                getServicios();
            } else {
                $(this).notify('Debe establecer un criterio de búsqueda más largo.', { position: "top" });
                $(this).select();
            }
            return false;
        });

        function getIndexBusquedaFuga(indexSeleccion) {
            $("#ddlServFuga").get(0).selectedIndex = indexSeleccion;
        }

        function getServFugas() {
            var params = new Object();
            params.busqDx = $("#txtBusqServFuga").val();
            params = JSON.stringify(params);

            $.ajax({
                type: "POST",
                url: "Auditoria.aspx/getServicios",
                data: params,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: loadServFugas,
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + ": " + xmlHttpRequest.responseText);
                }
            });
            return false;
        }

        function loadServFugas(result) {
            $("#ddlServFuga").html("");
            $("#ddlServFuga").append($("<option></option>").attr("value", "0").text(".::Seleccione::.").attr("cpto", ""));

            $.each(result.d, function () {
                $("#ddlServFuga").append($("<option></option>").attr("value", this.codServ).text(this.descripcion).attr("cpto", this.nombreConcepto));
            });
            if ($("#ddlServFuga").children("option").length > 2) {
                $("#ddlServFuga").notify("Determine el servicio.", { className: "info", position: "top" });
            } else {
                getIndexBusquedaFuga(1);
            }
            $("#ddlServFuga").focus();
            $("#ddlServFuga").change();
            
            return false;
        }

        $("#ddlServFuga").focusout(function () {
            $("#ddlServFuga").attr('size', '1');
            return false;
        });

        $("#ddlServFuga").focusin(function () {
            $("#ddlServFuga").attr('size', '7');
            if (parseInt(window.sessionStorage.getItem("indexSeleccionFuga")) > 0) {
                getIndexBusquedaFuga(window.sessionStorage.getItem("indexSeleccionFuga"));
                //$("#lblConcepto").text(this.options[this.selectedIndex].getAttribute("cpto"));
            }
            return false;
        });

        $("#txtBusqServFuga").autocomplete({
            source: function (request, response) {
                var params = new Object();
                params.prefixText = $(this).val();
                params.proceso = 1;
                params = JSON.stringify(params);

                $.ajax({
                    url: "Auditoria.aspx/getAutoCompletar",
                    data: params,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    error: function (xmlHttpRequest, textStatus, errorThrown) {
                        alert(textStatus + ": " + xmlHttpRequest.responseText);
                    },
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item.textoAutoCompletar,
                                value: item.textoAutoCompletar,
                                indexSeleccion: item.indexSeleccion
                            };
                        }));
                    }
                });
            },

            focus: function (event, ui) {
                $("#txtBusqServFuga").val(ui.item.value);
            },

            select: function (event, ui) {
                window.sessionStorage.setItem("indexSeleccionFuga", ui.item.indexSeleccion);
                $("#txtBusqServFuga").change();
                return false;
            },

            minLength: 2
        });
    });
</script>
<div class="tabla" id="divProcs">
    <div class="fila" style="width: 25%;">
        <div class="celda celdaTitulo" style="text-align: center;">
            Tipo Fuga
        </div>    
        <div class="celda celdaControl">
            <uc1:ctrDdlTipoFuga runat="server" id="ctrDdlTipoFuga" />
        </div>
    </div>
    <div class="fila" style="width: 15%;">
        <div class="celda celdaTitulo" style="text-align: center;">
            Busq Serv Fuga
        </div>
        <div class="celda celdaControl">
            <asp:TextBox runat="server" ID="txtBusqServFuga" ClientIDMode="Static"></asp:TextBox>
        </div>
    </div>
    <div class="fila" style="width: 59%;">
        <div class="celda celdaTitulo" style="text-align: center;">
            Serv Fuga
        </div>
        <div class="celda celdaControl" style="z-index: 9999 !important">
            <asp:DropDownList ID="ddlServFuga" TabIndex="2" CssClass="dropDown" runat="server" Width="650px" ClientIDMode="Static"></asp:DropDownList>
        </div>
    </div>
</div>
