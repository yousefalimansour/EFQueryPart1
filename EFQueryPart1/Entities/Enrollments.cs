﻿namespace EF_Migration.Entities
{
    public class Enrollment
    {
      
        public int SectionId { get; set; }
        public int StudentId { get; set; }
        public Section Section { get; set; }
        public Particpant Student { get; set; }
       
    }
}
