﻿using System;
using System.Collections.Generic;
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

        private void btnSaveAddStudent(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancelAddStudent(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
