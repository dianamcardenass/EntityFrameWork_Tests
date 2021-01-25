using System;
using System.Collections.Generic;
using System.Linq;
using codeFirst = EntityFramework_CodeFirst;
using DBFirst = EntityFrameWork_DBfirst.DataAccess;
using codeFisrt2 = EntityFramework_CodeFirst.FluentAPI;
using System.Data.Entity;

namespace EntityFrameWork_DBfirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //DBFirst_test_GetCourses_SP();
            //DBFirst_test();
            //CodeFirst_test();
            //CodeFirst_FluentAPI_test();
            CodeFirst_test_Disconnected();
            Console.ReadLine();
        }

        public static void CodeFirst_FluentAPI_test()
        {
            using (var ctx = new codeFisrt2.SchoolContext())
            {

                var grade = new codeFisrt2.Grade() { GradeName = "", Section = "n" };
                ctx.Grades.Add(grade);


                var stud = new codeFisrt2.Student() { Guid=Guid.NewGuid(), StudentName = "Bill", CurrentGradeId = grade.GradeId};
                ctx.Students.Add(stud);

                ctx.SaveChanges();
            }
        }

        public static void CodeFirst_test_Disconnected()
        {
            var stud = new codeFirst.Student() { StudentID= 7, StudentName = "JUAN", GradeId = 8 };
            stud.StudentName = "CAMILO";

            using (var ctx = new codeFirst.SchoolContext())
            {
                ctx.Entry(stud).State = EntityState.Modified;

                ctx.SaveChanges();
            }
        }

        public static void CodeFirst_test()
        {
            using (var ctx = new codeFirst.SchoolContext())
            {

                var grade = new codeFirst.Grade() { GradeName = "Grade", Section = "n" };
                ctx.Grades.Add(grade);


                var stud = new codeFirst.Student() { StudentName = "Bill", GradeId = grade.GradeId };
                ctx.Students.Add(stud);

                ctx.SaveChanges();
            }
        }

        public static void DBFirst_test_GetCourses_SP()
        {
            using (var context = new DBFirst.DBFirstNetEntities())
            {
                var courses = context.GetCoursesByStudentId(Guid.Parse("07F21A73-7268-448B-8DF0-B6A73C4B300C"));

                foreach (DBFirst.GetCoursesByStudentId_Result cs in courses)
                    Console.WriteLine(cs.CourseName);
            }
        }

        public static void DBFirst_test()
        {
            using (var db = new DBFirst.DBFirstNetEntities())
            {
                DBFirst.Course course = new DBFirst.Course()
                {
                    Id = Guid.NewGuid(),
                    CourseName = "Math" + RandomString(1),
                };
                db.Set<DBFirst.Course>().Add(course);

                DBFirst.Student student = new DBFirst.Student()
                {
                    Id = Guid.NewGuid(),
                    Name = RandomString(7),
                    Address = "street 123",
                    Mobil = "123",
                    Course = new List<DBFirst.Course>() { course }
                };

                db.Set<DBFirst.Student>().Add(student);
                db.SaveChanges();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }


        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
