using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webapp01
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayGridView();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string regNo = regno.Text;

            // Get the connection string from the web.config file
            string connectionString = ConfigurationManager.ConnectionStrings["con2"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT name, age, address FROM studentreg WHERE reg_no = @RegNo";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RegNo", regNo);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                regno1.Text = regNo;
                                name.Text = reader["name"].ToString();
                                age.Text = reader["age"].ToString();
                                address.Text = reader["address"].ToString();

                                DisplayGridView();


                            }
                            else
                            {
                                // Handle case where no data is found
                                regno1.Text = string.Empty;
                                name.Text = string.Empty;
                                age.Text = string.Empty;
                                address.Text = string.Empty;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle the error
                    // You can log the error or display a message to the user
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void DisplayGridView()
        {
            try
            {

                DataTable dataTable = new DataTable();


                string selectallQuery = "SELECT * FROM studentreg";

                string connectionString = ConfigurationManager.ConnectionStrings["con2"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(selectallQuery, connection))
                    {

                        connection.Open();


                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {

                            dataAdapter.Fill(dataTable);
                        }
                    }
                }


                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write("An error occurred: " + ex.Message);
            }
        }

        protected void btncr_Click(object sender, EventArgs e)
        {
            try
            {
                // Connection details 
                string connectionString = ConfigurationManager.ConnectionStrings["con2"].ConnectionString;
                string query = "SELECT * FROM studentreg";

                // Create a DataSet
                DataSet dataSet = new DataSet();

                // Connect to the database and fill the DataSet
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    dataAdapter.Fill(dataSet);
                }

                // Create an instance of the Crystal Report
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(Server.MapPath("~/CrystalReport2.rpt"));

                // Set the DataSet as the report source
                reportDocument.SetDataSource(dataSet.Tables["table"]);

                // Set the Crystal Report Viewer report source
                CrystalReportViewer1.ReportSource = reportDocument;
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Personal Information");
                CrystalReportViewer1.DataBind();

            }

            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
        }

    }
}
