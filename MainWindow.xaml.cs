using System.Windows;
using StudentContactApp.Views;

namespace StudentContactApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ScheduleView();
        }

        private void BtnAttendance_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new AttendanceView();
        }

        private void BtnEvaluation_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new EvaluationView();
        }

        private void BtnClassList_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ClassListView();
        }

        private void BtnTeachers_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TeachersView();
        }

        private void BtnNotifications_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new NotificationsView();
        }
    }
}
