using NeoSYSTEM;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
            try
            {
                if (!IsPostBack)
                {
                    items = DisplayData();
                }
            }
            catch (Exception)
            {

            }
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

                for (int i = 0; i < dtbl.Rows.Count - 1; i++)
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
                    String model_id = "id_Crud" + i.ToString();

                    HtmlInputButton btn_Edit = new HtmlInputButton("button");
                    btn_Edit.ID = "EditButton";
                    btn_Edit.Value = "Edit";
                    btn_Edit.Attributes.Add("class", "btn-success");
                    btn_Edit.Attributes.Add("runat", "server");
                    btn_Edit.Attributes.Add("data-toggle", "modal");
                    btn_Edit.Attributes.Add("data-target", "#MainContent_" + model_id);
                    //btn_Edit.Attributes.Add("AutoPostBack", "true");
                    //btn_Edit.Click += (object sender, EventArgs e) => { Edit_Click(sender, e, id_Crud); };
                    //button.ServerClick += new System.EventHandler(this.Button_Click);
                    //tcell.Controls.Clear();
                    tcell.Controls.Add(btn_Edit);

                    // Create a new HtmlGenericControl.
                    HtmlGenericControl Modal_Edit = new HtmlGenericControl("div");
                    Modal_Edit.ID = model_id;
                    Modal_Edit.Attributes.Add("class", "modal fade");
                    Modal_Edit.Attributes.Add("tabindex", "-1");
                    Modal_Edit.Attributes.Add("runat", "server");
                    Modal_Edit.Attributes.Add("role", "dialog");
                    Modal_Edit.Attributes.Add("aria-labelledby", "exampleModalLabel");
                    Modal_Edit.Attributes.Add("aria-hidden", "true");
                    Modal_Edit.Style["Height"] = "100px";
                    Modal_Edit.Style["Width"] = "100px";


                    // Create a new HtmlGenericControl.
                    HtmlGenericControl Modal_Dialog = new HtmlGenericControl("div");
                    Modal_Dialog.Attributes.Add("runat", "server");
                    Modal_Dialog.Attributes.Add("class", "modal-dailog");
                    Modal_Dialog.Attributes.Add("role", "document");

                    HtmlGenericControl Modal_Content = new HtmlGenericControl("div");
                    Modal_Content.Attributes.Add("runat", "server");
                    Modal_Content.Attributes.Add("class", "modal-content");

                    HtmlGenericControl Modal_Header = new HtmlGenericControl("div");
                    Modal_Header.Attributes.Add("class", "modal-header");

                    HtmlGenericControl Modal_Title = new HtmlGenericControl("h5");
                    Modal_Title.ID = "modal_title";
                    Modal_Title.Attributes.Add("class", "modal-title");
                    Modal_Title.InnerHtml = "Editing Data";
                    Modal_Header.Controls.Add(Modal_Title);

                    HtmlInputButton Modal_Close = new HtmlInputButton("button");
                    Modal_Close.Attributes.Add("class", "close");
                    Modal_Close.Attributes.Add("runat", "server");
                    Modal_Close.Attributes.Add("data-dismiss", "modal");
                    Modal_Close.Attributes.Add("aria-label", "Close");

                    HtmlGenericControl Modal_Span = new HtmlGenericControl("span");
                    Modal_Span.Attributes.Add("aria-hidden", "true");
                    Modal_Span.InnerHtml = "&times;";
                    Modal_Close.Controls.Add(Modal_Span);
                    Modal_Header.Controls.Add(Modal_Close);


                    Modal_Content.Controls.Add(Modal_Header);

                    HtmlGenericControl Modal_Body = new HtmlGenericControl("div");
                    Modal_Body.Attributes.Add("class", "modal-body");

                    HtmlForm Modal_Form = new HtmlForm();
                    Modal_Form.ID = "modal_form";
                    HtmlGenericControl Modal_Label1 = new HtmlGenericControl("label");
                    Modal_Label1.InnerText = "Name";
                    Modal_Form.Controls.Add(Modal_Label1);

                    HtmlInputText text1 = new HtmlInputText();
                    text1.Value = dtbl.Rows[i]["name"].ToString();;
                    Modal_Form.Controls.Add(text1);

                    HtmlGenericControl Modal_Label2 = new HtmlGenericControl("label");
                    Modal_Label2.InnerText = "Name";
                    Modal_Form.Controls.Add(Modal_Label2);

                    HtmlInputText text2 = new HtmlInputText();
                    text2.Value = dtbl.Rows[i]["name"].ToString();
                    Modal_Form.Controls.Add(text2);

                    Modal_Body.Controls.Add(Modal_Form);
                    Modal_Content.Controls.Add(Modal_Body);

                    HtmlGenericControl Modal_Footer = new HtmlGenericControl("div");
                    Modal_Footer.Attributes.Add("class", "modal-footer");
                    HtmlInputButton Modal_dismiss = new HtmlInputButton("button");
                    Modal_dismiss.Attributes.Add("class", "btn btn-secondary");
                    Modal_dismiss.Attributes.Add("runat", "server");
                    Modal_dismiss.Attributes.Add("data-dismiss", "modal");
                    Modal_dismiss.Value = "Close";
                    HtmlAnchor Modal_anchor = new HtmlAnchor();
                    Modal_anchor.Attributes.Add("class", "btn");
                    Modal_anchor.Attributes.Add("runat", "server");
                    Modal_anchor.Attributes.Add("data-dismiss", "modal");
                    Modal_anchor.ID = "closemodal";
                    Modal_dismiss.Controls.Add(Modal_anchor);
                    Modal_Footer.Controls.Add(Modal_dismiss);

                    Button Modal_Update = new Button();
                    Modal_Update.Attributes.Add("class", "btn btn-primary");
                    Modal_Update.Attributes.Add("runat", "server");
                    Modal_Update.Text = "Update";
                    Modal_Update.Click += (object sender, EventArgs e) => { Edit_Click(sender, e, id_Crud); };
                    Modal_Footer.Controls.Add(Modal_Update);

                    Modal_Content.Controls.Add(Modal_Footer);
                    Modal_Dialog.Controls.Add(Modal_Content);
                    Modal_Edit.Controls.Add(Modal_Dialog);

                    tcell.Controls.Add(Modal_Edit);
                    trow.Controls.Add(tcell);

                    //delete
                    String id_Delete = dtbl.Rows[i]["id"].ToString();
                    tcell = new TableCell();
                    Button btn_Delete = new Button();
                    btn_Delete.Text = "Delete";
                    btn_Delete.Attributes.Add("class", "btn btn-danger");
                    btn_Delete.Attributes.Add("runat", "server");
                    //btn_Delete.Click += new EventHandler(Delete_Click(id));
                    btn_Delete.Click += (object sender, EventArgs e) => { Delete_Click(sender, e, id_Delete); };
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
                int check = cmd.ExecuteNonQuery();
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

            
            String name_Crud = text1.Value;
            String college_Crud = text2.value;
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