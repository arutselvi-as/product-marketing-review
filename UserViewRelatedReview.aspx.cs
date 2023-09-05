using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;


public partial class UserViewRelatedReview : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataTable dt;
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
                bindgrid();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void bindgrid1(int pid)
    {
        adp = new SqlDataAdapter("select r1.uname,r1.srating,r1.rrating,r1.erating,r1.urating from revtable r1,rctable r2  where r1.pid=r2.pid and r1.uname=r2.uname and r1.pid=@pid order by rcount desc ", con);
        adp.SelectCommand.Parameters.AddWithValue("pid", pid);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
   
    }

    void bindgrid()
    {
        int pid = int.Parse(Request.QueryString.Get("PID"));

        cmd = new SqlCommand("select pid from ptable where pid <@pid order by pid desc", con);
        cmd.Parameters.AddWithValue("pid", pid);
        rs = cmd.ExecuteReader();
        int ppid = 0;
        if (rs.Read())
        {
            ppid = int.Parse(rs["pid"].ToString());
            rs.Close();
            cmd.Dispose();
        }
        else
        {
            rs.Close();
            cmd.Dispose();
          //  ppid = pid;
            bindgrid1(pid);
                return;
        }
        //cmd = new SqlCommand("select uname from rctable where pid=@pid1 and rcount=(select max(rcount) from rctable where pid=@pid2)", con);
        cmd = new SqlCommand("select uname,max(rcount) from rctable where pid=@pid group by uname order by max(rcount) desc", con);
        cmd.Parameters.AddWithValue("pid", ppid);
      
        rs = cmd.ExecuteReader();
        ArrayList uname = new ArrayList();
        ArrayList rcount = new ArrayList();
        while (rs.Read())
        {
            uname.Add(rs["uname"].ToString());
            rcount.Add(rs[1]);
        }

        rs.Close();
        cmd.Dispose();
        if (uname.Count == 0)
        {
            bindgrid1(pid);
            return;
        }

        cmd = new SqlCommand("select isnull(count(*),0) from revtable where pid=@pid", con);
        cmd.Parameters.AddWithValue("pid", ppid);
        int rc = int.Parse(cmd.ExecuteScalar().ToString());
        cmd.Dispose();
        if (rc <5) // change the line 
        {
            bindgrid1(pid);
            return;
        }


        DataTable dd=new DataTable ();
        dd.Columns .Add ("uname");
        dd.Columns .Add ("srating", typeof(int));
        dd.Columns .Add ("rrating", typeof(int));
        dd.Columns .Add ("erating", typeof(int));
        dd.Columns .Add ("urating", typeof(int));

        string funame = "";
        for (int i = 0; i < uname.Count; i++)
        {
            int mcount = rc / 2;
            int uc = int.Parse(rcount[i].ToString());
            if (uc >= mcount)
            {
                cmd = new SqlCommand("select r1.uname,r1.srating,r1.rrating,r1.erating,r1.urating from revtable r1,rctable r2  where r1.pid=r2.pid  and r1.uname=r2.uname and r1.pid=@pid and r1.uname=@uname", con);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.Parameters.AddWithValue("uname", uname[i].ToString());
                rs = cmd.ExecuteReader();
                if (rs.Read())
                {
                    DataRow dr = dd.NewRow();
                    dr[0] = rs[0];
                    dr[1] = rs[1];
                    dr[2] = rs[2];
                    dr[3] = rs[3];
                    dr[4] = rs[4];
                    dd.Rows.Add(dr);
                    rs.Close();
                    cmd.Dispose();
                    funame = uname[i].ToString() + ",";

                }
                else
                {
                    rs.Close();
                    cmd.Dispose();
                    continue;
                }


            }
 }


        if (funame == "")
        {
            bindgrid1(pid);
            return;
        }

        if (funame != "")
        {
            funame = funame.Substring(0, funame.LastIndexOf(","));

            cmd = new SqlCommand("select r1.uname,r1.srating,r1.rrating,r1.erating,r1.urating from revtable r1,rctable r2  where r1.pid=r2.pid and r1.uname=r2.uname and r1.pid=@pid and uname not in ("+funame +") order by rcount desc ", con);
           cmd.Parameters .AddWithValue("pid", pid);
           rs = cmd.ExecuteReader();
           while (rs.Read())
           {
               DataRow dr = dd.NewRow();
               dr[0] = rs[0];
               dr[1] = rs[1];
               dr[2] = rs[2];
               dr[3] = rs[3];
               dr[4] = rs[4];
               dd.Rows.Add(dr);
             
                 
           }
           rs.Close();
           cmd.Dispose();

           GridView1.DataSource = dd;
           GridView1.DataBind();
    






        }
        


       
    }
}