<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoragePage.aspx.cs" Inherits="INCLOUD.Pages.StoragePage" MasterPageFile="~/Pages/Master.Master" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div style="text-align: center; padding: 50px 16px; height: 800px;">
            <h1>Your Storage:</h1>
            <asp:FileUpload ID="FileUpload1" class="button" runat="server" Style="font-size: 20px" />
            <asp:Button ID="Button1" runat="server" class="button" Text="Upload" OnClick="Button1_Click" Style="font-size: 22px" />
            <br />
            <br />
            <asp:GridView HorizontalAlign="Center" ID="GridView1" runat="server" class="" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" DataKeyNames="ID">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="OpenDocument" Text='<%# Eval("File_Name")%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete?">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
            <asp:Button runat="server" Text="Update" id="Update" class="button" OnClick="UpdateTable" style="font-size: 20px"/>
        </div>
    </form>
</asp:Content>
