﻿namespace RandomProj
{
    public class Dto
    {
        public int Id { get; set; }
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public string Functie { get; set; } = null!;
        public DateTime? DataInceput { get; set; }
        public DateTime? DataSfarsit { get; set; }
    }
    public class Member
    {
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public string Functia { get; set; } = null!;
        public DateTime DataAngajarii { get; set; }
    }
}
