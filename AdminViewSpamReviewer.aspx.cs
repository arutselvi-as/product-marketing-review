using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AdminViewSpamReviewer : System.Web.UI.Page
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
            {
                bindgrid();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

    void bindgrid()
    {
        adp=new SqlDataAdapter ("select * from srtable ", con);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
     }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try 
        {

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string uname = GridView1.Rows[i].Cells[0].Text;
                int pid = int.Parse (GridView1.Rows[i].Cells[1].Text);

                cmd = new SqlCommand("delete from srtable where uname=@uname and pid=@pid", con);
                cmd.Parameters.AddWithValue("uname", uname);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
       
            }
            bindgrid();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }


    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string uname = GridView1.Rows[i].Cells[0].Text;
                int pid = int.Parse(GridView1.Rows[i].Cells[1].Text);

                cmd = new SqlCommand("delete from srtable where uname=@uname and pid=@pid", con);
                cmd.Parameters.AddWithValue("uname", uname);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from revtable where uname=@uname and pid=@pid", con);
                cmd.Parameters.AddWithValue("uname", uname);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            bindgrid();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}