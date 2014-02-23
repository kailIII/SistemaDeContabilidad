<%@ Page Title="Proveedores" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Proveedores.aspx.cs" Inherits="Proveedores" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/Proveedores.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
            <asp:ScriptManager ID="ScriptManager1" runat="server">	
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdateInfo" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAceptar" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <!-- Botones Invisibles -->
            
                    <!-- Cuerpo con la tabla -->
                    <div style="min-height: 500px;">
                        <asp:Button ID="btnInsertar" runat="server" Text="Insertar" CausesValidation="false" OnClick="btnInsertar_Click" CssClass="ui-widget ui-state-default"/>

                        <div class="grid_general">
                            <asp:GridView ID="GridViewProveedores" CssClass="grid_general" runat="server" AllowPaging="true" PageSize="15" OnPageIndexChanging="GridViewProveedores_PageIndexChanging" onrowcommand="GridViewProveedores_RowCommand">
                                <Columns>
                                    <asp:ButtonField CommandName="selectProveedor" CausesValidation="false" ButtonType="Image" Visible="true" ImageUrl="Images/arrow-right.png" ControlStyle-Height="20px" ControlStyle-Width="20px"/>
                                </Columns>
                            </asp:GridView> 
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

    <div id="popUpProveedor">
    
                <asp:UpdatePanel runat="server" ID="UpdatePopUp">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnInsertar" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>

                <div id="cntrlBtns">
                    <asp:Button ID="updateButton" runat="server" Text="Modificar" OnClick="updateButton_Click" CssClass="ui-widget ui-state-default" CausesValidation="false"/>
                    <asp:Button ID="deleteButton" runat="server" Text="Eliminar" CssClass="ui-widget ui-state-default" OnClick="deleteButton_Click" CausesValidation="false"/>

                </div>

                <div class="divider"></div>

                <div id="codeProveedor" class="fieldContainer">
                    <asp:Label ID="lblCodeProveedor" runat="server" Text="Código:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtCodeProveedor" runat="server" CssClass="txtContainer" Enabled="false"></asp:TextBox>
                </div>

                <div id="nombreProveedor" class="fieldContainer">
                    <asp:Label ID="lblProveedorName" runat="server" Text="Nombre:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtProveedorName" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ControlToValidate="txtProveedorName" CssClass="error" ID="RequiredFieldValidatorNombre" runat="server" ErrorMessage="* Nombre requerido"  ForeColor="#FF3300" Display="Dynamic" font-size="Small" Font-Bold="true" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorNombre" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos."
                        ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\ |., ]{1,50}$" ControlToValidate="txtProveedorName" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>


                <div id="ProveedorID" class="fieldContainer">
                    <asp:Label ID="lblCedula" runat="server" Text="Cédula:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtCedula" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ControlToValidate="txtCedula" CssClass="error" ID="RequiredFieldValidatorCedula" runat="server" ErrorMessage="* Cédula requerida"  ForeColor="#FF3300" Display="Dynamic" font-size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorCedula" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos. Ingrese únicamente caracteres numéricos"
                    ValidationExpression="[0-9]+" ControlToValidate="txtCedula" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorCedulaTam" CssClass="error"  runat="server" ErrorMessage="* Valor de la cédula entre 9 y 20 números"
                    ValidationExpression=".{9,20}" ControlToValidate="txtCedula" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="ProveedorAddress" class="fieldContainer">
                    <asp:Label ID="lblAddress" runat="server" Text="Dirección:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="txtContainer" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorDireccion" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos."
                        ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\ |., ]{1,50}$" ControlToValidate="txtAddress" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="ProveedorPhone" class="fieldContainer">
                    <asp:Label ID="lblPhone" runat="server" Text="Teléfono:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos. Ingrese únicamente caracteres numéricos"
                    ValidationExpression="([0-9]|-)+" ControlToValidate="txtPhone" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhoneTam" CssClass="error"  runat="server" ErrorMessage="* Valor del teléfono entre 8 y 15 caracteres"
                    ValidationExpression=".{8,15}" ControlToValidate="txtPhone" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="ProveedorFax" class="fieldContainer">
                    <asp:Label ID="lblFax" runat="server" Text="Fax:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtFax" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos. Ingrese únicamente caracteres numéricos"
                    ValidationExpression="([0-9]|-)+" ControlToValidate="txtPhone" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" CssClass="error"  runat="server" ErrorMessage="* Valor del teléfono entre 8 y 15 caracteres"
                    ValidationExpression=".{8,15}" ControlToValidate="txtPhone" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="ProveedorEmail" class="fieldContainer">
                    <asp:Label ID="lblEmail" runat="server" Text="Correo:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ControlToValidate="txtEmail" CssClass="error" ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="* Correo requerido"  ForeColor="#FF3300" Display="Dynamic" font-size="Small" Font-Bold="true" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" CssClass="error"  runat="server" ErrorMessage="* Formato de correo incorrecto"
                    ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$" ControlToValidate="txtEmail" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div class="divider"></div>

                <div id="btnAcCa">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="ui-widget ui-state-default" CausesValidation="true"/>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="ui-widget ui-state-default" OnClick="btnCancelar_Click" CausesValidation="false"/>
                </div>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>

        </div>

                <div id="popUpDeleteProveedor">
    
                        <asp:UpdatePanel runat="server" ID="UpdateDelete">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="deleteButton" EventName="Click" />
                            </Triggers>
                            <ContentTemplate>

                                <p>¿Está seguro que desea eliminar el proveedor?</p>

                                <div class="divider"></div>

                            <div id="btnsAcCaDelete">
                                <asp:Button ID="btnYesDel" runat="server" Text="Si" CssClass="ui-widget ui-state-default" OnClick="btnYesDel_Click" CausesValidation="false"/>
                                <asp:Button ID="btnNoDel" runat="server" Text="No" CssClass="ui-widget ui-state-default" OnClick="btnNoDel_Click" CausesValidation="false"/>
                            </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                </div> 


</asp:Content>
