<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrAtencEstablecidas.ascx.cs" Inherits="SIISAConc.webControls.concurrencia.CtrAtencEstablecidas" %>

<asp:Button runat="server" ClientIDMode="Static" ID="btnGetAtencEstab" OnClick="btnGetAtencEstab_OnClick" Style="display: none;" />
<asp:GridView ID="gvResultados" runat="server" AutoGenerateColumns="False" EmptyDataText="Sin registros" Width="100%" DataKeyNames="idRadicado">
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
                <asp:Label runat="server" ID="lblHDCodDx" Text="CodDx"></asp:Label>
                <img id="imgOrdenar3" style="display: none; cursor: pointer" title="Ordenar por código de diagnóstico" src="../../Images/icons/bi/flechaAbajo.png" onclick="ordenar(3);" width="15" height="15" />
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
