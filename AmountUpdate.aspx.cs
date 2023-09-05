﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class AmountUpdate : System.Web.UI.Page
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
                 
                   
                }
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
            cmd = new SqlCommand("select * from acctable where uname=@uname and accno=@accno", con);
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            cmd.Parameters.AddWithValue("accno", TextBox2.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b==false )
            {
                Label1.Text = "Invalid Account Number.....";
                return;
            }

            cmd = new SqlCommand("update acctable set amount=amount+@amount where uname=@uname and accno=@accno", con);
            cmd.Parameters.AddWithValue("amount", TextBox3.Text);
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            cmd.Parameters.AddWithValue("accno", TextBox2.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Amount Updated to Your Account......";


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
        TextBox2.Focus();

    }
}