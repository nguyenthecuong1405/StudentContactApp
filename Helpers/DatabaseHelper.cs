using System.Data;
using System.Data.SqlClient;

namespace StudentContactApp
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = "Server=DESKTOP-093S4TK;Database=StudentContactDB;Trusted_Connection=True;User Id=sa;Password=14052003;";
        //Server=localhost\\SQLEXPRESS;Database=QlyThuVien; integrated security = true;
        //Server=DESKTOP-093S4TK;Database=StudentContactDB;Trusted_Connection=True;User Id=sa;Password=14052003;
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
