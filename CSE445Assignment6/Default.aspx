<%@ Page Title="Service Preferences"
         Language="C#"
         MasterPageFile="~/Site.Master"
         AutoEventWireup="true"
         CodeBehind="Default.aspx.cs"
         Inherits="CSE445Assignment6._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Welcome, <%: Request.Cookies["memberName"]?.Value ?? "guest" %>!
  </h2>

  <p>Select which services you want to enable:</p>
  <asp:CheckBox ID="chkService1" runat="server" Text="Service 1 (placeholder)" /><br />
  <asp:CheckBox ID="chkService2" runat="server" Text="Service 2 (placeholder)" /><br />
  <asp:CheckBox ID="chkService3" runat="server" Text="Service 3 (placeholder)" /><br />

  <asp:Button ID="btnSave" runat="server"
              Text="Save Preferences"
              OnClick="btnSave_Click"
              CssClass="btn btn-primary" />
  &nbsp;
  <asp:HyperLink ID="hlLogout" runat="server"
                 NavigateUrl="Logout.aspx"
                 Text="Log Out"
                 CssClass="btn btn-link" />
</asp:Content>
