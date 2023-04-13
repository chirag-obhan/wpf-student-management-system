using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
