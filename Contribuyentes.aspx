<%@ Page Title="Contribuyentes" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Contribuyentes.aspx.cs" Inherits="Contribuyentes" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/Contribuyentes.js"></script>
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
                            <asp:GridView ID="GridViewContribuyentes" CssClass="grid_general" runat="server" AllowPaging="true" PageSize="15" OnPageIndexChanging="GridViewContribuyentes_PageIndexChanging" onrowcommand="GridViewContribuyentes_RowCommand">
                                <Columns>
                                    <asp:ButtonField CommandName="selectCliente" CausesValidation="false" ButtonType="Image" Visible="true" ImageUrl="Images/arrow-right.png" ControlStyle-Height="20px" ControlStyle-Width="20px"/>
                                </Columns>
                            </asp:GridView> 
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

    <div id="popUpCliente">
    
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

                <div id="codeCliente" class="fieldContainer">
                    <asp:Label ID="lblCodeCliente" runat="server" Text="Código:" CssClass="lblContainer"></asp:Label>
                    <asp:TextBox ID="txtCodeCiente" runat="server" CssClass="txtContainer" Enabled="false"></asp:TextBox>
                </div>

                <div class="divider"></div>

                <div id="btnAcCa">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="ui-widget ui-state-default" CausesValidation="true"/>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="ui-widget ui-state-default" OnClick="btnCancelar_Click" CausesValidation="false"/>
                </div>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>

        </div>

                <div id="popUpDeleteCliente">
    
                        <asp:UpdatePanel runat="server" ID="UpdateDelete">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="deleteButton" EventName="Click" />
                            </Triggers>
                            <ContentTemplate>

                                <p>¿Está seguro que desea eliminar el cliente?</p>

                                <div class="divider"></div>

                            <div id="btnsAcCaDelete">
                                <asp:Button ID="btnYesDel" runat="server" Text="Si" CssClass="ui-widget ui-state-default" OnClick="btnYesDel_Click" CausesValidation="false"/>
                                <asp:Button ID="btnNoDel" runat="server" Text="No" CssClass="ui-widget ui-state-default" OnClick="btnNoDel_Click" CausesValidation="false"/>
                            </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                </div> 


</asp:Content>
