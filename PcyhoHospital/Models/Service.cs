using System;
using System.Collections.Generic;

namespace PcyhoHospital.Models
{
    public partial class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int DiagnosisId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Diagnosis Diagnosis { get; set; } = null!;
    }
}
