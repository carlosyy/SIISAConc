<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrProcedimientos.ascx.cs" Inherits="SIISAConc.webControls.procedimientos.ctrProcedimientos" %>
<script>
    $(document).ready(function () {
        $('#divGrillaProc').height($('#divGrillaProc').parent().height() * 0.7);        
        $("#txtCantServ").addClass("textBoxCentrado");
        $("#txtVrUnit").addClass("textBoxCentrado");
        $("#txtVrTotal").addClass("textBoxCentrado");

        getServiciosAtencion();

        $("#txtBusqServ").change(function () {
            if ($(this).val().length > 5) {
                getServicios();
            } else {
                $(this).notify('Debe establecer un criterio de búsqueda más largo.', { position: "top" });
                $(this).select();
            }
            return false;
        });

        $(".textBoxCentrado").change(function (event) {            
            $("#divProcs").find(".textBoxCentrado").each(function () {                
                $(this).val() == "" ? $(this).val("0") : $(this).val();
            });
            switch (event.target.id) {
                case "txtCantServ":
                    var txtVrUnit = $("#txtVrUnit");
                    var txtVrTotal = $("#txtVrTotal");
                    if (txtVrUnit.val() > 0) {
                        txtVrTotal.val($(this).val() * txtVrUnit.val());
                    }
                    else {
                        txtVrUnit.val($(this).val() * txtVrTotal.val());
                    }
                    break;
                case "txtVrUnit":
                    var txtCantServ = $("#txtCantServ");
                    var txtVrTotal = $("#txtVrTotal");
                    if (txtCantServ.val() > 0) {
                        txtVrTotal.val($(this).val() * txtCantServ.val());
                    }
                    else {
                        txtCantServ.val(txtVrTotal.val() / $(this).val());
                    }
                    break;
                case "txtVrTotal":
                    var txtVrUnit = $("#txtVrUnit");
                    var txtCantServ = $("#txtCantServ");
                    if (txtCantServ.val() > 0) {
                        txtVrUnit.val($(this).val() / txtCantServ.val());
                    }
                    else {
                        txtCantServ.val($(this).val() / txtVrUnit.val());
                    }
                    break;
            }
        });

        $("#ddlServicio").change(function() {
            $("#lblConcepto").text(this.options[this.selectedIndex].getAttribute("cpto"));
            var concepto = $("#lblConcepto").text().substr(0, 10);            
            if (concepto == "MEDICAMENT" || concepto == "MATERIALES") {                
                $('div#divConcepto').width('22%');
                $('div#divAutorizacion').width('22%');
                $('div#divTipoAutorizacion').width('22%');
                $('div#divCantProc').css("display", "block");
                $('div#divVrUnitProc').css("display", "block");
                $('div#divVrTotProc').css("display", "block");
                $('div#divCantProc').width('8%');
                $('div#divVrUnitProc').width('8%');
                $('div#divVrTotProc').width('8%');                
            }
            else {
                $('div#divConcepto').width('30%');
                $('div#divAutorizacion').width('30%');
                $('div#divTipoAutorizacion').width('30%');
                $('div#divCantProc').css("display", "none");
                $('div#divVrUnitProc').css("display", "none");
                $('div#divVrTotProc').css("display", "none");
                $('div#divCantProc').width('0');
                $('div#divVrUnitProc').width('0');
                $('div#divVrTotProc').width('0');                
            }
            return false;
        });

        $("#ddlServicio").focusout(function () {
            $("#ddlServicio").attr('size', '1');
            return false;
        });

        $("#ddlServicio").focusin(function () {
            $("#ddlServicio").attr('size', '7');
            if (parseInt(window.sessionStorage.getItem("indexSeleccion")) > 0) {
                getIndexBusqueda(window.sessionStorage.getItem("indexSeleccion"));
                $("#lblConcepto").text(this.options[this.selectedIndex].getAttribute("cpto"));
            }
            return false;
        });

        $("#<%=txtBusqServ.ClientID%>").autocomplete({
            source: function(request, response) {
                var params = new Object();
                params.prefixText = $("#<%=txtBusqServ.ClientID%>").val();
                params.proceso = 1;
                params = JSON.stringify(params);

                $.ajax({
                    url: "Auditoria.aspx/getAutoCompletar",
                    data: params,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function(data) { return data; },
                    error: function(xmlHttpRequest, textStatus, errorThrown) {
                        alert(textStatus + ": " + xmlHttpRequest.responseText);
                    },
                    success: function(data) {
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
                $("#txtBusqServ").val(ui.item.value);
            },

            select: function (event, ui) {                
                window.sessionStorage.setItem("indexSeleccion", ui.item.indexSeleccion);
                $("#txtBusqServ").change();                
                return false;
            },

            minLength: 2
        });
    });    

    function getIndexBusqueda(indexSeleccion) {
        $("#ddlServicio").get(0).selectedIndex = indexSeleccion;
    }

    function getServicios() {        
        var params = new Object();
        params.busqDx = $("#txtBusqServ").val();
        params = JSON.stringify(params);

        $.ajax({
            type: "POST",
            url: "Auditoria.aspx/getServicios",
            data: params,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: loadPx,
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                alert(textStatus + ": " + xmlHttpRequest.responseText);
            }
        });        
        return false;
    }

    function getServiciosAtencion() {
        limpiarControles();
        var params = new Object();
        params.radicado = $("#hfRadicado").val();
        params = JSON.stringify(params);
        $.ajax({
            type: "POST",
            url: "Auditoria.aspx/getServiciosAtencionxRadicado",
            data: params,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (msg) {                
                $("[id*=gvServiciosAtencion] tr").not($("[id*=gvServiciosAtencion] tr:first-child")).remove();
                for (var i = 0; i < msg.d.length; i++) {                    
                    $("#gvServiciosAtencion").append("<tr><td>" + msg.d[i].codServ + "</td><td>" + msg.d[i].descripServ + "</td><td>" + msg.d[i].noAutorizacion + "</td><td>" + msg.d[i].concepto + "</td></tr>");
                }
                $('#gvServiciosAtencion').height($('#gvServiciosAtencion').parent().height());
            },
            error: function (msg) {
                alert("error " + msg.responseText);
            }
        });
        return false;
    }

    function addServiciosAtencion() {        
        if (validarGuardar()) {
            var params = new Object();
            params.tipoAutorizacion = $("#ddlTipoAutoriz").val();
            params.noAutorizacion = $("#txtAutorizacion").val();
            params.codServ = $("#ddlServicio").val();            
            params.idUser = 3;//'< % = Session["idUser"].ToString()%> '; //TODO: Cambiar
            params.radicado = $("#hfRadicado").val();
            params.indice = $("#ddlServicio").get(0).selectedIndex;
            params.txtBuscado = $("#txtBusqServ").val();
            params.cantServ = $("#txtCantServ").val();
            params.vrTotal = $("#txtVrTotal").val();            

            params = JSON.stringify(params);

            $.ajax({
                type: "POST",
                url: "Auditoria.aspx/AddServiciosAtencion",
                data: params,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (msg) {
                    $("#btnGuardarServ").notify("Se ha agregado el procedimiento satisfactoriamente.", { className: "success", position: "left bottom" });                    
                    getServiciosAtencion();
                    $('div#divCantProc').css("display", "none");
                    $('div#divVrUnitProc').css("display", "none");
                    $('div#divVrTotProc').css("display", "none");
                    $('div#divConcepto').animate({ width: '30%' }, 1000);
                    $('div#divAutorizacion').animate({ width: '30%' }, 1000);
                    $('div#divTipoAutorizacion').animate({ width: '30%' }, 1000);                    
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + ": " + xmlHttpRequest.responseText);
                }
            });
        }
        return false;
    }
    
    function loadPx(result) {
        $("#ddlServicio").html("");
        $("#ddlServicio").append($("<option></option>").attr("value", "0").text(".::Seleccione::.").attr("cpto", ""));
        
        $.each(result.d, function () {
            $("#ddlServicio").append($("<option></option>").attr("value", this.codServ).text(this.descripcion).attr("cpto", this.nombreConcepto));
        });
        if ($("#ddlServicio").children("option").length > 2) {
            $("#ddlServicio").notify("Determine el servicio.", { className: "info", position: "top" });
        } else {
            getIndexBusqueda(1);
        }
        $("#ddlServicio").focus();
        $("#ddlServicio").change();
        $("#divProcs").find(".textBoxCentrado").val("0");
        return false;
    }    

    function validarGuardar() {
        var ok = true;
        if ($("#ddlServicio").val() == "0") {
            $("#ddlServicio").notify("Establezca el procedimiento a agregar.", "warn");
            ok = false;
        }
        return ok;
    }

    function limpiarControles() {
        $("#txtBusqServ").val("");
        $("#ddlServicio").val("0");
        $("#lblConcepto").text("");
        $("#txtAutorizacion").val("");
        $("#ddlTipoAutoriz").val("0");
        $("#lblServRips").text("");
        $("#txtBusqServ").select();
    }

    function pressKeyGuardar(event) {
        var keyPress = event.keyCode;
        switch (keyPress) {
            case 13:
            case 32:
                event.preventDefault();
                addServiciosAtencion();
                break;
        }
    }

    
</script>
<div class="tabla" id="divProcs" style="width: 100%;">
    <div class="fila" style="width: 100%;">
        <div class="celda celdaTitulo" style="text-align:center; width: 100%;">
            Datos del Servicio
        </div>
    </div>
    <div class="fila" style="width: 25%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Busq Servicio
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox ID="txtBusqServ" AutoCompleteType="Search" TabIndex="1" runat="server" ClientIDMode="Static"></asp:TextBox>
        </div>
    </div>
    <div class="fila" style="width: 75%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Cod/Descrip Servicio
        </div>
        <div class="celda celdaControl" style="width: 100%; z-index:9999 !important">
            <asp:DropDownList ID="ddlServicio" TabIndex="2" CssClass="dropDown" runat="server" Width="650px" ClientIDMode="Static"></asp:DropDownList>
        </div>
    </div>
    <div id="divConcepto" class="fila" style="width: 30%;">
        <div class="celda celdaTitulo" style="width: 100%;">        
            Concepto
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:Label ID="lblConcepto" ClientIDMode="Static" runat="server"></asp:Label>
        </div>
    </div>
    <div id="divAutorizacion" class="fila" style="width: 30%;">
        <div class="celda celdaTitulo" style="width: 100%;"> 
            #Autorización
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox ID="txtAutorizacion" ClientIDMode="Static" runat="server" TabIndex="4" ValidationGroup="datos" Width="104px">0</asp:TextBox>
        </div>
    </div>
    <div id="divTipoAutorizacion" class="fila" style="width: 30%;">
        <div class="celda celdaTitulo" style="width: 100%;"> 
            Tipo Autoriz
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:DropDownList ID="ddlTipoAutoriz" runat="server" TabIndex="5" ClientIDMode="Static" >
                <asp:ListItem Selected="True" Text=".::Seleccione::." Value="0"></asp:ListItem>
                <asp:ListItem Text="Telefonica" Value="1"></asp:ListItem>
                <asp:ListItem Text="Regional" Value="2"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div id="divCantProc" class="fila" style="display:none; width:0;">
        <div class="celda celdaTitulo" style="width: 100%;"> 
            Cant Med
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox ID="txtCantServ" CssClass="textboxCentrado" ClientIDMode="Static" runat="server" TabIndex="6">0</asp:TextBox>
        </div>
    </div>
    <div id="divVrUnitProc" class="fila" style="display:none;  width:0;">
        <div class="celda celdaTitulo" style="width: 100%;"> 
            Vr Unit
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox ID="txtVrUnit" CssClass="textboxCentrado" ClientIDMode="Static" runat="server" TabIndex="7">0</asp:TextBox>
        </div>
    </div>
    <div id="divVrTotProc" class="fila" style="display:none; width:0;">
        <div class="celda celdaTitulo" style="width: 100%;"> 
            Vr total
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox ID="txtVrTotal" CssClass="textboxCentrado" ClientIDMode="Static" runat="server" TabIndex="8">0</asp:TextBox>
        </div>
    </div>
    <div class="fila" style="height:61px; width: 10%;">        
        <div class="celda celdaControl" style="height:100%; text-align:center; width: 100%;">
            Guardar
            <img style="cursor: pointer; vertical-align: middle;" onkeypress="pressKeyGuardar(event);" alt="Guardar Servicio ( Alt + G)" accesskey="g" tabindex="9" src="../../Images/icons/bi/guardar.png" onclick="addServiciosAtencion();" width="35" height="35" id="btnGuardarServ" />
        </div>    
    </div>
</div>
<asp:Label ID="lblServRips" runat="server" Font-Bold="True" ForeColor="Blue" ClientIDMode="Static"></asp:Label>        
<div style="float:left; height:15px; width: 100%;"></div>
<div class="celda celdaTitulo" style="float:left; width: 100%; text-align:center"> 
    Procedimientos agregados
</div>
<div id="divGrillaProc" style="float:left; width:100%; overflow: auto;">
    <asp:GridView ID="gvServiciosAtencion" runat="server" ClientIDMode="Static" AutoGenerateColumns="false" Width="100%">
        <Columns>
            <asp:BoundField ItemStyle-Width="150px" DataField="codServ" HeaderText="Cod procedimiento" />
            <asp:BoundField ItemStyle-Width="150px" DataField="descripServ" HeaderText="Nombre procedimiento" />
            <asp:BoundField ItemStyle-Width="150px" DataField="noAutorizacion" HeaderText="No. Autorización" />
            <asp:BoundField ItemStyle-Width="150px" DataField="concepto" HeaderText="Concepto" />
        </Columns>
    </asp:GridView>
</div>
