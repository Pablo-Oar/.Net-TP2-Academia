<%@ Page Theme="Azul" Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server" >
   
    <asp:Panel ID="gridPanel" runat="server">
        <br />
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged1"  SkinId="gridviewSkin" >
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="EMail" DataField="EMail" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
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
                    <asp:Label ID="habilitadoLabel" runat="server" Text=" Habilitado: "></asp:Label>
                </td>
                <td style="width: 53px">
                    <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 115px;">
                    <asp:Label ID="nombreUsuarioLabel" runat="server" Text=" Usuario: "></asp:Label>
                </td>
                <td style="width: 53px">
                    <asp:TextBox ID="nombreUsuarioTextBox" runat="server" SkinId="textBoxSkin" Width="359px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="nombreUsuarioTextBox" ErrorMessage="El nombre de usuario no puede estar vacio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 115px;">
                    <asp:Label ID="claveLabel" runat="server" Text=" Clave: "></asp:Label>
                </td>
                <td style="width: 53px">
                    <asp:TextBox ID="claveTextBox" runat="server" SkinId="textBoxSkin" TextMode="Password" Width="359px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="claveTextBox" ErrorMessage="La clave no puede estar vacia" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 115px;">
                    <asp:Label ID="repetirClaveLabel" runat="server" Text=" Repetir Clave: "></asp:Label>
                </td>
                <td style="width: 53px">
                    <asp:TextBox ID="repetirClaveTextBox" runat="server" SkinId="textBoxSkin" TextMode="Password" Width="359px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="claveTextBox" ControlToValidate="repetirClaveTextBox" ErrorMessage="Las claves no coinciden" ForeColor="Red"></asp:CompareValidator>
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
