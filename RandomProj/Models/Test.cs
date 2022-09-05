using System;
using System.Collections.Generic;

namespace RandomProj.Models
{
    public partial class Test
    {
        public int Id { get; set; }
        public int? TipConcediuId { get; set; }
        public int? StareConcediuid { get; set; }
        public int? Angajatid { get; set; }
        public DateTime? DataInceput { get; set; }
        public DateTime? DataSfarsit { get; set; }
    }
}
