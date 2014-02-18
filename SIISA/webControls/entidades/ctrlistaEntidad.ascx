
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlistaEntidad.ascx.cs" Inherits="SIISAConc.webControls.entidades.ctrlistaEntidad" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<script type="text/javascript">
    function confirmar() {
        var estado = document.getElementById("<%= hfEstado.ClientID %>").value;        
        if (estado == "r") {
            if (confirm("¿Esta seguro de la entidad seleccionada?")) {                
                return true;
            }
            else
                return false;
        }        
    }
    function Paginacion(pag) {
        //debugger
        document.getElementById("<%= hfPagina.ClientID %>").value = pag;
        __doPostBack("ctrLblPages")
    }
    window.onunload = (function () {
        window.opener.parent.alert("Por favor validar nuevamente los archivos.");
    });
</script>

<table border="1" width="50%">
    <tr>
        <td>LISTA DE ENTIDADES</td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtBuscarEnt" runat="server" Width="300px"></asp:TextBox>
            <asp:ImageButton runat="server" ImageUrl="~/Images/lupa.jpg" Width="25px" ID="btnBuscar" OnClick="btnBuscar_Click"></asp:ImageButton>

        </td>
    </tr>
    <tr>
        <td align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnFirst" runat="server" Text="|<" OnClick="btnFirst_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnPrev" runat="server" Text="<<" OnClick="btnPrev_Click" />
                    </td>
                    <td>
                        <asp:Label ID="ctrLblPages" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnNext" runat="server" Text=">>" OnClick="btnNext_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnLast" runat="server" Text=">|" OnClick="btnLast_Click" />
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hfPagina" runat="server" Value="1" />
            <asp:HiddenField ID="hfEstado" runat="server" Value="1" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvEntidad" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="gvEntidad_RowCommand">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="NIT">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkNIT" runat="server" Text='<%#Eval("Nit") %>' CommandName="Select" OnClientClick="return confirmar();"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Entidad" DataField="Entidad" />
                    <asp:TemplateField HeaderText="Capitado">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chbCapitado" Enabled="false" Checked='<%# Eval("capitado").ToString() == "1" ? true : false %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Regional " DataField="nombreReg" />
                    <asp:BoundField HeaderText="Municipio" DataField="depto" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>    
            <asp:ImageButton runat="server" ImageUrl="~/Images/Nuevo.PNG" Width="25px" ID="btnNuevo" OnClick="btnNuevo_Click"></asp:ImageButton>
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table>    
