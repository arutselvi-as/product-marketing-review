using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class BankAccount : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    TextBox1.Text = Session["UserName"].ToString();
                    AccountNumber();
                    cmd = new SqlCommand("select * from regtable where uname=@uname", con);
                    cmd.Parameters.AddWithValue("uname", TextBox1.Text);
                    rs = cmd.ExecuteReader();
                    if (rs.Read())
                    {
                        TextBox4.Text = rs["emailid"].ToString();
                        TextBox5.Text = rs["mnumber"].ToString();
                        TextBox6.Text = rs["address"].ToString();
                        rs.Close();
                        cmd.Dispose();
                    }
                    else
                    {
                        rs.Close();
                        cmd.Dispose();
                        Label1.Text = "Check RegTable.....";
                        return;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void AccountNumber()
    {
        try 
        {
            cmd = new SqlCommand("select isnull(max(accno),1000)+1 from acctable", con);
            TextBox2.Text = cmd.ExecuteScalar().ToString();
            cmd.Dispose();

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
            cmd = new SqlCommand("select  * from acctable where uname=@uname", con);
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Account Already Created....";
                return;
            }
            cmd = new SqlCommand("insert into acctable values(@uname,@accno,@bname,@amount)", con);
            cmd.Parameters .AddWithValue ("uname",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("accno",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("bname",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("amount",TextBox7 .Text );
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "New Account Creation Details Inserted.....";
        }
   
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
     
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox7.Text = "";
        AccountNumber();
    }
}