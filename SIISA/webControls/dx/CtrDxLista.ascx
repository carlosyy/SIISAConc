<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrDxLista.ascx.cs" Inherits="SIISAConc.webControls.dx.CtrDxLista" %>
<script>
    $(document).ready(function () {

        getDxAtencion();        

        $("#txtBusqDx").change(function () {
            if ($(this).val().length > 3) {
                var params = new Object();
                params.busqDx = $("#txtBusqDx").val();
                params.top = 100;
                params = JSON.stringify(params);

                $.ajax({
                    type: "POST",
                    url: "concurrencia.aspx/getDx",
                    data: params,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    success: loadDx,
                    error: function (xmlHttpRequest, textStatus, errorThrown) {
                        alert(textStatus + ": " + xmlHttpRequest.responseText);
                    }
                });
            }
            else {
                $(this).notify("Debe establecer un criterio de búsqueda mas largo.")
                $(this).select();
            }
            return false;
        });

        $("#ddlDx").focusout(function () {
            $(this).attr('size', '1');
            return false;
        });

        $("#ddlDx").focusin(function () {
            $(this).attr('size', '7');
            return false;
        });
    });
    
        
    function loadDx(result) {
        //quito los options que pudiera tener previamente el combo
        $("#ddlDx").html("");
        $("#ddlDx").append($("<option></option>").attr("value", "0").text(".::Seleccione::."));
        //recorro cada item que devuelve el servicio web y lo añado como un opcion
        $.each(result.d, function () {
            $("#ddlDx").append($("<option></option>").attr("value", this.codDx).text(this.codYDx));
        });
        $("#ddlDx").notify("Determine el diagnóstico.", { className: "info", position: "bottom" });
        $("#ddlDx").focus();
        $("#ddlDx").get(0).selectedIndex = 1;
    }

    function getDxAtencion() {        
        var params = new Object();
        params.radicado = $("#hfRadicado").val();
        params = JSON.stringify(params);
        $.ajax({
            type: "POST",
            url: "Auditoria.aspx/getDxAtencionxRadicado",
            data: params,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (msg) {
                $("[id*=gvDxAtencion] tr").not($("[id*=gvDxAtencion] tr:first-child")).remove();
                for (var i = 0; i < msg.d.length; i++) {
                    if (msg.d[i].dxPpal) {
                        $("#gvDxAtencion").append("<tr><td>" + msg.d[i].codDx + "</td><td>" + msg.d[i].descripDx + "</td><td Style='text-align:center;'><input type='hidden' class='hfIdDx' value=" + msg.d[i].idDx + "><input type='radio' name='dxPpal' class='css-checkbox' id='radio" + msg.d[i].idDx + "' checked onclick='setDxPpal(this)' /><label for='radio" + msg.d[i].idDx + "' onclick='setDxPpal(this)' class='css-label'></label></td></tr>");
                    } else {
                        $("#gvDxAtencion").append("<tr><td>" + msg.d[i].codDx + "</td><td>" + msg.d[i].descripDx + "</td><td Style='text-align:center;'><input type='hidden' class='hfIdDx' value=" + msg.d[i].idDx + "><input type='radio' name='dxPpal' class='css-checkbox' id='radio" + msg.d[i].idDx + "' onclick='setDxPpal(this)' /><label for='radio" + msg.d[i].idDx + "' onclick='setDxPpal(this)' class='css-label'></label></td></tr>");
                    }                    
                }
                $('#gvDxAtencion').height($('#gvDxAtencion').parent().height());                
            },
            error: function (msg) {
                alert("error " + msg.responseText);
            }
        });
        
        return false;
    }

    function validarGuardarDx() {
        var ok = true;
        if ($("#ddlDx").val() == "0") {
            $("#ddlDx").notify("Establezca el diagnóstico a agregar.", "warn");
            ok = false;
        }
        return ok;
    }

    function addDxAtencion() {
        if (validarGuardarDx()) {
        //console.log($('#chkDxPpal').is(":checked"));
            var params = new Object();            
            params.codDx = $("#ddlDx").val();
            params.idUser = 3;//'< %= Session["idUser"].ToString()%> '; //TODO: Cambiar
            params.radicado = $("#hfRadicado").val();
            params.dxPpal = $('#chkDxPpal').is(":checked");
            
            params = JSON.stringify(params);

            $.ajax({
                type: "POST",
                url: "Auditoria.aspx/AddDxAtencion",
                data: params,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (msg) {
                    $("#btnGuardarDx").notify("Se ha agregado el diagnóstico satisfactoriamente.", { className: "success", position: "left" });
                    getDxAtencion();
                    limpiarControlesDx();
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + ": " + xmlHttpRequest.responseText);
                }
            });
        }
        return false;
    }

    function limpiarControlesDx() {
        $("#txtBusqDx").val("");
        $("#ddlDx").val("0");
        $("#chkDxPpal").val("0");
        $("#txtBusqDx").select();
    }

    function pressKeyGuardarDx(event) {
        var keyPress = event.keyCode;
        switch (keyPress) {
            case 13:
            case 32:
                event.preventDefault();
                addDxAtencion();
                break;
        }
    }

    function setDxPpal(control) {
        var params = new Object();
        params.radicado = $("#hfRadicado").val();
        params.idDx = $(control).parent('td').find(".hfIdDx:first").val();

        params = JSON.stringify(params);

        $.ajax({
            type: "POST",
            url: "Auditoria.aspx/setDxPpal",
            data: params,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (msg) {                
                $("#txtBusqDx").notify("Se ha actualizado el diagnóstico principal.", { className: "success", position: "bottom left" });
            },
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                alert(textStatus + ": " + xmlHttpRequest.responseText);
            }
        });
    }

