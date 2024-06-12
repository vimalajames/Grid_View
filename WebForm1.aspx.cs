using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Grid_View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["conn"]);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public void getdata()
        {
            //con = new SqlConnection("Data Source=JAMES\\SQLEXPRESS;Integrated Security=True;Initial Catalog=Customer;");
            con.Open();
            string str = "";
            str = "select * from custgrid";
            da = new SqlDataAdapter(str, con);
            ds.Clear();
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0].DefaultView;
            GridView1.DataBind();
            con.Close();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getdata();
            }
        }

      

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            getdata();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getdata();
        }

        

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

           // con = new SqlConnection("Data Source=JAMES\\SQLEXPRESS;Integrated Security=True;Initial Catalog=Customer;");
            con.Open();
            string str = "";
            
            TextBox txt_id = GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
            TextBox txt_name = GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
            TextBox txt_address = GridView1.Rows[e.RowIndex].FindControl("TextBox3") as TextBox;
           /* Response.Write(txt_address);
            Response.Write(txt_id);
            Response.Write(txt_name);*/
            str = "update custgrid set Name='"+txt_name.Text+"'where Id='"+txt_id.Text+"'";
            cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            getdata();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            Response.Write(GridView1.Rows[1].Cells[1].Text);
           
                  
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}