using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;

public partial class AdminViewEarlyReviewChart : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;

    SqlDataAdapter adp;
    DataSet ds;
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
            DataTable dt =new DataTable ();
            dt.Columns .Add ("PUName");
            dt.Columns .Add ("RCount", typeof (int));
            adp=new SqlDataAdapter ("select * from rctable order by pid,rcdate,rcount desc", con);
            ds=new DataSet ();
            adp.Fill (ds);
            for (int i=0 ;i<ds.Tables [0].Rows.Count ; i++)
            {
                string puname=ds.Tables [0].Rows [i]["pid"].ToString ()+"-"+ds.Tables [0].Rows [i]["uname"].ToString ();
                DataRow dr=dt.NewRow ();
                dr[0]=puname ;
                dr[1]=ds .Tables [0].Rows [i]["rcount"].ToString ();
                dt.Rows .Add (dr);
            }
                Chart1.DataSource = dt;
                Chart1.DataBind();
                Chart1.Series[0].XValueMember = "PUName";
                Chart1.Series[0].YValueMembers = "RCount";

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
  }