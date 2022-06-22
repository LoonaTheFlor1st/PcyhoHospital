using System;
using System.Collections.Generic;

namespace PcyhoHospital.Models
{
    public partial class Diagnosis
    {
        public Diagnosis()
        {
            Services = new HashSet<Service>();
            SickDiagnoses = new HashSet<SickDiagnosis>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<SickDiagnosis> SickDiagnoses { get; set; }
    }
}
