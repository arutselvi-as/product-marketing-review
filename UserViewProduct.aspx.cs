using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;

public partial class UserViewProduct : System.Web.UI.Page
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
                cmd = new SqlCommand("select distinct(cname) from ptable", con);
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


    void bindlist()
    {
        cmd = new SqlCommand("select pid from ptable where cname=@cname", con);
        cmd.Parameters.AddWithValue("cname", DropDownList1.SelectedItem.Text);
        rs = cmd.ExecuteReader();

        ArrayList pid = new ArrayList();
        while (rs.Read())
            pid.Add(rs["pid"].ToString());
        rs.Close();
        cmd.Dispose();

        //    ArrayList rcount = new ArrayList();
        DataTable dc = new DataTable();
        dc.Columns.Add("pid", typeof(int));
        dc.Columns.Add("rating", typeof(float));

        //DataTable dc1 = new DataTable();
        //dc1.Columns.Add("pid", typeof(int));
        //dc1.Columns.Add("rating", typeof(int));

        if (pid.Count != 0)
        {
            for (int i = 0; i < pid.Count; i++)
            {
                cmd = new SqlCommand("select isnull(sum(srating),0),isnull(sum(rrating),0),isnull(sum(erating),0),isnull(sum(urating),0) from revtable where pid=@pid", con);
                cmd.Parameters.AddWithValue("pid", pid[i].ToString());
                rs = cmd.ExecuteReader();

                int rating = 0;

                if (rs.Read())
                {
                    rating = int.Parse(rs[0].ToString()) + int.Parse(rs[1].ToString()) + int.Parse(rs[2].ToString()) + int.Parse(rs[3].ToString());
                    rs.Close();
                    cmd.Dispose();

                }
                else
                {
                    rs.Close();
                    cmd.Dispose();
                    rating = 0;
                }
                float orating = 0;
                if (rating != 0)
                {
                    cmd = new SqlCommand("select count(*) from revtable where pid=@pid", con);
                    cmd.Parameters.AddWithValue("pid", pid[i].ToString());
                    int tuser = int.Parse(cmd.ExecuteScalar().ToString());
                    cmd.Dispose();
                    orating = (float)rating / tuser;
                }


                //  rcount.Add(rating);
                DataRow dr = dc.NewRow();
                dr[0] = pid[i].ToString();
                dr[1] = orating.ToString();
                dc.Rows.Add(dr);
            }
        }

        float dcpid = 0, dcrating = 0;
        for (int m = 0; m < dc.Rows.Count - 1; m++)
        {
            for (int n = m + 1; n < dc.Rows.Count; n++)
            {

                if (float.Parse(dc.Rows[m]["rating"].ToString()) < float.Parse(dc.Rows[n]["rating"].ToString()))
                {
                    dcpid = float.Parse(dc.Rows[m]["pid"].ToString());
                    dcrating = float.Parse(dc.Rows[m]["rating"].ToString());

                    dc.Rows[m]["pid"] = dc.Rows[n]["pid"].ToString();
                    dc.Rows[m]["rating"] = dc.Rows[n]["rating"].ToString();

                    dc.Rows[n]["pid"] = dcpid.ToString();
                    dc.Rows[n]["rating"] = dcrating.ToString();
                }
            }
        }



        DataTable sdt = new DataTable();
        sdt.Columns.Add("pid", typeof(int));
        sdt.Columns.Add("cname");
        sdt.Columns.Add("pname");
        sdt.Columns.Add("bname");
        sdt.Columns.Add("price", typeof(float));
        sdt.Columns.Add("description");
        sdt.Columns.Add("udate", typeof(DateTime));
        sdt.Columns.Add("pimage");
        sdt.Columns.Add("img1");




        for (int k = 0; k < dc.Rows.Count; k++)
        {

            string img1 = Server.MapPath("Images1/Star/");
            if (float.Parse(dc.Rows[k]["rating"].ToString()) > 16)
                img1 = img1 + "Star5.gif";
            else if (float.Parse(dc.Rows[k]["rating"].ToString()) > 12)
                img1 = img1 + "Star4.gif";
            else if (float.Parse(dc.Rows[k]["rating"].ToString()) > 8)
                img1 = img1 + "Star3.gif";
            else if (float.Parse(dc.Rows[k]["rating"].ToString()) > 4)
                img1 = img1 + "Star2.gif";
            else if (float.Parse(dc.Rows[k]["rating"].ToString()) > 0)
                img1 = img1 + "Star11.gif";
            else
                img1 = img1 + "NoRating1.gif";


            cmd = new SqlCommand("select * from ptable where pid=@pid", con);
            cmd.Parameters.AddWithValue("pid", dc.Rows[k]["pid"].ToString());
            rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                DataRow dr = sdt.NewRow();
                dr[0] = rs["pid"].ToString();
                dr[1] = rs["cname"].ToString();
                dr[2] = rs["pname"].ToString();
                dr[3] = rs["bname"].ToString();
                dr[4] = rs["price"].ToString();
                dr[5] = rs["description"].ToString();
                dr[6] = rs["udate"].ToString();
                dr[7] = Server.MapPath("PImage/") + rs["pimage"].ToString();
                dr[8] = img1;
                sdt.Rows.Add(dr);
            }
            rs.Close();
            cmd.Dispose();

        }


        DataList1.Visible = true;

        DataList1.DataSource = sdt;
        DataList1.DataBind();
            
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataList1.Visible = false;
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select CategoryName....";
                return;
            }
         
            bindlist();

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try 
        {
            if (e.CommandName == "bb")
            {
                int pid =int.Parse (e.CommandArgument .ToString ());
                Response.Redirect("UserViewProduct1.aspx?pid=" + pid);
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}