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
using System.Windows.Shapes;
using System.CodeDom;

namespace Group_6.View
{
    /// <summary>
    /// Interaction logic for addCourse.xaml
    /// </summary>
    public partial class addCourse : Window
    {
        public addCourse()
        {
            InitializeComponent();
        }
        CourseDetails details = new CourseDetails();
        private void btnSaveAddCourse(object sender, RoutedEventArgs e)
        {
            DataSet courses = BackEnd.ReadCourse();

            try
            {
                string name = AddCourseName.Text;
                string id = AddCid.Text;
                string desc = AddCDesc.Text;
                string duration = AddCDuration.Text;
                string email = AddCoursemail.Text;

              
                string con = Properties.Settings.Default.connectionString;
                SqlConnection connect = new SqlConnection(con);
                connect.Open();
               
                SqlCommand cmd = new SqlCommand("INSERT INTO [DbCourses](courseId,courseName,courseDesc,courseDur,courseEmail)VALUES (@cid,@cn,@cd,@cdur,@ce)", connect);
                cmd.Parameters.AddWithValue("@cid", AddCid.Text);
                cmd.Parameters.AddWithValue("@cn", AddCourseName.Text);
                cmd.Parameters.AddWithValue("@cd", AddCDesc.Text);
                cmd.Parameters.AddWithValue("@cdur", AddCDuration.Text);
                cmd.Parameters.AddWithValue("@ce", AddCoursemail.Text);
                cmd.Connection = connect;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);


                SqlCommand fetchCourse = new SqlCommand("SELECT * FROM DbCourses", connect);
                fetchCourse.CommandType = CommandType.Text;
                SqlDataAdapter fetchCourseAdapter = new SqlDataAdapter();
                fetchCourseAdapter.SelectCommand = fetchCourse;
                DataSet CourseDataSet = new DataSet();
                fetchCourseAdapter.Fill(CourseDataSet);
                if (CourseDataSet.Tables[0].Rows.Count > 0)
                {  
                    details.CourseDatabase.ItemsSource = CourseDataSet.Tables[0].DefaultView;
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

        private void btnCancelAddCourse(object sender, RoutedEventArgs e)
        {
            details.Show();
            Close();

        }
    }
}
