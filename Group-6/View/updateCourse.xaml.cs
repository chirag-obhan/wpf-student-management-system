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
using System.Text.RegularExpressions;

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
        
       
        CourseDetails details = new CourseDetails();
        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            /*string name = txtName.Text;
            string id = sid.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;*/
            

        private void Window_load(object sender, EventArgs e)
        {

            NavigationService.GoBack();
        }
        private void Button_Cancel_Click (object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
      
    
}
