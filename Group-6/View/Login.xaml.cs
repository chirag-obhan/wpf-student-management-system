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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Group_6.View;

namespace Group_6
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        Welcome welcome = new Welcome();
        private void loginClicked(object sender, RoutedEventArgs e)
        {
            if (email.Text.Length == 0 || password.Password.Length == 0)
            {
                errormessage.Text = "Both fields are mandatory";
                email.Focus();
            }
            else if (!Regex.IsMatch(email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                email.Select(0, email.Text.Length);
                email.Focus();
            }
            else
            {
                string emailValue = email.Text;
                string passwordValue = password.Password;
                string con = Properties.Settings.Default.connectionString;
                SqlConnection connect = new SqlConnection(con);
                connect.Open();
                SqlCommand cmd = new SqlCommand("Select * from Admin where Email='" + emailValue + "'  and password='" + passwordValue + "'", connect);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    string name = dataSet.Tables[0].Rows[0]["name"].ToString(); 
                    string email = dataSet.Tables[0].Rows[0]["email"].ToString();
                    welcome.name.Text = name;
                    welcome.loggedInAs.Text = email;
                    welcome.Show();
                    Close();
                }
                else
                {
                    errormessage.Text = "Your email and password does not match our records.";
                }
                connect.Close();
            }
        }
    }
}
