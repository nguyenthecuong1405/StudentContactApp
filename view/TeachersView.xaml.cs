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
using System.Data.SqlClient;

namespace StudentContactApp.Views
{
    public partial class TeachersView : UserControl
    {
        private int selectedTeacherID = -1;
        public TeachersView()
        {
            InitializeComponent();
            LoadTeachers();
        }

        private void LoadTeachers()
        {
            string query = "SELECT TeacherID, FullName, Subject, Phone FROM Teachers";
            DataTable teachersTable = DatabaseHelper.ExecuteQuery(query);
            dataGridTeachers.ItemsSource = teachersTable.DefaultView;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string fullName = txtFullName.Text;
            string SubjectName = txtSubject.Text;
            string PhoneNumber = txtPhone.Text;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(SubjectName) || string.IsNullOrEmpty(PhoneNumber))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string query = "INSERT INTO Teachers (FullName, Subject, Phone) VALUES (@FullName, @Subject, @PhoneNumber)";
            SqlParameter[] parameters = {
                new SqlParameter("@FullName", fullName),
                new SqlParameter("@Subject", SubjectName),
                new SqlParameter("@PhoneNumber", PhoneNumber)
            };

            int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
            if (result > 0)
            {
                MessageBox.Show("Thêm giáo viên thành công!");
                LoadTeachers();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm giáo viên.");
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTeacherID == -1)
            {
                MessageBox.Show("Vui lòng chọn giáo viên để sửa!");
                return;
            }

            string fullName = txtFullName.Text;
            string SubjectName = txtSubject.Text;
            string PhoneNumber = txtPhone.Text;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(SubjectName) || string.IsNullOrEmpty(PhoneNumber))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string query = "UPDATE Teachers SET FullName = @FullName, Subject = @Subject, Phone = @Phone WHERE TeacherID = @TeacherID";
            SqlParameter[] parameters = {
                new SqlParameter("@FullName", fullName),
                new SqlParameter("@Subject", SubjectName),
                new SqlParameter("@Phone", PhoneNumber),
                new SqlParameter("@TeacherID", selectedTeacherID)
            };

            int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
            if (result > 0)
            {
                MessageBox.Show("Sửa giáo viên thành công!");
                LoadTeachers();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi sửa giáo viên.");
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTeacherID == -1)
            {
                MessageBox.Show("Vui lòng chọn giáo viên để xóa!");
                return;
            }

            string query = "DELETE FROM Teachers WHERE TeacherID = @TeacherID";
            SqlParameter[] parameters = {
                new SqlParameter("@TeacherID", selectedTeacherID)
            };

            int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
            if (result > 0)
            {
                MessageBox.Show("Xóa giáo viên thành công!");
                LoadTeachers();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa giáo viên.");
            }
        }

        private void dataGridTeachers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridTeachers.SelectedItem is DataRowView rowView)
            {
                selectedTeacherID = Convert.ToInt32(rowView["TeacherID"]);
                txtFullName.Text = rowView["FullName"].ToString();
                txtSubject.Text = rowView["Subject"].ToString();
                txtPhone.Text = rowView["Phone"].ToString();
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadTeachers();
                return;
            }
            string query = "SELECT TeacherID, FullName, Subject, Phone FROM Teachers WHERE FullName LIKE @Keyword";
            SqlParameter[] parameters = {
                new SqlParameter("@Keyword", $"%{keyword}%")
            };

            DataTable filteredTable = DatabaseHelper.ExecuteQuery(query, parameters);
            dataGridTeachers.ItemsSource = filteredTable.DefaultView;
        }
    }
}
