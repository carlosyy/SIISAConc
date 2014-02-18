<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SIISAConc.Master" AutoEventWireup="true" CodeBehind="CargueConcurrencia.aspx.cs" Inherits="SIISAConc.Concurrencia.CargueConcurrencia" %>

<%@ Register Src="~/webControls/concurrencia/ctrCargueListPacie.ascx" TagPrefix="uc1" TagName="ctrCargueListPacie" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    <uc1:ctrCargueListPacie runat="server" id="ctrCargueListPacie" />    
</asp:Content>
