using System;
using System.Data;

using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class ShowMyDetails : System.Web.UI.Page
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
            if (!Page.IsPostBack)
                bindview();

        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }

    }
    void bindview()
    {
        if (Session["UserName"] != null)
        {
            adp = new SqlDataAdapter("select * from regtable where uname=@uname", con);
            adp.SelectCommand.Parameters.AddWithValue("uname", Session["UserName"].ToString());
            ds = new DataSet();
            adp.Fill(ds);
            DetailsView1.DataSource = ds.Tables[0];
            DetailsView1.DataBind();
        }
    }
    
}
