<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Docentes.aspx.cs" Inherits="UI.Web.Docentes" Theme="Azul" %>

<%@ Register Src="~/UCBotones.ascx" TagPrefix="uc1" TagName="UCBotones" %>

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
                <asp:Parameter DefaultValue="2" Name="tipo" Type="Int32" />
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
                <td style="text-align: right; width: 115px;">Tipo de persona</td>
                <td style="width: 53px">
                    <asp:TextBox ID="TipoPersonaTextBox" runat="server" SkinId="textBoxSkin" Width="359px" Enabled="False" OnTextChanged="TipoPersonaTextBox_TextChanged">2</asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label11" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TipoPersonaTextBox" ErrorMessage="El nombre de usuario no puede estar vacio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 115px;">Fecha de Nacimiento</td>
                <td style="width: 53px">
                    <asp:Calendar ID="fehcaNacCalendar" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
                </td>
                <td>
                    <asp:Label ID="Label10" runat="server" ForeColor="Red" Text="* "></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" CausesValidation="False" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    </asp:Panel> 
    <uc1:UCBotones runat="server" id="UCBotones" Oneditar="editarLinkButton_Click" Oneliminar="eliminarLinkButton_Click" Onnuevo="nuevoLinkButton_Click"/>
</asp:Content>
