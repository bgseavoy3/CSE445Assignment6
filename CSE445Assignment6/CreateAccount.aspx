<%@ Page 
    Language="C#" 
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true" 
    CodeBehind="CreateAccount.aspx.cs"
    Inherits="CSE445Assignment6.CreateAccount" 
%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <h2>Create Account</h2>

  <asp:Label ID="lblUser" runat="server" Text="Username:" /><br />
  <asp:TextBox ID="txtUser" runat="server" /><br /><br/>

  <asp:Label ID="lblPass" runat="server" Text="Password:" /><br />
  <asp:TextBox ID="txtPass" runat="server" TextMode="Password" /><br /><br/>

  <asp:Button ID="btnCreate" runat="server" Text="Register" OnClick="btnCreate_Click" /><br /><br/>
  <asp:Label ID="lblMsg" runat="server" ForeColor="Green" /><br />

  <asp:HyperLink 
      ID="hlLogin" 
      runat="server"
      NavigateUrl="~/Login.aspx"
      Text="Already have an account? Log in" 
      CssClass="btn btn-link" />

</asp:Content>
