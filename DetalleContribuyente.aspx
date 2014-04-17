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
    <div style="min-height: 500px;">
        <asp:Label ID="lblNameContribuyente" runat="server" Text="Nombre del contribuyente:" CssClass="lblContainer"></asp:Label>
        <asp:TextBox ID="txtNameContribuyente" runat="server" CssClass="txtContainer" Enabled="false"></asp:TextBox>
        <asp:Label ID="lblCedulaContribuyente" runat="server" Text="Cédula del contribuyente:" CssClass="lblContainer"></asp:Label>
        <asp:TextBox ID="txtCedulaContribuyente" runat="server" CssClass="txtContainer" Enabled="false"></asp:TextBox>
        <asp:Label ID="lblNameRepresentante" runat="server" Text="Nombre del Representante:" CssClass="lblContainer"></asp:Label>
        <asp:TextBox ID="txtNameRepresentante" runat="server" CssClass="txtContainer" Enabled="false"></asp:TextBox>
        <asp:Label ID="lblAddress" runat="server" Text="Dirección:" CssClass="lblContainer"></asp:Label>
        <asp:TextBox ID="txtAddress" runat="server" CssClass="txtContainer" Enabled="false"></asp:TextBox>
        <asp:Label ID="lblTipoContribuyente" runat="server" Text="Tipo de contribuyente:" CssClass="lblContainer"></asp:Label>
        <asp:TextBox ID="txtTipoContribuyente" runat="server" CssClass="txtContainer" Enabled="false"></asp:TextBox>
        <asp:Label ID="lblLastPeriod" runat="server" Text="Último período:" CssClass="lblContainer"></asp:Label>
        <asp:TextBox ID="txtLastPeriod" runat="server" CssClass="txtContainer" Enabled="false"></asp:TextBox>

        <div class="divider"></div>

        <div>
            <h1>Administrar facturas de compras y ventas</h1>

            <asp:Button ID="facVentasClicked" runat="server" Text="Facturación Ventas" OnClick="facVentasClicked_Click" CssClass="ui-widget ui-state-default systemButton" CausesValidation="false"/>
            <asp:Button ID="facComprasClicked" runat="server" Text="Facturación Compras" OnClick="facComprasClicked_Click" CssClass="ui-widget ui-state-default systemButton" CausesValidation="false"/>

        </div>

        <div class="divider"></div>

        <div>
            <h1>Consultar diferentes reportes del contribuyente</h1>

        </div>

    </div>
</asp:Content>
