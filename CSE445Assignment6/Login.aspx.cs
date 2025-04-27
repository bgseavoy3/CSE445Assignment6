using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using LocalCryptoLib;   // your local DLL

namespace CSE445Assignment6
{
    public partial class Login : Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // load your XML users file
            string xmlPath = Server.MapPath("~/App_Data/Member.xml");
            var doc = XDocument.Load(xmlPath);

            string user = txtUsername.Text.Trim();
            // encrypt the incoming password for comparison
            string attempt = CryptoUtils.Encrypt(txtPassword.Text.Trim());

            var node = doc.Root
                          .Elements("User")
                          .FirstOrDefault(x =>
                              (string)x.Attribute("username") == user
                              && (string)x.Attribute("password") == attempt
                          );

            if (node == null)
            {
                lblError.Text = "Invalid credentials";
                return;
            }

            // successful: drop a cookie & redirect
            var c = new HttpCookie("memberName", user);
            Response.Cookies.Add(c);
            Response.Redirect("Default.aspx");
        }
    }
}
