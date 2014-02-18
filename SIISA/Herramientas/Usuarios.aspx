<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SIISAConc.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="SIISAConc.Herramientas.Usuarios" %>
<%@ Register Src="~/webControls/usuarios/ctrAddUsuario.ascx" TagPrefix="uc1" TagName="ctrAddUsuario" %>
<%@ Register src="../webControls/usuarios/ctrListUsuarios.ascx" tagname="ctrListUsuarios" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    

    <asp:Panel ID="pnlLista" runat="server">
        <uc2:ctrListUsuarios ID="ctrListUsuarios1" runat="server" />
    </asp:Panel>
    <asp:Panel ID="pnlDetalle" runat="server" Visible="false">
        <uc1:ctrAddUsuario runat="server" ID="ctrAddUsuario" />
    </asp:Panel>
</asp:Content>
