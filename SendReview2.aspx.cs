using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Data;

public partial class SendReview2 : System.Web.UI.Page
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
            Menu m3 = (Menu)Master.FindControl("Menu3");
            m3.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    TextBox1.Text = Session["UserName"].ToString();
                    TextBox2.Text = Request.QueryString.Get("PID").ToString();
                    TextBox3.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void checkuser()
    {
        cmd = new SqlCommand("select * from revtable where pid=@pid and srating=@srating and rrating=@rrating and erating=@erating and urating=@urating order by rdate", con);
        cmd.Parameters.AddWithValue("pid", TextBox2.Text);
        cmd.Parameters.AddWithValue("srating", DropDownList1.SelectedItem.Text);
        cmd.Parameters.AddWithValue("rrating", DropDownList2.SelectedItem.Text);
        cmd.Parameters.AddWithValue("erating", DropDownList3.SelectedItem.Text);
        cmd.Parameters.AddWithValue("urating", DropDownList4.SelectedItem.Text);
        rs = cmd.ExecuteReader();
        string uname = "";
        if (rs.Read())
        {
            uname = rs["uname"].ToString();
            rs.Close();
            cmd.Dispose();
        }
        else
        {
            rs.Close();
            cmd.Dispose();
            uname = Session["UserName"].ToString();
        }

        cmd = new SqlCommand("select * from rctable where uname=@uname and pid=@pid", con);
        cmd.Parameters.AddWithValue("uname", uname);
        cmd.Parameters.AddWithValue("pid", TextBox2.Text);
        rs = cmd.ExecuteReader();
        bool b = rs.Read();
        rs.Close();
        cmd.Dispose();
        if (b)
        {
            cmd = new SqlCommand("update rctable set rcount=rcount+1 where uname=@uname and pid=@pid", con);
            cmd.Parameters.AddWithValue("uname", uname);
            cmd.Parameters.AddWithValue("pid", TextBox2.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        else
        {
            cmd = new SqlCommand("insert into rctable values(@uname,@pid,@rcount,@rcdate)", con);
            cmd.Parameters.AddWithValue("uname", uname);
            cmd.Parameters.AddWithValue("pid", TextBox2.Text);
            cmd.Parameters.AddWithValue("rcount", 1);
            cmd.Parameters.AddWithValue("rcdate", DateTime.Now.ToString("dd-MMM-yyyy"));
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
    }

  
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        try
        {

            if (Session["UserName"] != null)
            {
                cmd = new SqlCommand("select * from revtable where uname=@uname and pid=@pid", con);
                cmd.Parameters.AddWithValue("uname", TextBox1.Text);
                cmd.Parameters.AddWithValue("pid", TextBox2.Text);
                rs = cmd.ExecuteReader();
                bool b = rs.Read();
                rs.Close();
                cmd.Dispose();
                if (b)
                {
                    cmd = new SqlCommand("insert into srtable values(@uname,@pid,@srating,@rrating,@erating,@urating)", con);
                    cmd.Parameters.AddWithValue("uname", TextBox1.Text);
                    cmd.Parameters.AddWithValue("pid", TextBox2.Text);
                    cmd.Parameters.AddWithValue("srating", DropDownList1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("rrating", DropDownList2.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("erating", DropDownList3.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("urating", DropDownList4.SelectedItem.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return;

                }




                int pid = int.Parse(Request.QueryString.Get("PID"));
                string uname = Session["UserName"].ToString();


                cmd=new SqlCommand ("select * from purtable where uname=@uname and pid=@pid", con );
                cmd.Parameters .AddWithValue ("uname", uname );
                cmd.Parameters .AddWithValue ("pid", pid);
                rs=cmd.ExecuteReader ();
                 b =rs.Read ();
                rs.Close ();
                cmd.Dispose ();
                string status="";
                if(b)
                    status ="Purchased User";
                else
                    status ="Not Purchased User";

                    cmd = new SqlCommand("select isnull(max(rid),1000)+1 from revtable", con);
                    int rid = int.Parse(cmd.ExecuteScalar().ToString());
                    cmd.Dispose();
                    cmd = new SqlCommand("insert into revtable values(@uname,@pid,@rid,@rdate,@srating,@rrating,@erating,@urating,@status)", con);
                    cmd.Parameters.AddWithValue("uname", TextBox1.Text);
                    cmd.Parameters.AddWithValue("pid", TextBox2.Text);
                    cmd.Parameters.AddWithValue("rid", rid);
                    cmd.Parameters.AddWithValue("rdate", TextBox3.Text);
               
                    cmd.Parameters.AddWithValue("srating", DropDownList1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("rrating", DropDownList2.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("erating", DropDownList3.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("urating", DropDownList4.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("status", status );
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    Label1.Text = "Review Details Inserted.";

                    checkuser();
                }
            }
        
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
  
        DropDownList1.SelectedIndex = 0;
        DropDownList2.SelectedIndex = 0;
        DropDownList3.SelectedIndex = 0;
        DropDownList4.SelectedIndex = 0;
      
    }
}