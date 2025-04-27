using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;

namespace CSE445Assignment6
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // redirect to login if no cookie
            var cookie = Request.Cookies["memberName"];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                // load from XML
                string user = cookie.Value;
                string xmlPath = Server.MapPath("~/App_Data/Member.xml");
                var doc = XDocument.Load(xmlPath);

                var node = doc.Root
                              .Elements("User")
                              .FirstOrDefault(x => (string)x.Attribute("username") == user);
                if (node != null)
                {
                    chkService1.Checked = (string)node.Attribute("service1") == "true";
                    chkService2.Checked = (string)node.Attribute("service2") == "true";
                    chkService3.Checked = (string)node.Attribute("service3") == "true";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // same cookie check
            var cookie = Request.Cookies["memberName"];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
            {
                Response.Redirect("Login.aspx");
                return;
            }

            // update XML
            string user = cookie.Value;
            string xmlPath = Server.MapPath("~/App_Data/Member.xml");
            var doc = XDocument.Load(xmlPath);

            var node = doc.Root
                          .Elements("User")
                          .FirstOrDefault(x => (string)x.Attribute("username") == user);
            if (node != null)
            {
                node.SetAttributeValue("service1", chkService1.Checked ? "true" : "false");
                node.SetAttributeValue("service2", chkService2.Checked ? "true" : "false");
                node.SetAttributeValue("service3", chkService3.Checked ? "true" : "false");
                doc.Save(xmlPath);
            }
        }
    }
}
