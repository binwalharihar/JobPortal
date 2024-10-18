<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeeker.Master" AutoEventWireup="true" CodeBehind="newJobs.aspx.cs" Inherits="job_portal.JobSeekerModule.newJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table>
         <tr>
             <asp:DropDownList runat="server" ID="ddljobprofile"></asp:DropDownList>
             <asp:Button runat="server" ID="btnsearch" OnClick="btnsearch_Click" Text="Search"/>
         </tr>
     <tr>
         <td>
             <asp:GridView runat="server" ID="gvjobpost" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" >
                 <AlternatingRowStyle BackColor="White" />
                 <Columns>
                     <asp:TemplateField HeaderText="Recruiter Name">
                         <ItemTemplate><%#Eval("JobRecruiterName") %></ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Job Profile">
                         <ItemTemplate><%#Eval("JobProfileName") %></ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Work Mode">
                         <ItemTemplate><%#Eval("JobPostMode").ToString()=="1"?"Work From Home":Eval("JobPostMode").ToString()=="2"?"Work From office":"Hybrid Mode" %></ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Required Gender">
                         <ItemTemplate><%#Eval("JobPostGender").ToString()=="1"?"Male":Eval("JobPostMode").ToString()=="2"?"Female":"Both" %></ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Required Qualification">
                         <ItemTemplate><%#Eval("JobPostQualifications") %></ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Required Experience">
                         <ItemTemplate><%#Eval("JobPostMinExp") %>-<%#Eval("JobPostMaxExp") %></ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Offered Salary">
                         <ItemTemplate><%#Eval("JobPostMinSalary") %>-<%#Eval("JobPostMaxSalary") %></ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Vacancy">
                         <ItemTemplate><%#Eval("JobPostvacancy") %></ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Comment">
                         <ItemTemplate><%#Eval("JobPostcomments") %></ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField>
                         <ItemTemplate>
                             <asp:Button runat="server" Text="Apply" ID="btnapply"/>
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
