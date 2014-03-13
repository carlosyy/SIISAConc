<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrListUsuarios.ascx.cs" Inherits="SIISAConc.webControls.ctrListUsuarios" %>
<div>
    <asp:TextBox ID="txtConsulta" runat="server" Width="247px"></asp:TextBox>
    <asp:Button ID="btnConsulta" runat="server" Text="Consultar" OnClick="btnConsulta_Click" />
</div>
<div>

    <asp:Repeater ID="rptUsuarios" runat="server" OnItemCommand="rptUsuarios_ItemCommand1">
        <HeaderTemplate>
            <table>
                <tr>
                    <td>
                        Documento
                    </td>
                    <td>
                        nick
                    </td>
                    <td>
                        Nombre
                    </td>
                    <td>
                        Perfil
                    </td>
                    <td>
                        Sucursal
                    </td>
                    <td>
                        Editar
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#DataBinder.Eval(Container.DataItem, "Documento") %>                    
                    <asp:Label runat="server" ID="lblIdUser" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "UsuarioID") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblNick" Text='<%#DataBinder.Eval(Container.DataItem, "Nick") %>'></asp:Label>
                </td>                    
                <td>
                    <%#DataBinder.Eval(Container.DataItem, "Nombre") %>
                </td>    
                <td>
                    <%#DataBinder.Eval(Container.DataItem, "Perfil") %>
                </td>
                <td>
                    <%#DataBinder.Eval(Container.DataItem, "Sucursal") %>
                </td>           
                <td>
                    <asp:ImageButton ID="btnEditarUs" runat="server" CausesValidation="False" CommandName="Editar" ImageUrl="~/Images/Editar1.png" AlternateText="Editar Usuario" ToolTip="Editar Usuario" />
                </td>
            </tr>            
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="~/Images/Nuevo.png" OnClick="btnNuevo_Click" Width="25px" ToolTip="Nuevo Usuario" CommandName="nuevo" />                        
</div>