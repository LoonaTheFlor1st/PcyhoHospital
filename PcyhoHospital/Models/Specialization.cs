using System;
using System.Collections.Generic;

namespace PcyhoHospital.Models
{
    public partial class Specialization
    {
        public Specialization()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
