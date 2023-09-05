using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class NewProduct : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";

            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            TextBox5.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            if (!IsPostBack)
            {
                cmd = new SqlCommand("select cname from ctable", con);
                rs = cmd.ExecuteReader();
                DropDownList1.DataSource = rs;
                DropDownList1.DataTextField = "cname";
                DropDownList1.DataBind();
                rs.Close();
                cmd.Dispose();
                DropDownList1.Items.Insert(0, "Select");

            }

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
                FileUpload1.PostedFile.SaveAs(Server.MapPath("PImage/" + path));
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
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select ProductID.....";
                return;
            }
            cmd = new SqlCommand("select * from ptable where cname=@cname and pname=@pname and bname=@bname", con);
            cmd.Parameters.AddWithValue("cname", DropDownList1 .SelectedItem .Text );
            cmd.Parameters.AddWithValue("pname", TextBox1.Text);
            cmd.Parameters.AddWithValue("bname", TextBox2.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Record Already Found.....";
                return;
            }

            cmd = new SqlCommand("select isnull(max(pid),0)+1 from ptable", con);
            int pid = int.Parse(cmd.ExecuteScalar().ToString());
            cmd.Dispose();

            cmd = new SqlCommand("insert into ptable values(@pid,@cname,@pname,@bname,@price,@description,@udate,@pimage)", con);
            cmd.Parameters.AddWithValue("pid", pid);
            cmd.Parameters .AddWithValue ("cname",DropDownList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("pname",TextBox1 .Text );
            cmd.Parameters.AddWithValue("bname", TextBox2.Text);
            cmd.Parameters .AddWithValue ("price",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("description",TextBox4 .Text );
            cmd.Parameters.AddWithValue("udate", TextBox5.Text);
            cmd.Parameters .AddWithValue ("pimage",HiddenField1 .Value );
           int no= cmd.ExecuteNonQuery ();
            cmd.Dispose ();
            Label1 .Text ="New Product Details Inserted.....";
            if (no != 0)
            {
                cmd = new SqlCommand("insert into rtable values(@pid,@cname,@pname,@bname,@rank)", con);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.Parameters.AddWithValue("cname", DropDownList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("pname", TextBox1.Text);
                cmd.Parameters.AddWithValue("bname", TextBox2.Text);
                cmd.Parameters.AddWithValue("rank", "0");
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = 0;
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        HiddenField1.Value = "";
        Image1.ImageUrl = "";


    }
}