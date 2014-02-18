<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrBusqueda.ascx.cs" Inherits="SIISAConc.webControls.concurrencia.CtrBusqueda" %>
<%@ Register Src="~/webControls/concurrencia/ctrAddPacteConcurr.ascx" TagPrefix="uc1" TagName="ctrAddPacteConcurr" %>


<style type="text/css">
    .modal {
        text-align: center;
        font-family: Arial, Helvetica, sans-serif;
        top: 0;
        right: 0;
        bottom: 0;
        left: 0;
        background: #000000;
        background: rgba(0,0,0,0.8);
        z-index: 99999;
        display: none;
        -webkit-transition: opacity 400ms ease-in;
        -moz-transition: opacity 400ms ease-in;
        -ms-transition: opacity 400ms ease-in;
        -o-transition: opacity 400ms ease-in;
        transition: opacity 400ms ease-in;
    }

    .modal > div {
            text-align: center;
            width: 400px;
            position: relative;
            margin: 10% auto;
            padding: 5px 20px 13px 20px;
            -ms-border-radius: 10px;
            border-radius: 10px;
            background: #fff;
            background: -moz-linear-gradient(#fff, #999);
            background: -webkit-linear-gradient(#fff, #999);
            background: -o-linear-gradient(#fff, #999);
        }

    .close {
        background: #606061;
        color: #FFFFFF;
        line-height: 25px;
        position: absolute;
        right: -12px;
        text-align: center;
        top: -10px;
        width: 24px;
        text-decoration: none;
        font-weight: bold;
        -webkit-border-radius: 12px;
        -moz-border-radius: 12px;
        -ms-border-radius: 12px;
        border-radius: 12px;
        -moz-box-shadow: 1px 1px 3px #000;
        -webkit-box-shadow: 1px 1px 3px #000;
        -ms-box-shadow: 1px 1px 3px #000;
        box-shadow: 1px 1px 3px #000;
    }

    .close:hover {
            background: #00d9ff;
        }

    .notifyjs-foo-base {
  opacity: 0.85;
  width: 200px;
  background: #F5F5F5;
  padding: 5px;
  border-radius: 10px;
}

.notifyjs-foo-base .title {
  width: 100px;
  float: left;
  margin: 10px 0 0 10px;
  text-align: right;
}

.notifyjs-foo-base .buttons {
  width: 70px;
  float: right;
  font-size: 9px;
  padding: 5px;
  margin: 2px;
}

.notifyjs-foo-base button {
  font-size: 9px;
  padding: 5px;
  margin: 2px;
  width: 60px;
}
</style>

<script type="text/javascript">
    var _idRadicado;
    var _lblBtnEstablecer;
    var _tr;
    $(document).ready(function () {
        agregaBotonConfirm();
    });
    
    function showModal() {
        $("#divModal").animate({            
            height: "350px"
        }, 1000, function () {
            // Animation complete.
        });
        window.modal.style.display = 'block';
        window.modal.style.opacity = '1';
        window.modal.style.position = 'absolute';
        window.modal.style.pointerEvents = 'auto';
        document.getElementById('txtBusqDoc').select();        
    }
    function cerrar() {
        window.modal.style.display = 'none';
        window.divNuevoPaciente.style.display = 'none';
    }
    function escape() {
        var key = window.event.keyCode;
        if (key == 27) {
            cerrar();
        }
    }
    function aplicarFiltro() {
        var txtBusqDoc = document.getElementById('txtBusqDoc');
        var txtBusqNombre = document.getElementById('txtBusqNombre');
        var txtFecDesde = document.getElementById('txtFecDesde');
        var txtFecHasta = document.getElementById('txtFecHasta');
        var ddlNitNombre = document.getElementById('ddlNitNombre');
        var ddlCodDescrip = document.getElementById('ddlCodDescrip');
        var ddlProgramas = document.getElementById('ddlProgramas');
        
        var filtrandoPor = "Filtrando por: ";
        if (txtBusqDoc.value != "") {
            window.lblTextoFiltro.innerHTML += filtrandoPor + "*Documento=" + txtBusqDoc.value;
            filtrandoPor = ", ";
        }
        if (txtBusqNombre.value != "") {
            window.lblTextoFiltro.innerHTML += filtrandoPor + "*Nombre=" + txtBusqNombre.value;
            filtrandoPor = ", ";
        }
        if (txtFecDesde.value != "") {
            window.lblTextoFiltro.innerHTML += filtrandoPor + "*Fecha desde=" + txtFecDesde.value;
            filtrandoPor = ", ";
        }
        if (txtFecHasta.value != "") {
            window.lblTextoFiltro.innerHTML += filtrandoPor + "*Fecha hasta=" + txtFecHasta.value;
            filtrandoPor = ", ";
        }
        if (ddlNitNombre.options[ddlNitNombre.selectedIndex].value != "0") {
            window.lblTextoFiltro.innerHTML += filtrandoPor + "*Entidad=" + ddlNitNombre.options[ddlNitNombre.selectedIndex].text;
            filtrandoPor = ", ";
        }
        if (ddlCodDescrip.options[ddlCodDescrip.selectedIndex].value != "0") {
            window.lblTextoFiltro.innerHTML += filtrandoPor + "*DX=" + ddlCodDescrip.options[ddlCodDescrip.selectedIndex].text;
            filtrandoPor = ", ";
        }
        if (ddlProgramas.options[ddlProgramas.selectedIndex].value != "0") {
            window.lblTextoFiltro.innerHTML += filtrandoPor + "*Programa=" + ddlProgramas.options[ddlProgramas.selectedIndex].text;
            //filtrandoPor = ", ";
        }
        cerrar();
    }

    function ordenar(tipoOrden) {
        var hfOrden = document.getElementById('hfOrden');
        hfOrden.value = tipoOrden;
        var btnOrdenar = document.getElementById('btnOrdenar');
        btnOrdenar.click();
    }

    function agregaBotonConfirm() {
        $.notify.addStyle('foo', {
            html:
                "<div>" +
                    "<div class='warn' style='background:lightblue; float:left; font-weight:bold; width:250px'>" +
                    "<div class='title' data-notify-html='title' style='float:left; width:200px'/>" +
                    "<div class='buttons'>" +
                    "<button class='no'>No</button>" +
                    "<button class='yes' data-notify-text='button'></button>" +
                    "</div>" +
                    "</div>" +
                    "</div>"
        });

        //listen for click events from this style
        $(document).on('click', '.notifyjs-foo-base .no', function () {
            //programmatically trigger propogating hide event
            $(this).trigger('notify-hide');
            var btnOrdenar = document.getElementById('btnOrdenar');
            btnOrdenar.click();
        });
        $(document).on('click', '.notifyjs-foo-base .yes', function () {
            _tr = $(_lblBtnEstablecer).closest('tr');
            $(_tr).fadeOut('slow', function () { $(this).remove(); });
            //show button text
            SIISAConc.WbsSIISAConc.establecerAuditarWs(_idRadicado, getResultado);
            //hide notification
            $(this).trigger('notify-hide');
            return false;
        });
    }

    function establecerAuditar(idRadicado, nombrePaciente, control) {
        _idRadicado = idRadicado;
        _lblBtnEstablecer = document.getElementById(control);
        $(_lblBtnEstablecer).notify({
            title: '¿Esta seguro de establecer al paciente ' + nombrePaciente + ' para auditoria?.',
            button: 'Establecer'
        }, {
            style: 'foo',
            autoHide: false,
            clickToHide: false,
            elementPosition: 'left',
            gap: 16
        });
    }

    function getResultado(result) {
        if (result == 1) {
            $.notify("Auditoria establecida.", "info");
        }
    }

    function showImg(tipoOrden, mostrar) {
        var imgOrdenar = document.getElementById('imgOrdenar' + tipoOrden);
        if (mostrar == true) {
            imgOrdenar.style.display = 'block';
        }
            
        else {
            imgOrdenar.style.display = 'none';
        }
    }
    
    function nuevoPaciente() {
        $("#divNuevoPaciente").fadeIn('slow');
        window.divNuevoPaciente.style.display = 'block';
        window.divNuevoPaciente.style.opacity = '1';
        window.divNuevoPaciente.style.position = 'absolute';
        window.divNuevoPaciente.style.pointerEvents = 'auto';
        document.getElementById('txtBusqDoc').select();
        var btnNuevoPaciente = document.getElementById('btnNuevoPaciente');
        btnNuevoPaciente.click();
    }

</script>

<table style="text-align: center; width: 100%">
    <tr>
        <td>
            <div style="width: 100%">
                <div style="float: left; text-align: center;">
                    LISTA DE ATENCIONES EN ORDEN DE RELEVANCIA
                </div>
                <div style="text-align: right">
                    <label id="lblTextoFiltro" style="color:darkred"></label>
                    <img title="Aplicar Filtros" src="../../Images/filter.png" style="height: 25px; width: 25px; cursor: pointer;" onclick="showModal();" />
                </div>
            </div>
            <asp:UpdatePanel runat="server" ID="uppGrilla">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnOrdenar" ClientIDMode="Static" OnClick="btnOrdenar_OnClick" Style="display: none" />                    
                    <asp:HiddenField ID="hfOrden" ClientIDMode="Static" runat="server" Value="0" />
                    <asp:HiddenField ID="hfIdRadicado" ClientIDMode="Static" runat="server" Value="0" />
                    <asp:GridView ID="gvResultados" runat="server" AllowSorting="true" OnRowDataBound="gvResultados_RowDataBound" AutoGenerateColumns="False" OnRowCommand="gvResultados_RowCommand" EmptyDataText="Sin registros" Width="100%" DataKeyNames="idRadicado">
                        <Columns>                            
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label runat="server" ID="lblHDIdentificacion" Text="Identificacion"></asp:Label>
                                    <img id="imgOrdenar2" style="display: none; cursor: pointer" title="Ordenar por numero de identificación" src="../../Images/icons/bi/flechaAbajo.png" onclick="ordenar(2);" width="15" height="15" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblIdentificacion" Text='<%# DataBinder.Eval(Container.DataItem, "docIden") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label runat="server" ID="lblHDNombreUsuario" Text="Nombre de Usuario"></asp:Label>
                                    <img id="imgOrdenar6" style="display: none; cursor: pointer" title="Ordenar por nombre de usuario" src="../../Images/icons/bi/flechaAbajo.png" onclick="ordenar(6);" width="15" height="15" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblNombreUsuario" Text='<%# DataBinder.Eval(Container.DataItem, "nombre_a") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label runat="server" ID="lblHDFechaIngreso" Text="Fecha de Ingreso"></asp:Label>
                                    <img id="imgOrdenar0" style="display: none; cursor: pointer" title="Ordenar por fecha de ingreso" src="../../Images/icons/bi/flechaAbajo.png" onclick="ordenar(0);" width="15" height="15" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblFechaIngreso" Text='<%# DataBinder.Eval(Container.DataItem, "fecIngreso") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label runat="server" ID="lblHDFechaEgreso" Text="Fecha de Egreso"></asp:Label>
                                    <img id="imgOrdenar1" style="display: none; cursor: pointer" title="Ordenar por fecha de egreso" src="../../Images/icons/bi/flechaAbajo.png" onclick="ordenar(1);" width="15" height="15" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblFechaEgreso" Text='<%# DataBinder.Eval(Container.DataItem, "fecEgreso") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label runat="server" ID="lblHDCodDx" Text="CodDx"></asp:Label>
                                    <img id="imgOrdenar3" style="display: none; cursor: pointer" title="Ordenar por código de diagnóstico"  src="../../Images/icons/bi/flechaAbajo.png" onclick="ordenar(3);" width="15" height="15" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblCodDx" Text='<%# DataBinder.Eval(Container.DataItem, "codDx") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label runat="server" ID="lblHDCama" Text="Cama"></asp:Label>
                                    <img id="imgOrdenar4" style="display: none; cursor: pointer" title="Ordenar por tipo de cama" src="../../Images/icons/bi/flechaAbajo.png" onclick="ordenar(4);" width="15" height="15" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblCama" Text='<%# DataBinder.Eval(Container.DataItem, "cama") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label runat="server" ID="lblHDTipoEstancia" Text="Tipo de<br /> Estancia"></asp:Label>
                                    <img id="imgOrdenar5" style="display: none; cursor: pointer" title="Ordenar por tipo de estancia" src="../../Images/icons/bi/flechaAbajo.png" onclick="ordenar(5);" width="15" height="15" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblTipoEstancia" Text='<%# DataBinder.Eval(Container.DataItem, "tipoEstancia") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label runat="server" ID="lblHDDiasEstancia" Text="Dias <br />Estancia"></asp:Label>
                                    <img id="imgOrdenar8" style="display: none; cursor: pointer" title="Ordenar por dias de estancia" src="../../Images/icons/bi/flechaAbajo.png" onclick="ordenar(8);" width="15" height="15" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblDiasEstancia" Text='<%# DataBinder.Eval(Container.DataItem, "diasEstancia") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label runat="server" ID="lblHDPuntaje" Text="Puntaje"></asp:Label>
                                    <img id="imgOrdenar7" style="display: none; cursor: pointer" title="Ordenar por puntaje" src="../../Images/icons/bi/flechaAbajo.png" onclick="ordenar(7);" width="15" height="15" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPuntaje" Text='<%# DataBinder.Eval(Container.DataItem, "puntaje") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Estado" DataField="estadoRad" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblBtnEstablecer"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnOrdenar" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnFirst" runat="server" AccessKey="r" ToolTip="Ir a la primera página ( Alt + r )" Text="|<" OnClick="btnFirst_Click" />
            <asp:Button ID="btnPrev" runat="server" AccessKey="l" ToolTip="Ir a la página anterior ( Alt + l )" Text="<<" OnClick="btnPrev_Click" />
            <asp:Label ID="lblPagina" runat="server" ForeColor="#0099cc" Font-Bold="true"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlPagina" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="ddlPagina_SelectedIndexChanged"></asp:DropDownList>
            <asp:Button ID="btnNext" runat="server" AccessKey="n" ToolTip="Ir a la siguiente página ( Alt + n )" Text=">>" OnClick="btnNext_Click" />
            <asp:Button ID="btnLast" runat="server" AccessKey="u" ToolTip="Ir a la última página ( Alt + u )" Text=">|" OnClick="btnLast_Click" />
            <asp:Label ClientIDMode="Static" ID="lblFiltrado" runat="server" ForeColor="#0099cc" Font-Bold="true"></asp:Label>
        </td>
    </tr>
</table>
<asp:HiddenField runat="server" ID="hfPrograma" />
<asp:HiddenField runat="server" ID="hfNit" />
<asp:HiddenField runat="server" ID="hfCodDx" />
<asp:HiddenField runat="server" ID="hfPagina" />
<asp:HiddenField runat="server" ID="hf" />
<button id="btnaNuevoPaciente" type="button" style="width: 135px; height: 26px; cursor: pointer" onclick="nuevoPaciente();">
    <img src="../../Images/icons/bi/nuevo.png" style="vertical-align: top; width: 20px; height: 20px" alt="Agregar nuevo paciente" />Agregar nuevo paciente</button>

<%--Modal para agregar nuevo paciente*/--%>
<div id="divNuevoPaciente" onkeyup="escape();" class="modal">
    <div style="height: 370px; margin: 50px; width: 90%">
        <a onclick="cerrar();" id="A1" title="Close" class="close" style="cursor: pointer">X</a>
        <uc1:ctrAddPacteConcurr runat="server" ID="ctrAddPacteConcurr" />
    </div>
</div>
<%--Fin de modal--%>

<%--Modal para establecer filtros*/--%>
<div id="modal" onkeyup="escape();" class="modal">
    <div id="divModal">
        <a onclick="cerrar();" id="Close" title="Close" class="close" style="cursor: pointer">X</a>
        <table>
            <tr>
                <td colspan="2">
                    <div style="width: 100%">
                        <div style="float: left; width: 40%">
                            Documento:                    
                        </div>
                        <div style="float: left; width: 59%">
                            <asp:TextBox ClientIDMode="Static" ID="txtBusqDoc" Width="90%" runat="server"></asp:TextBox>
                        </div>
                    </div>

                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="width: 100%">
                        <div style="float: left; width: 40%">
                            Nombres:                    
                        </div>
                        <div style="float: left; width: 59%">
                            <asp:TextBox ClientIDMode="Static" ID="txtBusqNombre" Width="90%" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>Desde:
                    <asp:TextBox ClientIDMode="Static" runat="server" ID="txtFecDesde" />
                    <cc1:CalendarExtender ID="txtFecDesde_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFecDesde">
                    </cc1:CalendarExtender>
                </td>
                <td>Hasta:
                    <asp:TextBox ClientIDMode="Static" runat="server" ID="txtFecHasta" />
                    <cc1:CalendarExtender ID="txtFecHasta_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFecHasta">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="txtBusqEntidad" OnTextChanged="txtBusqEntidad_TextChanged" AutoPostBack="True"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender runat="server" Enabled="True" TargetControlID="txtBusqEntidad" WatermarkText="Buscar Entidad" WatermarkCssClass="watermarked" ID="txtBusqEntidad_TextBoxWatermarkExtender"></cc1:TextBoxWatermarkExtender>
                    <ajax:UpdatePanel ID="uppEntidad" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlNitNombre" ClientIDMode="Static" runat="server" Width="280px" OnDataBound="ddlNitNombre_DataBound"></asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <ajax:AsyncPostBackTrigger ControlID="txtBusqEntidad" EventName="TextChanged" />
                        </Triggers>
                    </ajax:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="txtBusqDx" AutoPostBack="True" OnTextChanged="txtBusqDx_TextChanged"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender runat="server" Enabled="True" TargetControlID="txtBusqDx" WatermarkText="Buscar DX" WatermarkCssClass="watermarked" ID="TextBoxWatermarkExtender1"></cc1:TextBoxWatermarkExtender>
                    <ajax:UpdatePanel ID="uppDx" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlCodDescrip" ClientIDMode="Static" Width="280px" runat="server"></asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <ajax:AsyncPostBackTrigger ControlID="txtBusqDx" EventName="TextChanged" />
                        </Triggers>
                    </ajax:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="txtBusqPrograma" AutoPostBack="True" OnTextChanged="txtBusqPrograma_TextChanged"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender runat="server" Enabled="True" TargetControlID="txtBusqPrograma" WatermarkText="Buscar Programa" WatermarkCssClass="watermarked" ID="TextBoxWatermarkExtender2"></cc1:TextBoxWatermarkExtender>
                    <ajax:UpdatePanel ID="uppPrograma" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlProgramas" ClientIDMode="Static" Width="280px" runat="server" OnDataBound="ddlProgramas_DataBound"></asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <ajax:AsyncPostBackTrigger ControlID="txtBusqPrograma" EventName="TextChanged" />
                        </Triggers>
                    </ajax:UpdatePanel>
                </td>
            </tr>
        </table>
        <button type="button" style="width: 135px; height: 26px; cursor: pointer" onclick="aplicarFiltro();">
            <img src="../../Images/filter.png" style="vertical-align: middle; width: 25px; height: 25px" alt="Continuar Detalle" />Aplicar Filtro 
        </button>
    </div>
</div>
<%--Fin de modal--%>