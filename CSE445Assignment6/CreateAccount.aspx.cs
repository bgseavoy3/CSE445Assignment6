using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using LocalCryptoLib;

namespace CSE445Assignment6
{
    public partial class CreateAccount : Page
    {
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string xmlPath = Server.MapPath("~/App_Data/Member.xml");
            var doc = XDocument.Load(xmlPath);
            var user = txtUser.Text.Trim();

            if (string.IsNullOrEmpty(user))
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Username required";
                return;
            }

            if (doc.Root.Elements("User")
                    .Any(x => (string)x.Attribute("username") == user))
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Username already exists";
                return;
            }

            // encrypt the password before saving
            var encrypted = CryptoUtils.Encrypt(txtPass.Text.Trim());

            doc.Root.Add(new XElement("User",
                new XAttribute("username", user),
                new XAttribute("password", encrypted),
                new XAttribute("service1", "false"),
                new XAttribute("service2", "false"),
                new XAttribute("service3", "false")
            ));

            doc.Save(xmlPath);

            // auto-login
            var c = new HttpCookie("memberName", user);
            Response.Cookies.Add(c);
            Response.Redirect("Default.aspx");
        }
    }
}
