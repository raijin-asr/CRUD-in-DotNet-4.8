using NeoSYSTEM;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportApp
{
    public partial class _Default : Page
    {
        public class ItemDetail
        {
            public string id { get; set; }
            public string name { get; set; }
            public string college { get; set; }

        }

        public List<ItemDetail> items = new List<ItemDetail>();

        public void Page_Load(object sender, EventArgs e)
        {
           
            items = DisplayData();
        }

        public List<ItemDetail> DisplayData()
        {

            Connection connect = new Connection();
            connect.Connect();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = Connection.connect;
                cmd.CommandText = "SELECT * FROM public.\"tblTest\" ORDER BY id ASC";

                NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
                DataTable dtbl = new DataTable();
                adp.Fill(dtbl);
                items.Clear();
                TableRow trow = null;
                TableCell tcell;

                for (int i = 0; i < dtbl.Rows.Count -1; i++)
                {
                    trow = new TableRow();

                    tcell = new TableCell();
                    tcell.Text = dtbl.Rows[i]["id"].ToString();
                    trow.Controls.Add(tcell);

                    tcell = new TableCell();
                    tcell.Text = dtbl.Rows[i]["name"].ToString();
                    trow.Controls.Add(tcell);

                    tcell = new TableCell();
                    tcell.Text = dtbl.Rows[i]["college"].ToString();
                    trow.Controls.Add(tcell);

                    String id_Crud = dtbl.Rows[i]["id"].ToString();
                    tcell = new TableCell();
                    Button btn_Edit = new Button();
                    btn_Edit.Text = "Edit";
                    btn_Edit.Attributes.Add("class", "btn-success");
                    btn_Edit.Attributes.Add("runat", "server");
                    btn_Edit.Attributes.Add("data-toggle", "modal");
                    btn_Edit.Attributes.Add("data-target", "#id_Crud");
                    //btn_Edit.Click += (object sender, EventArgs e) => { Edit_Click(sender, e, id_Crud); };
                    tcell.Controls.Add(btn_Edit);
                    trow.Controls.Add(tcell);
		    
		            String id_Delete=dtbl.Rows[i]["id"].ToString();
                    tcell = new TableCell();
                    Button btn_Delete = new Button();
                    btn_Delete.Text = "Delete";
                    btn_Delete.Attributes.Add("class", "btn btn-danger");
                    btn_Delete.Attributes.Add("runat", "server");
                    //btn_Delete.Click += new EventHandler(Delete_Click(id));
                    btn_Delete.Click +=(object sender, EventArgs e) => { Delete_Click(sender, e, id_Delete); };
                    //OnClientClick = "this.form.reset();return false;"
                    //btn_Delete.Attributes.Add("OnClick", "(() =>Delete_Click(id))");
                    tcell.Controls.Add(btn_Delete);
                    trow.Controls.Add(tcell);


                    Table1.Rows.Add(trow);
                }

                connect.Close();
            }
            catch (Exception)
            {

            }
            return items;
        }


        protected void Insert_Click(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            connect.Connect();
            String id_Crud = txtId.Text;
            String name_Crud = txtName.Text; 
            String college_Crud = txtCollege.Text;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = Connection.connect;

                cmd.CommandText = "INSERT INTO public.\"tblTest\" (id,name,college ) VALUES ('" + id_Crud + "', '" + name_Crud + "', '" + college_Crud + "')";
                int check =cmd.ExecuteNonQuery();
                cmd.Dispose();
                connect.Close();
            }
            catch (Exception)
            {

            }
            Label1.Text = "Inserted";
            //Response.Write("<script>window.location.href='Default.aspx';</script>");

        }

        protected void Delete_Click(object sender, EventArgs e, String id)

        {
            
            Connection connect = new Connection();
            connect.Connect();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = Connection.connect;

                cmd.CommandText = "DELETE FROM public.\"tblTest\" where id='" + id + "'";

                cmd.ExecuteNonQuery();
                connect.Close();

            }
            catch (Exception)
            {

            }
            Label1.Text = "Deleted";
           // Response.Write("<script>window.location.href='Default.aspx';</script>");

        }

        //public string id_Crud { get; set; }

        //public void Update()
        //{ 
        //Edit_Click(id_Crud);
        //}

        protected void Edit_Click(object sender, EventArgs e, String id_Crud)
        {
            Connection connect = new Connection();
            connect.Connect();

            id_Crud = txtId.Text;
            String name_Crud = txtName.Text;
            String college_Crud = txtCollege.Text;
            try
            {

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = Connection.connect;

                string query = "UPDATE public.\"tblTest\" SET name ='" + name_Crud + "',college ='" + college_Crud + "' where id='" + id_Crud + "'";
                cmd.CommandText = query;
                int exe = cmd.ExecuteNonQuery();

                connect.Close();

            }
            catch (Exception)
            {

            }
            Label1.Text = "Updated";
           // Response.Write("<script>window.location.href='Default.aspx';</script>");

        }

    }//end of class
} //end of namespace