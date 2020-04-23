using Facebook.Mobile.Test.Main;
using System.Data;
using System.Data.SqlClient;

namespace Facebook.Mobile.Test.Utility
{
    public class DBHelper
    {
        public DataTable runSelectQuery(string query)
        {
           // query = UtilityCode.RemoveNewLine(query);
            DataTable results = new DataTable();
            // using (SqlConnection conn = new SqlConnection(Config.ConnectionString.ToString()))
            using (SqlConnection conn = new SqlConnection(""))
            using (SqlCommand command = new SqlCommand(query, conn))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(results);
            return null;
        }

    }
}
