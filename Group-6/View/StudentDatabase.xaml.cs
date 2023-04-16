using Group_6.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Group_6
{
    /// <summary>
    /// Interaction logic for StudentDatabase.xaml
    /// </summary>
    /// 
    public partial class StudentDatabase : Window
    {
        List<Student> students = new List<Student>();
        List<Student> search = new List<Student>();
        string sql = "SELECT * FROM studentdb";
        DataTable dt = new DataTable();
        
                
        public StudentDatabase()
        {
            InitializeComponent();
            FillDataGrid();
                    
        }
        private void FillDataGrid()
        {
            try
            {

            string con = Properties.Settings.Default.connectionString;
            SqlConnection myConnection = new SqlConnection(con);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                StudentDatabaseGrid.ItemsSource = ds.Tables[0].DefaultView;
            }
            myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string con = Properties.Settings.Default.connectionString;
                SqlConnection myConnection = new SqlConnection(con); 
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                if (StudentDatabaseGrid.SelectedItem == null)
            {
                return;
            }

                DataRowView row = (DataRowView)StudentDatabaseGrid.SelectedItem;
                updateStudent updateWindow = new updateStudent();
            {
                updateWindow.fullname.Text = row["fullName"].ToString();
                updateWindow.id.Text = row["stringId"].ToString();
                updateWindow.Address.Text = row["address"].ToString();
                updateWindow.phoneNumber.Text = row["phoneNumber"].ToString();
                updateWindow.emailId.Text = row["email"].ToString();

                    adapter.Update(ds);
                    myConnection.Close();
                    //this.Content = updateWindow;
                    updateWindow.Show();
                    Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void Student_Add_btn(object sender, RoutedEventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataSet students = BackEnd.ReadData();

            try
            {
                string con = Properties.Settings.Default.connectionString;
                SqlConnection myConnection = new SqlConnection(con); 
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandText = "SELECT * FROM studentdb where fullName like '%" + student_Search.Text + "%'";
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    StudentDatabaseGrid.ItemsSource = ds.Tables[0].DefaultView;
                }

                adapter.Update(ds);
                myConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

    }


}