</script>

<div class="tabla" style="width: 100%;">
    <div class="fila" style="width: 20%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Busq Diagnóstico
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox ID="txtBusqDx" AutoCompleteType="Search" TabIndex="1" runat="server" ClientIDMode="Static"></asp:TextBox>
        </div>
    </div>
    <div class="fila" style="width: 63%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Establecer Diagnóstico
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:DropDownList ID="ddlDx" TabIndex="2" runat="server" ClientIDMode="Static" AppendDataBoundItems="true" CssClass="dropDown" Style="max-width: 700px; min-width: 300px;">
                <asp:ListItem Text=".::Seleccione::." Value="0"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="fila" style="height: 61px; width: 8%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            dx Ppal            
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:CheckBox runat="server" ID="chkDxPpal" ClientIDMode="Static" TabIndex="3" />
        </div>
    </div>
    <div class="fila" style="height: 61px; width: 8%;">
        <div class="celda celdaControl" style="height: 100%; text-align: center; width: 100%;">
            Guardar
            <img style="cursor: pointer; vertical-align: middle;" onkeypress="pressKeyGuardarDx(event);" alt="Guardar Dx ( Alt + d)" accesskey="d" tabindex="4" src="../../Images/icons/bi/guardar.png" onclick="addDxAtencion();" width="35" height="35" id="btnGuardarDx" />
        </div>
    </div>
    <div style="float: left; height: 15px; width: 100%;">        
    </div>
    <div id="divGrillaProc" style="float: left; width: 100%; overflow: auto;">
        <asp:GridView ID="gvDxAtencion" runat="server" ClientIDMode="Static" AutoGenerateColumns="false" Style="width: 100%;">
            <Columns>
                <asp:BoundField DataField="codDx" HeaderText="Cod Dx" />
                <asp:BoundField DataField="descripDx" HeaderText="Nombre diagnóstico" />
                <asp:BoundField DataField="dxPpal" HeaderText="Dx Ppal" />
            </Columns>
        </asp:GridView>
    </div>
</div>

<%--<div style="background: #444; color: #fafafa; padding: 10px;">
    <h3>Dark Background</h3>
    <table>
        <tr>
            <td>
                <input type="radio" name="radiog_lite" id="radio1" class="css-checkbox" /><label for="radio1" class="css-label">Option 1</label></td>
            <td>
                <input type="radio" name="radiog_lite" id="radio2" class="css-checkbox" checked="checked" /><label for="radio2" class="css-label">Option 2</label></td>
            <td>
                <input type="radio" name="radiog_lite" id="radio3" class="css-checkbox" /><label for="radio3" class="css-label">Option 1</label></td>
        </tr>
    </table>
</div>
<div style="background: #fafafa; color: #222; padding: 10px;">
    <h3>Light Background</h3>
    <table>
        <tr>
            <td>
                <input type="radio" name="radiog_dark" id="radio4" class="css-checkbox" /><label for="radio4" class="css-label">Option 1</label></td>
            <td>
                <input type="radio" name="radiog_dark" id="radio5" class="css-checkbox" checked="checked" /><label for="radio5" class="css-label">Option 2</label></td>
            <td>
                <input type="radio" name="radiog_dark" id="radio6" class="css-checkbox" /><label for="radio6" class="css-label">Option 1</label></td>
        </tr>
    </table>
</div>--%>
