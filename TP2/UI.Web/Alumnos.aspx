﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Alumnos.aspx.cs" Inherits="UI.Web.WebForm2" Theme="Azul" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <br />
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="gridView_SelectedIndexChanged1"  SkinId="gridviewSkin" DataSourceID="ObjectDataSource1" DataKeyNames="ID" >
           
            <Columns>
                <asp:BoundField DataField="Legajo" HeaderText="Legajo" SortExpression="Legajo" />
                <asp:BoundField DataField="IDPlan" HeaderText="IDPlan" SortExpression="IDPlan" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" SortExpression="FechaNacimiento" />
                <asp:BoundField DataField="TipoPersona" HeaderText="TipoPersona" SortExpression="TipoPersona" />
                <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
           
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetByTipo" TypeName="Business.Logic.PersonasLogic">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="tipo" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server"  SkinId="formSkin" Width="740px">
        <table style="width:100%;">
            <tr>
                <td style="text-align: right; width: 115px;">
                    <asp:Label ID="nombreLabel0" runat="server" Text=" Nombre: "></asp:Label>
                </td>
                <td style="width: 53px">
                    <asp:TextBox ID="nombreTextBox" runat="server" SkinId="textBoxSkin" Width="359px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="nombreTextBox" ErrorMessage="El nombre no puede estar vacio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 115px;">
                    <asp:Label ID="apellidoLabel" runat="server" Text=" Apellido: "></asp:Label>
                </td>
                <td style="width: 53px">
                    <asp:TextBox ID="apellidoTextBox" runat="server" SkinId="textBoxSkin" style="margin-right: 9px" Width="359px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="El apellido no puede estar vacio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 115px;">
                    <asp:Label ID="emailLabel" runat="server" Text=" EMail: "></asp:Label>
                </td>
                <td style="width: 53px; height: 26px">
                    <asp:TextBox ID="emailTextBox" runat="server" SkinId="textBoxSkin" style="margin-right: 9px" Width="359px"></asp:TextBox>
                </td>
                <td style="height: 26px">
                    <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="emailTextBox" ErrorMessage="El email es invalido " ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="emailTextBox" ErrorMessage="(mail@mail.com)" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 115px;">
                    Direccion</td>
                <td style="width: 53px">
                    <asp:TextBox ID="DireccionTextBox" runat="server" SkinId="textBoxSkin" Width="359px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DireccionTextBox" ErrorMessage="El nombre de usuario no puede estar vacio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 115px; height: 26px;">
                    Id de plan</td>
                <td style="width: 53px; height: 26px;">
                    <asp:TextBox ID="idPlanTextBox" runat="server" SkinId="textBoxSkin" Width="359px"></asp:TextBox>
                </td>
                <td style="height: 26px">
                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="idPlanTextBox" ErrorMessage="El nombre de usuario no puede estar vacio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 115px; height: 26px;">
                    Legajo</td>
                <td style="width: 53px; height: 26px;">
                    <asp:TextBox ID="LegajoTextBox" runat="server" SkinId="textBoxSkin" Width="359px"></asp:TextBox>
                </td>
                <td style="height: 26px">
                    <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="LegajoTextBox" ErrorMessage="El nombre de usuario no puede estar vacio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 115px;">Telefono</td>
                <td style="width: 53px">
                    <asp:TextBox ID="TelefonoTextBox" runat="server" SkinId="textBoxSkin" Width="359px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TelefonoTextBox" ErrorMessage="El nombre de usuario no puede estar vacio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 115px;">Fecha de Nacimiento</td>
                <td style="width: 53px">
                    <asp:TextBox ID="FechadeNacTextBox" runat="server" SkinId="textBoxSkin" Width="359px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label10" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="FechadeNacTextBox" ErrorMessage="El nombre de usuario no puede estar vacio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 115px;">Tipo de persona</td>
                <td style="width: 53px">
                    <asp:TextBox ID="TipoPersonaTextBox" runat="server" SkinId="textBoxSkin" Width="359px" Enabled="False" OnTextChanged="TipoPersonaTextBox_TextChanged">1</asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label11" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TipoPersonaTextBox" ErrorMessage="El nombre de usuario no puede estar vacio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <br />
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" CausesValidation="False" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    </asp:Panel> 
    <asp:Panel ID="gridActionsPanel" runat="server">
        <br />
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
</asp:Content>