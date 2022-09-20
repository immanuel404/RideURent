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
    public partial class Login : System.Web.UI.Page
    {
        static string connString = "";
        SqlConnection dbConn = new SqlConnection(connString);
        SqlCommand dbComm;
        SqlDataAdapter dbAdapter;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){}
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                dbConn.Open();
                string sql = "SELECT * FROM login WHERE name = @name AND password = @password";

                dbComm = new SqlCommand(sql, dbConn);
                dbComm.Parameters.AddWithValue("@name", txtLoginName.Text);
                dbComm.Parameters.AddWithValue("@password", txtLoginPassword.Text);
                dbAdapter = new SqlDataAdapter(dbComm);
                dt = new DataTable();
                dbAdapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    //REDIRECT
                    Server.Transfer("Home.aspx");
                }
                else
                {
                    lblLoginMessage.Text = "Login failed";
                }
                dbConn.Close();
            }
            catch (Exception ex)
            {
                lblLoginMessage.Text += "Error Message: " + ex.ToString();
            }
        }
    }
}
