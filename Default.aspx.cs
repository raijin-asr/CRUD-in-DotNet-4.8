using Microsoft.Ajax.Utilities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ReportApp
{
    public partial class _Default : Page
    {
        //public class ItemDetail
        //{
        //public string id { get; set; }
        //public string name { get; set; }
        //public string college { get; set; }

        //}



        public void Page_Load(object sender, EventArgs e)
        {
                DisplayData();

            //try
            //{
            //    if (!IsPostBack)
            //    {

            //    }
            //}

            //catch (Exception)
            //{

            //}
        }

        public void DisplayData()
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

                    //Action part
                    String id_Crud = dtbl.Rows[i]["id"].ToString();
                    tcell = new TableCell();
                    String model_id = "id_Crud" + i.ToString();

                    HtmlInputButton btn_Edit = new HtmlInputButton("button");
                    btn_Edit.ID = "EditButton" + i.ToString();
                    btn_Edit.Value = "Edit";
                    btn_Edit.Attributes.Add("class", "btn-success");
                    btn_Edit.Attributes.Add("data-toggle", "modal");
                    btn_Edit.Attributes.Add("data-target", "#MainContent_" + model_id);
                    tcell.Controls.Add(btn_Edit);

                    //modal part
                    // Create a new HtmlGenericControl.
                    HtmlGenericControl Modal_Edit = new HtmlGenericControl("div");
                    Modal_Edit.ID = model_id;
                    Modal_Edit.Attributes.Add("class", "modal fade");
                    Modal_Edit.Attributes.Add("tabindex", "-1");
                    Modal_Edit.Attributes.Add("role", "dialog");
                    Modal_Edit.Attributes.Add("aria-labelledby", "exampleModalLabel");
                    Modal_Edit.Attributes.Add("aria-hidden", "true");
                    //Modal_Edit.Style["Height"] = "200px";
                    //Modal_Edit.Style["Width"] = "80%";

                    //// Create a new HtmlGenericControl.
                    HtmlGenericControl Modal_Dialog = new HtmlGenericControl("div");
                    Modal_Dialog.Attributes.Add("class", "modal-dailog");
                    Modal_Dialog.Attributes.Add("role", "document");

                    HtmlGenericControl Modal_Content = new HtmlGenericControl("div");
                    Modal_Content.Attributes.Add("class", "modal-content");

                    HtmlGenericControl Modal_Header = new HtmlGenericControl("div");
                    Modal_Header.Attributes.Add("class", "modal-header");

                    HtmlGenericControl Modal_Title = new HtmlGenericControl("h5");
                    Modal_Title.ID = "modal_title" + i.ToString();
                    Modal_Title.Attributes.Add("class", "modal-title");
                    Modal_Title.InnerHtml = "Editing Data...";
                    Modal_Header.Controls.Add(Modal_Title);

                    Button Modal_Close = new Button();
                    //Modal_Close.Attributes.Add("type", "button");
                    Modal_Close.Attributes.Add("class", "close");
                    Modal_Close.Text = "X";
                    //Modal_Close.Attributes.Add("data-dismiss", "modal");
                    //Modal_Close.Attributes.Add("aria-label", "Close");
                    Modal_Close.Click += (object sender, EventArgs e) => { Close_Btn_Modal(sender, e); };

                    HtmlGenericControl Modal_Span = new HtmlGenericControl("span");
                    Modal_Span.Attributes.Add("aria-hidden", "true");
                    Modal_Span.InnerHtml = "X";
                    Modal_Close.Controls.Add(Modal_Span);
                    Modal_Header.Controls.Add(Modal_Close);
                    Modal_Content.Controls.Add(Modal_Header);

                    HtmlGenericControl Modal_Body = new HtmlGenericControl("div");
                    Modal_Body.Attributes.Add("class", "modal-body");

                    //HtmlForm Modal_Form = new HtmlForm();
                    //Modal_Form.ID = "modal_form";
                    HtmlGenericControl Modal_Label1 = new HtmlGenericControl("label");
                    Modal_Label1.InnerText = "Name";
                    Modal_Body.Controls.Add(Modal_Label1);

                    HtmlInputText textName = new HtmlInputText();
                    textName.Attributes.Add("type", "text");
                    String id_update = dtbl.Rows[i]["id"].ToString();
                    textName.Value = dtbl.Rows[i]["name"].ToString();
                    textName.ID = "id_name" + i.ToString();
                    textName.Attributes.Add("onchange", "myFunction(this.value)");
                    String name_Update = textName.Value;
                    Modal_Body.Controls.Add(textName);

                    HtmlGenericControl Modal_Label2 = new HtmlGenericControl("label");
                    Modal_Label2.InnerText = "College";
                    Modal_Body.Controls.Add(Modal_Label2);

                    HtmlInputText textCollege = new HtmlInputText();
                    textCollege.Value = dtbl.Rows[i]["college"].ToString();
                    textCollege.ID = "id_college_" + i.ToString();
                    textName.Attributes.Add("onchange", "myFunction1(this.value)");
                    String college_Update = textCollege.Value;
                    Modal_Body.Controls.Add(textCollege);

                    //Modal_Body.Controls.Add(Modal_Form);
                    Modal_Content.Controls.Add(Modal_Body);

                    HtmlGenericControl Modal_Footer = new HtmlGenericControl("div");
                    Modal_Footer.Attributes.Add("class", "modal-footer");

                    Button Modal_dismiss = new Button();
                    Modal_dismiss.Attributes.Add("class", "btn btn-secondary");
                    //Modal_dismiss.Attributes.Add("data-dismiss", "modal");
                    Modal_dismiss.Text = "Close";
                    Modal_dismiss.Click += (object sender, EventArgs e) => { Close_Btn_Modal(sender, e); };

                    HtmlAnchor Modal_anchor = new HtmlAnchor();
                    Modal_anchor.Attributes.Add("class", "btn");
                    Modal_anchor.Attributes.Add("data-dismiss", "modal");
                    Modal_anchor.ID = "closemodal" + i.ToString();
                    Modal_dismiss.Controls.Add(Modal_anchor);
                    Modal_Footer.Controls.Add(Modal_dismiss);


                    Button Modal_Update = new Button();
                    Modal_Update.Attributes.Add("class", "btn btn-primary");
                    //Modal_Update.Attributes.Add("type", "submit");
                    Modal_Update.Text = "Update";
                    Modal_Update.ID = "UpdateButton" + i.ToString();
                    //Modal_Update.Attributes.Add("runat","server");
                    //Modal_Update.Attributes.Add("AutoPostBack","true");
                    Modal_Update.Click += (object sender, EventArgs e) => { Edit_Click(sender, e, i.ToString(), name_Update, college_Update); };
                    Modal_Footer.Controls.Add(Modal_Update);

                    Modal_Content.Controls.Add(Modal_Footer);

                    Modal_Dialog.Controls.Add(Modal_Content);
                    Modal_Edit.Controls.Add(Modal_Dialog);
                    tcell.Controls.Add(Modal_Edit);

                    trow.Controls.Add(tcell);

                    //delete
                    tcell = new TableCell();
                    String id_Delete = dtbl.Rows[i]["id"].ToString();
                    Button btn_Delete = new Button();
                    btn_Delete.Text = "Delete";
                    btn_Delete.ID = "DeleteButton" + i.ToString();
                    btn_Delete.Attributes.Add("class", "btn btn-danger");
                    btn_Delete.Click += (object sender, EventArgs e) => { Delete_Click(sender, e, id_Delete); };
                    tcell.Controls.Add(btn_Delete);
                    trow.Controls.Add(tcell);

                    Table1.Rows.Add(trow);
                }

                connect.Close();
            }
            catch (Exception)
            {

            }
          
        }


        protected void Close_Btn_Modal(object sender, EventArgs e)
        {

            Response.Write("<script>window.location.href='Default.aspx';</script>");
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
            Response.Write("<script>window.location.href='Default.aspx';</script>");
        }

        protected void Delete_Click(object sender, EventArgs e, String id)

        {

            Connection connect = new Connection();
            connect.Connect();
            try
            {
                Console.WriteLine("Deleted");
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
            Response.Write("<script>window.location.href='Default.aspx';</script>");

        }

        String name_update;
        protected void Name_TextChanged(object sender, EventArgs e)
        {
            TextBox Txt_Name_Update = this.FindControl("id_name_") as TextBox;
            name_update = Txt_Name_Update.Text;
        }

        protected void Edit_Click(object sender, EventArgs e, String id,  String name, String college)
        {
            Connection connect = new Connection();
            connect.Connect();

            try
            {
                //String id_Up = id + i.ToString();
                //Control myControl1 = FindControl("textName");
                //name = (row.FindControl("txtName") as TextBox).Text;
                //Control myControl2 = FindControl("textCollege");
                //String update_college = (this.FindControl("id_college_" + id) as TextBox).Text;
                //String update_college = txtModelCollege.Text;
                //String updated_name = Request.Form["id_name_"+id];

                //TextBox txt_update_name ;
                //String updated_name=null;
                //for (int i = 0; i < int.Parse(id); i++)
                //{
                //    txt_update_name = (TextBox)this.FindControl("id_name_" + i);
                //    updated_name = txt_update_name.Text;

                //}

                //TextBox txt_update_name = this.FindControl("id_name_"+id) as TextBox;
                //String updated_name = txt_update_name.Text;
                //TextBox txt_update_college = this.FindControl("id_college_" + id) as TextBox;
                //String updated_college = txt_update_college.Text;
                //String name_Udpdate=txtName.InnerHtml;
            
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = Connection.connect;

                string query = "UPDATE public.\"tblTest\" SET name ='" + name + "',college ='" + college + "' where id='" + id + "'";
                cmd.CommandText = query;
                int exe = cmd.ExecuteNonQuery();

                connect.Close();

            }
            catch (Exception)
            {

            }
            Label1.Text = "Updated";
            Response.Write("<script>window.location.href='Default.aspx';</script>");

        }

    }//end of class
} //end of namespace