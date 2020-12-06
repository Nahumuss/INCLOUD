<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="INCLOUD.Pages.ChangePass" MasterPageFile="~/Pages/Master.Master" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
    <script src='https://www.google.com/recaptcha/api.js'></script>
    <script type="text/javascript" src="JavaScript/Forms.js"></script>
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="div">
        <form runat="server" onsubmit="return changePassVeri()">
            <%
                Response.Write("<h3>" + Session["secQuest"] + "</h3>");
            %>
            <input type="text" id="secureVeri" name="secureVeri" placeholder="Answer Security Question" class="input" />
            <div id="secureDiv" style="color: crimson; height: 20px;"></div>
            <h3>New Password:</h3>
            <input type="password" id="passmake" name="passmake" placeholder="Type New Password" class="input" />
            <div id="passmakeDiv" style="color: crimson; height: 20px;"></div>
            <input type="password" id="passmake2" name="passmake2" placeholder="Type New Password Again" class="input" />
            <div id="passmake2Div" style="color: crimson; height: 20px;"></div>
            <div class="g-recaptcha" data-sitekey="6LfHSIsUAAAAAKYoZXmoMMPkdaGnImYy6ivtmSfx" style="margin: auto; width: 304px; padding: 20px;padding-bottom: 50px; height: 30px"></div>
            <div id="captchaDiv" style="color: crimson; height: 20px;"></div>
            <br />
            <input style="font-size: 40px" class="button" type="submit" name="submit" id="submit" value="Change Password" />
        </form>
    </div>
</asp:Content>