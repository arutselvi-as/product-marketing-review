using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AdminViewSpamReviewChart : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;

    SqlDataAdapter adp;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Label1.Text = "";
            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
                bindchart();



        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void bindchart()
    {
        try
        {

            adp = new SqlDataAdapter("select pid, count(*) as scount from srtable group by pid", con);
            dt = new DataTable();
            adp.Fill(dt);


            Chart1.DataSource = dt;
            Chart1.DataBind();
            Chart1.Series[0].XValueMember = "pid";


            Chart1.Series[0].YValueMembers = "sCount";




        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}