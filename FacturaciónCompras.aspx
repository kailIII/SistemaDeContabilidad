<%@ Page Title="FacturaciónCompras" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="FacturaciónCompras.aspx.cs" Inherits="FacturaciónCompras" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
            <asp:ScriptManager ID="ScriptManager1" runat="server">	
            </asp:ScriptManager>
            <asp:UpdatePanel runat="server" ID="UpdatePopUp">
                <Triggers>
                    
                </Triggers>
                <ContentTemplate>

                <div id="cntrlBtns">
                    <asp:Button ID="updateButton" runat="server" Text="Modificar" OnClick="updateButton_Click" CssClass="ui-widget ui-state-default" CausesValidation="false"/>
                    <asp:Button ID="deleteButton" runat="server" Text="Eliminar" CssClass="ui-widget ui-state-default" OnClick="deleteButton_Click" CausesValidation="false"/>

                </div>

                <div class="divider"></div>

                <div id="invoiceFields">

                    <div id="fieldProvCust" class="fieldContainer">
                        <asp:Label ID="lblProvCust" runat="server" Text="Proveedor:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtProvCust" runat="server" CssClass="txtContainer"></asp:TextBox>
                    </div>

                    <div id="fieldInvoiceNumber" class="fieldContainer">
                        <asp:Label ID="lblInvoiceNumber" runat="server" Text="Número de factura:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtInvoiceNumber" runat="server" CssClass="txtContainer"></asp:TextBox>
                    </div>

                    <div id="fieldDate" class="fieldContainer">
                        <asp:Label ID="lblDate" runat="server" Text="Fecha:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtDate" runat="server" CssClass="txtContainer" TextMode="Date"></asp:TextBox>
                    </div>

                    <div id="fieldType" class="fieldContainer">
                        <asp:Label ID="lblInvoiceType" runat="server" Text="Tipo de factura:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtInvoiceType" runat="server" CssClass="txtContainer"></asp:TextBox>
                    </div>

                    <div id="fieldTerm" class="fieldContainer">
                        <asp:Label ID="lblTerm" runat="server" Text="Plazo:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtTerm" runat="server" CssClass="txtContainer"></asp:TextBox>
                    </div>

                    <div id="expirationDate" class="fieldContainer">
                        <asp:Label ID="lblExpiration" runat="server" Text="Vencimiento:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtExpiration" runat="server" CssClass="txtContainer"></asp:TextBox>
                    </div>

                    <div id="exemptFields">

                        <div id="montoExempt" class="fieldContainer">
                            <asp:Label ID="lblMontoExempt" runat="server" Text="Monto exento:" CssClass="lblContainer"></asp:Label>
                            <asp:TextBox ID="txtMontoExempt" runat="server" CssClass="txtContainer"></asp:TextBox>
                        </div>

                        <div id="porDescExempt" class="fieldContainer">
                            <asp:Label ID="lblPorDescExempt" runat="server" Text="Porcentaje descuento:" CssClass="lblContainer"></asp:Label>
                            <asp:TextBox ID="txtPorDescExempt" runat="server" CssClass="txtContainer"></asp:TextBox>
                        </div>

                        <div id="desExempt" class="fieldContainer">
                            <asp:Label ID="lblDesExempt" runat="server" Text="Descuento exento:" CssClass="lblContainer"></asp:Label>
                            <asp:TextBox ID="txtDesExempt" runat="server" CssClass="txtContainer"></asp:TextBox>
                        </div>

                        <div id="subExempt" class="fieldContainer">
                            <asp:Label ID="lblSubExempt" runat="server" Text="Subtotal exento:" CssClass="lblContainer"></asp:Label>
                            <asp:TextBox ID="txtSubExempt" runat="server" CssClass="txtContainer"></asp:TextBox>
                        </div>

                    </div>

                    <div id="taxedFields">

                        <div id="montoTaxed" class="fieldContainer">
                            <asp:Label ID="lblMontoTaxed" runat="server" Text="Monto gravado:" CssClass="lblContainer"></asp:Label>
                            <asp:TextBox ID="txtMontoTaxed" runat="server" CssClass="txtContainer"></asp:TextBox>
                        </div>

                        <div id="porDescTaxed" class="fieldContainer">
                            <asp:Label ID="lblPorDescTaxed" runat="server" Text="Porcentaje gravado:" CssClass="lblContainer"></asp:Label>
                            <asp:TextBox ID="txtPorDescTaxed" runat="server" CssClass="txtContainer"></asp:TextBox>
                        </div>

                        <div id="desTaxed" class="fieldContainer">
                            <asp:Label ID="lblDesTaxed" runat="server" Text="Descuento gravado:" CssClass="lblContainer"></asp:Label>
                            <asp:TextBox ID="txtDesTaxed" runat="server" CssClass="txtContainer"></asp:TextBox>
                        </div>

                        <div id="subTaxed" class="fieldContainer">
                            <asp:Label ID="lblSubTaxed" runat="server" Text="Subtotal gravado:" CssClass="lblContainer"></asp:Label>
                            <asp:TextBox ID="txtSubTaxed" runat="server" CssClass="txtContainer"></asp:TextBox>
                        </div>

                    </div>

                    <div id="fieldIV" class="fieldContainer">
                        <asp:Label ID="lblIV" runat="server" Text="Impuesto de Venta:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtIV" runat="server" CssClass="txtContainer"></asp:TextBox>
                    </div>

                    <div id="fieldFlete" class="fieldContainer">
                        <asp:Label ID="lblFlete" runat="server" Text="Flete:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtFlete" runat="server" CssClass="txtContainer"></asp:TextBox>
                    </div>

                    <div id="fieldTotal" class="fieldContainer">
                        <asp:Label ID="lblTotal" runat="server" Text="Total:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtTotal" runat="server" CssClass="txtContainer"></asp:TextBox>
                    </div>

                </div>

                <div class="divider"></div>

                <div id="btnAcCa">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="ui-widget ui-state-default" CausesValidation="true"/>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="ui-widget ui-state-default" OnClick="btnCancelar_Click" CausesValidation="false"/>
                </div>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
</asp:Content>
