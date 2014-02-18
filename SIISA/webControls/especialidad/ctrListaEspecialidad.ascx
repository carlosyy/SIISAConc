<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrListaEspecialidad.ascx.cs" Inherits="SIISAConc.webControls.especialidad.CtrListaEspecialidad" %>
<table style="width: 520px">
    <tr>
        <td>LISTA DE ESPECIALIDADES</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Repeater ID="rptEspecialidades" runat="server">
                <HeaderTemplate>
                    <table >
                        <tr>
                            <td>Id
                            </td>
                            <td>Especialidad
                            </td>
                            <td>SubMayor
                            </td>
                            <td>Clase
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href='/Archivo/Especialidades.aspx?IdEspecialidad=<%#DataBinder.Eval(Container.DataItem, "Idespecialidad") %>'>
                                <%#DataBinder.Eval(Container.DataItem, "Idespecialidad") %>
                            </a>
                        </td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Especialidad") %></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "SubMayor") %></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Clase") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate></table></FooterTemplate>
            </asp:Repeater>
        </td>
    </tr>
    <tr>
        <td>
            <asp:ImageButton runat="server" ImageUrl="~/Images/icons/bi/nuevo.png" Width="25px" ID="btnNuevo" OnClick="btnNuevo_Click"></asp:ImageButton>
        </td>
    </tr>
</table>

