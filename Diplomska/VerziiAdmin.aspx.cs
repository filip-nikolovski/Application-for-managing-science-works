﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Diplomska
{
    public partial class VerziiAdmin : System.Web.UI.Page
    {
     //   static string connString = "SERVER=localhost;DATABASE=naucen_trud;UID=root;PWD=filip;Allow Zero Datetime=True;";

        static string connString = ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;
        MySqlConnection conn = new MySqlConnection(connString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["New"].ToString() == "admin@finki.com")
                {
                    lblLoged.Text = "You are logged in as ";
                    lblLogedAs.Text = Session["New"].ToString() + " ";
                    if (!IsPostBack)
                    {
                        try
                        {
                            conn.Open();
                            string sqlSelect = "SELECT v.*, sw.title FROM versions v, science_work sw WHERE v.id_science_work = sw.id and sw.id=?swid";
                               
                            MySqlCommand cmd = new MySqlCommand(sqlSelect, conn);
                            cmd.Parameters.Add("?swid", Session["sessi"].ToString());
                            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);

                            gvVerziiAdmin.DataSource = ds;
                            gvVerziiAdmin.DataBind();

                            lblTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
                        }
                        catch (Exception)
                        {
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
                else
                {

                    Response.Redirect("Login.aspx");
                }
            }
        }

        //delete gridview row
        protected void button_click(object sender, EventArgs e)
        {
            Button ibtn1 = sender as Button;
            int rowIndex = Convert.ToInt32(ibtn1.Attributes["RowIndex"]);

            try
            {

                conn.Open();

                string sqlDelete = "DELETE FROM  versions WHERE id_version =@id";
                MySqlCommand cmd = new MySqlCommand(sqlDelete, conn);

                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(rowIndex.ToString()));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //lblEx.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
                Response.Redirect("VerziiAdmin.aspx");
            }


        }

        //gvVerziiAdmin_RowCreated
        protected void gvVerziiAdmin_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.background='#D1DDF1';";

                if ((e.Row.RowIndex % 2) == 0)  // if even row
                    e.Row.Attributes["onmouseout"] = "this.style.background='#EFF3FB';";
                else  // alternate row
                    e.Row.Attributes["onmouseout"] = "this.style.background='White';";
           }
        }

        protected void btnLoguot_Click(object sender, EventArgs e)
        {
            Session["New"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}