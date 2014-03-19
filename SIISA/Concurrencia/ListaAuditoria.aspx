<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SIISAConc.Master" AutoEventWireup="true" CodeBehind="ListaAuditoria.aspx.cs" Inherits="SIISAConc.Concurrencia.ListaAuditoria" %>

<%@ Register Src="~/webControls/auditoria/ctrListaAuditoria.ascx" TagPrefix="uc1" TagName="ctrListaAuditoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    <uc1:ctrListaAuditoria runat="server" ID="ctrListaAuditoria" />
</asp:Content>
