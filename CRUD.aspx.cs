using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.WebControls;
using Npgsql;

namespace ReportApp
{
    public partial class CRUD : System.Web.UI.Page
    {
        private Connection db = new Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTable();
            }
        }

        private void BindTable()
        {
            db.Connect();
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Students", Connection.connect))
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                studentsTable.Controls.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    TableRow tr = new TableRow();

                    TableCell tdId = new TableCell();
                    tdId.Text = row["Id"].ToString();
                    tr.Cells.Add(tdId);

                    TableCell tdName = new TableCell();
                    tdName.Text = row["Name"].ToString();
                    tr.Cells.Add(tdName);

                    TableCell tdAddress = new TableCell();
                    tdAddress.Text = row["Address"].ToString();
                    tr.Cells.Add(tdAddress);

                    TableCell tdActions = new TableCell();
                    tdActions.Controls.Add(CreateEditButton(row["Id"].ToString()));
                    tdActions.Controls.Add(CreateDeleteButton(row["Id"].ToString()));
                    tr.Cells.Add(tdActions);

                    studentsTable.Controls.Add(tr);
                }
            }
            db.Close();
        }

        private LinkButton CreateEditButton(string id)
        {
            LinkButton btnEdit = new LinkButton();
            btnEdit.Text = "Edit";
            btnEdit.CommandArgument = id;
            btnEdit.Click += BtnEdit_Click;
            return btnEdit;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btnEdit = (LinkButton)sender;
            string id = btnEdit.CommandArgument;
            Response.Redirect($"EditStudent.aspx?id={id}");
        }

        private LinkButton CreateDeleteButton(string id)
        {
            LinkButton btnDelete = new LinkButton();
            btnDelete.Text = "Delete";
            btnDelete.CommandArgument = id;
            btnDelete.Click += BtnDelete_Click;
            return btnDelete;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btnDelete = (LinkButton)sender;
            string id = btnDelete.CommandArgument;

            db.Connect();
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM Students WHERE Id = @Id", Connection.connect))
            {
                cmd.Parameters.AddWithValue("@Id", int.Parse(id));
                cmd.ExecuteNonQuery();
            }
            db.Close();
            BindTable();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtAddress.Text))
            {
                db.Connect();
                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO Students (Name, Address) VALUES (@Name, @Address)", Connection.connect))
                {
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.ExecuteNonQuery();
                }
                db.Close();
                BindTable();
                txtName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                lblMessage.Text = string.Empty;
            }
            else
            {
                lblMessage.Text = "Both fields are required.";
            }
        }
    }
}
