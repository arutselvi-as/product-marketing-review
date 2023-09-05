using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class ViewAccount : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataSet ds;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m3 = (Menu)Master.FindControl("Menu3");
            m3.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();

            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    bindview();
                }
            }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

    void bindview()
    {
        try 
        {
            adp = new SqlDataAdapter("select  r1.uname,r1.emailid,r1.mnumber,r1.gender,a1.accno,a1.bname,a1.amount from  regtable r1,acctable a1 where  r1.uname=a1.uname and a1.uname=@uname", con);
            adp.SelectCommand.Parameters.AddWithValue("uname", Session["UserName"].ToString());
            ds = new DataSet();
            adp.Fill(ds);
            DetailsView1.DataSource = ds;
            DetailsView1.DataBind();

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}
