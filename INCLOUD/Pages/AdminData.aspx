<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminData.aspx.cs" Inherits="INCLOUD.Pages.AdminData" MasterPageFile="~/Pages/Master.Master" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="div">
        <h1 style="margin-top: 0px">Admin data:</h1>
        <form onsubmit="return true" method="post" runat="server">
            <input type="text" name="searchbar" class="input" placeholder="Search somone by email" />
            <input type="submit" id="submit" name="submit" class="button" style="width: 200px; height: 60px; font-size: 20px;" value="Search" />
            <%
                    Response.Write("<p>Star rate avarage: " + (int)Application["stars"] / ((int)Application["starsCount"] * 1.0) + " (" + (int)Application["starsCount"] + " Votes)</p>");
                    Response.Write("<p>Number of online users: " + Application["numberOfOnlineUsers"] + ", All time users: " + Application["numberOfUsers"] + "</p>");
                    Response.Write(GetChart(Request.Form["searchbar"]));
            %>
            <input type="submit" name="update" class="button" style="width: 200px; height: 60px; font-size: 20px;" value="Update" />
            <div style="height: 150px;"></div>
        </form>
    </div>
</asp:Content>