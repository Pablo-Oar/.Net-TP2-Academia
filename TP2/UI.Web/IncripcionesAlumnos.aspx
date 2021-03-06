<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="IncripcionesAlumnos.aspx.cs" Inherits="UI.Web.InscricionesAlumnos
    " Theme="Azul" %>

<%@ Register Src="~/UCBotones.ascx" TagPrefix="uc1" TagName="UCBotones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <br />
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="gridView_SelectedIndexChanged1"  SkinId="gridviewSkin" DataSourceID="ObjectDataSource1" DataKeyNames="ID" >
           
            <Columns>
                <asp:BoundField DataField="IDAlumno" HeaderText="IDAlumno" SortExpression="IDAlumno" />
                <asp:BoundField DataField="IDCurso" HeaderText="IDCurso" SortExpression="IDCurso" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" SortExpression="Nota" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" SortExpression="Condicion" />
                <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
           
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.AlumnoInscripcionLogic">
        </asp:ObjectDataSource>
        <br />
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server"  SkinId="formSkin" Width="740px">
        <table style="width:100%;">
            <tr>
                <td style="text-align: right; width: 115px;">
                    <asp:Label ID="DescripcionLabel" runat="server"  Text="id de alumno:"></asp:Label></td>
                <td style="width: 53px">
                    <asp:TextBox ID="idAlumnoTextBox" runat="server" SkinId="textBoxSkin" Width="359px" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="idAlumnoTextBox" ErrorMessage="El id alumno  no puede estar vacio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>  
            <tr>
                <td style="text-align: right; width: 115px;">
                    <asp:Label ID="Label1" runat="server"  Text="Id del curso:"></asp:Label></td>
                <td style="width: 53px">
                    <asp:TextBox ID="idCursoTextBox" runat="server" SkinId="textBoxSkin" Width="359px" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="idCursoTextBox" ErrorMessage="El campo id de curso  no puede estar vacio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 115px;">
                    <asp:Label ID="Label3" runat="server"  Text="Condicion"></asp:Label></td>
                <td style="width: 53px">
                    <asp:TextBox ID="CondicionTextBox" runat="server" SkinId="textBoxSkin" Width="359px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CondicionTextBox" ErrorMessage="El campo Condicion  no puede estar vacio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 115px;">
                    <asp:Label ID="Label5" runat="server"  Text="Nota"></asp:Label></td>
                <td style="width: 53px" aria-busy="False">
                    <asp:DropDownList ID="DdlNota" runat="server" Width="98px">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="* "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DdlNota" ErrorMessage="El campo Nota  no puede estar vacio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>

        </table>
        <br />
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" CausesValidation="False" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    </asp:Panel> 
    <uc1:UCBotones runat="server" id="UCBotones" Oneditar="editarLinkButton_Click" Oneliminar="eliminarLinkButton_Click" Onnuevo="nuevoLinkButton_Click"/>
</asp:Content>
