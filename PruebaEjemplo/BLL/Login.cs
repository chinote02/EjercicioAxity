using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Login
    {
        BLL.Connection conn = new Connection();
        DataTable dataTable = new DataTable();

        public bool IsValid(string usr, string pwd)
        {
            conn.Query = string.Format("SELECT [id] ,[user] ,[pwd] FROM [dbo].[Users] WHERE [user] = '{0}' AND [pwd] = '{1}'", usr, pwd);

            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                SqlCommand command = new SqlCommand(conn.Query, connection);

                try
                {
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dataTable);

                    return dataTable.Rows.Count > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
