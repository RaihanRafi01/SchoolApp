using System;
using System.Collections.Generic;

namespace SchoolApp.Models
{
    public partial class StudentTable
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public int? ClassId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual ClassTable? Class { get; set; }
    }
}
