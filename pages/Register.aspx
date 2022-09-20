<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" EnableSessionState="ReadOnly" Inherits="cldvPoeFinal.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Register Page</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
        <Scripts>
            <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
            <%--Framework Scripts--%>
            <asp:ScriptReference Name="MsAjaxBundle" />
            <asp:ScriptReference Name="jquery" />
            <asp:ScriptReference Name="bootstrap" />
            <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
            <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
            <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
            <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
            <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
            <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
            <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
            <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
            <asp:ScriptReference Name="WebFormsBundle" />
            <%--Site Scripts--%>
        </Scripts>
        </asp:ScriptManager>

        <div class="container body-content">
            <div class="col-md-6">
                <h2>THE RIDE YOU RENT WEBSITE</h2>
                <h3>INSPECTOR-REGISTER</h3><br /><br />
                <asp:Label ID="lblRegisterName" class="col-sm-3 col-form-label"  runat="server" Text="Name: "></asp:Label>
                <asp:TextBox ID="txtRegisterName" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="lblRegisterPassword" class="col-sm-3 col-form-label"  runat="server" Text="Password: "></asp:Label>
                <asp:TextBox ID="txtRegisterPassword" type="password" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click"/>
                <br /><br /><asp:Label ID="lblRegisterMessage" runat="server" Text=""></asp:Label>

                <br /><br /><p>Return to login page using the link below.</p>
                <a href="/Login">Login</a><br /><br /><br /><br />
            </div>
        </div>
        <hr />
        <footer>
            <p>&copy; <%: DateTime.Now.Year %> - My ASP.NET Application</p>
        </footer>
    </form>
</body>
</html>