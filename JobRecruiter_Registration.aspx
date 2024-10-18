<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="JobRecruiter_Registration.aspx.cs" Inherits="job_portal.JobRecruiter_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f9fa;
            margin: 0;
            padding: 20px;
        }

        table {
            width: 100%;
            max-width: 800px;
            margin: 0 auto;
            background-color: #fff;
            border-radius: 8px;
            padding: 20px;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
        }

        table td {
            padding: 10px;
            vertical-align: middle;
        }

        table tr {
            margin-bottom: 15px;
        }

        table tr td:first-child {
            text-align: right;
            font-weight: bold;
        }

        input[type="text"],
        input[type="password"],
        input[type="email"],
        input[type="file"],
        select,
        textarea {
            width: 100%;
            padding: 10px;
            margin: 8px 0;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            font-size: 16px;
            transition: border-color 0.3s ease-in-out;
        }

        input[type="text"]:focus,
        input[type="password"]:focus,
        input[type="email"]:focus,
        input[type="file"]:focus,
        select:focus,
        textarea:focus {
            border-color: #4CAF50;
            outline: none;
        }

        input[type="submit"],
        button,
        input[type="button"] {
            background-color: #4CAF50;
            color: white;
            padding: 12px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            text-align: center;
            margin-top: 20px;
        }

        input[type="submit"]:hover,
        button:hover,
        input[type="button"]:hover {
            background-color: #45a049;
        }

        textarea {
            resize: vertical;
            height: 100px;
        }

    </style>

    <table>
        <tr>
            <td>Name:</td>
            <td>
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            </td>
            <td>Email:</td>
            <td>
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Password:</td>
            <td>
                <asp:TextBox ID="txtpwd" TextMode="Password" runat="server"></asp:TextBox>
            </td>
            <td>Mobile Number:</td>
            <td>
                <asp:TextBox ID="txtmobile" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>URL:</td>
            <td>
                <asp:TextBox ID="txturl" runat="server"></asp:TextBox>
            </td>
            <td>State:</td>
            <td>
                <asp:DropDownList ID="ddlstate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>City:</td>
            <td>
                <asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList>
            </td>
            <td>HR Name:</td>
            <td>
                <asp:TextBox ID="txthr" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Address:</td>
            <td>
                <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
            </td>
            <td>Company Image:</td>
            <td>
                <asp:FileUpload ID="fuimage" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Comment:</td>
            <td colspan="3">
                <asp:TextBox ID="txtcomment" TextMode="MultiLine" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btnjobrecruitersubmit" Text="Submit" runat="server" OnClick="btnjobrecruitersubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
