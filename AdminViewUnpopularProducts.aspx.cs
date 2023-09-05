using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AdminViewUnpopularProducts : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
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

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void bindgrid1()
    {
        //verify the data  show records in lessthan date 

        adp = new SqlDataAdapter("select * from ptable where udate<=@udate and pid not in (select pid from revtable)", con);
        adp.SelectCommand.Parameters.AddWithValue("udate", DateTime.Now.ToString("dd-MMM-yyyy"));
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.Visible = true;
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    void bindgrid2()
    {

        adp = new SqlDataAdapter("select * from ptable where udate<=@udate and pid not in (select pid from purtable)", con);

        adp.SelectCommand.Parameters.AddWithValue("udate", DateTime.Now.ToString("dd-MMM-yyyy"));
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.Visible = true;
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    void bindgrid3()
    {
        adp = new SqlDataAdapter("select * from ptable where udate<=@udate and pid not in (select pid from purtable) and pid not in (select pid from revtable)", con);

        adp.SelectCommand.Parameters.AddWithValue("udate", DateTime.Now.ToString("dd-MMM-yyyy"));
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.Visible = true;
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
                Label1.Text = "Select Options.....";
                return;
            }
            //review,purchase,review-purchase

            int i = 0;
            if (DropDownList1.SelectedIndex == 1)
            {
                bindgrid1();
                for (i = 0; i < GridView1.Rows.Count; i++)
                {
                    GridView1.Rows[i].Cells[8].Enabled = false;
                }
            }
            else if (DropDownList1.SelectedIndex == 2)
            {
                bindgrid2();
                for (i = 0; i < GridView1.Rows.Count; i++)
                {
                    GridView1.Rows[i].Cells[8].Enabled = false;
                }
            }
            else if (DropDownList1.SelectedIndex == 3)
            {
                bindgrid3();
                for (i = 0; i < GridView1.Rows.Count; i++)
                {
                    GridView1.Rows[i].Cells[8].Enabled = true;
                }
            }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            if (e.CommandName == "dd")
            {

                int pid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());

                cmd = new SqlCommand("delete from ptable where pid=@pid", con);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from purtable where pid=@pid", con);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from rctable where pid=@pid", con);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from revtable where pid=@pid", con);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = new SqlCommand("delete from rtable where pid=@pid", con);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from srtable where pid=@pid", con);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                if (DropDownList1.SelectedIndex == 1)
                    bindgrid1();
                else if (DropDownList1.SelectedIndex == 2)
                    bindgrid2();
                else if (DropDownList1.SelectedIndex == 3)
                    bindgrid3();

            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}