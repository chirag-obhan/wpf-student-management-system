using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Group_6.View
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class updateCourse : Window
    {
        public updateCourse()
        {
            InitializeComponent();
        }
        
       
        CourseDetails details = new CourseDetails();
        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = CourseName.Text;
                string coId = cid.Text;
                string description = desc.Text;
                string durations = duration.Text;
                string email = Coursemail.Text;

                string con = Properties.Settings.Default.connectionString;
                SqlConnection connect = new SqlConnection(con);
                connect.Open();
                SqlCommand cmd = new SqlCommand("UPDATE DbCourses SET courseName = '" +name + "',courseDesc = '" + description+ "', courseDur = '" + durations + "',courseEmail = '" + email +   "'Where courseId = '" + coId + "'", connect);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                SqlCommand fetchCourse = new SqlCommand("SELECT * FROM DbCourses", connect);
                fetchCourse.CommandType = CommandType.Text;
                SqlDataAdapter fetchCourseAdapter = new SqlDataAdapter();
                fetchCourseAdapter.SelectCommand = fetchCourse;
                DataSet courseDataSet = new DataSet();
                fetchCourseAdapter.Fill(courseDataSet);

                if (courseDataSet.Tables[0].Rows.Count > 0)
                {
                    details.CourseDatabase.ItemsSource = courseDataSet.Tables[0].DefaultView;
                    MessageBox.Show("The data was successfully updated");

                    details.Show();
                    Close();
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void Window_load(object sender, EventArgs e)
        {

        }
        private void btnCancelStudent(object sender, RoutedEventArgs e)
        {
            details.Show();
            Close();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.GoBack();
        }
    }
      
    
}
