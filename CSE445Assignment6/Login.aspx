<%@ Page 
    Language="C#" 
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true" 
    CodeBehind="Login.aspx.cs"
    Inherits="CSE445Assignment6.Login" 
%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <h2>Log In</h2>

  <asp:Label ID="lblUser" runat="server" Text="Username:" /><br />
  <asp:TextBox ID="txtUsername" runat="server" /><br /><br/>

  <asp:Label ID="lblPass" runat="server" Text="Password:" /><br />
  <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /><br /><br/>

  <asp:Button ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click" /><br /><br/>
  <asp:Label ID="lblError" runat="server" ForeColor="Red" /><br />

  <asp:HyperLink 
      ID="hlCreate" 
      runat="server"
      NavigateUrl="~/CreateAccount.aspx"
      Text="New user? Create an account" 
      CssClass="btn btn-link" />

</asp:Content>
