<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="INCLOUD.Pages.SignIn" MasterPageFile="~/Pages/Master.Master" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
    <script src='https://www.google.com/recaptcha/api.js'></script>
    <script type="text/javascript" src="JavaScript/Forms.js"></script>
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form" runat="server" onsubmit="return SignInVerification()">
        <div class="div">
            <h1 style="margin: 10px">Sign In:</h1>
            <br />
            E-Mail:
                <br />
            <input type="text" id="email" name="email" placeholder="Type Email" class="input" />
            <div id="loginNotValid" style="color: crimson; height: 20px;"></div>
            Password:
                <br />
            <input type="password" id="password" name="password" placeholder="Type Password" class="input" />
            <br />
            <br />
            <input type="submit" id="submit" name="submit" class="button" style="width: 300px; height: 100px; font-size: 40px;" value="Sign-In" />
            <h3 style="margin-bottom: 0">Don't have an account?</h3>
            <p style="margin: 0"><a href="SignUp.aspx" class="link">Sign-Up</a></p>
            <h3 style="margin-bottom: 0">Forgot your password?</h3>
            <p style="margin: 0"><a href="ForgotPass.aspx" class="link">Change Password</a></p>
            <div class="g-recaptcha" data-sitekey="6LfHSIsUAAAAAKYoZXmoMMPkdaGnImYy6ivtmSfx" style="margin: auto; width: 304px; padding: 50px; height: 30px"></div>
            <div id="captchaDiv" style="color: crimson; height: 95px;"></div>
        </div>
    </form>
</asp:Content>
