namespace MyApp
{
    public class Kerdes
    {
        private string kerdesSzoveg;
        private string[] valaszok = new string[4];
        private string helyesValaszKod;
        private string kategoria;

        public Kerdes(string kerdesSzoveg, string[] valaszok, string helyesValaszKod, string kategoria)
        {
            this.kerdesSzoveg = kerdesSzoveg;
            this.valaszok = valaszok;
            this.helyesValaszKod = helyesValaszKod;
            this.kategoria = kategoria;
        }

        public string KerdesSzoveg { get => kerdesSzoveg; set => kerdesSzoveg = value; }
        public string[] Valaszok { get => valaszok; set => valaszok = value; }
        public string HelyesValaszKod { get => helyesValaszKod; set => helyesValaszKod = value; }
        public string Kategoria { get => kategoria; set => kategoria = value; }
    }
}