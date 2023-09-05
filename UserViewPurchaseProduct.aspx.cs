using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class UserViewPurchaseProduct : System.Web.UI.Page
{
    SqlConnection con;
   
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
                    BindList();
            }
            
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

    void BindList()
    {
        adp = new SqlDataAdapter("select p1.pid, p1.cname,p1.pname,p1.bname,p1.price,p1.pimage  from ptable p1, purtable p2 where p2.uname=@uname and p1.pid=p2.pid", con);
        adp.SelectCommand.Parameters.AddWithValue("uname", Session["UserName"].ToString());
        dt = new DataTable();
        adp.Fill(dt);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["pimage"] = Server.MapPath("PImage/") + dt.Rows[i]["pimage"];
            //   dt.Rows[i]["UDate"] =  DateTime.Parse (dt.Rows[i]["UDate"].ToString ()).ToString ("dd-MMM-yyyy");
        }
        DataList1.Visible = true;
        DataList1.DataSource = dt;
        DataList1.DataBind();

    }
   
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "SS")
            {
                int pid = int.Parse(e.CommandArgument.ToString());
                Response.Redirect("SendReview.aspx?pid=" + pid);
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}