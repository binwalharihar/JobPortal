<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageJobSeekers.aspx.cs" Inherits="job_portal.AdminModule.ManageJobSeekers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:GridView runat="server" ID="gvSek" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvSek_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText=" Name">
                            <ItemTemplate><%#Eval("JobSeekerName") %></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText=" Email">
                            <ItemTemplate><%#Eval("JobSeekerEmail") %></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText=" State">
                            <ItemTemplate><%#Eval("StateName") %></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText=" City">
                            <ItemTemplate><%#Eval("CityName") %></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText=" Mobile">
                            <ItemTemplate><%#Eval("JobSeekerMobile") %></ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Comment">
                            <ItemTemplate><%#Eval("JobSeekerComments") %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Profile">
                            <ItemTemplate><%#Eval("JobProfileName") %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qualification">
                            <ItemTemplate><%#Eval("QualificationName") %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DOB">
                            <ItemTemplate><%#Eval("JobSeekerDOB") %></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnblock" Text='<%# Eval("JobSeekerStatus").ToString()=="0" ? "Active":"Blocked" %>' CommandName="A" CommandArgument='<%# Eval("JobSeekerId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
