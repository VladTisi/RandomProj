namespace RandomProj
{
    public class Dto
    {
        public int Id { get; set; }
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public string Functie { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime? DataInceput { get; set; }
        public DateTime? DataSfarsit { get; set; }

    }

    public class CreareCerereConcediu
    {
        public int TipConcediuId { get; set; }
        public int stareConcediuId { get; set; }

        public DateTime? Data_inceput { get; set; }

        public DateTime? Data_sfarsit { get; set; }

        public int angajatId { get; set; }

        public int InlocuitorId { get; set; }

        public string comentarii { get; set; } 


    }

    public class Concediuedt
    {
        public int Id { get; set; }
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public string Functie { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime? DataInceput { get; set; }
        public DateTime? DataSfarsit { get; set; }

        public string Inlocuitor { get; set; } 

    }

    public class AngajatFunctie
    {
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public string Functie { get; set; } = null!;
        public int IdFunctieFromFunctie { get; set; }

        public int IdFunctie { get; set; }


        public int IdFunctieFromAngajat { get; set; }

    }

    public class AngajatConcediu
    {
        public int IdAngajatFromAngajat { get; set; }

        public DateTime DataInceput { get; set; }

        public DateTime DataSfarsit { get; set; }

        public int? StareConcediuId { get; set; }
    }
    public class Member
    {
        public int Id { get; set; }
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public string Functia { get; set; } = null!;

        public string Poza { get; set; }
        public DateTime? DataAngajarii { get; set; }
    }

    public class UpdatePozaTest
    {
        public int ID { get; set; } 

        public string PozaTest { get; set; }
    }
}
