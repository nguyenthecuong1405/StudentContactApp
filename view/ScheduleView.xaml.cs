//using System;
//using System.Data;
//using System.Data.SqlClient;

//namespace StudentContactApp.Helpers
//{
//    public static class DatabaseHelper
//    {
//        private static string ConnectionString = "Data Source=.;Initial Catalog=StudentContactDB;Integrated Security=True";

//        public static DataTable ExecuteQuery(string query)
//        {
//            using (SqlConnection conn = new SqlConnection(ConnectionString))
//            {
//                DataTable dataTable = new DataTable();
//                try
//                {
//                    conn.Open();
//                    using (SqlCommand cmd = new SqlCommand(query, conn))
//                    {
//                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
//                        {
//                            adapter.Fill(dataTable);
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine("Error: " + ex.Message);
//                }
//                return dataTable;
//            }
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Data;

namespace StudentContactApp.Views
{
    public partial class ScheduleView : UserControl
    {
        public ScheduleView()
        {
            InitializeComponent();
            LoadSchedule();
        }

        private void LoadSchedule()
        {
            string query = @"
        SELECT 
            s.Day AS Day,
            s.Subject AS Subject,
            s.Time AS Time,
            t.FullName AS FullName
        FROM Schedule s
        INNER JOIN Teachers t ON t.TeacherID = s.TeacherID";

            DataTable attendanceTable = DatabaseHelper.ExecuteQuery(query);
            dataGridSchedule.ItemsSource = attendanceTable.DefaultView;
        }
    }
}

