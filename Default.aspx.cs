using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TryItPage.ServiceReference1;
using TryItPage.ServiceReference2;
using TryItPage.ServiceReference3;

namespace TryItPage
{
    public partial class _Default : Page
    {
        ServiceReference1.Service1Client client1 = new ServiceReference1.Service1Client();
        ServiceReference2.Service1Client client2 = new ServiceReference2.Service1Client();
        ServiceReference3.Service1Client client3 = new ServiceReference3.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                System.Diagnostics.Debug.WriteLine("Check passed");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Check failed");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string input = TextBox1.Text;
            string result = client1.RemoveAdditionalWords(input);
            Label1.Text = result;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string input = TextBox2.Text;
            string result = client2.ChatResponses(input);
            Label2.Text = result;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string input = TextBox3.Text;
            AnalysisResult result = client3.AnalyzeInput(input);
            Label3.Text = result.Diagnosis;
            Label4.Text = result.Severity;
            Label5.Text = string.Join(", ", result.Symptoms);
            Label6.Text = result.SymptomCount.ToString();

        }
    }
}