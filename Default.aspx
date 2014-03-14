<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/Contribuyentes.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="contButtons">
        <asp:Button ID="btnInsertar" runat="server" Text="Nuevo" CausesValidation="false" OnClick="btnInsertar_Click" CssClass="ui-widget ui-state-default"/>
        <asp:Button ID="btnSelect" runat="server" Text="Seleccionar" CausesValidation="false" OnClick="btnSeleccionar_Click" CssClass="ui-widget ui-state-default"/>
    </div>
    <h2>
       ¡Bienvenidos al Sistema de Contabilidad!
    </h2>
    <p>
        El propósito de esta aplicación es mejorar y agilizar el procesamiento de facturación en la oficina de abuelo Lele.
    </p>
    <p>
        Aplicación diseñada por:
    </p>
    <ul>
        <li>Heriberto Ureña Madrigal</li>
    </ul>
            <asp:ScriptManager ID="ScriptManager1" runat="server">	
            </asp:ScriptManager>
            <div id="popUpContribuyente">
                <asp:UpdatePanel ID="UpdateInfo" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSelect" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <!-- Botones Invisibles -->
            
                        <!-- Cuerpo con la tabla -->
                        <div style="min-height: 500px;">
                            <div class="grid_general">
                                <asp:GridView ID="GridViewContribuyentes" CssClass="grid_general" runat="server" AllowPaging="true" PageSize="15" OnPageIndexChanging="GridViewContribuyentes_PageIndexChanging" onrowcommand="GridViewContribuyentes_RowCommand">
                                    <Columns>
                                        <asp:ButtonField CommandName="selectContribuyente" CausesValidation="false" ButtonType="Image" Visible="true" ImageUrl="Images/arrow-right.png" ControlStyle-Height="20px" ControlStyle-Width="20px"/>
                                    </Columns>
                                </asp:GridView> 
                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

    <div id="popUpInfoContribuyente">
    
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

                <div id="codeContribuyente" class="fieldContainer">
                    <asp:Label ID="lblcodeContribuyente" runat="server" Text="Código:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtcodeContribuyente" runat="server" CssClass="txtContainer" Enabled="false"></asp:TextBox>
                </div>

                <div id="nombreContribuyente" class="fieldContainer">
                    <asp:Label ID="lblNombreContribuyente" runat="server" Text="Nombre contribuyente:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtNombreContribuyente" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>

                <div id="cedulaContribuyente" class="fieldContainer">
                    <asp:Label ID="lblCedulaContribuyente" runat="server" Text="Cédula contribuyente:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtCedulaContribuyente" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>

                <div id="nombreRepresentante" class="fieldContainer">
                    <asp:Label ID="lblNombreRepresentante" runat="server" Text="Nombre representante:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtNombreRepresentante" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>

                <div id="cedulaRepresentante" class="fieldContainer">
                    <asp:Label ID="lblCedulaRepresentante" runat="server" Text="Cédula representante:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtCedulaRepresentante" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>

                <div id="provincia" class="fieldContainer">
                    <asp:Label ID="lblProvincia" runat="server" Text="Provincia:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtProvincia" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>

                <div id="canton" class="fieldContainer">
                    <asp:Label ID="lblCanton" runat="server" Text="Canton:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtCanton" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>

                <div id="distrito" class="fieldContainer">
                    <asp:Label ID="lblDistrito" runat="server" Text="Distrito:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtDistrito" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>

                <div id="direccion" class="fieldContainer">
                    <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtDirección" runat="server" CssClass="txtContainer" TextMode="MultiLine"></asp:TextBox>
                </div>

                <div id="tipo" class="fieldContainer">
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo de contribuyente:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtTipo" runat="server" CssClass="txtContainer"></asp:TextBox>
                </div>

                <div id="ultimoPeriodo" class="fieldContainer">
                    <asp:Label ID="lblUltimoPeriodo" runat="server" Text="Último período:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtUltimoPeriodo" runat="server" CssClass="txtContainer"></asp:TextBox>
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

</asp:Content>
