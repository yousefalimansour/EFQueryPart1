using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Migration.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string SectionName { get; set; }


        public int CourseId { get; set; }
        public Course course { get;set; }

        public int InstructorId { get; set; }
        public Instructor? instructor { get; set; }

        public int ScheduleId { get; set; }
        public Schedule schedule { get; set; }

       public  TimeSlot TimeSlot { get; set; }

        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
        public ICollection<Particpant> Particpants { get; set; } = new List<Particpant>();


    }
    public class TimeSlot
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public override string ToString()
        {
            return $"{StartTime.ToString("hh\\mm")} - {EndTime.ToString("hh\\mm")}";
        }
    }
   
}
