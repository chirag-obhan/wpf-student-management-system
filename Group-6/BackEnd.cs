using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Group_6
{
    public static class BackEnd
    {
        private const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
           "Trusted_Connection=true;" +
           "Connection timeout=60";

        // connection for students
        static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // connection for students
        public static DataSet ReadData(string sqlQuery = @"select * from studentdb")
        {
            using (SqlConnection myConnection = GetConnection())
            {
                if (myConnection == null)
                {
                    Console.WriteLine("Cannot connect to the database: {0}", myConnection.State.ToString());
                    return null;
                }

                DataSet students = new DataSet();
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, myConnection);



                    myConnection.Open();
                    adapter.SelectCommand = myConnection.CreateCommand();
                    adapter.Fill(students, "StudentDatabaseGrid");
                    myConnection.Close();


                }
                catch (Exception e)
                {
                    Console.WriteLine(sqlQuery);
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (myConnection != null)
                    {
                        myConnection.Close();
                    }

                }

                return students;


            }
        }

        // connection for courses
        public static DataSet ReadCourse(string sqlQuery = @"select * from DbCourses")
        {
            using (SqlConnection myConnection = GetConnection())
            {
                if (myConnection == null)
                {
                    Console.WriteLine("Cannot connect to the database: {0}", myConnection.State.ToString());
                    return null;
                }

                DataSet courses = new DataSet();
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, myConnection);



                    myConnection.Open();
                    adapter.SelectCommand = myConnection.CreateCommand();
                    adapter.Fill(courses, "CourseDatabase");
                    myConnection.Close();


                }
                catch (Exception e)
                {
                    Console.WriteLine(sqlQuery);
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (myConnection != null)
                    {
                        myConnection.Close();
                    }

                }

                return courses;


            }
        }

       public static DataSet InsertStudent(string sqlInsert)
        {
            using (SqlConnection myConnection = GetConnection())
            {
                if (myConnection == null)
                {
                    Console.WriteLine("Cannot connect to the database: {0}", myConnection.State.ToString());
                    return null;
                }

                 DataSet students = new DataSet();
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlInsert, myConnection);

                    myConnection.Open();
                    cmd.ExecuteNonQuery();
                    myConnection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(sqlInsert);
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (myConnection != null)
                    {
                        myConnection.Close();
                    }
                }
                return students;
            }
            

        }

        public static DataSet InsertCourses(string sqlInsert)
        {
            using (SqlConnection myConnection = GetConnection())
            {
                if (myConnection == null)
                {
                    Console.WriteLine("Cannot connect to the database: {0}", myConnection.State.ToString());
                    return null;
                }

                DataSet courses = new DataSet();
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlInsert, myConnection);

                    myConnection.Open();
                    cmd.ExecuteNonQuery();
                    myConnection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(sqlInsert);
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (myConnection != null)
                    {
                        myConnection.Close();
                    }
                }
                return courses;
            }

        }

    }
        
}
