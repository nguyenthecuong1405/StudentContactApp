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
    public partial class EvaluationView : UserControl
    {
        private int selectedEvaluationID = -1;
        public EvaluationView()
        {
            InitializeComponent();
            LoadEvaluation();
        }

        private void LoadEvaluation()
        {
            string query = "SELECT EvaluationID, Name, TEvaluation, PFeedback FROM Evaluation";
            DataTable evaluationTable = DatabaseHelper.ExecuteQuery(query);
            dataGridEvaluation.ItemsSource = evaluationTable.DefaultView;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string Name = txtName.Text;
            string TEvaluation = txtTEvaluation.Text;
            string PFeedback = txtPFeedback.Text;

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(TEvaluation) || string.IsNullOrEmpty(PFeedback))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string query = "INSERT INTO Evaluation (Name, TEvaluation, PFeedback) VALUES (@Name, @TEvaluation, @PFeedback)";
            SqlParameter[] parameters = {
                new SqlParameter("@Name", Name),
                new SqlParameter("@TEvaluation", TEvaluation),
                new SqlParameter("@PFeedback", PFeedback)
            };

            int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
            if (result > 0)
            {
                MessageBox.Show("Thêm đánh giá thành công!");
                LoadEvaluation();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm đánh giá.");
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedEvaluationID == -1)
            {
                MessageBox.Show("Vui lòng chọn đánh giá để sửa!");
                return;
            }

            string Name = txtName.Text;
            string TEvaluation = txtTEvaluation.Text;
            string PFeedback = txtPFeedback.Text;

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(TEvaluation) || string.IsNullOrEmpty(PFeedback))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string query = "UPDATE Evaluation SET Name = @Name, TEvaluation = @TEvaluation, PFeedback = @PFeedback WHERE EvaluationID = @EvaluationID";
            SqlParameter[] parameters = {
                new SqlParameter("@Name", Name),
                new SqlParameter("@TEvaluation", TEvaluation),
                new SqlParameter("@PFeedback", PFeedback),
                new SqlParameter("@EvaluationID", selectedEvaluationID)
            };

            int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
            if (result > 0)
            {
                MessageBox.Show("Sửa đánh giá thành công!");
                LoadEvaluation();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi sửa đánh giá.");
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedEvaluationID == -1)
            {
                MessageBox.Show("Vui lòng chọn đánh giá để xóa!");
                return;
            }

            string query = "DELETE FROM Evaluation WHERE EvaluationID = @EvaluationID";
            SqlParameter[] parameters = {
                new SqlParameter("@EvaluationID", selectedEvaluationID)
            };

            int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
            if (result > 0)
            {
                MessageBox.Show("Xóa đánh giá thành công!");
                LoadEvaluation();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa đánh giá.");
            }
        }

        private void dataGridEvaluation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridEvaluation.SelectedItem is DataRowView rowView)
            {
                selectedEvaluationID = Convert.ToInt32(rowView["EvaluationID"]);
                txtName.Text = rowView["Name"].ToString();
                txtTEvaluation.Text = rowView["TEvaluation"].ToString();
                txtPFeedback.Text = rowView["PFeedback"].ToString();
            }
        }
    }
}
