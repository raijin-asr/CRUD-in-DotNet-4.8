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
            //if (!IsPostBack)
            //{
                
            //}
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
                //DataSet dtbl = new DataSet();
                DataTable dtbl = new DataTable();
                adp.Fill(dtbl);
                items.Clear();
                TableRow trow = null;
                TableCell tcell;

                for (int i = 0; i < dtbl.Rows.Count; i++)
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

                    Table1.Rows.Add(trow);
                }

                connect.Close();
            }
            catch (Exception)
            {

            }
            return items;
        }


        //public void insertData(string id_Crud,string name_Crud, string college_Crud)
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
                connect.Close();
            }
            catch (Exception)
            {

            }
            //DisplayData();
            Label1.Text = "Insert";

        }

        public void deleteData(String id)
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
        }


        public void updateItem(String id, String name, String college)
        {
            Connection connect = new Connection();
            connect.Connect();

            String naam = name;
            String colz = college;
            try
            {

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = Connection.connect;

                string query = "UPDATE public.\"tblTest\" SET name ='" + naam + "',college ='" + colz + "' where id='" + id + "'";
                Console.WriteLine(query);
                cmd.CommandText = query;
                int exe = cmd.ExecuteNonQuery();

                connect.Close();

            }
            catch (Exception)
            {

            }

        }

    }//end of class
} //end of namespace