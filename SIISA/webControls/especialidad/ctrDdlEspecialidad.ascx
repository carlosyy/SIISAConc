<%@ Control AutoEventWireup="true" CodeBehind="ctrDdlEspecialidad.ascx.cs" Inherits="SIISAConc.webControls.especialidad.CtrEspecialidad" Language="C#" %>
<script type="text/javascript">
    function setValorES(control) {
        var key = window.event.keyCode;
        var valor = 0;
        switch (key) {
            case 48:
            case 96:
                valor = 308;
                break;
            case 49:
            case 97:
                valor = 45;
                break;
            case 50:
            case 98:
                valor = 435;
                break;
            case 51:
            case 99:
                valor = 222;
                break;
            case 52:
            case 100:
                valor = 31;
                break;
            case 53:
            case 101:
                valor = 87;
                break;
            case 54:
            case 102:
                valor = 468;
                break;
            case 55:
            case 103:
                valor = 47;
                break;
            case 56:
            case 104:
                valor = 467;
                break;
            case 57:
            case 105:
                valor = 21;
                break;
        }
        if (valor > 0)
            document.getElementById(control).value = valor;
    }
</script>
<asp:DropDownList AppendDataBoundItems="True" ID="ddlEspecialidad" OnDataBound="ddlEspecialidad_DataBound" runat="server" Width="280px">
    <asp:ListItem Text=".::Seleccione::." Value="0"></asp:ListItem>
</asp:DropDownList>