using System;
using System.Collections.Generic;

namespace PcyhoHospital.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Sicks = new HashSet<Sick>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int SpecializationId { get; set; }
        public int Schedule { get; set; }
        public int Branch { get; set; }
        public int? FunctionId { get; set; }

        public virtual Branch BranchNavigation { get; set; } = null!;
        public virtual Function? Function { get; set; }
        public virtual Schedule ScheduleNavigation { get; set; } = null!;
        public virtual Specialization Specialization { get; set; } = null!;
        public virtual Cabinet Cabinet { get; set; } = null!;
        public virtual ICollection<Sick> Sicks { get; set; }
    }
}
