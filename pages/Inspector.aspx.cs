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
    public partial class crudInspector : System.Web.UI.Page
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
                GetInspector();
            }
        }

        protected void GetInspector()
        {
            try
            {
                dbConn.Open();
                string sql = "SELECT inspectorNo, name, email, mobile FROM users WHERE inspectorNo IS NOT NULL";

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
                lblInspectorMessage.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void btnAddInspector_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInspectorNo.Text != "")
                {
                    dbConn.Open();
                    string sql1 = "INSERT INTO inspector (inspectorNo) VALUES (@inspectorNo)";
                    dbComm = new SqlCommand(sql1, dbConn);
                    dbComm.Parameters.AddWithValue("@inspectorNo", txtInspectorNo.Text);
                    dbComm.ExecuteNonQuery();
                    dbConn.Close();

                    dbConn.Open();
                    string sql2 = "INSERT INTO users (inspectorNo, name, email, mobile) " +
                        "VALUES (@inspectorNo, @name, @email, @mobile)";
                    dbComm = new SqlCommand(sql2, dbConn);
                    dbComm.Parameters.AddWithValue("@inspectorNo", txtInspectorNo.Text);
                    dbComm.Parameters.AddWithValue("@name", txtInspectorName.Text);
                    dbComm.Parameters.AddWithValue("@email", txtInspectorEmail.Text);
                    dbComm.Parameters.AddWithValue("@mobile", txtInspectorMobile.Text);
                    int x = dbComm.ExecuteNonQuery();
                    dbConn.Close();
                    if (x > 0)
                    {
                        GetInspector();
                    }
                    lblInspectorMessage.Text = "Submission Successful!";

                    txtInspectorNo.Text = "";
                    txtInspectorName.Text = "";
                    txtInspectorEmail.Text = "";
                    txtInspectorMobile.Text = "";
                }
                else {
                    lblInspectorMessage.Text = "Error, please enter required details!";
                }
            }
            catch (Exception ex)
            {
                lblInspectorMessage.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void btnGridAction_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnAction = (Button)sender;
                string inspectorNo = btnAction.CommandArgument.ToString();
                dbConn.Open();

                string sql = "SELECT inspectorNo, name, email, mobile FROM users WHERE inspectorNo = @inspectorNo";

                dbComm = new SqlCommand(sql, dbConn);
                dbComm.Parameters.AddWithValue("@inspectorNo", inspectorNo);
                dbAdapter = new SqlDataAdapter(dbComm);
                dt = new DataTable();
                dbAdapter.Fill(dt);

                lblInspectorID2.Text = dt.Rows[0]["inspectorNo"].ToString();
                txtInspectorName2.Text = dt.Rows[0]["name"].ToString();
                txtInspectorEmail2.Text = dt.Rows[0]["email"].ToString();
                txtInspectorMobile2.Text = dt.Rows[0]["mobile"].ToString();
                dbConn.Close();
            }
            catch (Exception ex)
            {
                lblInspectorMessage2.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void btnUpdateInspector_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblInspectorID2.Text != "")
                {
                    dbConn.Open();
                    string sql = "UPDATE users SET name = @name2, email = @email2, mobile = @mobile2 " +
                      "WHERE inspectorNo = @inspectorNo2";
                    dbComm = new SqlCommand(sql, dbConn);
                    dbComm.Parameters.AddWithValue("@inspectorNo2", lblInspectorID2.Text);
                    dbComm.Parameters.AddWithValue("@name2", txtInspectorName2.Text);
                    dbComm.Parameters.AddWithValue("@email2", txtInspectorEmail2.Text);
                    dbComm.Parameters.AddWithValue("@mobile2", txtInspectorMobile2.Text);
                    int x = dbComm.ExecuteNonQuery();

                    dbConn.Close();
                    if (x > 0)
                    {
                        GetInspector();
                    }
                    lblInspectorMessage2.Text = "Successfully Updated!";
                }
                else {
                    lblInspectorMessage2.Text = "Error, Select row below to enter details!";
                }
            }
            catch (Exception ex)
            {
                lblInspectorMessage2.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void btnDeleteInspector_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblInspectorID2.Text != "")
                {
                    dbConn.Open();
                    string sql = "DELETE FROM users WHERE inspectorNo = @inspectorNo2";
                    dbComm = new SqlCommand(sql, dbConn);
                    dbComm.Parameters.AddWithValue("@inspectorNo2", lblInspectorID2.Text);
                    dbComm.ExecuteNonQuery();
                    dbConn.Close();

                    dbConn.Open();
                    string sql2 = "DELETE FROM inspector WHERE inspectorNo = @inspectorNo2";
                    dbComm = new SqlCommand(sql2, dbConn);
                    dbComm.Parameters.AddWithValue("@inspectorNo2", lblInspectorID2.Text);
                    int x = dbComm.ExecuteNonQuery();
                    dbConn.Close();

                    if (x > 0)
                    {
                        GetInspector();
                    }
                    lblInspectorMessage2.Text = "Successfully Deleted!";

                    lblInspectorID2.Text = "";
                    txtInspectorName2.Text = "";
                    txtInspectorEmail2.Text = "";
                    txtInspectorMobile2.Text = "";
                }
                else {
                    lblInspectorMessage2.Text = "Error, Select row below!";
                }
            }
            catch (Exception ex)
            {
                lblInspectorMessage2.Text = "Error Message: " + ex.ToString();
            }
        }
    }
}
