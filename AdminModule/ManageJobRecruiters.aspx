<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageJobRecruiters.aspx.cs" Inherits="job_portal.AdminModule.ManageJobRecruiters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:GridView runat="server" ID="gvRec" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvRec_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText=" Name">
                            <ItemTemplate><%#Eval("JobRecruiterName") %></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText=" Email">
                            <ItemTemplate><%#Eval("JobRecruiterEmail") %></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText=" State">
                            <ItemTemplate><%#Eval("StateName") %></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText=" City">
                            <ItemTemplate><%#Eval("CityName") %></ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText=" Mobile">
                            <ItemTemplate><%#Eval("JobRecruiterMobile") %></ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Comment">
                            <ItemTemplate><%#Eval("JobRecruiterComments") %></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image runat="server" ID="imgRecruiter"   ImageUrl='<%# Eval("JobRecruiterImage", "~/JobRecruiterimage/{0}") %>' Width="100px" Height="100px" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btndel"
                                    CommandName="A"
                                    Text='<%# Eval("JobRecruiterStatus").ToString() == "0" ? "Active" : "Blocked" %>'
                                    CommandArgument='<%# Eval("JobRecruiterId") %>' />

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
