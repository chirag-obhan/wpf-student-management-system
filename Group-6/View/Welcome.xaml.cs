using System.Windows;

namespace Group_6.View
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
        }
        StudentDatabase studentDatabase = new StudentDatabase();
        CourseDetails courseView = new CourseDetails();

        private void studentBtnClicked(object sender, RoutedEventArgs e)
        {
            studentDatabase.Show();
        }

        private void courseBtnClicked(object sender, RoutedEventArgs e)
        {
            courseView.Show();
        }
    }
}
