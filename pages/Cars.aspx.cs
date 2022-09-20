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
    public partial class crudCars : System.Web.UI.Page
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
                GetCarMake();
                GetCarBodyType();
                GetCarTable();
            }
        }

        public void GetCarMake() {
            try
            {
                dbConn.Open();
                string sql = "SELECT * FROM carMake";
                dbComm = new SqlCommand(sql, dbConn);
                dbAdapter = new SqlDataAdapter(dbComm);
                dt = new DataTable();
                dbAdapter.Fill(dt);

                cmbCarMake.DataSource = dt; cmbCarMake2.DataSource = dt;
                cmbCarMake.DataValueField = "makeID"; cmbCarMake2.DataValueField = "makeID";
                cmbCarMake.DataTextField = "makeDescription"; cmbCarMake2.DataTextField = "makeDescription";
                cmbCarMake.DataBind(); cmbCarMake2.DataBind();
                dbConn.Close();
            }
            catch (Exception ex) {
                lblCarMessage.Text = "Error Message: " +ex.ToString();
            }
        }

        public void GetCarBodyType() {
            try {
                dbConn.Open();
                string sql = "SELECT * FROM carBodyType";
                dbComm = new SqlCommand(sql, dbConn);
                dbAdapter = new SqlDataAdapter(dbComm);
                dt = new DataTable();
                dbAdapter.Fill(dt);

                cmbCarBodyType.DataSource = dt; cmbCarBodyType2.DataSource = dt;
                cmbCarBodyType.DataValueField = "bodyTypeID"; cmbCarBodyType2.DataValueField = "bodyTypeID";
                cmbCarBodyType.DataTextField = "bodyDescription"; cmbCarBodyType2.DataTextField = "bodyDescription";
                cmbCarBodyType.DataBind(); cmbCarBodyType2.DataBind();
                dbConn.Close();
            }
            catch (Exception ex)
            {
                lblCarMessage.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void GetCarTable()
        {
            try
            {
                dbConn.Open();
                string sql = "SELECT car.carNo, carMake.makeDescription, car.model, carBodyType.bodyDescription, car.kiloTravelled, car.serviceKilo, car.available "+
                    "FROM car, carMake, carBodyType "+
                    "WHERE car.makeID = carMake.makeID AND car.bodyTypeID = carBodyType.bodyTypeID";

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
                lblCarMessage.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void btnAddCar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCarNo.Text != "")
                {
                    dbConn.Open();
                    string sql = "INSERT INTO car (carNo, makeID, model, bodyTypeID, kiloTravelled, serviceKilo, available) " +
                        "VALUES (@carNo, @makeID, @model, @bodyTypeID, @kiloTravelled, @serviceKilo, @available)";

                    dbComm = new SqlCommand(sql, dbConn);
                    dbComm.Parameters.AddWithValue("@carNo", txtCarNo.Text);
                    dbComm.Parameters.AddWithValue("@makeID", cmbCarMake.SelectedValue.ToString());
                    dbComm.Parameters.AddWithValue("@model", txtCarModel.Text);
                    dbComm.Parameters.AddWithValue("@bodyTypeID", cmbCarBodyType.SelectedValue.ToString());
                    dbComm.Parameters.AddWithValue("@kiloTravelled", txtKiloTravelled.Text);
                    dbComm.Parameters.AddWithValue("@serviceKilo", txtServiceKilo.Text);
                    dbComm.Parameters.AddWithValue("@available", txtAvailable.Text);

                    int x = dbComm.ExecuteNonQuery();
                    dbConn.Close();
                    if (x > 0)
                    {
                        GetCarTable();
                    }
                    lblCarMessage.Text = "Submission Successful!";

                    txtCarNo.Text = "";
                    txtCarModel.Text = "";
                    txtKiloTravelled.Text = "";
                    txtServiceKilo.Text = "";
                    txtAvailable.Text = "";
                }
                else
                {
                    lblCarMessage.Text = "Error, please enter required details!";
                }
            }
            catch (Exception ex)
            {
                lblCarMessage.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void btnGridAction_Click(object sender, EventArgs e) {
            try
            {
                Button btnAction = (Button)sender;
                string carNo = btnAction.CommandArgument.ToString();
                dbConn.Open();

                string sql = "SELECT car.carNo, carMake.makeDescription, car.model, carBodyType.bodyDescription, car.kiloTravelled, car.serviceKilo, car.available " +
                    "FROM car, carMake, carBodyType " +
                    "WHERE carNo = @carNo AND car.makeID = carMake.makeID AND car.bodyTypeID = carBodyType.bodyTypeID";

                dbComm = new SqlCommand(sql, dbConn);
                dbComm.Parameters.AddWithValue("@carNo", carNo);
                dbAdapter = new SqlDataAdapter(dbComm);
                dt = new DataTable();
                dbAdapter.Fill(dt);

                lblCarID2.Text = dt.Rows[0]["carNo"].ToString();
                lblCarMake2.Text = "Car Make: " + dt.Rows[0]["makeDescription"].ToString() + " ";
                txtCarModel2.Text = dt.Rows[0]["model"].ToString();
                lblCarBodyType2.Text = "Car Body-Type: " + dt.Rows[0]["bodyDescription"].ToString() + " ";
                txtKiloTravelled2.Text = dt.Rows[0]["kiloTravelled"].ToString();
                txtServiceKilo2.Text = dt.Rows[0]["serviceKilo"].ToString();
                txtAvailable2.Text = dt.Rows[0]["available"].ToString();
                dbConn.Close();
            }
            catch (Exception ex)
            {
                lblCarMessage2.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void btnUpdateCar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCarID2.Text != "")
                {
                    dbConn.Open();
                    string sql = "UPDATE car SET makeID = @makeID2, model = @model2, bodyTypeID = @bodyTypeID2, " +
                        "kiloTravelled = @kiloTravelled2, serviceKilo = @serviceKilo2, available = @available2 " +
                        "WHERE carNo = @carNo2";
                    dbComm = new SqlCommand(sql, dbConn);
                    dbComm.Parameters.AddWithValue("@carNo2", lblCarID2.Text);
                    dbComm.Parameters.AddWithValue("@makeID2", cmbCarMake2.SelectedValue.ToString());
                    dbComm.Parameters.AddWithValue("@model2", txtCarModel2.Text);
                    dbComm.Parameters.AddWithValue("@bodyTypeID2", cmbCarBodyType2.SelectedValue.ToString());
                    dbComm.Parameters.AddWithValue("@kiloTravelled2", txtKiloTravelled2.Text);
                    dbComm.Parameters.AddWithValue("@serviceKilo2", txtServiceKilo2.Text);
                    dbComm.Parameters.AddWithValue("@available2", txtAvailable2.Text);
                    int x = dbComm.ExecuteNonQuery();

                    dbConn.Close();
                    if (x > 0)
                    {
                        GetCarTable();
                    }
                    lblCarMessage2.Text = "Successfully Updated!";
                }
                else {
                    lblCarMessage2.Text = "Error, Select row below to enter details!";
                }
            }
            catch (Exception ex)
            {
                lblCarMessage2.Text = "Error Message: " + ex.ToString();
            }
        }

        protected void btnDeleteCar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCarID2.Text != "")
                {
                    dbConn.Open();
                    string sql = "DELETE FROM car WHERE carNo = @carNo2";
                    dbComm = new SqlCommand(sql, dbConn);
                    dbComm.Parameters.AddWithValue("@carNo2", lblCarID2.Text);
                    int x = dbComm.ExecuteNonQuery();
                    dbConn.Close();

                    if (x > 0)
                    {
                        GetCarTable();
                    }
                    lblCarMessage2.Text = "Successfully Deleted!";

                    lblCarID2.Text = "";
                    txtCarModel2.Text = "";
                    txtKiloTravelled2.Text = "";
                    txtServiceKilo2.Text = "";
                    txtAvailable2.Text = "";
                }
                else
                {
                    lblCarMessage2.Text = "Error, Select row below!";
                }
            }
            catch (Exception ex)
            {
                lblCarMessage2.Text = "Error Message: " + ex.ToString();
            }
        }
    }
}
