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
    public partial class crReturns : System.Web.UI.Page
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
                GetCarNo();
                GetInspectorName();
                GetDriverName();
                GetReturnsTable();
            }
        }

        public void GetCarNo()
        {
            try
            {
                dbConn.Open();
                string sql = "SELECT carNo FROM car";
                dbComm = new SqlCommand(sql, dbConn);
                dbAdapter = new SqlDataAdapter(dbComm);
                dt = new DataTable();
                dbAdapter.Fill(dt);

                cmbCarNo.DataSource = dt;
                //cmbCarNo.DataValueField = "carNo";
                cmbCarNo.DataTextField = "carNo";
                cmbCarNo.DataBind();
                dbConn.Close();
            }
            catch (Exception ex)
            {
                lblReturnsMessage.Text = "Error Message: " + ex.ToString();
            }
        }

        public void GetInspectorName()
        {
            try
            {
                dbConn.Open();
                string sql = "SELECT inspectorNo, name FROM users WHERE inspectorNo IS NOT NULL";
                dbComm = new SqlCommand(sql, dbConn);
                dbAdapter = new SqlDataAdapter(dbComm);
                dt = new DataTable();
                dbAdapter.Fill(dt);

                cmbInspectorName.DataSource = dt;
                cmbInspectorName.DataValueField = "inspectorNo";
                cmbInspectorName.DataTextField = "name";
                cmbInspectorName.DataBind();
                dbConn.Close();
            }
            catch (Exception ex)
            {
                lblReturnsMessage.Text = "Error Message: " + ex.ToString();
            }
        }

        public void GetDriverName()
        {
            try
            {
                dbConn.Open();
                string sql = "SELECT driverNo, name FROM users WHERE driverNo IS NOT NULL";
                dbComm = new SqlCommand(sql, dbConn);
                dbAdapter = new SqlDataAdapter(dbComm);
                dt = new DataTable();
                dbAdapter.Fill(dt);

                cmbDriverName.DataSource = dt;
                cmbDriverName.DataValueField = "driverNo";
                cmbDriverName.DataTextField = "name";
                cmbDriverName.DataBind();
                dbConn.Close();
            }
            catch (Exception ex)
            {
                lblReturnsMessage.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void GetReturnsTable()
        {
            try
            {
                dbConn.Open();
                string sql = "SELECT carNo, inspectorNo, driverNo, Cast(returnDate As VarChar(10)) as 'return-date', elapsedDate " +
                    "FROM returnTbl";

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
                lblReturnsMessage.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void btnAddReturns_Click(object sender, EventArgs e)
        {
            try
            {
                dbConn.Open();
                string sql = "INSERT INTO returnTbl (carNo, inspectorNo, driverNo, returnDate, elapsedDate) " +
                    "VALUES (@carNo, @inspectorNo, @driverNo, @returnDate, @elapsedDate)";

                dbComm = new SqlCommand(sql, dbConn);
                dbComm.Parameters.AddWithValue("@carNo", cmbCarNo.SelectedItem.ToString());
                dbComm.Parameters.AddWithValue("@inspectorNo", cmbInspectorName.SelectedValue.ToString());
                dbComm.Parameters.AddWithValue("@driverNo", cmbDriverName.SelectedValue.ToString());
                dbComm.Parameters.AddWithValue("@returnDate", txtReturnDate.Text);
                dbComm.Parameters.AddWithValue("@elapsedDate", txtElapsedDate.Text);

                int x = dbComm.ExecuteNonQuery();
                dbConn.Close();
                if (x > 0)
                {
                    GetReturnsTable();
                }
                lblReturnsMessage.Text = "Submission Successful!";

                txtReturnDate.Text = "";
                txtElapsedDate.Text = "";
            }
            catch (Exception ex)
            {
                lblReturnsMessage.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void btnCalculateFee_Click(object sender, EventArgs e)
        {
            try
            {
                dbConn.Open();
                string sql = "SELECT carNo, inspectorNo, driverNo, Cast(returnDate As VarChar(10)) as 'return-date', elapsedDate, " +
                    "(500 * elapsedDate) as 'Late/Penalty Fee' "+
                    "FROM returnTbl ORDER BY elapsedDate";

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
                lblReturnsMessage.Text = "Error Message: " + ex.ToString();
            }
        }
    }
}
