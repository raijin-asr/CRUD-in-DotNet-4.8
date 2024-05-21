using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

namespace ReportApp
{
    public partial class EditStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int studentId = int.Parse(Request.QueryString["id"]);
                    LoadStudentData(studentId);
                }
                else
                {
                    Response.Redirect("CRUD.aspx");
                }
            }
        }

        private void LoadStudentData(int id)
        {
            db.Connect();
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Students WHERE Id = @Id", Connection.connect))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblStudentId.Text = reader["Id"].ToString();
                    txtName.Text = reader["Name"].ToString();
                    txtAddress.Text = reader["Address"].ToString();
                }
            }
            db.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtAddress.Text))
            {
                db.Connect();
                using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE Students SET Name = @Name, Address = @Address WHERE Id = @Id", Connection.connect))
                {
                    cmd.Parameters.AddWithValue("@Id", int.Parse(lblStudentId.Text));
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.ExecuteNonQuery();
                }
                db.Close();
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMessage.Text = "Both fields are required.";
            }
        }
    }
}