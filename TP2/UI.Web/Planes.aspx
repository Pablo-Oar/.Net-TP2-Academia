<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes
    " Theme="Azul" %>

<%@ Register Src="~/UCBotones.ascx" TagPrefix="uc1" TagName="UCBotones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <br />
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="gridView_SelectedIndexChanged1"  SkinId="gridviewSkin" DataSourceID="ObjectDataSource1" DataKeyNames="ID" >
           
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="IdEspecialidad" HeaderText="IdEspecialidad" SortExpression="IdEspecialidad" />
                <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                 <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
           
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.PlanLogic">
        </asp:ObjectDataSource>
        <br />
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server"  SkinId="formSkin" Width="740px">
        <table style="width:100%;">
            <tr>
                <td style="text-align: right; width: 115px;">
                    <asp:Label ID="DescripcionLabel" runat="server"  Text="Descripcion:"></asp:Label></td>
                <td style="width: 53px">
                    <asp:TextBox ID="DescTextBox" runat="server" SkinId="textBoxSkin" Width="359px" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DescTextBox" ErrorMessage="El campo descripcion  no puede estar vacio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>  
            <tr>
                <td style="text-align: right; width: 115px;">
                    <asp:Label ID="idEspLabel" runat="server"  Text="id de especialidad:"></asp:Label></td>
                <td style="width: 53px">
                    <asp:TextBox ID="IdEspTextBox" runat="server" SkinId="textBoxSkin" Width="359px" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IdEspTextBox" ErrorMessage="El campo id especialidad no puede estar vacio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>


        </table>
        <br />
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" CausesValidation="False" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    </asp:Panel> 
    <uc1:UCBotones runat="server" id="UCBotones" Oneditar="editarLinkButton_Click" Oneliminar="eliminarLinkButton_Click" Onnuevo="nuevoLinkButton_Click"/>
</asp:Content>
