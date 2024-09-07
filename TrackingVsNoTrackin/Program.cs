using EF015.QueryData.Data;
using Microsoft.EntityFrameworkCore;

namespace TrackingVsNoTrackin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var result = context.Sections.Single(x => x.Id == 1);
                Console.WriteLine(" before changing tracked object  ");
                Console.WriteLine(result.SectionName);

                result.SectionName = "bbbbbb";
                context.SaveChanges();

                Console.WriteLine(" after changing tracked object  ");
                Console.WriteLine(result.SectionName);
            }
            //using (var context = new AppDbContext())
            //{
            //    var result = context.Sections.AsNoTracking().Single(x => x.Id == 1);
            //    Console.WriteLine(" before changing tracked object  ");
            //    Console.WriteLine(result.SectionName);

            //    result.SectionName = "01A51C05";
            //    context.SaveChanges();

            //    Console.WriteLine(" after changing tracked object  ");
            //    Console.WriteLine(result.SectionName);
            //}
        }
    }
}
