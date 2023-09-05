using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Net;

public partial class Login : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;
          
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
                cmd = new SqlCommand("select * from regtable where uname=@uname and password=@password  ", con);
                cmd.Parameters.AddWithValue("uname", TextBox1.Text);
                cmd.Parameters.AddWithValue("password", TextBox2.Text);
                rs = cmd.ExecuteReader();
                string status = "";
                if (rs.Read())
                {
                    status = rs["status"].ToString().ToLower ();
                    rs.Close();
                    cmd.Dispose();
                }
                else
                {
                    rs.Close();
                    cmd.Dispose();
                    Label1.Text = "Invalid Username Or Password.....";
                    return;
                }

                if (status.Equals("register"))
                {
                    Label1.Text = "Your Status is Register.So Please Waiting.....";
                    return;
                }
                else if (status.Equals("reject"))
                {
                    Label1.Text = "Your Status is Rejected.So You Are Not Login.....";
                    return;
                }
                else if (status .Equals ("accept"))
                {
                    Session.Add("UserName", TextBox1.Text);
                    //Response.Redirect("UserViewProduct.aspx");
                  //  Response.Redirect("BankAccount.aspx");
                   // Response.Redirect("ViewAccount.aspx");
                    //Response.Redirect("UserViewPurchaseProduct.aspx");
                   Response.Redirect("SendReview1.aspx");
                }
        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.Message;
        }

    }
}
