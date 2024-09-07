using EF_Migration.Data;
using EF_Migration.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFQueryPart1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           using(var context = new AppDBContext())
            {
                var courses = context.courses.Single(x => x.Id == 2);

                //Console.WriteLine(courses.ToQueryString());
                /* 
                 foreach(var course in courses)
                 {
                     Console.WriteLine($"Course Name : {course.CourseName}" +
                         $" ,{course.Price.ToString("C")}" +
                         $" ,{course.HoursToComplete} hrs");
                 }
                =====================================
                 Console.WriteLine($"Course Name : {courses.CourseName}" +
                      $" ,{courses.Price.ToString("C")}" +
                      $" ,{courses.HoursToComplete} hrs");
                */
            }


        }
    }
}
