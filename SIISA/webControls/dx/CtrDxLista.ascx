<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrDxLista.ascx.cs" Inherits="SIISAConc.webControls.dx.CtrDxLista" %>
<script>
    $(document).ready(function () {
        $("#txtBusqDx").change(function () {            
            var params = new Object();
            params.busqDx = $("#txtBusqDx").val();
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
    }

</script>
<div class="tabla" style="width: 100%;">
    <div class="fila" style="width: 25%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Busq Diagnóstico
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:TextBox ID="txtBusqDx" AutoCompleteType="Search" TabIndex="1" runat="server" ClientIDMode="Static"></asp:TextBox>
        </div>
    </div>
    <div class="fila" style="width: 74%;">
        <div class="celda celdaTitulo" style="width: 100%;">
            Establecer Diagnóstico
        </div>
        <div class="celda celdaControl" style="width: 100%;">
            <asp:DropDownList ID="ddlDx" TabIndex="2" runat="server" ClientIDMode="Static" AppendDataBoundItems="true">
                <asp:ListItem Text=".::Seleccione::." Value="0"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
</div>