<%@ Page Title="FacturaciónCompras" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="FacturaciónCompras.aspx.cs" Inherits="FacturaciónCompras" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/FacturasCompras.js"></script>
    <script src="Scripts/jquery.maskedinput.min.js"></script>
    <script src="Scripts/TextFormatScriptCompras.js"></script>
    <script src="Scripts/moment.js"></script>
    <script src="Scripts/jquery.number.js"></script>
    <script src="Scripts/jquery.number.min.js"></script>
    <script src="Scripts/NumberValidator.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
            <asp:UpdatePanel runat="server" ID="UpdatePopUp">
                <Triggers>
                    
                </Triggers>
                <ContentTemplate>

                <div id="cntrlBtns">
                    <asp:Button ID="insertButton" runat="server" Text="Insertar" OnClick="insertButton_Click" CssClass="ui-widget ui-state-default systemButton" CausesValidation="false"/>
                    <asp:Button ID="updateButton" runat="server" Text="Modificar" OnClick="updateButton_Click" CssClass="ui-widget ui-state-default systemButton" CausesValidation="false"/>
                    <asp:Button ID="deleteButton" runat="server" Text="Eliminar" CssClass="ui-widget ui-state-default systemButton" OnClick="deleteButton_Click" CausesValidation="false"/>

                </div>

                <div class="divider"></div>

                <div id="invoiceFields">

                    <div class="coupleFieldContainer">

                        <div id="fieldProvCust" class="singleFieldContainer">
                            <asp:Label ID="lblProvCust" runat="server" Text="Proveedor:" CssClass="lblContainer"></asp:Label>
                            <asp:TextBox ID="txtProvCust" runat="server" CssClass="txtContainer"></asp:TextBox>
                            <asp:HiddenField ID="hfCustomerName" runat="server" />
                        </div>

                        <div id="fieldInvoiceNumber" class="singleFieldContainer">
                            <asp:Label ID="lblInvoiceNumber" runat="server" Text="Número de factura:" CssClass="lblContainer"></asp:Label>
                            <asp:TextBox ID="txtInvoiceNumber" runat="server" CssClass="txtContainer"></asp:TextBox>
                        </div>

                    </div>

                    <div class="coupleFieldContainer">

                        <div id="fieldDate" class="singleFieldContainer">
                            <asp:Label ID="lblDate" runat="server" Text="Fecha:" CssClass="lblContainer"></asp:Label>
                            <asp:TextBox ID="txtDate" runat="server" CssClass="txtContainer dateField" AutoPostBack="false" onblur="updateDate()" TextMode="SingleLine"></asp:TextBox>
                        </div>

                        <div id="fieldType" class="singleFieldContainer">
                            <asp:Label ID="lblInvoiceType" runat="server" Text="Tipo de factura:" CssClass="lblContainer"></asp:Label>
                            <asp:DropDownList ID="drpType" runat="server" CssClass="txtContainer" AutoPostBack="true" ></asp:DropDownList>
                        </div>

                    </div>

                    <div class="coupleFieldContainer">

                        <div id="fieldTerm" class="singleFieldContainer">
                            <asp:Label ID="lblTerm" runat="server" Text="Plazo:" CssClass="lblContainer"></asp:Label>
                            <asp:TextBox ID="txtTerm" runat="server" CssClass="txtContainer" AutoPostBack="false" onblur="updateDate()"></asp:TextBox>
                        </div>

                        <div id="expirationDate" class="singleFieldContainer">
                            <asp:Label ID="lblExpiration" runat="server" Text="Vencimiento:" CssClass="lblContainer"></asp:Label>
                            <asp:TextBox ID="txtExpiration" runat="server" CssClass="txtContainer dateField"></asp:TextBox>
                        </div>

                    </div>

                <div class="coupleFieldContainer">

                    <div id="montoExempt" class="txtInvoice">
                        <asp:Label ID="lblMontoExempt" runat="server" Text="Monto exento:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtMontoExempt" runat="server" CssClass="txtContainer" onkeydown="return jsDecimals(event);" AutoPostBack="false" onblur="blurFunction(this)"></asp:TextBox>
                    </div>

                    <div id="porDescExempt" class="txtInvoice">
                        <asp:Label ID="lblPorDescExempt" runat="server" Text="Porcentaje descuento:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtPorDescExempt" runat="server" CssClass="txtContainer" onkeydown="return jsDecimals(event);" AutoPostBack="false" onblur="blurFunction(this)"></asp:TextBox>
                    </div>

                    <div id="desExempt" class="txtInvoice">
                        <asp:Label ID="lblDesExempt" runat="server" Text="Descuento exento:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtDesExempt" runat="server" CssClass="txtContainer" onkeydown="return jsDecimals(event);" AutoPostBack="false" onblur="blurFunction(this)"></asp:TextBox>
                    </div>

                    <div id="subExempt" class="txtInvoice">
                        <asp:Label ID="lblSubExempt" runat="server" Text="Subtotal exento:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtSubExempt" runat="server" CssClass="txtContainer" onkeydown="return jsDecimals(event);" AutoPostBack="false" onblur="blurFunction(this)"></asp:TextBox>
                    </div>

                    <div id="montoTaxed" class="txtInvoice">
                        <asp:Label ID="lblMontoTaxed" runat="server" Text="Monto gravado:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtMontoTaxed" runat="server" CssClass="txtContainer" onkeydown="return jsDecimals(event);" AutoPostBack="false" onblur="blurFunction(this)"></asp:TextBox>
                    </div>

                    <div id="porDescTaxed" class="txtInvoice">
                        <asp:Label ID="lblPorDescTaxed" runat="server" Text="Porcentaje gravado:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtPorDescTaxed" runat="server" CssClass="txtContainer" onkeydown="return jsDecimals(event);" AutoPostBack="false" onblur="blurFunction(this)"></asp:TextBox>
                    </div>

                    <div id="desTaxed" class="txtInvoice">
                        <asp:Label ID="lblDesTaxed" runat="server" Text="Descuento gravado:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtDesTaxed" runat="server" CssClass="txtContainer" onkeydown="return jsDecimals(event);" AutoPostBack="false" onblur="blurFunction(this)"></asp:TextBox>
                    </div>

                    <div id="fieldIV" class="txtInvoice">
                        <asp:Label ID="lblIV" runat="server" Text="Impuesto de Venta:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtIV" runat="server" CssClass="txtContainer" onkeydown="return jsDecimals(event);" AutoPostBack="false" onblur="blurFunction(this)"></asp:TextBox>
                    </div>

                    <div id="subTaxed" class="fieldContainer txtInvoice">
                        <asp:Label ID="lblSubTaxed" runat="server" Text="Subtotal gravado:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtSubTaxed" runat="server" CssClass="txtContainer" onkeydown="return jsDecimals(event);" AutoPostBack="false" onblur="blurFunction(this)"></asp:TextBox>
                    </div>

                    <div id="fieldFlete" class="txtInvoice">
                        <asp:Label ID="lblFlete" runat="server" Text="Flete:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtFlete" runat="server" CssClass="txtContainer" onkeydown="return jsDecimals(event);" AutoPostBack="false" onblur="blurFunction(this)"></asp:TextBox>
                    </div>

                    <div id="fieldTotal" class="txtInvoice">
                        <asp:Label ID="lblTotal" runat="server" Text="Total:" CssClass="lblContainer"></asp:Label>
                        <asp:TextBox ID="txtTotal" runat="server" CssClass="txtContainer" onkeydown="return jsDecimals(event);" AutoPostBack="false" onblur="blurFunction(this)"></asp:TextBox>
                    </div>

                </div>

                </div>

                <div class="divider"></div>

                <div id="btnAcCa">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="ui-widget ui-state-default systemButton" CausesValidation="true"/>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="ui-widget ui-state-default systemButton" OnClick="btnCancelar_Click" CausesValidation="false"/>
                </div>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdateInfo" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAceptar" EventName="Click" />
                    
                </Triggers>
                <ContentTemplate>
                    <!-- Botones Invisibles -->
                    <asp:TextBox ID="txtSearch" runat="server" onkeydown = "enterBuscar(event, 'MainContent_btnSearch');"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="ui-widget ui-state-default systemButton" OnClick="btnSearch_Click"/>
            
                    <!-- Cuerpo con la tabla -->
                    <div style="min-height: 500px;">

                        <div class="grid_general">
                            <asp:GridView ID="GridViewFacturaCompras" CssClass="grid_general" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridViewFacturaCompras_PageIndexChanging" onrowcommand="GridViewFacturaCompras_RowCommand">
                                <Columns>
                                    <asp:ButtonField CommandName="selectFV" CausesValidation="false" ButtonType="Image" Visible="true" ImageUrl="Images/arrow-right.png" ControlStyle-Height="20px" ControlStyle-Width="20px"/>
                                </Columns>
                            </asp:GridView> 
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

                <div id="popUpDeleteFacturaCompra">
    
                        <asp:UpdatePanel runat="server" ID="UpdateDelete">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="deleteButton" EventName="Click" />
                            </Triggers>
                            <ContentTemplate>

                                <p>¿Está seguro que desea eliminar la factura?</p>

                                <div class="divider"></div>

                            <div id="btnsAcCaDelete">
                                <asp:Button ID="btnYesDel" runat="server" Text="Si" CssClass="ui-widget ui-state-default systemButton" OnClick="btnYesDel_Click" CausesValidation="false"/>
                                <asp:Button ID="btnNoDel" runat="server" Text="No" CssClass="ui-widget ui-state-default systemButton" OnClick="btnNoDel_Click" CausesValidation="false"/>
                            </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                </div> 

</asp:Content>
