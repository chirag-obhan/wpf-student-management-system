﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Group_6.View;

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

            string con = Properties.Settings.Default.connectionString;
            SqlConnection myConnection = new SqlConnection(con);
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

            updateCourse update = new updateCourse();

            try
            {
                string con = Properties.Settings.Default.connectionString;
                SqlConnection myConnection = new SqlConnection(con); 
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                if (CourseDatabase.SelectedItem == null)
                {
                    MessageBox.Show("select a row ");
                    return;
                }

                DataRowView row = (DataRowView)CourseDatabase.SelectedItem;
                updateCourse updateWindow = new updateCourse();

                updateWindow.CourseName.Text = row["courseName"].ToString();
                updateWindow.cid.Text = row["courseId"].ToString();
                updateWindow.desc.Text = row["courseDesc"].ToString();
                updateWindow.duration.Text = row["courseDur"].ToString();
                updateWindow.Coursemail.Text = row["courseEmail"].ToString();


                adapter.Update(ds);
                myConnection.Close();
                this.Content = updateWindow;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

         }

    

        private void Course_Add_btn(object sender, RoutedEventArgs e)
        {

        }

  

        private void CourseSearch(object sender, TextChangedEventArgs e)
        {
            DataSet courses = BackEnd.ReadData();

            try
            {
                string con = Properties.Settings.Default.connectionString;
                SqlConnection myConnection = new SqlConnection(con); 
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandText = "SELECT * FROM DbCourses where CourseName like '%" + course_Search.Text + "%'";
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    CourseDatabase.ItemsSource = ds.Tables[0].DefaultView;
                }

                adapter.Update(ds);
                myConnection.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            
            
        }
    }
}
