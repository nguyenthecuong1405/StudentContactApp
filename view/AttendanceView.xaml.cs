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
    public partial class AttendanceView : UserControl
    {
        public AttendanceView ()
        {
            InitializeComponent();
            LoadAttendance();
        }

        private void LoadAttendance()
        {
            string query = @"
        SELECT 
            s.FullName AS Name,
            s.Class AS Class,
            a.Date AS Date,
            CASE 
                WHEN a.IsPresent = 1 THEN N'Có'
                ELSE N'Vắng'
            END AS Present
        FROM Attendance a
        INNER JOIN Students s ON a.StudentID = s.StudentID";

            DataTable attendanceTable = DatabaseHelper.ExecuteQuery(query);
            dataGridAttendance.ItemsSource = attendanceTable.DefaultView;
        }
    }
}
