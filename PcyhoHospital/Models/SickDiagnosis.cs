using System;
using System.Collections.Generic;

namespace PcyhoHospital.Models
{
    public partial class SickDiagnosis
    {
        public int Id { get; set; }
        public int DiagnosisId { get; set; }
        public int Quantity { get; set; }
        public int SickId { get; set; }

        public virtual Diagnosis Diagnosis { get; set; } = null!;
        public virtual Sick DiagnosisNavigation { get; set; } = null!;
    }
}
