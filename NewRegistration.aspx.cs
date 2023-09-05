using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class NewRegistration : System.Web.UI.Page
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
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        try
        {

            Image1.ImageUrl = "";
            HiddenField1.Value = "";
            if (FileUpload1.HasFile)
            {
                string path = DateTime.Now.Ticks + "_" + FileUpload1.FileName;
                Image1.ImageUrl = FileUpload1.PostedFile.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("UImage/" + path));
                HiddenField1.Value = path;
            }
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

            cmd = new SqlCommand("select uname from regtable where uname=@uname", con);
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "User Name Already Found...";
                return;
            }
            cmd = new SqlCommand("select emailid from regtable where emailid=@emailid", con);
            cmd.Parameters.AddWithValue("emailid", TextBox3.Text);
            rs = cmd.ExecuteReader();
            b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "EMailID Already Found...";
                return;
            }
            cmd = new SqlCommand("select mnumber from regtable where mnumber=@mnumber", con);
            cmd.Parameters.AddWithValue("mnumber", TextBox4.Text);
            rs = cmd.ExecuteReader();
            b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Mobile Number Already Found...";
                return;
            }

            cmd = new SqlCommand("insert into regtable values(@uname,@password,@emailid,@mnumber,@address,@gender,@pincode,@uimage,@status)", con);
            cmd.Parameters .AddWithValue ("uname",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("password",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("emailid",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("mnumber",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("address",TextBox5 .Text );
           
            cmd.Parameters .AddWithValue ("gender",RadioButtonList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("pincode",TextBox6 .Text );
            cmd.Parameters .AddWithValue ("uimage",HiddenField1 .Value );
            cmd.Parameters.AddWithValue  ("status", "Register");
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "New User Registration Details Inserted....";
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
       
        HiddenField1.Value = "";
        Image1.ImageUrl = "";


       
        RadioButtonList1.SelectedIndex = -1;
        TextBox1.Focus();
    }
}