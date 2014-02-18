<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrSetAtencion.ascx.cs" Inherits="SIISAConc.webControls.concurrencia.ctrSetAtencion" %>
<table>
    <tr>
        <td>
            Buscar Usuario:
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtBusqUsuario"></asp:TextBox>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td>
            <asp:GridView ID="gvAtencClinic" runat="server" AutoGenerateColumns="False" GridLines="Vertical" EmptyDataText="No hay registros con el filtro especificado.">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="Nombre Paciente" DataField="apellido_a" />
                    <asp:BoundField HeaderText="Fecha Ingreso" DataField="fechaIng" />
                    <asp:BoundField HeaderText="Fecha Egreso" DataField="fechaEgr" />
                    <asp:BoundField HeaderText="Dias Estancia" DataField="dias" />
                    <asp:BoundField HeaderText="Diagnostico" DataField="codDx1" />
                    <asp:BoundField HeaderText="Tipo Atencion" DataField="tipoAtencion" />
                    <asp:BoundField HeaderText="Cama" DataField="cama" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="btnSeleccionar" ImageUrl="~/Images/Editar1.png" CommandName="Seleccionar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>