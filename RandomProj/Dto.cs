namespace RandomProj
{
    public class Dto
    {
        public int Id { get; set; }
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public DateTime? DataInceput { get; set; }
        public DateTime? DataSfarsit { get; set; }
    }
}
