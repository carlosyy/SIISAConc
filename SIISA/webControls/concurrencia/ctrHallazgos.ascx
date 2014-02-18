<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrHallazgos.ascx.cs" Inherits="SIISAConc.webControls.concurrencia.ctrNotas" %>
<%@ Register Src="~/webControls/areasAtencion/ctrAreasAtencion.ascx" TagPrefix="uc1" TagName="ctrAreasAtencion" %>
<%@ Register Src="~/webControls/eventosAdversos/ctrEventosAdversos.ascx" TagPrefix="uc1" TagName="ctrEventosAdversos" %>
<%@ Register Src="~/webControls/noCalidad/ctrNoCalidad.ascx" TagPrefix="uc1" TagName="ctrNoCalidad" %>
<%@ Register Src="~/webControls/inoportunidad/ctrInoportunidad.ascx" TagPrefix="uc1" TagName="ctrInoportunidad" %>
<%@ Register Src="~/webControls/pertinencia/ctrPertinencia.ascx" TagPrefix="uc1" TagName="ctrPertinencia" %>



<asp:UpdatePanel UpdateMode="Conditional" runat="server" ID="uppGral">
    <ContentTemplate>
        <table style="width:100%">
            <tr>
                <td colspan="3">
                    <asp:Label runat="server" ID="lblUsuarioEstablecido" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Area
                </td>
                <td>
                    No Pertinencia
                </td>
                <td>
                    Inoportunidad
                </td>
            </tr>    
            <tr>
                <td>
                    <uc1:ctrAreasAtencion runat="server" ID="ctrAreasAtencion" />
                </td>
                <td>
                    <uc1:ctrPertinencia runat="server" id="ctrPertinencia" />
                </td>
                <td>
                    <uc1:ctrInoportunidad runat="server" id="ctrInoportunidad" />
                </td>
            </tr>
            <tr>
                <td>
                    No Calidad
                </td>
                <td colspan="2">
                    Eventos Adversos
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:ctrNoCalidad runat="server" id="ctrNoCalidad" />
                </td>
                <td colspan="2">
                    <uc1:ctrEventosAdversos runat="server" id="ctrEventosAdversos" />
                </td>
            </tr>
            <tr>
                <td colspan="3" >
                    Nota de hallazgo
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtHallazgo" TextMode="MultiLine" Height="69px" Width="755px"></asp:TextBox>
                    <asp:ImageButton ID="btnGuardar" runat="server" ImageUrl="" OnClick="btnGuardar_Click" Width="40px" AccessKey="G" ToolTip="Guardar Hallazgo ( Alt + G)" Height="40px" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:UpdatePanel UpdateMode="Conditional" runat="server" ID="uppGrilla">
                        <ContentTemplate>
                            <asp:GridView ID="gvServAtencConcur" runat="server" AutoGenerateColumns="False" GridLines="Vertical" OnRowCommand="gvServAtencConcur_RowCommand" >
                            <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField HeaderText="Area" DataField="nArea" />
                                    <asp:BoundField HeaderText="No Pertinencia" DataField="nPertinenciaAtencion" />
                                    <asp:BoundField HeaderText="Inoportunidad" DataField="nInoportunidadAtencion" />
                                    <asp:BoundField HeaderText="No Calidad" DataField="nNoCalidadAtencion" />
                                    <asp:BoundField HeaderText="Eventos Adversos" DataField="nEventosAdversosAtencion" />
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>                                            
                                            <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" CommandName="Editar" ImageUrl="~/Images/EnviarCorreo.png" AlternateText="Editar"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
            
                </td>
            </tr>
        </table>
    </ContentTemplate>
    <Triggers>
        <%--<asp:AsyncPostBackTrigger ControlID=""--%>
    </Triggers>
</asp:UpdatePanel>