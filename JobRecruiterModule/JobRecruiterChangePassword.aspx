<%@ Page Title="" Language="C#" MasterPageFile="~/JobRecruiter.Master" AutoEventWireup="true" CodeBehind="JobRecruiterChangePassword.aspx.cs" Inherits="job_portal.JobRecruiterModule.JobRecruiterChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Current Password:</td>
            <td>
                <asp:TextBox runat="server" ID="txtcp"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>New Password:</td>
            <td>
                <asp:TextBox runat="server" ID="txtnp"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Confirm New Password:</td>
            <td>
                <asp:TextBox runat="server" ID="txtcnp"></asp:TextBox>
            </td>
        </tr>
        <tr>
           <td> <asp:Button  runat="server" ID="btncp" OnClick="btncp_Click" Text="Change Password"/></td>
            <asp:Label runat="server" ID="lblmsg" forecolor="Red" ></asp:Label>
        </tr>
    </table>
</asp:Content>
