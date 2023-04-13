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

        public CourseDetails()
        {
            InitializeComponent();

            //Create new students

            CourseView Maths = new CourseView();
            Maths.courseId = 101;
            Maths.courseName = "Bob Smith";
            Maths.courseDescription = "101 Waterloo Ave.";
            Maths.courseDuration = "123-123-1234";
            Maths.courseEmail = "bobsmith@gmail.com";
            CourseDatabase.Items.Add(Maths);



            CourseView Microprocessor = new CourseView();
            Microprocessor.courseId = 102;
            Microprocessor.courseName = "Taylor Swift";
            Microprocessor.courseDescription = "324 Erb Street";
            Microprocessor.courseDuration = "123-421-1234";
            Microprocessor.courseEmail = "Swift@gmail.com";
            CourseDatabase.Items.Add(Microprocessor);


            CourseView OperatingSys = new CourseView();
            OperatingSys.courseId = 101;
            OperatingSys.courseName = "Bob Smith";
            OperatingSys.courseDescription = "101 Waterloo Ave.";
            OperatingSys.courseDuration = "123-123-1234";
            OperatingSys.courseEmail = "bobsmith@gmail.com";
            CourseDatabase.Items.Add(OperatingSys);



        }

        public class CourseView
        {
            public int courseId { get; set; }
            public string courseName { get; set; }
            public string courseDescription { get; set; }
            public string courseDuration { get; set; }
            public string courseEmail { get; set; }
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
