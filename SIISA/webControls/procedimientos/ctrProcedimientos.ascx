<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrProcedimientos.ascx.cs" Inherits="SIISAConc.webControls.procedimientos.ctrProcedimientos" %>
<script>
    $(document).ready(function () {
        $("#txtBusqServ").change(function () {
            if ($("#txtBusqServ").val().length > 5) {
                getServicios();
            } else {
                $(this).notify('Debe establecer un criterio de búsqueda más largo.');
                $(this).select();
            }
            return false;
        });

        $("#ddlServicio").change(function() {
            $("#lblConcepto").text(this.options[this.selectedIndex].getAttribute("cpto"));
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
        console.log('a');
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

    function addServiciosAtencion() {        
        var params = new Object();
        params.tipoAutorizacion = $("#txtBusqServ").val();
        params.noAutorizacion = $("#txtBusqServ").val();
        params.codServ = $("#txtBusqServ").val();
        params.radicado = $("#txtBusqServ").val();
        params.idUser = '<%= Session["idUser"].ToString()%> ';

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
        return false;
    }

    function bindGridView() {
        $.ajax({
            type: "POST",
            url: "Auditoria.aspx/getServicios",
            data: "{}",
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                for (var i = 0; i < data.d.length; i++) {
                    $("#NamesGridView").append("<tr><td>" + data.d[i].FirstName +
                                                "</td><td>" + data.d[i].Age + "</td></tr>");
                }
            }
        })
    }
</script>
<table>                        
    <tr>                
        <td colspan="8" style="background-color: #DADADA; text-align: center; color: #0000FF;">
            <div style="width:100%">
                Datos del Servicio
            </div>                    
        </td>
    </tr>
    <tr>
        <td>
            <div style="float:left;width:59%">
                Busq Servicio
            </div>
        </td>                
        <td colspan="7">
            Cod/Descrip Servicio
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtBusqServ" AutoCompleteType="Search" TabIndex="1" runat="server" ClientIDMode="Static"></asp:TextBox>
        </td>
        <td colspan="7">
            <asp:DropDownList ID="ddlServicio" TabIndex="2" runat="server" Width="650px" ClientIDMode="Static"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            Concepto
        </td>
        <td>
            #Autorización
        </td>
        <td>
            Tipo Autoriz
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Label ID="lblConcepto" ClientIDMode="Static" runat="server" ValidationGroup="datos" Width="263px"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAutorizacion" runat="server" TabIndex="4" ValidationGroup="datos" Width="104px">0</asp:TextBox>
        </td>
        <td>
            <asp:DropDownList ID="ddlTipoAutoriz" runat="server" TabIndex="5" >
                <asp:ListItem Selected="True" Text=".::Seleccione::." Value="0"></asp:ListItem>
                <asp:ListItem Text="Telefonica" Value="1"></asp:ListItem>
                <asp:ListItem Text="Regional" Value="2"></asp:ListItem>
            </asp:DropDownList>                    
        </td>
        <td>
            <asp:ImageButton ID="btnGuardarServ" runat="server" AccessKey="G" CommandName="guardarServ" TabIndex="9" ImageUrl="~/Images/icons/bi/guardar.png" ToolTip="Guardar Servicio ( Alt + G)" ValidationGroup="datos" Width="25px" /><%--OnClick="btnGuardarServ_Click"--%>
        </td>
    </tr>
</table>
<asp:Label ID="lblServRips" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>        
<br>
<br>
<asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="codServ" HeaderText="Cod procedimiento" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Servicio" HeaderText="Nombre procedimiento" />
        <asp:BoundField ItemStyle-Width="150px" DataField="autorizacion" HeaderText="No. Autorización" />
    </Columns>
</asp:GridView>
