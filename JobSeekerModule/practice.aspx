<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeeker.Master" AutoEventWireup="true" CodeBehind="practice.aspx.cs" Inherits="job_portal.JobSeekerModule.practice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../jquery.js"></script>
    <script type="text/javascript">
        function Insert() {
            $.ajax({
                url: 'practice.aspx/SaveData',
                type: 'post',
                contentType: 'application/json;charset=utf-8',
                data: "{name:'" + $(txtname).val() + "',age:'" + $(txtage).val() +"'}",
                dataType: 'json',
                success: function () {
                    alert("success !!")
                },
                error: function () {
                    alert("failed !!")
                },
            });
        }
    </script>
    <table>
        <tr>
            <td>Name:</td>
            <td>
                <input id="txtname" type="text" />
            </td>
        </tr>
        <tr>
            <td>Age:</td>
            <td>
                <input id="txtage" type="number" />
            </td>
        </tr>
        <tr>
            <td>
                <input id="btnSubmit" type="button" onclick="Insert()" value="Submit"/>
            </td>
        </tr>
    </table>
</asp:Content>
