<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CRUD_WebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Name:</td>
                    <td>
                        <asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Gender:</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Date of Birth:</td>
                    <td>
                        <asp:TextBox ID="txtdob" TextMode="Date" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>Hobby:</td>
                    <td>
                        <asp:CheckBox ID="CheckBox1" Text="Football" runat="server" />
                        <asp:CheckBox ID="CheckBox2" Text="Football" runat="server" />
                        <asp:CheckBox ID="CheckBox3" Text="Football" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />

                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="Show" />

                    </td>
                </tr>
            </table>
        </div>
        <div><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:TextBox ID="grdtxtId" Text='<%#Eval("Id") %>' runat="server" Enabled="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:TextBox ID="grdtxtName" Text='<%#Eval("Name") %>' runat="server" Enabled="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Gender">
                    <ItemTemplate>
                        <asp:TextBox  ID="grdtxtGender" Text='<%#Eval("Gender") %>' runat="server" Enabled="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date of Birth">
                    <ItemTemplate>
                        <asp:TextBox ID="grdtxtDOB" Text='<%#Eval("Date_of_Birth") %>' runat="server" Enabled="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hobby">
                    <ItemTemplate>
                        <asp:TextBox ID="grdtxtHobby" Text='<%#Eval("Hobby") %>' runat="server" Enabled="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView></div>
    </form>
</body>
</html>
