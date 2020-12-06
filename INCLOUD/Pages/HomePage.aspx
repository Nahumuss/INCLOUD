<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="INCLOUD.Pages.HomePage" MasterPageFile="~/Pages/Master.Master" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="JavaScript/Interactive.js"></script>
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="div">
            <%
                if (Session["email"] != null)
                {
                    Response.Write("Hello, " + Session["username"]);
                }
            %>
            <h1 class="big">IN<a style="font-size: 170px; color: aliceblue">☁</a></h1>
            <h2 style="text-decoration: none">The Perfect Cloud Solution</h2>
            <% 
                if (Session["email"] == null)
                {
                    Response.Write("<a class='button' href='SignUp.aspx'>Sign-Up</a>" +
                    "<a class='button' href='SignIn.aspx'>Sign-In</a>");
                };
            %>
            <div id="clock" class="clock"></div>
        </div>
    </form>
</asp:Content>