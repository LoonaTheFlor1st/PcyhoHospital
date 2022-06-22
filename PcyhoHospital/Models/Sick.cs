using System;
using System.Collections.Generic;

namespace PcyhoHospital.Models
{
    public partial class Sick
    {
        public Sick()
        {
            SickDiagnoses = new HashSet<SickDiagnosis>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PersonalInformation { get; set; } = null!;
        public int DoctorId { get; set; }
        public int Branch { get; set; }

        public virtual Branch BranchNavigation { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual ICollection<SickDiagnosis> SickDiagnoses { get; set; }
    }
}
