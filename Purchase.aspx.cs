using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Purchase : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m3 = (Menu)Master.FindControl("Menu3");
            m3.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try 
        {
            if (Session["UserName"] != null)
            {
                string uname = Session["UserName"].ToString();
               int pid =int.Parse (Request .QueryString .Get ("pid"));
               float price = float.Parse(Request.QueryString.Get("price"));

                

                cmd = new SqlCommand("select amount from acctable where uname=@uname and accno=@accno", con);
                cmd.Parameters.AddWithValue("uname", Session["UserName"].ToString());
                cmd.Parameters.AddWithValue("accno", TextBox1.Text);
                rs = cmd.ExecuteReader();
                float amount = 0;
                if (rs.Read())
                {
                    amount = float.Parse(rs["amount"].ToString());
                    rs.Close();
                    cmd.Dispose();
                }
                else
                {
                    rs.Close();
                    cmd.Dispose();
                    Label1.Text = "Invalid UserName Or Account Number.....";
                    return;
                }
                if (amount < price)
                {
                    Label1.Text = "Insufficient Balance.So Product Not Purchased....";
                    return;
                }

                cmd = new SqlCommand("insert into purtable values(@accno,@uname,@pid,@price,@pdate)", con);
                cmd.Parameters .AddWithValue ("accno",TextBox1 .Text );
                cmd.Parameters .AddWithValue ("uname",Session ["UserName"].ToString ());
                cmd.Parameters .AddWithValue ("pid",pid );
                cmd.Parameters .AddWithValue ("price",price );
                cmd.Parameters .AddWithValue ("pdate",DateTime .Now .ToString ());
                int no = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (no != 0)
                {
                    cmd = new SqlCommand("update acctable set amount=amount-@amount where uname=@uname and accno=@accno", con);
                    cmd.Parameters.AddWithValue("amount", price);
                    cmd.Parameters.AddWithValue("uname", Session["UserName"].ToString());
                    cmd.Parameters.AddWithValue("accno", TextBox1.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    cmd = new SqlCommand("update rtable set rank=rank+1 where pid=@pid", con);
                    cmd.Parameters.AddWithValue("pid", pid);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    Label1.Text = "Product Purchase Details Inserted....";

                }
           }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}