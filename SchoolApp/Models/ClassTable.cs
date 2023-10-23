using System;
using System.Collections.Generic;

namespace SchoolApp.Models
{
    public partial class ClassTable
    {
        public ClassTable()
        {
            StudentTables = new HashSet<StudentTable>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual ICollection<StudentTable> StudentTables { get; set; }
    }
}
