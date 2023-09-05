using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient ;
using System.Data ;
using System.Configuration ;

public partial class AdminViewMonthwiseReport : System.Web.UI.Page
{
    SqlConnection con;
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
                TextBox1.Text = DateTime.Now.Year.ToString();
            
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

    void bindgrid()
    {
        GridView1.Visible =true ;
        adp = new SqlDataAdapter("select * from purtable where month(pdate)=@pdate1 and year(pdate)=@pdate2", con);
        adp.SelectCommand .Parameters .AddWithValue ("pdate1", DropDownList1 .SelectedItem.Value );
        adp.SelectCommand .Parameters .AddWithValue ("pdate2", TextBox1 .Text );
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            GridView1.Visible = false;

            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Month......";
                return;
            }

            bindgrid();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}