using System;
using System.Collections.Generic;
using System.Configuration;
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
    }
}
