<%@ Page Title="" Language="C#" MasterPageFile="~/JobRecruiter.Master" AutoEventWireup="true" CodeBehind="PostNewJobs.aspx.cs" Inherits="job_portal.JobRecruiterModule.PostNewJobs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Job Profile:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddljobprofile"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Job Mode:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddljobmode">
                    <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="work from home" Value="1"></asp:ListItem>
                    <asp:ListItem Text="work from office" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Hybrid mode" Value="3"></asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>Required Gender : </td>
            <td>
                <asp:RadioButtonList runat="server" ID="rblgender" RepeatColumns="3">
                    <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Both" Value="3"></asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>Required Qualification :</td>
            <td>
                <asp:CheckBoxList runat="server" ID="cblqualification" RepeatColumns="6"></asp:CheckBoxList></td>
        </tr>
        <tr>
            <td>Min Exp :</td>
            <td>
                <asp:TextBox runat="server" ID="txtminexp"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Max Exp :</td>
            <td>
                <asp:TextBox runat="server" ID="txtmaxexp"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Min Salary :</td>
            <td>
                <asp:TextBox runat="server" ID="txtminsalary"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Max Salary :</td>
            <td>
                <asp:TextBox runat="server" ID="txtmaxsalary"></asp:TextBox></td>
        </tr>
        <tr>
            <td>No. of Vacancies  :</td>
            <td>
                <asp:TextBox runat="server" ID="txtvacancies"></asp:TextBox></td>
        </tr>
        <tr>
            <td> comments :</td>
            <td>
                <asp:TextBox runat="server" ID="txtcomment"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" ID="btnjobpost" Text="Post Job" OnClick="btnjobpost_Click"/>
                <asp:Label runat="server" ID="lblmsg" ForeColor="Red"></asp:Label>
            </td>
        </tr>

    </table>
</asp:Content>
