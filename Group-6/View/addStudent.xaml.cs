using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;

namespace Group_6.View
{
    /// <summary>
    /// Interaction logic for addStudent.xaml
    /// </summary>
    public partial class addStudent : Window
    {
        public addStudent()
        {
            InitializeComponent();
        }

        StudentDatabase studentDatabase = new StudentDatabase();

        private void btnSaveAddStudent(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = AddSFullName.Text;
                string id = AddSId.Text;
                string desc = AddSAddress.Text;
                string duration = AddSPhoneNumber.Text;
                string email = AddSEmailId.Text;
                string con = Properties.Settings.Default.connectionString;
                SqlConnection connect = new SqlConnection(con);
                connect.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO [studentdb](stringId,fullName,address,phoneNumber,email)VALUES (@sid,@fn,@sadd,@sphone,@semail)", connect);
                cmd.Parameters.AddWithValue("@sid", AddSId.Text);
                cmd.Parameters.AddWithValue("@fn", AddSFullName.Text);
                cmd.Parameters.AddWithValue("@sadd", AddSAddress.Text);
                cmd.Parameters.AddWithValue("@sphone", AddSPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@semail", AddSEmailId.Text);
                cmd.Connection = connect;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);


                SqlCommand fetchStudent = new SqlCommand("SELECT * FROM studentdb", connect);
                fetchStudent.CommandType = CommandType.Text;
                SqlDataAdapter fetchStudentAdapter = new SqlDataAdapter();
                fetchStudentAdapter.SelectCommand = fetchStudent;
                DataSet StudentDataSet = new DataSet();
                fetchStudentAdapter.Fill(StudentDataSet);
                if (StudentDataSet.Tables[0].Rows.Count > 0)
                {
                    studentDatabase.StudentDatabaseGrid.ItemsSource = StudentDataSet.Tables[0].DefaultView;
                    MessageBox.Show("The data was successfully updated");

                    studentDatabase.Show();
                    Close();
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancelAddStudent(object sender, RoutedEventArgs e)
        {
            studentDatabase.Show();
            Close();

        }
    }
}
