using System;
using System.Collections.Generic;

namespace PcyhoHospital.Models
{
    public partial class Cabinet
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public virtual Doctor IdNavigation { get; set; } = null!;
    }
}
