using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace cldvPoeFinal
{
    public partial class Register : System.Web.UI.Page
    {
        static string connString = "";
        SqlConnection dbConn = new SqlConnection(connString);
        SqlCommand dbComm;
        SqlDataAdapter dbAdapter;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtRegisterName.Text;
                string password = txtRegisterPassword.Text;

                dbConn.Open();
                string sql1 = "SELECT name FROM login";
                dbComm = new SqlCommand(sql1, dbConn);
                dbComm.Parameters.AddWithValue("@name", name);
                dbAdapter = new SqlDataAdapter(dbComm);
                dt = new DataTable();
                dbAdapter.Fill(dt);
                if (name == dt.Rows[0]["name"].ToString())
                {
                    lblRegisterMessage.Text = "Failed! This name already exists!";
                    dbConn.Close();
                }
                else
                {
                    dbConn.Close();
                    dbConn.Open();
                    string sql2 = "INSERT INTO login (name, password) VALUES (@name, @password)";
                    dbComm = new SqlCommand(sql2, dbConn);
                    dbComm.Parameters.AddWithValue("@name", name);
                    dbComm.Parameters.AddWithValue("@password", password);
                    dbAdapter = new SqlDataAdapter(dbComm);
                    dt = new DataTable();
                    dbAdapter.Fill(dt);

                    lblRegisterMessage.Text = "Registration Successful, return to login-page.";
                    dbConn.Close();
                }
            }
            catch (Exception ex)
            {
                lblRegisterMessage.Text += "Error Message: " + ex.ToString();
            }
        }
    }
}
