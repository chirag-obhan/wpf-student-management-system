using Group_6.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using static Group_6.StudentDatabase;

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

        public StudentDatabase()
        {
            InitializeComponent();
            FillDataGrid();
          

            //Create new students
          
        }


        private void FillDataGrid()
        {
            DataSet students = BackEnd.ReadData();

            SqlConnection myConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Project\\Group-6\\Database\\SMM.mdf");
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


        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            updateStudent update = new updateStudent();
            this.Content = update;
           
        }



        private void Student_Add_btn(object sender, RoutedEventArgs e)
        {

        }

      

        private void StudentSearch(object sender, TextChangedEventArgs e)
        {
            // StudentDatabase.Items.Clear();

            search.Clear();
            if (student_Search.Text.Equals(""))
            {
                search.AddRange(students);
            }
            else
            {
                foreach (Student searchStudent in search)
                {
                    if (searchStudent.fullName.Contains(student_Search.Text))
                    {
                        search.Add(searchStudent);
                    }
                }
            }
            StudentDatabaseGrid.ItemsSource = search.ToList();
        }

       

        
    }

    internal class gridDataContext
    {
        public gridDataContext()
        {
        }
    }
}

