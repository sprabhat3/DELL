<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="HospitalManagement.RegistrationForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td style="padding: 20px; border-style: solid; border-color: black">
                <center>
                <table>
                    <tr>
                        <td>Name:</td>
                        <td>
                            <asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>Gender:</td>
                        <td>
                            <asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3"></asp:RadioButtonList></td>
                    </tr>

                    <tr>
                        <td>Blood Group:</td>
                        <td>
                            <asp:RadioButtonList ID="rblbloodgroup" runat="server" RepeatColumns="8"></asp:RadioButtonList></td>
                    </tr>

                    <tr>
                        <td>Status:</td>
                        <td>
                            <asp:RadioButtonList ID="rblstatus" runat="server" RepeatColumns="4"></asp:RadioButtonList></td>
                    </tr>

                    <tr>
                        <td>Department:</td>
                        <td>
                            <asp:DropDownList ID="ddldepartment" runat="server"></asp:DropDownList></td>
                    </tr>

                    <tr>
                        <td>Course:</td>
                        <td>
                            <asp:DropDownList ID="ddlcourse" runat="server"></asp:DropDownList></td>
                    </tr>

                    <tr>
                        <td>Country:</td>
                        <td>
                            <asp:DropDownList ID="ddlcountry" runat="server"></asp:DropDownList></td>
                    </tr>

                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" Text="Save" /></td>
                    </tr>


                </table>
</center>
            </td>
        </tr>

        <tr>



            <td>
                <asp:GridView ID="gvregistration" runat="server" OnRowCommand="gvregistration_RowCommand" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                    <Columns>
                        <asp:TemplateField HeaderText="Employee ID">
                        <ItemTemplate>
                            <%#Eval("employee_id") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee Name">
                            <ItemTemplate>
                                <%#Eval("employee_name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee Gender">
                            <ItemTemplate>
                                <%#Eval("gender_name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee Blood Group">
                            <ItemTemplate>
                                <%#Eval("bloodgroup_name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee Status">
                            <ItemTemplate>
                                <%#Eval("status_name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee Department">
                            <ItemTemplate>
                                <%#Eval("department_name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee Course">
                            <ItemTemplate>
                                <%#Eval("course_name") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Country">
                            <ItemTemplate>
                                <%#Eval("country_name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="DEL" CommandArgument='<%#Eval("employee_id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="EDI" CommandArgument='<%#Eval("employee_id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>


            </td>
        </tr>
    </table>


</asp:Content>
