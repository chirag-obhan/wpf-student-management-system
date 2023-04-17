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
    /// Interaction logic for updateCourse.xaml
    /// </summary>
    public partial class updateCourse : Window
    {
        public updateCourse()
        {
            InitializeComponent();
        }
        CourseDetails courseDetails = new CourseDetails();

        private void btnSaveCourseEdit(object sender, RoutedEventArgs e)
        {
            try
            {
                string editCourseName = editCName.Text;
                string editCourseId = editCId.Text;
                string editCourseDescription = editCDesc.Text;
                string editCourseDuration = editCDuration.Text;
                string editCourseEmail = editCoursEmail.Text;

                string con = Properties.Settings.Default.connectionString;
                SqlConnection connect = new SqlConnection(con);
                connect.Open();
                SqlCommand cmd = new SqlCommand("UPDATE DbCourses SET courseName = '" + editCourseName + "', courseDesc = '" + editCourseDescription + "', courseDur = '" + editCourseDuration + "', courseEmail = '" + editCourseEmail + "'Where courseId = '" + editCourseId + "'", connect);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                SqlCommand fetchCourses = new SqlCommand("SELECT * FROM DbCourses", connect);
                fetchCourses.CommandType = CommandType.Text;
                SqlDataAdapter fetchStudentsAdapter = new SqlDataAdapter();
                fetchStudentsAdapter.SelectCommand = fetchCourses;
                DataSet courseDataSet = new DataSet();
                fetchStudentsAdapter.Fill(courseDataSet);

                if (courseDataSet.Tables[0].Rows.Count > 0)
                {
                    courseDetails.CourseDatabase.ItemsSource = courseDataSet.Tables[0].DefaultView;
                    MessageBox.Show("The data was successfully updated");

                    courseDetails.Show();
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
        private void btnCancelCourseEdit(object sender, RoutedEventArgs e)
        {
            courseDetails.Show();
            Close();
        }
    }
}
