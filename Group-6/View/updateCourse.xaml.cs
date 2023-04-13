using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Group_6.View
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class updateCourse : Page
    {
        public updateCourse()
        {
            InitializeComponent();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            /*string name = txtName.Text;
            string id = sid.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;*/
            

            //save info in database

            NavigationService.GoBack();
        }
        private void Button_Cancel_Click (object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
