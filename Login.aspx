<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="job_portal.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .login-container {
            margin: 0 auto;
            padding: 20px;
            max-width: 400px;
            background-color: #f4f4f4;
            border-radius: 8px;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
        }

        .login-container table {
            width: 100%;
        }

        .login-container td {
            padding: 10px;
        }

        .login-container td:first-child {
            text-align: right;
            font-weight: bold;
            color: #333;
        }

        .login-container td:last-child {
            text-align: left;
        }

        .login-container input[type="text"],
        .login-container input[type="password"],
        .login-container select {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .login-container input[type="text"]:focus,
        .login-container input[type="password"]:focus,
        .login-container select:focus {
            outline: none;
            border-color: #007BFF;
            box-shadow: 0 0 8px rgba(0, 123, 255, 0.25);
        }

        .login-container button,
        .login-button {
            background-color: #007BFF;
            color: white;
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            width: 100%;
            transition: background-color 0.3s ease, box-shadow 0.3s ease;
        }

        .login-container button:hover,
        .login-button:hover {
            background-color: #0056b3;
            box-shadow: 0 4px 8px rgba(0, 91, 187, 0.2);
        }

        .login-container button:active,
        .login-button:active {
            background-color: #004494;
            box-shadow: 0 3px 6px rgba(0, 68, 148, 0.3);
        }

        .login-container .error-label {
            color: red;
            padding-top: 5px;
            text-align: center;
            display: block;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-container">
        <table>
            <tr>
                <td>User Type:</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlusertype">
                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                        <asp:ListItem Text="JobSeeker" Value="2"></asp:ListItem>
                        <asp:ListItem Text="JobRecruiter" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtemail"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtpwd" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" Text="Login" ID="btnlogin" OnClick="btnlogin_Click" CssClass="login-button" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblmsg" runat="server" CssClass="error-label" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
