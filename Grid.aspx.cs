using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace Grid_View
{

    public partial class Grid : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=JAMES\\SQLEXPRESS;Integrated Security=True;Initial Catalog=sacredheart;");

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            Refreshdata();
        }

        

        
        public void Refreshdata()
        {
            try
            {
               
                con.Open();
                string str = "";
                str = "select * from addmin";
                da = new SqlDataAdapter(str, con);
                ds.Clear();
                da.Fill(ds);
                GridView.DataSource = ds.Tables[0].DefaultView;
                GridView.DataBind();

               
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                con.Close();

            }

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
        }

       

      

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       /* protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }*/
        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView.EditIndex = e.NewEditIndex;
            Refreshdata();
        }

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView.EditIndex = -1;
            Refreshdata();
        }

        protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

           con.Open();
            string str = "";
            TextBox txt_id =GridView.Rows[e.RowIndex].FindControl("Id") as TextBox;
            TextBox txt_name = GridView.Rows[e.RowIndex].FindControl("Name") as TextBox;
            TextBox txt_phone = GridView.Rows[e.RowIndex].FindControl("Phone") as TextBox;
            /*Response.Write(txt_id);
            Response.Write(txt_name);
            Response.Write(txt_phone);*/
            str = "update addmin set Phone = '"+ txt_phone + "', Id = "+ txt_id + ",Name = '"+ txt_name + "'where Id = "+ txt_id + "";  
            cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView.EditIndex = -1;
            Refreshdata();
        }

        protected void GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Response.Write(GridView.Rows[0].Cells[2].Text);
        }
    }
}