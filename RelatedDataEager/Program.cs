using EF015.QueryData.Data;
using EF015.QueryData.Entities;
using Microsoft.EntityFrameworkCore;

namespace RelatedDataEager
{
    internal class Program
    {
        static void Main(string[] args)
        {
           using(var context =new AppDbContext())
            {
                var sectionid = 1;
                var sectionQuery = context.Sections
                    .Include(x=>x.Participants)//=>theninclude>>
                    .Where(x => x.Id == sectionid);

                Console.WriteLine(sectionQuery.ToQueryString());

                var section =sectionQuery.FirstOrDefault();

                Console.WriteLine($"Section: {section.SectionName}");
                Console.WriteLine("===================");
                foreach(var part in section.Participants)
                {
                 Console.WriteLine($"[{part.Id}] {part.FName} {part.LName}");
                }
            }
        }
    }
}
