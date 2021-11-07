<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 325px;
            width: 1329px;
        }
        .auto-style2 {
            width: 35%;
            height: 297px;
            position: absolute;
            right: 41%;
            top: 14px;
        }
        .auto-style7 {
            width: 131px;
        }
        .auto-style9 {
            width: 234px;
        }
        .auto-style10 {
            margin-top: 0px;
        }
        .auto-style12 {
            height: 68px;
            width: 234px;
        }
        .auto-style13 {
            height: 68px;
            width: 131px;
        }
        .auto-style14 {
            height: 68px;
            width: 187px;
        }
        .auto-style16 {
            width: 187px;
        }
        .auto-style17 {
            height: 70px;
            width: 187px;
        }
        .auto-style18 {
            height: 70px;
            width: 234px;
        }
        .auto-style19 {
            height: 70px;
            width: 131px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="auto-style1" style="background-color: #3366FF">
                <table class="auto-style2" style="color: #FFFFFF">
                    <tr>
                        <td class="auto-style14">&nbsp;</td>
                        <td class="auto-style12" style="text-align: center; font-size: x-large; font-weight: 700; font-family: Verdana, Geneva, Tahoma, sans-serif;">Academia</td>
                        <td class="auto-style13"></td>
                    </tr>
                    <tr>
                        <td class="auto-style17" style="padding: 0px 5px 0px 0px; text-align: right">
                            <asp:Label ID="UsuarioLabel" runat="server" Text="Usuario:  "></asp:Label>
                        </td>
                        <td class="auto-style18">
                            <asp:TextBox ID="UsuarioTextBox" runat="server" Width="223px"></asp:TextBox>
                        </td>
                        <td class="auto-style19"></td>
                    </tr>
                    <tr>
                        <td class="auto-style16" style="padding: 0px 5px 0px 0px; text-align: right">
                            <asp:Label ID="ClaveLabel" runat="server" Text="Contraseña: "></asp:Label>
                        </td>
                        <td class="auto-style9">
                            <asp:TextBox ID="ClaveTextBox" runat="server" TextMode="Password" Width="227px"></asp:TextBox>
                        </td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style16">&nbsp;</td>
                        <td class="auto-style9">
                            <asp:Label ID="FailLoginLabel" runat="server" BackColor="White" Font-Bold="True" ForeColor="Red" Text="Usuario o contraseña incorrectos" Visible="False" Width="100%"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="LoginButton" runat="server" CssClass="auto-style10" OnClick="LoginButton_Click" Text="Iniciar Sesion" Width="233px" />
                        </td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
