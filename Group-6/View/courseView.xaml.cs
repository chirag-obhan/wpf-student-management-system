﻿using System;
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

namespace Group_6
{
    /// <summary>
    /// Interaction logic for StudentDatabase.xaml
    /// </summary>
    /// 
    public partial class CourseDetails : Window
    {
        List<CourseView> courses = new List<CourseView>();
        List<CourseView> search = new List<CourseView>();
        string sql = "SELECT * FROM DbCourses";


        public CourseDetails()
        {
            InitializeComponent();
            FillCourses();

            //Create new students        

        }

        private void FillCourses()
        {
            DataSet courses = BackEnd.ReadCourse();

            SqlConnection myConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Project\\Group-6\\Database\\SMM.mdf");
            myConnection.Open();
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet cs = new DataSet();
            adapter.Fill(cs);

            if (cs.Tables[0].Rows.Count > 0)
            {
                CourseDatabase.ItemsSource = cs.Tables[0].DefaultView;
            }
            myConnection.Close();
        }

            private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }



        private void Course_Add_btn(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CourseSearch(object sender, TextChangedEventArgs e)
        {
            // StudentDatabase.Items.Clear();

            search.Clear();
            if (course_Search.Text.Equals(""))
            {
                search.AddRange(courses);
            }
            else
            {
                foreach (CourseView searchCourse in search)
                {
                    if (searchCourse.courseName.Contains(course_Search.Text))
                    {
                        search.Add(searchCourse);
                    }
                }
            }
            CourseDatabase.ItemsSource = search.ToList();
        }
    }
}
