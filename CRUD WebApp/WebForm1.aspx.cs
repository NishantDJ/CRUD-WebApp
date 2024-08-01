using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CRUD_WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        String CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void databind()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("sp_getempdetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
                con.Close();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("sp_insertemp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@gender", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@Date_of_Birth", txtdob.Text);
                cmd.Parameters.AddWithValue("@hobby", null);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                databind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("grdtxtId")).Text;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("sp_Deleteemp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                databind();
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataBind();
            databind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("grdtxtId")).Text;
            string name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("grdtxtName")).Text;
            string gender = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("grdtxtGender")).Text;
            string dob = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("grdtxtDOB")).Text;
            string hobby = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("grdtxtHobby")).Text;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("sp_Updateemp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@Date_of_Birth", dob);
                cmd.Parameters.AddWithValue("@hobby", hobby);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                databind();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            TextBox id = (TextBox)GridView1.Rows[e.NewEditIndex].Cells[0].FindControl("grdtxtId");
            TextBox name = (TextBox)GridView1.Rows[e.NewEditIndex].Cells[0].FindControl("grdtxtName");
            TextBox gender = (TextBox)GridView1.Rows[e.NewEditIndex].Cells[0].FindControl("grdtxtGender");
            TextBox dob = (TextBox)GridView1.Rows[e.NewEditIndex].Cells[0].FindControl("grdtxtDOB");
            TextBox hobby = (TextBox)GridView1.Rows[e.NewEditIndex].Cells[0].FindControl("grdtxtHobby");

            name.Enabled = true;
            gender.Enabled = true;
            dob.Enabled = true;
            hobby.Enabled = true;


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            databind();
        }
    }
}