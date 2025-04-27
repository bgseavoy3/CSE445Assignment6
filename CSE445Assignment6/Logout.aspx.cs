using System;
using System.Web;
using System.Web.UI;

namespace CSE445Assignment6
{
    public partial class Logout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["memberName"] != null)
            {
                var c = new HttpCookie("memberName")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(c);
            }
            Response.Redirect("Login.aspx");
        }
    }
}
