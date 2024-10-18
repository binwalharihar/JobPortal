<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeeker.Master" AutoEventWireup="true" CodeBehind="JobSeekerHome.aspx.cs" Inherits="job_portal.JobSeeker.JobSeekerHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            margin: 0;
            padding: 0;
        }

        table {
            width: 100%;
            max-width: 800px;
            margin: 30px auto;
            background-color: white;
            border-collapse: collapse;
            border: 1px solid #ddd;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        td {
            padding: 15px;
            vertical-align: middle;
            border-bottom: 1px solid #ddd;
        }

        td:first-child {
            font-weight: bold;
            color: #333;
            width: 25%;
        }

        td:nth-child(2), 
        td:nth-child(4) {
            width: 35%;
        }

        tr:last-child td {
            border-bottom: none;
        }

        .btn-submit {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            cursor: pointer;
            font-size: 14px;
            margin-top: 10px;
            display: inline-block;
            border-radius: 5px;
            transition: background-color 0.3s ease;
        }

        .btn-submit:hover {
            background-color: #45a049;
        }

        /* Style for labels */
        label {
            font-size: 14px;
            color: #555;
        }

        /* Center the table and content for better readability */
        table,
        .btn-submit {
            text-align: center;
        }

        /* Media query for responsive design */
        @media screen and (max-width: 768px) {
            table {
                width: 95%;
            }

            td {
                display: block;
                width: 100%;
                text-align: left;
            }

            td:first-child {
                font-weight: normal;
                padding-top: 10px;
                color: #666;
            }

            .btn-submit {
                width: 100%;
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
            <td>Gender:</td>
            <td>
                <asp:Label runat="server" ID="lblgender"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Email:</td>
            <td>
                <asp:Label ID="lblemail" runat="server"></asp:Label>
            </td>
            <td>Password:</td>
            <td>
                <asp:Label ID="lblpwd" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Mobile Number:</td>
            <td>
                <asp:Label ID="lblmobile" runat="server"></asp:Label>
            </td>
            <td>Date of Birth:</td>
            <td>
                <asp:Label ID="lbldob" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Security Question:</td>
            <td>
                <asp:Label ID="lblsecurityquestion" runat="server"></asp:Label>
            </td>
            <td>Security Answer:</td>
            <td>
               <asp:Label runat="server" ID="lblans"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Job Profile:</td>
            <td>
                <asp:Label ID="lbljobprofile" runat="server"></asp:Label>
            </td>
            <td>Job Experience:</td>
            <td>
                <asp:Label ID="lblexp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Qualifications:</td>
            <td>
                <asp:Label ID="lblqualifications" runat="server"></asp:Label>
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
            <td>Address:</td>
            <td>
                <asp:Label ID="lbladdress" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Upload Resume:</td>
            <td>
                <asp:Label runat="server" ID="lblresume" />
            </td>
            <td>Upload Image:</td>
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
        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button runat="server" ID="btnjobseekersubmit" CssClass="btn-submit" Text="Submit" />
            </td>
        </tr>
    </table>
</asp:Content>
