using System;
using System.Collections.Generic;

namespace RandomProj.Models
{
    public partial class Echipa
    {
        public Echipa()
        {
            Angajats = new HashSet<Angajat>();
        }

        public int Id { get; set; }
        public string Nume { get; set; } = null!;

        public virtual ICollection<Angajat> Angajats { get; set; }
    }
}
