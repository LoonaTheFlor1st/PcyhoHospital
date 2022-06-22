using System;
using System.Collections.Generic;

namespace PcyhoHospital.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int Id { get; set; }
        public TimeSpan? VisitStart { get; set; }
        public TimeSpan? VisitEnd { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
