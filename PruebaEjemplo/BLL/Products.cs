using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Products
    {
        BLL.Connection conn = new Connection();
        DataTable dataTable = new DataTable();

        public DataTable GetProducts()
        {
            conn.Query = "SELECT [id], [Name], [Sku], [Description] FROM [dbo].[Products]";

            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                SqlCommand command = new SqlCommand(conn.Query, connection);

                try
                {
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dataTable);

                    return dataTable;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
