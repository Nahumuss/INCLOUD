using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace INCLOUD.Pages
{
    public partial class StoragePage : System.Web.UI.Page
    {
        //Connction String
        string gone = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Users.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    filldata();
                }
            }
        }

        //Calls the download function and gets the info
        protected void OpenDocument(Object sender, EventArgs e)
        {
            LinkButton Ink = (LinkButton)sender;
            GridViewRow gr = (GridViewRow)Ink.NamingContainer;
            int id = int.Parse(GridView1.DataKeys[gr.RowIndex].Value.ToString());
            Download(id);
        }

        //Downloads a document
        private void Download(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(gone))
            {
                SqlCommand cmd = new SqlCommand("getDocument", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            string name = dt.Rows[0]["File_Name"].ToString();
            byte[] documentBytes = (byte[])dt.Rows[0]["File_Content"];
            Response.ClearContent();
            Response.ContentType = "application/octetstream";
            Response.AddHeader("Content-Disposition", $"attachment; filename={name}");
            Response.AddHeader("Content-Length", documentBytes.Length.ToString());
            Response.BinaryWrite(documentBytes);
            Response.Flush();
            Response.Close();
        }

        //Fill the table with the files data
        private void filldata()
        {
            DataTable dt = new DataTable();
            string mia = "select Id, File_Name, File_Content from [Files] where Email = '" + Session["email"] + "'";
            using (SqlConnection cn = new SqlConnection(gone))
            {
                SqlCommand cmd = new SqlCommand(mia, cn);
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        //Save the uploaded document
        protected void Button1_Click(object sender, EventArgs e)
        {
            FileInfo f1 = new FileInfo(FileUpload1.FileName);
            byte[] documentContent = FileUpload1.FileBytes;
            string name = f1.Name;
            using (SqlConnection cn = new SqlConnection(gone))
            {
                SqlCommand cmd = new SqlCommand("saveDocument", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@filename", SqlDbType.NVarChar).Value = name;
                cmd.Parameters.Add("@filecontent", SqlDbType.VarBinary).Value = documentContent;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = Session["email"].ToString();
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            Response.Redirect("StoragePage.aspx");
        }

        //Delete the checked items in the table
        protected void UpdateTable(object sender, EventArgs e)
        {
            foreach (GridViewRow item in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)item.FindControl("CheckBox1");
                if (chk != null)
                {
                    if (chk.Checked)
                    {
                        LinkButton btn = (LinkButton)item.FindControl("LinkButton2");
                        string result = btn.Text;
                        using (SqlConnection cn = new SqlConnection(gone))
                        {
                            SqlCommand cmd = new SqlCommand("removeFile", cn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@filename", SqlDbType.NVarChar).Value = result;
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                        }
                    }
                }
            }
            Response.Redirect("StoragePage.aspx");
        }
    }
}