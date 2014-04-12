<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Usuarios.aspx.cs" Inherits="Usuarios" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/Usuarios.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
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
                            <asp:GridView ID="GridViewUsers" CssClass="grid_general" runat="server" AllowPaging="true" PageSize="15" OnPageIndexChanging="GridViewUsers_PageIndexChanging" onrowcommand="GridViewUsers_RowCommand">
                                <Columns>
                                    <asp:ButtonField CommandName="selectUser" CausesValidation="false" ButtonType="Image" Visible="true" ImageUrl="Images/arrow-right.png" ControlStyle-Height="20px" ControlStyle-Width="20px"/>
                                </Columns>
                            </asp:GridView> 
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

    <div id="popUpUsuario">
    
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

                <div id="userName" class="fieldContainer">
                    <asp:Label ID="lblUserName" runat="server" Text="Nombre:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ControlToValidate="txtUserName" CssClass="error" ID="RequiredFieldValidatorNombre" runat="server" ErrorMessage="* Nombre requerido"  ForeColor="#FF3300" Display="Dynamic" font-size="Small" Font-Bold="true" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorNombre" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos."
                        ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\ |., ]{1,50}$" ControlToValidate="txtUserName" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="userLastName" class="fieldContainer">
                    <asp:Label ID="lblLastName" runat="server" Text="Apellidos:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ControlToValidate="txtLastName" CssClass="error" ID="RequiredFieldValidatorApellido" runat="server" ErrorMessage="* Apellido requerido"  ForeColor="#FF3300" Display="Dynamic" font-size="Small" Font-Bold="true" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorApellido" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos."
                        ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\ |., ]{1,50}$" ControlToValidate="txtLastName" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="userID" class="fieldContainer">
                    <asp:Label ID="lblCedula" runat="server" Text="Cédula:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtCedula" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ControlToValidate="txtCedula" CssClass="error" ID="RequiredFieldValidatorCedula" runat="server" ErrorMessage="* Cédula requerida"  ForeColor="#FF3300" Display="Dynamic" font-size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorCedula" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos. Ingrese únicamente caracteres numéricos"
                    ValidationExpression="[0-9]+" ControlToValidate="txtCedula" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorCedulaTam" CssClass="error"  runat="server" ErrorMessage="* Valor de la cédula entre 9 y 15 números"
                    ValidationExpression=".{9,15}" ControlToValidate="txtCedula" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="userEmail" class="fieldContainer">
                    <asp:Label ID="lblEmail" runat="server" Text="Correo:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ControlToValidate="txtEmail" CssClass="error" ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="* Correo requerido"  ForeColor="#FF3300" Display="Dynamic" font-size="Small" Font-Bold="true" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" CssClass="error"  runat="server" ErrorMessage="* Formato de correo incorrecto"
                    ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$" ControlToValidate="txtEmail" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="userPass" class="fieldContainer">
                    <asp:Label ID="lblPass" runat="server" Text="Contraseña:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCnt" runat="server" CssClass ="error" ErrorMessage="* Contraseña de usuario requerida" ControlToValidate="txtPass" Display="Dynamic" ForeColor="#FF3300" font-size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rxvContraseña" runat="server" CssClass ="error" ErrorMessage="* La contraseña no puede contener caracteres blancos, comillas dobles o sencillas"
					ValidationExpression="([^\s&quot;' ])+" ControlToValidate="txtPass" Display="Dynamic" ForeColor="#FF3300" font-size="Small" Font-Bold="true"/>
                </div>

                <div id="userConfPass" class="fieldContainer">
                    <asp:Label ID="lblConfPass" runat="server" Text="Confirmar contraseña:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtConfPass" runat="server" TextMode="Password" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfCont" runat="server" CssClass ="error" ErrorMessage="* Confirmación de contraseña de usuario requerida" ControlToValidate="txtPass" Display="Dynamic" ForeColor="#FF3300" font-size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorConfCont" runat="server" CssClass ="error" ErrorMessage="* La contraseña no puede contener caracteres blancos, comillas dobles o sencillas"
					ValidationExpression="([^\s&quot;' ])+" ControlToValidate="txtPass" Display="Dynamic" ForeColor="#FF3300" font-size="Small" Font-Bold="true"/>
                    <asp:CompareValidator runat="server" id="cmpClaves" ControlToValidate="txtPass" ControlToCompare="txtConfPass"
                    operator="Equal" type="String" CssClass ="error" ErrorMessage="* Las contraseñas introducidas no son iguales" Display="Dynamic" ForeColor="#FF3300" font-size="Small" Font-Bold="true"/>
                </div>

                <div id="userPhone" class="fieldContainer">
                    <asp:Label ID="lblPhone" runat="server" Text="Teléfono:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos. Ingrese únicamente caracteres numéricos"
                    ValidationExpression="([0-9]|-)+" ControlToValidate="txtPhone" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhoneTam" CssClass="error"  runat="server" ErrorMessage="* Valor del teléfono entre 8 y 15 caracteres"
                    ValidationExpression=".{8,15}" ControlToValidate="txtPhone" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div id="userAddress" class="fieldContainer">
                    <asp:Label ID="lblAddress" runat="server" Text="Dirección:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="txtContainer" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorDireccion" CssClass="error"  runat="server" ErrorMessage="* Se han escrito caracteres inválidos."
                        ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\ |., ]{1,50}$" ControlToValidate="txtAddress" ForeColor="#FF3300" Display="Dynamic" font-size="Small"></asp:RegularExpressionValidator>
                </div>

                <div class="divider"></div>

                <div id="btnAcCa">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="ui-widget ui-state-default" CausesValidation="true"/>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="ui-widget ui-state-default" OnClick="btnCancelar_Click" CausesValidation="false"/>
                </div>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>

        </div>

                <div id="popUpDeleteUsuario">
    
                        <asp:UpdatePanel runat="server" ID="UpdateDelete">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="deleteButton" EventName="Click" />
                            </Triggers>
                            <ContentTemplate>

                                <p>¿Está seguro que desea eliminar el usuario?</p>

                                <div class="divider"></div>

                            <div id="btnsAcCaDelete">
                                <asp:Button ID="btnYesDel" runat="server" Text="Si" CssClass="ui-widget ui-state-default" OnClick="btnYesDel_Click" CausesValidation="false"/>
                                <asp:Button ID="btnNoDel" runat="server" Text="No" CssClass="ui-widget ui-state-default" OnClick="btnNoDel_Click" CausesValidation="false"/>
                            </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                </div> 


</asp:Content>
