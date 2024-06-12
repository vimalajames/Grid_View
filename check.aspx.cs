using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Grid_View
{
    public partial class check : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            int length = Convert.ToInt32(GridView1.Rows.Count);
            for (int i = 0; i <= length - 1; i++)
            {
                Response.Write(GridView1.Rows[i].Cells[1].Text);
            }
        }

        protected void btn_show_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow item in GridView1.Rows)
            {
                var check = item.FindControl("CheckBox1") as CheckBox;
                if(check.Checked)
                {
                    
                      Response.Write(GridView1.Rows[1].Cells[2].Text);

                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow)
            {
                
                    if (e.Row.Cells[2].Text == "jency")
                    {
                        e.Row.BackColor = System.Drawing.Color.Aqua;
                    }
                

               // e.Row.BackColor = System.Drawing.Color.Aqua;
                    
            }
        }
    }
}