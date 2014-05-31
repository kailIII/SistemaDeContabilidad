<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Reportes.aspx.cs" Inherits="_Reportes" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery.maskedinput.min.js"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(function () {
                jQuery(document).ready(function ($) {
                    $(".dateField").mask("99/99/9999");
                });
            });
        }
    </script>
   
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="min-height: 500px;">

        <h1>Reportes</h1>
        </br>

        <div class="container">
            <asp:Label ID="lblNameContribuyente" runat="server"></asp:Label>
        </div>

        <div class="container">
            <asp:Label ID="lblReportType" runat="server" Text="Tipo de reporte:" CssClass="lblReport" Font-Bold="true"></asp:Label>
            <asp:DropDownList ID="drpReportType" runat="server" CssClass="txtReport" AutoPostBack="true" ></asp:DropDownList>
        </div>

        <div class="container">
            <asp:Label ID="lblDesde" runat="server" Text="Desde:" CssClass="lblReport" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="txtDesde" runat="server" CssClass="txtReport dateField" AutoPostBack="false" TextMode="SingleLine" onkeydown = "enterPreventDefault(event);"></asp:TextBox>
            <asp:Label ID="lblHasta" runat="server" Text="Hasta:" CssClass="lblReport" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="txtHasta" runat="server" CssClass="txtReport dateField" AutoPostBack="false" TextMode="SingleLine" onkeydown = "enterPreventDefault(event);"></asp:TextBox>
        </div>

        <asp:Button ID="generateReport" runat="server" Text="Generar reporte" CssClass="ui-widget ui-state-default systemButton" OnClick="generateReport_Click" CausesValidation="false"/>

    </div>
</asp:Content>
