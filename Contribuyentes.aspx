<%@ Page Title="Contribuyentes" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Contribuyentes.aspx.cs" Inherits="Contribuyentes" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/Contribuyentes.js"></script>
	<script type="text/javascript">
	    $(document).ready(function () {
	        $("a.level1:contains('Contribuyentes')").parent().addClass("item_active");
	    });
	</script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">           
                <asp:UpdatePanel ID="UpdateInfo" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAceptar" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <!-- Botones Invisibles -->
                        <asp:TextBox ID="txtSearch" runat="server" onkeydown = "enterBuscar(event, 'MainContent_btnSearch');"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="ui-widget ui-state-default systemButton" OnClick="btnSearch_Click" CausesValidation="false"/>
            
                        <!-- Cuerpo con la tabla -->
                        <div style="min-height: 500px;">
                            <asp:Button ID="btnInsertar" runat="server" Text="Insertar" CausesValidation="false" OnClick="btnInsertar_Click" CssClass="ui-widget ui-state-default"/>
                            <div class="grid_general">
                                <asp:GridView ID="GridViewContribuyentes" CssClass="grid_general" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridViewContribuyentes_PageIndexChanging" onrowcommand="GridViewContribuyentes_RowCommand">
                                    <Columns>
                                        <asp:ButtonField CausesValidation="false" CommandName="infoContribuyente" ButtonType="Image" Visible="true" ImageUrl="Images/arrow-right.png" ControlStyle-Height="20px" ControlStyle-Width="20px"/>
                                        <asp:ButtonField CommandName="selectContribuyente" CausesValidation="false" ButtonType="Image" Visible="true" ImageUrl="Images/edit.png" ControlStyle-Height="20px" ControlStyle-Width="20px"/>
                                    </Columns>
                                </asp:GridView> 
                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            

    <div id="popUpInfoContribuyente">
    
                <asp:UpdatePanel runat="server" ID="UpdatePopUp">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnInsertar" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>

                <div id="cntrlBtns">
                    <asp:Button ID="updateButton" runat="server" Text="Modificar" OnClick="updateButton_Click" CssClass="ui-widget ui-state-default" CausesValidation="false"/>
                    <asp:Button ID="deleteButton" runat="server" Text="Eliminar" CssClass="ui-widget ui-state-default" OnClick="deleteButton_Click" CausesValidation="false"/>
                    <asp:Button ID="manageCustomer" runat="server" Text="Asociar clientes" CssClass="ui-widget ui-state-default" OnClick="manageCustomer_Click" CausesValidation="false"/>
                    <asp:Button ID="manageProveedor" runat="server" Text="Asociar proveedores" CssClass="ui-widget ui-state-default" OnClick="manageProveedor_Click" CausesValidation="false"/>
                </div>

                <div class="divider"></div>

                <div id="codeContribuyente" class="fieldContainer">
                    <asp:Label ID="lblcodeContribuyente" runat="server" Text="Código:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtcodeContribuyente" runat="server" CssClass="txtContainer" Enabled="false"></asp:TextBox>
                </div>

                <div id="nombreContribuyente" class="fieldContainer">
                    <asp:Label ID="lblNombreContribuyente" runat="server" Text="Nombre contribuyente:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtNombreContribuyente" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ControlToValidate="txtNombreContribuyente" CssClass="error" ID="RequiredFieldValidatorNombre" runat="server" ErrorMessage="* Nombre de contribuyente requerido"  ForeColor="#FF3300" Display="Dynamic" font-size="Small" Font-Bold="true" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorNombre" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos."
                        ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\ |., ]{1,50}$" ControlToValidate="txtNombreContribuyente" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="cedulaContribuyente" class="fieldContainer">
                    <asp:Label ID="lblCedulaContribuyente" runat="server" Text="Cédula contribuyente:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtCedulaContribuyente" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ControlToValidate="txtCedulaContribuyente" CssClass="error" ID="RequiredFieldValidatorCedula" runat="server" ErrorMessage="* Cédula requerida"  ForeColor="#FF3300" Display="Dynamic" font-size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorCedula" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos. Ingrese únicamente caracteres numéricos"
                    ValidationExpression="[0-9]+" ControlToValidate="txtCedulaContribuyente" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorCedulaTam" CssClass="error"  runat="server" ErrorMessage="* Valor de la cédula entre 9 y 20 números"
                    ValidationExpression=".{9,20}" ControlToValidate="txtCedulaContribuyente" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="nombreRepresentante" class="fieldContainer">
                    <asp:Label ID="lblNombreRepresentante" runat="server" Text="Nombre representante:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtNombreRepresentante" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ControlToValidate="txtNombreRepresentante" CssClass="error" ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Nombre de representante requerido"  ForeColor="#FF3300" Display="Dynamic" font-size="Small" Font-Bold="true" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos."
                        ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\ |., ]{1,50}$" ControlToValidate="txtNombreRepresentante" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="cedulaRepresentante" class="fieldContainer">
                    <asp:Label ID="lblCedulaRepresentante" runat="server" Text="Cédula representante:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtCedulaRepresentante" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ControlToValidate="txtCedulaRepresentante" CssClass="error" ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Cédula requerida"  ForeColor="#FF3300" Display="Dynamic" font-size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos. Ingrese únicamente caracteres numéricos"
                    ValidationExpression="[0-9]+" ControlToValidate="txtCedulaRepresentante" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" CssClass="error"  runat="server" ErrorMessage="* Valor de la cédula entre 9 y 20 números"
                    ValidationExpression=".{9,20}" ControlToValidate="txtCedulaRepresentante" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="provincia" class="fieldContainer">
                    <asp:Label ID="lblProvincia" runat="server" Text="Provincia:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtProvincia" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ControlToValidate="txtProvincia" CssClass="error" ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Provincia requerida"  ForeColor="#FF3300" Display="Dynamic" font-size="Small" Font-Bold="true" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos."
                        ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\ |., ]{1,50}$" ControlToValidate="txtProvincia" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="canton" class="fieldContainer">
                    <asp:Label ID="lblCanton" runat="server" Text="Canton:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtCanton" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ControlToValidate="txtCanton" CssClass="error" ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Cantón requerido"  ForeColor="#FF3300" Display="Dynamic" font-size="Small" Font-Bold="true" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos."
                        ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\ |., ]{1,50}$" ControlToValidate="txtCanton" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="distrito" class="fieldContainer">
                    <asp:Label ID="lblDistrito" runat="server" Text="Distrito:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtDistrito" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ControlToValidate="txtDistrito" CssClass="error" ID="RequiredFieldValidator5" runat="server" ErrorMessage="* Distrito requerido"  ForeColor="#FF3300" Display="Dynamic" font-size="Small" Font-Bold="true" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos."
                        ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\ |., ]{1,50}$" ControlToValidate="txtDistrito" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="direccion" class="fieldContainer">
                    <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtDirección" runat="server" CssClass="txtContainer" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ControlToValidate="txtDirección" CssClass="error" ID="RequiredFieldValidator6" runat="server" ErrorMessage="* Dirección requerida"  ForeColor="#FF3300" Display="Dynamic" font-size="Small" Font-Bold="true" ></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorDireccion" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos."
                        ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\ |., ]{1,50}$" ControlToValidate="txtDirección" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="tipo" class="fieldContainer">
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo de contribuyente:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtTipo" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>

                <div id="ultimoPeriodo" class="fieldContainer">
                    <asp:Label ID="lblUltimoPeriodo" runat="server" Text="Último período:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtUltimoPeriodo" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos. Ingrese únicamente caracteres numéricos"
                    ValidationExpression="[0-9]+" ControlToValidate="txtUltimoPeriodo" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div class="divider"></div>

                <div id="btnAcCa">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="ui-widget ui-state-default" CausesValidation="true"/>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="ui-widget ui-state-default" OnClick="btnCancelar_Click" CausesValidation="false"/>
                </div>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>

        </div>

                <div id="popUpDeleteContribuyente">
    
                        <asp:UpdatePanel runat="server" ID="UpdateDelete">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="deleteButton" EventName="Click" />
                            </Triggers>
                            <ContentTemplate>

                                <p>¿Está seguro que desea eliminar el contribuyente?</p>

                                <div class="divider"></div>

                            <div id="btnsAcCaDelete">
                                <asp:Button ID="btnYesDel" runat="server" Text="Si" CssClass="ui-widget ui-state-default" OnClick="btnYesDel_Click" CausesValidation="false"/>
                                <asp:Button ID="btnNoDel" runat="server" Text="No" CssClass="ui-widget ui-state-default" OnClick="btnNoDel_Click" CausesValidation="false"/>
                            </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                </div> 

            <div id="ManageCustomerProveedorPopUp" title="Administrar">
                <asp:UpdatePanel ID="UpdatePanelManager" runat="server">
                    <Triggers>
                        
                    </Triggers>
                    <ContentTemplate>
                        <table class="tableManager">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:GridView ID="grid_Seleccionar" CssClass="grid_general" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridSeleccionar_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField >
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="checkSeleccionar" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAsignar" runat="server" Text="Asignar" CausesValidation="false" font-size="8pt" width="100%" OnClick="btnAsignar_Click"/>
                                    </td>
                                    <td>
                                        <asp:GridView ID="grid_Seleccionados" CssClass="grid_general" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridSeleccionados_PageIndexChanging" OnRowCommand="grid_Seleccionados_RowCommand">
                                            <Columns>
                                                <asp:ButtonField CausesValidation="false" CommandName="eliminarAsociacion" ButtonType="Image" Visible="true" ImageUrl="Images/arrow-right.png" ControlStyle-Height="20px" ControlStyle-Width="20px"/>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

</asp:Content>

