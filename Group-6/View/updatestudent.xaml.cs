using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using Group_6.View;


namespace Group_6.View
{
    /// <summary>
    /// Interaction logic for updateStudent.xaml
    /// </summary>
    public partial class updateStudent : Window
    {
        public updateStudent()
        {
            InitializeComponent();
        }
        StudentDatabase studentDatabase = new StudentDatabase();

        private void btnSaveStudent(object sender, RoutedEventArgs e)
        {
            if (fullname.Text.Length == 0 || id.Text.Length == 0 || Address.Text.Length == 0 || phoneNumber.Text.Length == 0 || emailId.Text.Length == 0)
            {
                Errormessage.Text = "All the fields are mandatory";
            }

            else if (!Regex.IsMatch(emailId.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                Errormessage.Text = "Enter a valid email";
            }
            else if (!Regex.IsMatch(phoneNumber.Text, @"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$"))
            {
                Errormessage.Text = "Enter a valid phone number";

            }
            else
            {
                try
                {
                    string name = fullname.Text;
                    string stid = id.Text;
                    string address = Address.Text;
                    string phone = phoneNumber.Text;
                    string email = emailId.Text;

                    string con = Properties.Settings.Default.connectionString;
                    SqlConnection connect = new SqlConnection(con);
                    connect.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE studentdb SET fullName = '" + name + "', address = '" + address + "', phoneNumber = '" + phone + "', email = '" + email + "'Where stringId = '" + stid + "'", connect);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    SqlCommand fetchStudents = new SqlCommand("SELECT * FROM studentdb", connect);
                    fetchStudents.CommandType = CommandType.Text;
                    SqlDataAdapter fetchStudentsAdapter = new SqlDataAdapter();
                    fetchStudentsAdapter.SelectCommand = fetchStudents;
                    DataSet studentsDataSet = new DataSet();
                    fetchStudentsAdapter.Fill(studentsDataSet);


                    if (studentsDataSet.Tables[0].Rows.Count > 0)
                    {
                        studentDatabase.StudentDatabaseGrid.ItemsSource = studentsDataSet.Tables[0].DefaultView;
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
        }

        private void Window_load(object sender, EventArgs e)
        {
            
        }
        private void btnCancelStudent(object sender, RoutedEventArgs e)
        {
            studentDatabase.Show();
            Close();
        }
    }
}
