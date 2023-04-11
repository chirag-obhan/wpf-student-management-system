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

        public StudentDatabase()
        {
            InitializeComponent();

            //Create new students

            Student bobSmith = new Student();
            bobSmith.studentId = 101;
            bobSmith.fullName = "Bob Smith";
            bobSmith.address = "101 Waterloo Ave.";
            bobSmith.phoneNumber = "123-123-1234";
            bobSmith.email = "bobsmith@gmail.com";
            StudentDatabase.Items.Add(bobSmith);



            Student taylorSwift = new Student();
            taylorSwift.studentId = 102;
            taylorSwift.fullName = "Taylor Swift";
            taylorSwift.address = "324 Erb Street";
            taylorSwift.phoneNumber = "123-421-1234";
            taylorSwift.email = "Swift@gmail.com";
            StudentDatabase.Items.Add(taylorSwift);


            Student michealEarth = new Student();
            michealEarth.studentId = 102;
            michealEarth.fullName = "Micheal Earth ";
            michealEarth.address = "123 University Ave.";
            michealEarth.phoneNumber = "123-123-4321";
            michealEarth.email = "Mearth@gmail.com";
            StudentDatabase.Items.Add(michealEarth);


            Student janeDoe = new Student();
            janeDoe.studentId = 104;
            janeDoe.fullName = "Jane Doe";
            janeDoe.address = "350 Waterloo Ave.";
            janeDoe.phoneNumber = "321-167-1234";
            janeDoe.email = "janeDoe@gmail.com";
            StudentDatabase.Items.Add(janeDoe);
        }

        public class Student
        {
            public int studentId { get; set; }
            public string fullName { get; set; }
            public string address { get; set; }
            public string phoneNumber { get; set; }
            public string email { get; set; }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }



        private void Student_Add_btn(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
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
            StudentDatabase.ItemsSource = search.ToList();
        }
    }
}

