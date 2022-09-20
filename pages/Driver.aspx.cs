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
    public partial class crudDriver : System.Web.UI.Page
    {
        static string connString = "";
        SqlConnection dbConn = new SqlConnection(connString);
        SqlCommand dbComm;
        SqlDataAdapter dbAdapter;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDriver();
            }
        }
        protected void GetDriver()
        {
            try
            {
                dbConn.Open();
                string sql = "SELECT users.driverNo, users.name, users.email, users.mobile, driver.address "+
                    "FROM users, driver "+
                    "WHERE users.driverNo IS NOT NULL AND users.driverNo = driver.driverNo";

                dbComm = new SqlCommand(sql, dbConn);
                dbAdapter = new SqlDataAdapter(dbComm);
                dt = new DataTable();
                dbAdapter.Fill(dt);
                dgvItem.DataSource = dt;
                dgvItem.DataBind();
                dbConn.Close();
            }
            catch (Exception ex)
            {
                lblDriverMessage.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void btnAddDriver_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDriverNo.Text != "")
                {
                    dbConn.Open();
                    string sql1 = "INSERT INTO driver (driverNo, address) VALUES (@driverNo, @address)";
                    dbComm = new SqlCommand(sql1, dbConn);
                    dbComm.Parameters.AddWithValue("@driverNo", txtDriverNo.Text);
                    dbComm.Parameters.AddWithValue("@address", txtDriverAddress.Text);
                    dbComm.ExecuteNonQuery();
                    dbConn.Close();

                    dbConn.Open();
                    string sql2 = "INSERT INTO users (driverNo, name, email, mobile) " +
                        "VALUES (@driverNo, @name, @email, @mobile)";
                    dbComm = new SqlCommand(sql2, dbConn);
                    dbComm.Parameters.AddWithValue("@driverNo", txtDriverNo.Text);
                    dbComm.Parameters.AddWithValue("@name", txtDriverName.Text);
                    dbComm.Parameters.AddWithValue("@email", txtDriverEmail.Text);
                    dbComm.Parameters.AddWithValue("@mobile", txtDriverMobile.Text);
                    int x = dbComm.ExecuteNonQuery();
                    dbConn.Close();
                    if (x > 0)
                    {
                        GetDriver();
                    }
                    lblDriverMessage.Text = "Submission Successful!";

                    txtDriverNo.Text = "";
                    txtDriverName.Text = "";
                    txtDriverEmail.Text = "";
                    txtDriverMobile.Text = "";
                    txtDriverAddress.Text = "";
                }
                else {
                    lblDriverMessage.Text = "Error, please enter required details!";
                }
            }
            catch (Exception ex)
            {
                lblDriverMessage.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void btnGridAction_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnAction = (Button)sender;
                string driverNo = btnAction.CommandArgument.ToString();
                dbConn.Open();

                string sql = "SELECT users.driverNo, users.name, users.email, users.mobile, driver.address " +
                    "FROM users, driver " +
                    "WHERE users.driverNo = @driverNo";

                dbComm = new SqlCommand(sql, dbConn);
                dbComm.Parameters.AddWithValue("@driverNo", driverNo);
                dbAdapter = new SqlDataAdapter(dbComm);
                dt = new DataTable();
                dbAdapter.Fill(dt);

                lblDriverID2.Text = dt.Rows[0]["driverNo"].ToString();
                txtDriverName2.Text = dt.Rows[0]["name"].ToString();
                txtDriverEmail2.Text = dt.Rows[0]["email"].ToString();
                txtDriverMobile2.Text = dt.Rows[0]["mobile"].ToString();
                txtDriverAddress2.Text = dt.Rows[0]["address"].ToString();
                dbConn.Close();
            }
            catch (Exception ex)
            {
                lblDriverMessage2.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void btnUpdateDriver_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblDriverID2.Text != "")
                {
                    dbConn.Open();
                    string sql1 = "UPDATE driver SET address = @address2 " +
                      "WHERE driverNo = @driverNo2";
                    dbComm = new SqlCommand(sql1, dbConn);
                    dbComm.Parameters.AddWithValue("@driverNo2", lblDriverID2.Text);
                    dbComm.Parameters.AddWithValue("@address2", txtDriverAddress2.Text);
                    dbComm.ExecuteNonQuery();
                    dbConn.Close();

                    dbConn.Open();
                    string sql2 = "UPDATE users SET name = @name2, email = @email2, mobile = @mobile2 " +
                      "WHERE driverNo = @driverNo2";
                    dbComm = new SqlCommand(sql2, dbConn);
                    dbComm.Parameters.AddWithValue("@driverNo2", lblDriverID2.Text);
                    dbComm.Parameters.AddWithValue("@name2", txtDriverName2.Text);
                    dbComm.Parameters.AddWithValue("@email2", txtDriverEmail2.Text);
                    dbComm.Parameters.AddWithValue("@mobile2", txtDriverMobile2.Text);
                    int x = dbComm.ExecuteNonQuery();

                    dbConn.Close();
                    if (x > 0)
                    {
                        GetDriver();
                    }
                    lblDriverMessage2.Text = "Successfully Updated!";
                } else {
                    lblDriverMessage2.Text = "Error, Select row below to enter details!";
                }
            }
            catch (Exception ex)
            {
                lblDriverMessage2.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void btnDeleteDriver_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblDriverID2.Text != "")
                {
                    dbConn.Open();
                    string sql = "DELETE FROM users WHERE driverNo = @driverNo2";
                    dbComm = new SqlCommand(sql, dbConn);
                    dbComm.Parameters.AddWithValue("@driverNo2", lblDriverID2.Text);
                    dbComm.ExecuteNonQuery();
                    dbConn.Close();

                    dbConn.Open();
                    string sql2 = "DELETE FROM driver WHERE driverNo = @driverNo2";
                    dbComm = new SqlCommand(sql2, dbConn);
                    dbComm.Parameters.AddWithValue("@driverNo2", lblDriverID2.Text);
                    int x = dbComm.ExecuteNonQuery();
                    dbConn.Close();

                    if (x > 0)
                    {
                        GetDriver();
                    }
                    lblDriverMessage2.Text = "Successfully Deleted!";

                    lblDriverID2.Text = "";
                    txtDriverName2.Text = "";
                    txtDriverEmail2.Text = "";
                    txtDriverMobile2.Text = "";
                    txtDriverAddress2.Text = "";
                }
                else {
                    lblDriverMessage2.Text = "Error, Select row below!";
                }
            }
            catch (Exception ex)
            {
                lblDriverMessage2.Text = "Error Message: " + ex.ToString();
            }
        }
    }
}
