<%@ Page Title="" Language="C#" MasterPageFile="~/JobRecruiter.Master" AutoEventWireup="true" CodeBehind="JobRecruiterHome.aspx.cs" Inherits="job_portal.JobRecruiter.JobRecruiterHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        table {
            width: 100%;
            max-width: 800px;
            margin: 20px auto;
            border-collapse: collapse;
            background-color: #f9f9f9;
            border: 1px solid #ddd;
            box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
        }

        td {
            padding: 15px;
            border-bottom: 1px solid #ddd;
        }

        tr:last-child td {
            border-bottom: none;
        }

        td:first-child {
            font-weight: bold;
            width: 20%;
            color: #333;
        }

        td:nth-child(2),
        td:nth-child(4) {
            width: 30%;
        }

        label {
            color: #555;
        }

        /* Style for the submit button */
        .btn-submit {
            background-color: #4CAF50;
            color: white;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
            font-size: 14px;
            margin: 10px 0;
            display: inline-block;
        }

        .btn-submit:hover {
            background-color: #45a049;
        }

        /* Responsive design */
        @media screen and (max-width: 768px) {
            table {
                width: 90%;
            }

            td {
                display: block;
                width: 100%;
            }

            td:first-child {
                font-weight: normal;
                margin-top: 10px;
                text-align: left;
            }

            td:nth-child(2),
            td:nth-child(4) {
                width: 100%;
            }

            .btn-submit {
                width: 100%;
                text-align: center;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Name:</td>
            <td>
                <asp:Label ID="lblname" runat="server"></asp:Label>
            </td>
            <td>Email:</td>
            <td>
                <asp:Label ID="lblemail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Password:</td>
            <td>
                <asp:Label ID="lblpwd" runat="server"></asp:Label>
            </td>
            <td>Mobile Number:</td>
            <td>
                <asp:Label ID="lblmobile" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>URL:</td>
            <td>
                <asp:Label ID="lblurl" runat="server"></asp:Label>
            </td>
            <td>State:</td>
            <td>
                <asp:Label ID="lblstate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>City:</td>
            <td>
                <asp:Label ID="lblcity" runat="server"></asp:Label>
            </td>
            <td>HR Name :</td>
            <td>
                <asp:Label runat="server" ID="lblhr"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Address:</td>
            <td>
                <asp:Label ID="lbladdress" runat="server"></asp:Label>
            </td>
            <td>Company Image:</td>
            <td>
                <asp:Label runat="server" ID="lblimage" />
            </td>
        </tr>
        <tr>
            <td>Comment:</td>
            <td colspan="3">
                <asp:Label ID="lblcomment" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
