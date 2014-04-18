<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="DetalleContribuyente.aspx.cs" Inherits="_DetalleContribuyente" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
	    $(document).ready(function () {
	        $("a.level1:contains('Detalle')").parent().addClass("item_active");
	    });
    </script> 

    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="min-height: 500px; padding:5% 10% 5% 10%;">

        <div class="container">
            <asp:Label ID="lblNameContribuyente" runat="server" Text="Nombre del contribuyente:" CssClass="lblDetail" Font-Bold="true"></asp:Label>
            <asp:Label ID="txtNameContribuyente" runat="server" CssClass="txtDetail" ></asp:Label>
        </div>

        <div class="container">
            <asp:Label ID="lblCedulaContribuyente" runat="server" Text="Cédula del contribuyente:" CssClass="lblDetail" Font-Bold="true"></asp:Label>
            <asp:Label ID="txtCedulaContribuyente" runat="server" CssClass="txtDetail" ></asp:Label>
        </div>

        <div class="container">
            <asp:Label ID="lblNameRepresentante" runat="server" Text="Nombre del Representante:" CssClass="lblDetail" Font-Bold="true"></asp:Label>
            <asp:Label ID="txtNameRepresentante" runat="server" CssClass="txtDetail" ></asp:Label>
        </div>

        <div class="container">
            <asp:Label ID="lblAddress" runat="server" Text="Dirección:" CssClass="lblDetail" Font-Bold="true"></asp:Label>
            <asp:Label ID="txtAddress" runat="server" CssClass="txtDetail" ></asp:Label>
        </div>

        <div class="container">
            <asp:Label ID="lblTipoContribuyente" runat="server" Text="Tipo de contribuyente:" CssClass="lblDetail" Font-Bold="true"></asp:Label>
            <asp:Label ID="txtTipoContribuyente" runat="server" CssClass="txtDetail" ></asp:Label>
        </div>

        <div class="container">
            <asp:Label ID="lblLastPeriod" runat="server" Text="Último período:" CssClass="lblDetail" Font-Bold="true"></asp:Label>
            <asp:Label ID="txtLastPeriod" runat="server" CssClass="txtDetail" ></asp:Label>
        </div>

        <div class="divider"></div>

        <div style="float:left;">
            <h1>Administrar facturas de compras y ventas</h1>

            <asp:Button ID="facVentasClicked" runat="server" Text="Facturación Ventas" OnClick="facVentasClicked_Click" CssClass="ui-widget ui-state-default systemButton" CausesValidation="false"/>
            <asp:Button ID="facComprasClicked" runat="server" Text="Facturación Compras" OnClick="facComprasClicked_Click" CssClass="ui-widget ui-state-default systemButton" CausesValidation="false"/>

        </div>

        <div class="divider"></div>

        <div style="float:left;">
            <h1>Consultar diferentes reportes del contribuyente</h1>

            <asp:Button ID="btnReport" runat="server" Text="Reportes" OnClick="btnReport_Click" CssClass="ui-widget ui-state-default systemButton" CausesValidation="false"/>

        </div>

    </div>
</asp:Content>
