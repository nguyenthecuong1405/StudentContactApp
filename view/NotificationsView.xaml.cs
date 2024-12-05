using StudentContactApp;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace StudentContactApp.Views
{
    public partial class NotificationsView : UserControl
    {
        private int selectNotiID = -1;
        public NotificationsView()
        {
            InitializeComponent();
            LoadNoti();
        }

        private void LoadNoti()
        {
            string query = "SELECT NotificationID, Title, Content FROM Notifications";
            DataTable notiTable = DatabaseHelper.ExecuteQuery(query);
            dataGridNoti.ItemsSource = notiTable.DefaultView;
        }
        private void BtnSendNotification_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtContent.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Thực hiện lưu thông báo vào cơ sở dữ liệu
            string query = "INSERT INTO Notifications (Title, Content) VALUES (@Title, @Content)";
            SqlParameter[] parameters = {
                new SqlParameter("@Title", txtTitle.Text),
                new SqlParameter("@Content", txtContent.Text)
            };

            int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

            if (result > 0)
            {
                MessageBox.Show("Thông báo đã được gửi thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadNoti();
            }
            else
            {
                MessageBox.Show("Gửi thông báo thất bại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDeleteNotification_Click(object sender, RoutedEventArgs e)
        {
            if (selectNotiID == -1)
            {
                MessageBox.Show("Vui lòng chọn thông báo để xóa!");
                return;
            }

            string query = "DELETE FROM Notifications WHERE NotificationID = @NotificationID";
            SqlParameter[] parameters = {
                new SqlParameter("@NotificationID", selectNotiID)
            };

            int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
            if (result > 0)
            {
                MessageBox.Show("Xóa thông báo thành công!");
                LoadNoti();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa thông báo.");
            }
        }

        private void dataGridNoti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridNoti.SelectedItem is DataRowView rowView)
            {
                selectNotiID = Convert.ToInt32(rowView["NotificationID"]);
                txtTitle.Text = rowView["Title"].ToString();
                txtContent.Text = rowView["Content"].ToString();
            }
        }
    }
}
