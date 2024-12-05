using StudentContactApp;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace StudentContactApp.Views
{
    public partial class ClassListView : UserControl
    {
        private int selectedStudentID = -1;

        public ClassListView()
        {
            InitializeComponent();
            LoadStudents();
        }

        // Tải danh sách từ cơ sở dữ liệu
        private void LoadStudents()
        {
            string query = "SELECT StudentID, FullName, Class, DateOfBirth FROM Students";
            DataTable studentsTable = DatabaseHelper.ExecuteQuery(query);
            dataGridStudents.ItemsSource = studentsTable.DefaultView;
        }

        // Thêm học sinh
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string fullName = txtFullName.Text;
            string className = txtClass.Text;
            DateTime? dateOfBirth = dpDateOfBirth.SelectedDate;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(className) || dateOfBirth == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string query = "INSERT INTO Students (FullName, Class, DateOfBirth) VALUES (@FullName, @Class, @DateOfBirth)";
            SqlParameter[] parameters = {
                new SqlParameter("@FullName", fullName),
                new SqlParameter("@Class", className),
                new SqlParameter("@DateOfBirth", dateOfBirth.Value)
            };

            int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
            if (result > 0)
            {
                MessageBox.Show("Thêm học sinh thành công!");
                LoadStudents();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm học sinh.");
            }
        }

        // Sửa học sinh
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedStudentID == -1)
            {
                MessageBox.Show("Vui lòng chọn học sinh để sửa!");
                return;
            }

            string fullName = txtFullName.Text;
            string className = txtClass.Text;
            DateTime? dateOfBirth = dpDateOfBirth.SelectedDate;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(className) || dateOfBirth == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string query = "UPDATE Students SET FullName = @FullName, Class = @Class, DateOfBirth = @DateOfBirth WHERE StudentID = @StudentID";
            SqlParameter[] parameters = {
                new SqlParameter("@FullName", fullName),
                new SqlParameter("@Class", className),
                new SqlParameter("@DateOfBirth", dateOfBirth.Value),
                new SqlParameter("@StudentID", selectedStudentID)
            };

            int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
            if (result > 0)
            {
                MessageBox.Show("Sửa học sinh thành công!");
                LoadStudents();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi sửa học sinh.");
            }
        }

        // Xóa học sinh


        // Sự kiện chọn dòng trong DataGrid
        private void DataGridStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridStudents.SelectedItem is DataRowView rowView)
            {
                selectedStudentID = Convert.ToInt32(rowView["StudentID"]);
                txtFullName.Text = rowView["FullName"].ToString();
                txtClass.Text = rowView["Class"].ToString();
                dpDateOfBirth.SelectedDate = Convert.ToDateTime(rowView["DateOfBirth"]);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedStudentID == -1)
            {
                MessageBox.Show("Vui lòng chọn học sinh để xóa!");
                return;
            }

            string query = "DELETE FROM Students WHERE StudentID = @StudentID";
            SqlParameter[] parameters = {
                new SqlParameter("@StudentID", selectedStudentID)
            };

            int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
            if (result > 0)
            {
                MessageBox.Show("Xóa học sinh thành công!");
                LoadStudents();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa học sinh.");
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadStudents();
                return;
            }
            string query = "SELECT StudentID, FullName, Class, DateOfBirth FROM Students WHERE FullName LIKE @Keyword";
            SqlParameter[] parameters = {
                new SqlParameter("@Keyword", $"%{keyword}%")
            };

            DataTable filteredTable = DatabaseHelper.ExecuteQuery(query, parameters);
            dataGridStudents.ItemsSource = filteredTable.DefaultView;
        }
    }
}
