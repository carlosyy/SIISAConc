<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SIISAConc.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SIISAConc._default" %>
<%@ Register Src="webControls/login/ctrLogin.ascx" TagName="ctrLogin" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cphContenido">
    <div style="margin: 0 auto 0 auto; width: 590px; text-align: center;">
        <asp:Panel ID="pnlLogin" runat="server">
            <uc1:ctrLogin ID="ctrLogin1" runat="server" />            
        </asp:Panel>
    </div>    
</asp:Content>

