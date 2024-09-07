using EF015.QueryData.Data;
using Microsoft.EntityFrameworkCore;

namespace ClientVsServerSide
{
    internal class Program
    {
        static void Main(string[] args)
        {
              //using (var context = new AppDbContext())
              //{
              //    var CoursID = 2;
              //    var result = context.Sections
              //        .Where(x => x.CourseId == CoursID)
              //        .Select(x => new
              //        {
              //            id = x.CourseId,
              //            name = x.SectionName
              //        });
              //    /*Console.WriteLine(result.ToQueryString());
              //    SELECT[s].[CourseId] AS[id], [s].[SectionName] AS[name]
              //    FROM[Sections] AS[s]
              //    WHERE[s].[CourseId] = @__CoursID_0
              //    */
              //      foreach (var res in result)
              //      {
              //          Console.WriteLine($"{res.id} {res.name}");
              //      }

              //}
        
        
            using (var context = new AppDbContext())
            {
                var CoursID = 2;
                var result = context.Sections
                    .Where(x => x.CourseId == CoursID)
                    .Select(x => new
                    {
                        id = x.CourseId,
                        name = x.SectionName.Substring(4),
                        totaldays = CalcTotalDays(x.DateRange.StartDate, x.DateRange.EndDate)
                    });
              
                foreach (var res in result)
                {
                    Console.WriteLine($"{res.id} {res.name} ({res.totaldays})");
                }
            }

        }

        private static int CalcTotalDays(DateOnly startDate, DateOnly endDate)
        {
            return endDate.DayNumber - startDate.DayNumber;
        }
    }
}
