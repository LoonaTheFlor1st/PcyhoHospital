using System;
using System.Collections.Generic;

namespace PcyhoHospital.Models
{
    public partial class Branch
    {
        public Branch()
        {
            Doctors = new HashSet<Doctor>();
            Sicks = new HashSet<Sick>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Sick> Sicks { get; set; }
    }
}
