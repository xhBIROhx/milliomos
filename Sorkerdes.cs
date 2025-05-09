
namespace MyApp
{
    public class Sorkerdes
    {
        private string kerdesSzoveg;
        private string[] valaszok = new string[4];
        private char helyesValaszKod;
        private string kategoria;

        public Sorkerdes(string kerdesSzoveg, string[] valaszok, char helyesValaszKod, string kategoria)
        {
            this.kerdesSzoveg = kerdesSzoveg;
            this.valaszok = valaszok;
            this.helyesValaszKod = helyesValaszKod;
            this.kategoria = kategoria;
        }

        public string KerdesSzoveg { get => kerdesSzoveg; set => kerdesSzoveg = value; }
        public string[] Valaszok { get => valaszok; set => valaszok = value; }
        public char HelyesValaszKod { get => helyesValaszKod; set => helyesValaszKod = value; }
        public string Kategoria { get => kategoria; set => kategoria = value; }
    }
}