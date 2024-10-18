<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminChangePassword.aspx.cs" Inherits="job_portal.AdminModule.AdminChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Current Password :</td>
            <td><asp:TextBox runat="server" ID="txtcp"></asp:TextBox></td>
        </tr>
        <tr>
    <td>New Password :</td>
    <td><asp:TextBox runat="server" ID="txtnp"></asp:TextBox></td>
</tr>
        <tr>
    <td>Confirm New Password :</td>
    <td><asp:TextBox runat="server" ID="txtcnp"></asp:TextBox></td>
</tr>
        <tr>
           <td> <asp:Button runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" Text="Change Password"/></td>
             <asp:Label runat="server" ID="lblmsg" forecolor="Red" ></asp:Label>
        </tr>
    </table>
</asp:Content>
