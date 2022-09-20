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
    public partial class crRental : System.Web.UI.Page
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
                GetRentalTable();
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
                lblRentalMessage.Text = "Error Message: " + ex.ToString();
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
                lblRentalMessage.Text = "Error Message: " + ex.ToString();
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
                lblRentalMessage.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void GetRentalTable()
        {
            try
            {
                dbConn.Open();
                string sql = "SELECT carNo, inspectorNo, driverNo, rentalFee, Cast(startDate As VarChar(10)) as 'start-date', "+
                    "Cast(endDate As VarChar(10)) as 'end-date' FROM rental WHERE rentalID > 9";

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
                lblRentalMessage.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void btnAddRental_Click(object sender, EventArgs e)
        {
            try
            {
                dbConn.Open();
                string sql = "INSERT INTO rental (carNo, inspectorNo, driverNo, rentalFee, startDate, endDate) " +
                    "VALUES (@carNo, @inspectorNo, @driverNo, @rentalFee, @startDate, @endDate)";

                dbComm = new SqlCommand(sql, dbConn);
                dbComm.Parameters.AddWithValue("@carNo", cmbCarNo.SelectedItem.ToString());
                dbComm.Parameters.AddWithValue("@inspectorNo", cmbInspectorName.SelectedValue.ToString());
                dbComm.Parameters.AddWithValue("@driverNo", cmbDriverName.SelectedValue.ToString());
                dbComm.Parameters.AddWithValue("@rentalFee", txtRentalFee.Text);
                dbComm.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                dbComm.Parameters.AddWithValue("@endDate", txtEndDate.Text);

                int x = dbComm.ExecuteNonQuery();
                dbConn.Close();
                if (x > 0)
                {
                    GetRentalTable();
                }
                lblRentalMessage.Text = "Submission Successful!";

                txtRentalFee.Text = "";
                txtStartDate.Text = "";
                txtEndDate.Text = "";
            }
            catch (Exception ex)
            {
                lblRentalMessage.Text = "Error Message: " + ex.ToString();
            }
        }
    }
}
