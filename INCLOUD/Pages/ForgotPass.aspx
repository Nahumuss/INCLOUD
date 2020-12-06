<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPass.aspx.cs" Inherits="INCLOUD.Pages.ForgotPass" MasterPageFile="~/Pages/Master.Master" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript" src="JavaScript/Forms.js"></script>
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center; padding: 50px 16px; height: 1000px;">
        <form id="form1" runat="server" onsubmit="return mailVeri()">
            <h3>Forgot Password?</h3>
            <input class="input" type="text" placeholder="Type your e-mail" id="email" name="email" />
            <div id="emailErrDiv" style="color: crimson; height: 20px;"></div>
            <input class="button" type="submit" name="submit" id="submit" value="Send E-Mail" style="font-size:50px;" />
            <div id="sentMailDiv" style="color: darkseagreen; height: 20px;"></div>
        </form>
    </div>
</asp:Content>