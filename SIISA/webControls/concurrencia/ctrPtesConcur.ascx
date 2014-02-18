<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrPtesConcur.ascx.cs" Inherits="SIISAConc.webControls.concurrencia.CtrPtesConcur" %>
<%@ Register Src="~/webControls/patologias/ctrDdlPatologias.ascx" TagPrefix="uc1" TagName="ctrDdlPatologias" %>

<%@ Register src="../areasAtencion/ctrAreasAtencion.ascx" tagname="ctrAreasAtencion" tagprefix="uc2" %>

<table>
    <tr>
        <td>
            Area Atencion:
        </td>
        <td>
            <uc2:ctrAreasAtencion ID="ctrAreasAtencion1" runat="server" />
        </td>
        <td>
            Patologia:
        </td>
        <td>
            <uc1:ctrDdlPatologias runat="server" ID="ctrDdlPatologias" />
        </td>
    </tr>
    <tr>        
        <td>                                            
            Busq Servicio            
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtBusqServ" AutoPostBack="True" OnTextChanged="txtBusqServ_TextChanged"></asp:TextBox>
        </td>
        <td>
            Cod/Descrip Servicio
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="uppServicio" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlServicio" TabIndex="2" runat="server"></asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtBusqServ" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>           
        </td>
        <td>
            Cant Servicio
            <asp:TextBox runat="server" ID="txtCantidad" Text="0" Width="56px"></asp:TextBox>
        </td>
        <td>
            <asp:ImageButton ID="btnGuardarServ" runat="server" AccessKey="G" CommandName="guardarServ" TabIndex="9" ImageUrl="../../Images/icons/bi/guardar.png" OnClick="btnGuardarServ_Click" ToolTip="Guardar Servicio ( Alt + G)" ValidationGroup="datos" Width="25px" />        
        </td>
    </tr>
    <tr>
        <td colspan="6">            
            <asp:GridView ID="gvServAtencConcur" runat="server" AutoGenerateColumns="False" GridLines="Vertical" >
            <AlternatingRowStyle BackColor="White" />
                <Columns>                   

                    <asp:TemplateField HeaderText="Cod Serv">
                        <ItemTemplate>                            
                            <asp:Label ID="lblCodServ" runat="server" Text='<%# Eval("codServ") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Descrip Serv">
                        <ItemTemplate>
                            <asp:Label ID="lblDescripServ" runat="server" Text='<%# Eval("descripServ") %>' Width="300px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                   

                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("cantServ") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>                                            
                            <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" CommandName="Editar" ImageUrl="~/Images/Editar1.png" AlternateText="Editar"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
<asp:Label runat="server" ID="lblErrorValid"></asp:Label>